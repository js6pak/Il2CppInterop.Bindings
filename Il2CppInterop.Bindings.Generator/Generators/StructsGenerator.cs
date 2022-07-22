using AssetRipper.VersionUtilities;
using CSharpPoet;
using Il2CppInterop.Bindings.Generator.Generators.Struct;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static class StructsGenerator
{
    public static string RenameStruct(string name)
    {
        if (name == "TypeInfo") return "Il2CppClass";
        if (name is "EventInfo" or "MethodInfo" or "FieldInfo" or "PropertyInfo" or "ParameterInfo") return "Il2Cpp" + name[..^4];
        return name;
    }

    public static StructGenerator[] Generators { get; } =
    {
        new Il2CppClassGenerator(),
        new Il2CppMethodGenerator(),
        new Il2CppExceptionGenerator(),
    };

    public static StructGenerator GetGeneratorByName(string className)
    {
        return Generators.Single(x => x.StructName == className);
    }

    public static void Generate(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        foreach (var structGenerator in Generators)
        {
            Il2CppVersion.Struct? last = null;

            foreach (var (unityVersion, version) in versions)
            {
                var current = version.Structs.Single(x => x.Name == structGenerator.StructName);

                if (last == null || last != current)
                {
                    last = current;
                    structGenerator.Versions.Add(unityVersion, current);
                }
            }
        }

        foreach (var structGenerator in Generators)
        {
            structGenerator.Generate(outputPath);
        }

        GenerateInitializeNativeStructHandlers().WriteTo(Path.Join(outputPath, "UnityVersionHandler.generated.cs"));

        Console.WriteLine($"Generated {Generators.Length} struct types, {Generators.SelectMany(x => x.Versions).Count()} structs");
    }

    private static CSharpFile GenerateInitializeNativeStructHandlers()
    {
        var members = new List<CSharpType.IMember>();

        foreach (var structGenerator in Generators)
        {
            // public static INativeIl2CppClassStructHandler Il2CppClass { get; private set; }
            members.Add(new CSharpProperty(structGenerator.HandlerInterfaceName, structGenerator.StructName)
            {
                IsStatic = true,
                Getter = new CSharpProperty.Accessor(),
                Setter = new CSharpProperty.Accessor(Visibility.Private),
            });
        }

        members.Add(new CSharpMethod(Visibility.Private, "void", "InitializeNativeStructHandlers")
        {
            IsStatic = true,
            Parameters =
            {
                new CSharpParameter("UnityVersion", "unityVersion"),
            },
            Body = writer =>
            {
                var first = true;
                foreach (var structGenerator in Generators)
                {
                    if (first) first = false;
                    else writer.WriteLine();

                    var firstVersion = true;
                    foreach (var unityVersion in structGenerator.Versions.Keys.Reverse())
                    {
                        if (firstVersion) firstVersion = false;
                        else writer.Write("else ");

                        writer.WriteLine($"if (unityVersion >= new UnityVersion({unityVersion.ToConstructorParameters()})) {structGenerator.StructName} = new {structGenerator.HandlerName}_{unityVersion.ToSanitizedString()}();");
                    }
                }
            },
        });

        var file = new CSharpFile("Il2CppInterop.Bindings")
        {
            Usings =
            {
                "AssetRipper.VersionUtilities",
            },
            Members =
            {
                new CSharpClass("UnityVersionHandler")
                {
                    IsPartial = true,
                    Members = members,
                    IsStatic = true,
                },
            },
        };

        foreach (var structGenerator in Generators)
        {
            file.Usings.Add(structGenerator.Namespace.Name);
        }

        return file;
    }
}
