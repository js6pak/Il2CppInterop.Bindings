#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppThread
{
    public bool IsVmThread => Il2CppImports.il2cpp_is_vm_thread(Pointer);

    public void Detach() => Il2CppImports.il2cpp_thread_detach(Pointer);

    public static NativeArray<Handle<Il2CppThread>> GetAllAttachedThreads()
    {
        nuint size = 0;
        var array = Il2CppImports.il2cpp_thread_get_all_attached_threads(&size);
        return NativeArray.From(size, array);
    }

    public static Il2CppThread* Current => Il2CppImports.il2cpp_thread_current();
    public static Il2CppThread* Attach(Il2CppDomain* domain) => Il2CppImports.il2cpp_thread_attach(domain);
    public static Il2CppThread* Attach() => Attach(Il2CppDomain.Current);
}
