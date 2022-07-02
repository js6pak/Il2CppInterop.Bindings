using System.Runtime.InteropServices;
using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static class ImportsGenerator
{
    private static CSharpMethod MakeMethodFor(Il2CppVersion.Function function, UnityVersion startVersion)
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
            Parameters = function.Parameters.Select(static parameter =>
            {
                var name = parameter.Name;
                if (name == string.Empty && parameter.Type == "Il2CppException*") name = "ex";

                var type = parameter.Type;

                var csharpParameter = new CSharpParameter(type, name);

                UnmanagedType? stringType = null;
                if (type.StartsWith("byte*")) stringType = UnmanagedType.LPUTF8Str;
                if (type.StartsWith("char*")) stringType = UnmanagedType.LPWStr;
                if (stringType != null)
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

        return method;
    }

    public static void Generate(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        var ignored = new[] { "init", "unity_liveness", "profiler", "set_find_plugin_callback", "capture_memory_snapshot", "free_captured_memory_snapshot", "delegate", "thread_get_name", "stats", "debug", "register_debugger_agent_transport" };

        var methods = new Dictionary<string, CSharpMethod>();

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

                if (!methods.ContainsKey(function.Name))
                {
                    methods.Add(function.Name, MakeMethodFor(function, unityVersion));
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
            Members =
            {
                new CSharpClass("IL2CPP")
                {
                    IsStatic = true,
                    IsUnsafe = true,
                    Members = new List<CSharpType.IMember>(methods.Values),
                },
            },
        };

        file.WriteTo(Path.Combine(outputPath, "IL2CPP.generated.cs"));

        Console.WriteLine($"Generated {methods.Count} import methods");
    }
}
