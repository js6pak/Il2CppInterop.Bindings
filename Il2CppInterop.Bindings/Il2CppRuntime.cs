using AssetRipper.VersionUtilities;
using Il2CppInterop.Bindings.Structs;

namespace Il2CppInterop.Bindings;

public static unsafe class Il2CppRuntime
{
    public static int Init(string domainName)
    {
        if (UnityVersionHandler.Version >= new UnityVersion(2019, 1, 0, UnityVersionType.Final))
        {
            return Il2CppImports.il2cpp_init_2019_1_0(domainName);
        }

        Il2CppImports.il2cpp_init_5_2_2(domainName);
        return 0;
    }

    public static void Shutdown() => Il2CppImports.il2cpp_shutdown();

    public static void SetConfigDir(string configPath) => Il2CppImports.il2cpp_set_config_dir(configPath);

    public static void SetDataDir(string dataPath) => Il2CppImports.il2cpp_set_data_dir(dataPath);

    public static void SetCommandlineArguments(string[] arguments)
    {
        if (UnityVersionHandler.Version >= new UnityVersion(5, 5, 0, UnityVersionType.Final))
        {
            Il2CppImports.il2cpp_set_commandline_arguments_utf16(arguments.Length, arguments, null);
        }
        else
        {
            Il2CppImports.il2cpp_set_commandline_arguments(arguments.Length, arguments, null);
        }
    }

    public static void AddInternalCall(string name, void* method) => Il2CppImports.il2cpp_add_internal_call(name, method);

    public static void* ResolveInternalCall(string name) => Il2CppImports.il2cpp_resolve_icall(name);

    public static void* Alloc(nuint size) => Il2CppImports.il2cpp_alloc(size);

    public static void Free(void* ptr) => Il2CppImports.il2cpp_free(ptr);

    public static void UnhandledException(Il2CppException* ex) => Il2CppImports.il2cpp_unhandled_exception(ex);
}
