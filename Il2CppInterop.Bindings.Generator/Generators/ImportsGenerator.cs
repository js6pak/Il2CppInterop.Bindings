using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static partial class ImportsGenerator
{
    public static void Generate(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        var importMethods = new Dictionary<string, ImportMethod>();

        foreach (var (unityVersion, version) in versions)
        {
            var currentFunctions = new HashSet<string>();

            foreach (var function in version.Functions)
            {
                // TODO these functions use a lot of structs that don't change often, figure out a way to auto generate those
                if (
                    function.Name.StartsWith("il2cpp_delegate") ||
                    function.Name.EndsWith("memory_snapshot") ||
                    function.Name is "il2cpp_register_debugger_agent_transport" or "il2cpp_debug_get_method_info"
                ) continue;

                currentFunctions.Add(function.Name);

                if (!importMethods.TryGetValue(function.Name, out var importMethod))
                {
                    importMethod = new ImportMethod();
                    importMethods.Add(function.Name, importMethod);
                }

                importMethod.Add(unityVersion, function);
            }

            foreach (var (name, importMethod) in importMethods)
            {
                if (!currentFunctions.Contains(name))
                {
                    importMethod.Finish(unityVersion);
                }
            }
        }

        var @class = new CSharpClass(Visibility.Internal, "Il2CppImports")
        {
            IsStatic = true,
            IsUnsafe = true,
            IsPartial = true,
        };

        foreach (var importMethod in importMethods.Values)
        {
            @class.Members.AddRange(importMethod.ToCSharpMethods());
        }

        var file = new CSharpFile("Il2CppInterop.Bindings")
        {
            Usings = { "System.Runtime.InteropServices", "Il2CppInterop.Bindings.Structs" },
            Members = { @class },
        };

        file.WriteTo(Path.Combine(outputPath, "Il2CppImports.generated.cs"));

        Console.WriteLine($"Generated {importMethods.Count} import methods");
    }
}
