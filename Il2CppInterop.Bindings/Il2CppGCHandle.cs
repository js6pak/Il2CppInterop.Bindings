using Il2CppInterop.Bindings.Structs;

namespace Il2CppInterop.Bindings;

public unsafe struct Il2CppGCHandle
{
    private readonly nuint _handle;

    private Il2CppGCHandle(uint handle)
    {
        _handle = handle;
    }

    private Il2CppGCHandle(void* handle)
    {
        _handle = (nuint)handle;
    }

    public Il2CppObject* Target => IsPointerSized
        ? Il2CppImports.il2cpp_gchandle_get_target_2023_1_0((void*)_handle)
        : Il2CppImports.il2cpp_gchandle_get_target_5_2_2((uint)_handle);

    public void Free()
    {
        if (IsPointerSized) Il2CppImports.il2cpp_gchandle_free_2023_1_0((void*)_handle);
        else Il2CppImports.il2cpp_gchandle_free_5_2_2((uint)_handle);
    }

    public static Il2CppGCHandle New(Il2CppObject* obj, bool pinned)
    {
        return IsPointerSized
            ? new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new_2023_1_0(obj, pinned))
            : new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new_5_2_2(obj, pinned));
    }

    public static Il2CppGCHandle NewWeakref(Il2CppObject* obj, bool trackResurrection)
    {
        return IsPointerSized
            ? new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new_weakref_2023_1_0(obj, trackResurrection))
            : new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new_weakref_5_2_2(obj, trackResurrection));
    }

    public static bool IsPointerSized => UnityVersionHandler.Version.IsGreaterEqual(2023, 1, 0);
}
