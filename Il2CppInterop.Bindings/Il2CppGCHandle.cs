using Il2CppInterop.Bindings.Structs;

namespace Il2CppInterop.Bindings;

public unsafe struct Il2CppGCHandle
{
    private readonly uint _handle;

    private Il2CppGCHandle(uint handle)
    {
        _handle = handle;
    }

    public Il2CppObject* Target => Il2CppImports.il2cpp_gchandle_get_target(_handle);

    public void Free() => Il2CppImports.il2cpp_gchandle_free(_handle);

    public static Il2CppGCHandle New(Il2CppObject* obj, bool pinned)
    {
        return new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new(obj, pinned));
    }

    public static Il2CppGCHandle NewWeakref(Il2CppObject* obj, bool trackResurrection)
    {
        return new Il2CppGCHandle(Il2CppImports.il2cpp_gchandle_new_weakref(obj, trackResurrection));
    }
}
