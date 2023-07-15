#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppMethod
{
    public Il2CppObject* Invoke(void* obj, void** @params, out Il2CppException* exc)
    {
        exc = default;
        fixed (Il2CppException** excPtr = &exc)
        {
            return Il2CppImports.il2cpp_runtime_invoke(Pointer, obj, @params, excPtr);
        }
    }

    public Il2CppObject* Invoke(void* obj, void** @params)
    {
        var result = Invoke(obj, @params, out var exc);
        if (exc != default) throw new WrappedIl2CppException(exc);

        return result;
    }

    public static Il2CppMethod* FromReflectionMethod(Il2CppReflectionMethod* method)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_method_get_from_reflection(method);
#else
        return method->Method;
#endif
    }
}
