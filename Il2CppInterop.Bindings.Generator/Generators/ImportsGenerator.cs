using System.Runtime.InteropServices;
using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static class ImportsGenerator
{
    private static CSharpMethod MakeMethodFor(Il2CppVersion.Function function, UnityVersion startVersion, bool duplicate = false)
    {
        var dllImportAttribute = new CSharpAttribute("LibraryImportAttribute") { new CSharpAttribute.Parameter("\"GameAssembly\"") };

        if (duplicate)
        {
            dllImportAttribute.Add(new CSharpAttribute.Property("EntryPoint", $"\"{function.Name}\""));
        }

        var method = new CSharpMethod(function.ReturnType, function.Name)
        {
            IsStatic = true,
            IsPartial = true,
            Attributes =
            {
                new CSharpAttribute("ApplicableToUnityVersionsSince") { new CSharpAttribute.Parameter($"\"{startVersion.ToFriendlyString()}\"") },
                dllImportAttribute,
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
                    csharpParameter.Type = isArray ? "string?[]" : "string?";

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

                if (type == "bool")
                {
                    csharpParameter.Attributes.Add(new CSharpAttribute("MarshalAs")
                    {
                        new CSharpAttribute.Parameter("UnmanagedType.U1"),
                    });
                }

                return csharpParameter;
            }).ToList(),
        };

        if (function.ReturnType == "bool")
        {
            method.Attributes.Add(new CSharpAttribute("return: MarshalAs")
            {
                new CSharpAttribute.Parameter("UnmanagedType.U1"),
            });
        }

        if (duplicate)
        {
            method.Name += "_" + startVersion.ToSanitizedString();
        }

        return method;
    }

    public static void Generate(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        var ignored = new[] { "unity_liveness", "profiler", "set_find_plugin_callback", "capture_memory_snapshot", "free_captured_memory_snapshot", "delegate", "thread_get_name", "stats", "debug", "register_debugger_agent_transport", "unity_set_android_network_up_state_func" };

        var @class = new CSharpClass(Visibility.Internal, "Il2CppImports")
        {
            IsStatic = true,
            IsUnsafe = true,
            IsPartial = true,
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
                    var indexOf = @class.Members.IndexOf(existingFunction.Method);
                    @class.Members[indexOf] = existingFunction.Method = MakeMethodFor(existingFunction.Function, existingFunction.UnityVersion, true);
                    var method = MakeMethodFor(function, unityVersion, true);
                    @class.Members.Insert(indexOf + 1, method);
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
