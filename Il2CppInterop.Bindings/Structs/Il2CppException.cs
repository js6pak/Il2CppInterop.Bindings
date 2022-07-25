#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

#if DISABLE_SHORTCUTS
using System.Runtime.InteropServices;
#endif

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppException
{
#if DISABLE_SHORTCUTS
    [ThreadStatic]
    private static byte[]? _buffer;
#endif

    public void Raise() => Il2CppImports.il2cpp_raise_exception(Pointer);

    public string Format()
    {
#if DISABLE_SHORTCUTS
        _buffer ??= new byte[65536];
        fixed (byte* message = _buffer)
        {
            Il2CppImports.il2cpp_format_exception(Pointer, message, _buffer.Length);
            return Marshal.PtrToStringUTF8((IntPtr)message)!;
        }
#else
        var klass = Object->Class;
        var fullName = klass->Namespace + "." + klass->Name;

        if (Message != default)
        {
            return fullName + ": " + Message->ToString();
        }

        return fullName;
#endif
    }

    public string FormatStackTrace()
    {
#if DISABLE_SHORTCUTS
        _buffer ??= new byte[65536];
        fixed (byte* message = _buffer)
        {
            Il2CppImports.il2cpp_format_stack_trace(Pointer, message, _buffer.Length);
            return Marshal.PtrToStringUTF8((IntPtr)message)!;
        }
#else
        if (StackTrace != default)
        {
            return StackTrace->ToString();
        }

        return string.Empty;
#endif
    }

    public static Il2CppException* New(Il2CppImage* image, string @namespace, string name, string msg) => Il2CppImports.il2cpp_exception_from_name_msg(image, @namespace, name, msg);
    public static Il2CppException* NewArgumentNull(string arg) => Il2CppImports.il2cpp_get_exception_argument_null(arg);
}
