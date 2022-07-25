#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppObject
{
    private Il2CppClass* klass;
    private MonitorData monitor;

    public Il2CppClass* Class =>
#if DISABLE_SHORTCUTS
        Il2CppImports.il2cpp_object_get_class(Pointer);
#else
        klass;
#endif

    public static Il2CppObject* New(Il2CppClass* klass)
    {
        return Il2CppImports.il2cpp_object_new(klass);
    }

    public void* Unbox()
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_object_unbox(Pointer);
#else
        void* val = (byte*)Pointer + sizeof(Il2CppObject);
        return val;
#endif
    }

    public static Il2CppObject* Box(Il2CppClass* klass, void* data)
    {
        return Il2CppImports.il2cpp_value_box(klass, data);
    }
}
