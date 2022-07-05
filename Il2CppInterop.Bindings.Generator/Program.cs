using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AssetRipper.VersionUtilities;
using ClangSharp;
using ClangSharp.Interop;
using ClangSharp.Pathogen;
using Il2CppInterop.Bindings.Generator;
using Il2CppInterop.Bindings.Generator.Generators;

if (args.Length != 1)
{
    Console.Error.WriteLine("./Il2CppInterop.Bindings.Generator <output path>");
    return -1;
}

var outputPath = args[0];

if (!Directory.Exists(outputPath))
{
    Console.Error.WriteLine($"{outputPath} doesn't exist!");
    return -1;
}

var sourcesPath = await SourceManager.EnsureExists();

IDictionary<UnityVersion, Il2CppVersion> versions = new ConcurrentDictionary<UnityVersion, Il2CppVersion>();

var metadataVersionRegex = new Regex(@"\(s_GlobalMetadataHeader->version == (?<version>\d+)\);", RegexOptions.Compiled);

var stopwatch = Stopwatch.StartNew();

await Parallel.ForEachAsync(Directory.GetDirectories(sourcesPath), new ParallelOptions { MaxDegreeOfParallelism = Math.Min(Environment.ProcessorCount, 4) }, async (sourcePath, token) =>
{
    var unityVersion = UnityVersion.Parse(Path.GetFileName(sourcePath));

    // Versions before 5.2.1 didn't have source files which we need for extracting metadata version
    if (unityVersion <= new UnityVersion(5, 2, 1, UnityVersionType.Final))
    {
        return;
    }

    Console.WriteLine("Parsing " + unityVersion.ToFriendlyString());

    var path = Path.Combine(sourcePath, "vm", unityVersion >= new UnityVersion(2020, 2, 0, UnityVersionType.Final) ? "GlobalMetadata.cpp" : "MetadataCache.cpp");
    var match = metadataVersionRegex.Match(await File.ReadAllTextAsync(path, token));
    var metadataVersion = int.Parse(match.Groups["version"].Value);

    var functions = new List<Il2CppVersion.Function>();
    var structs = new List<Il2CppVersion.Struct>();

    using (var cppParser = new CppParser(sourcePath, new[]
           {
               "il2cpp-api.h",
               unityVersion >= new UnityVersion(2020, 2, 0, UnityVersionType.Final) ? Path.Join("vm", "GlobalMetadataFileInternals.h") : "il2cpp-metadata.h",
               unityVersion >= new UnityVersion(2017, 3, 0, UnityVersionType.Final) ? "il2cpp-class-internals.h" : "class-internals.h",
               unityVersion >= new UnityVersion(2017, 3, 0, UnityVersionType.Final) ? "il2cpp-object-internals.h" : "object-internals.h",
           })
           {
               CommandLineArguments =
               {
                   "--language=c++",
               },
           })
    {
        var translationUnit = cppParser.Parse();

        var hasErrors = false;

        foreach (var diagnostic in translationUnit.Handle.DiagnosticSet)
        {
            if (diagnostic.Severity >= CXDiagnosticSeverity.CXDiagnostic_Error) hasErrors = true;

            Console.ForegroundColor = diagnostic.Severity switch
            {
                CXDiagnosticSeverity.CXDiagnostic_Ignored => ConsoleColor.Gray,
                CXDiagnosticSeverity.CXDiagnostic_Note => ConsoleColor.White,
                CXDiagnosticSeverity.CXDiagnostic_Warning => ConsoleColor.Yellow,
                CXDiagnosticSeverity.CXDiagnostic_Error => ConsoleColor.Red,
                CXDiagnosticSeverity.CXDiagnostic_Fatal => ConsoleColor.Red,
                _ => throw new ArgumentOutOfRangeException(),
            };
            Console.WriteLine($"{diagnostic.Location.ToString()}: {diagnostic.Severity}: {diagnostic.ToString()}");
            Console.ResetColor();
        }

        if (hasErrors)
        {
            throw new Exception("Failed to parse " + unityVersion.ToFriendlyString());
        }

        void ProcessCursor(Cursor cursor)
        {
            if (cursor is NamespaceDecl or Decl { Kind: CX_DeclKind.CX_DeclKind_LinkageSpec })
            {
                foreach (var childCursor in cursor.CursorChildren)
                {
                    ProcessCursor(childCursor);
                }
            }

            if (cursor.Extent.Start.IsInSystemHeader || cursor.Extent.End.IsInSystemHeader)
                return;

            if (cursor is FunctionDecl function)
            {
                var inheritableAttr = function.Attrs.OfType<InheritableAttr>().SingleOrDefault();
                if (inheritableAttr == null || inheritableAttr.Kind != CX_AttrKind.CX_AttrKind_Visibility)
                {
                    return;
                }

                // Versions before 5.3.6 used uint16_t instead Il2CppChar (char16_t) which messes with string marshalling
                var fixIl2CppChar = unityVersion < new UnityVersion(5, 3, 6, UnityVersionType.Final);

                var parameters = new List<Il2CppVersion.Function.Parameter>();
                foreach (var parameter in function.Parameters)
                {
                    var parameterType = parameter.Type.ToCSharpString();
                    if (fixIl2CppChar && function.Name == "il2cpp_string_new_utf16" && parameter.Name == "text") parameterType = "char*";
                    parameters.Add(new Il2CppVersion.Function.Parameter(parameter.Name.Intern(), parameterType.Intern()));
                }

                var returnType = function.ReturnType.ToCSharpString().Intern();
                if (fixIl2CppChar && function.Name == "il2cpp_string_chars") returnType = "char*";

                functions.Add(new Il2CppVersion.Function(function.Name.Intern(), returnType, parameters));
            }
            else if (cursor is RecordDecl record)
            {
                var name = StructsGenerator.RenameStruct(record.TypeForDecl.AsString);
                var fields = new List<Il2CppVersion.Struct.Field>();

                unsafe
                {
                    var layout = PathogenExtensions.pathogen_GetRecordLayout(record.Handle);

                    if (layout != null)
                    {
                        try
                        {
                            for (var field = layout->FirstField; field != null; field = field->NextField)
                            {
                                if (field->Kind == PathogenRecordFieldKind.Normal)
                                {
                                    var type = translationUnit.FindType(field->Type);

                                    var fieldName = field->Name.ToString().Intern();
                                    var fieldTypeName = type.ToCSharpString().Intern();

                                    fields.Add(
                                        field->IsBitField != 0
                                            ? new Il2CppVersion.Struct.BitField(fieldName, fieldTypeName, field->BitFieldStart, field->BitFieldWidth)
                                            : new Il2CppVersion.Struct.Field(fieldName, fieldTypeName)
                                    );
                                }
                            }
                        }
                        finally
                        {
                            PathogenExtensions.pathogen_DeleteRecordLayout(layout);
                        }
                    }
                }

                structs.Add(new Il2CppVersion.Struct(name.Intern(), fields));
            }
        }

        foreach (var cursor in translationUnit.TranslationUnitDecl.CursorChildren)
        {
            ProcessCursor(cursor);
        }

        translationUnit.CleanCursors();
    }


    Console.WriteLine($"Parsed {unityVersion.ToFriendlyString()} - V{metadataVersion}, {functions.Count} functions, {structs.Count} structs");

    if (!versions.TryAdd(unityVersion, new Il2CppVersion(metadataVersion, functions, structs)))
    {
        throw new InvalidOperationException($"Unity version '{unityVersion}' was processed more than once!");
    }
});

Console.WriteLine("Parsed in " + stopwatch.Elapsed);

versions = new SortedDictionary<UnityVersion, Il2CppVersion>(versions);

foreach (var file in Directory.GetFiles(outputPath, "*.generated.cs", SearchOption.AllDirectories))
{
    File.Delete(file);
}

await ApiHistoryGenerator.GenerateAsync(versions, outputPath);
ImportsGenerator.Generate(versions, outputPath);
StructsGenerator.Generate(versions, outputPath);

return 0;
