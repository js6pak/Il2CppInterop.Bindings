using System.Runtime.InteropServices;
using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static class ImportsGenerator
{
    private static CSharpMethod MakeMethodFor(Il2CppVersion.Function function, UnityVersion startVersion, bool duplicate = false)
    {
        var method = new CSharpMethod(function.ReturnType, function.Name)
        {
            IsStatic = true,
            IsExtern = true,
            Attributes =
            {
                new CSharpAttribute("ApplicableToUnityVersionsSince") { new CSharpAttribute.Parameter($"\"{startVersion.ToFriendlyString()}\"") },
                new CSharpAttribute("DllImport") { new CSharpAttribute.Parameter("\"GameAssembly\"") },
            },
            Parameters = function.Parameters.Select(parameter =>
            {
                var name = parameter.Name;
                if (name == string.Empty && parameter.Type == "Il2CppException*") name = "ex";

                var type = parameter.Type;

                var csharpParameter = new CSharpParameter(type, name);

                UnmanagedType? stringType = null;
                if (type.StartsWith("byte*")) stringType = UnmanagedType.LPUTF8Str;
                if (type.StartsWith("char*")) stringType = UnmanagedType.LPWStr;
                if (!function.Name.StartsWith("il2cpp_format_") && stringType != null)
                {
                    var isArray = type.EndsWith("[]");
                    csharpParameter.Type = isArray ? "string[]" : "string";

                    var attribute = new CSharpAttribute("MarshalAs");

                    if (isArray)
                    {
                        attribute.Add(new CSharpAttribute.Parameter("UnmanagedType.LPArray"));
                        attribute.Add(new CSharpAttribute.Property("ArraySubType", "UnmanagedType." + stringType));
                    }
                    else
                    {
                        attribute.Add(new CSharpAttribute.Parameter("UnmanagedType." + stringType));
                    }

                    csharpParameter.Attributes.Add(attribute);
                }

                return csharpParameter;
            }).ToList(),
        };

        if (duplicate)
        {
            method.Name += "_" + startVersion.ToSanitizedString();
        }

        return method;
    }

    public static void Generate(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        var ignored = new[] { "unity_liveness", "profiler", "set_find_plugin_callback", "capture_memory_snapshot", "free_captured_memory_snapshot", "delegate", "thread_get_name", "stats", "debug", "register_debugger_agent_transport" };

        var @class = new CSharpClass(Visibility.Internal, "Il2CppImports")
        {
            IsStatic = true,
            IsUnsafe = true,
        };

        var methods = new Dictionary<string, (UnityVersion UnityVersion, Il2CppVersion.Function Function, CSharpMethod Method)>();

        foreach (var (unityVersion, version) in versions)
        {
            var currentFunctions = new List<string>();

            foreach (var function in version.Functions)
            {
                if (ignored.Any(c => function.Name.StartsWith("il2cpp_" + c)))
                {
                    continue;
                }

                currentFunctions.Add(function.Name);

                if (!methods.TryGetValue(function.Name, out var existingFunction))
                {
                    var method = MakeMethodFor(function, unityVersion);
                    @class.Members.Add(method);
                    methods.Add(function.Name, (unityVersion, function, method));
                }
                else if (function != existingFunction.Function)
                {
                    existingFunction.Method.Name = existingFunction.Function.Name + "_" + existingFunction.UnityVersion.ToSanitizedString();
                    var method = MakeMethodFor(function, unityVersion, true);
                    @class.Members.Insert(@class.Members.IndexOf(existingFunction.Method) + 1, method);
                    methods[function.Name] = (unityVersion, function, method);
                }
            }

            foreach (var function in methods.ToList())
            {
                if (!currentFunctions.Contains(function.Key))
                {
                    throw new NotSupportedException("Removed methods not supported for now - " + function.Key);
                }
            }
        }

        var file = new CSharpFile("Il2CppInterop.Bindings")
        {
            Usings = { "System.Runtime.InteropServices", "Il2CppInterop.Bindings.Structs" },
            Members = { @class },
        };

        file.WriteTo(Path.Combine(outputPath, "Il2CppImports.generated.cs"));

        Console.WriteLine($"Generated {methods.Count} import methods");
    }
}
