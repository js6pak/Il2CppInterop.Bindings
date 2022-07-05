using AssetRipper.VersionUtilities;

#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

namespace Il2CppInterop.Bindings.Structs;

public struct Il2CppType
{
}

public struct EventInfo
{
}

public struct MethodInfo
{
}

public struct FieldInfo
{
}

public struct PropertyInfo
{
}

public struct Il2CppAssembly
{
}

public unsafe struct Il2CppArray
{
    public static Il2CppArray* New(Il2CppClass* elementClass, int length)
    {
        if (UnityVersionHandler.Version >= new UnityVersion(2017, 2, 0, UnityVersionType.Final))
        {
            return Il2CppImports.il2cpp_array_new_2017_2_0(elementClass, (nuint)length);
        }

        return Il2CppImports.il2cpp_array_new_5_2_2(elementClass, length);
    }

    public static Il2CppArray* NewSpecific(Il2CppClass* arrayClass, int length)
    {
        if (UnityVersionHandler.Version >= new UnityVersion(2017, 2, 0, UnityVersionType.Final))
        {
            return Il2CppImports.il2cpp_array_new_specific_2017_2_0(arrayClass, (nuint)length);
        }

        return Il2CppImports.il2cpp_array_new_specific_5_2_2(arrayClass, length);
    }

    public static uint GetLength(Il2CppArray* array) => Il2CppImports.il2cpp_array_length(array);
}

public struct Il2CppDomain
{
}

public unsafe struct Il2CppImage
{
    public static Il2CppImage* Corlib => Il2CppImports.il2cpp_get_corlib();
}

public unsafe partial struct Il2CppException
{
#if DISABLE_SHORTCUTS
    [ThreadStatic]
    private static byte[]? _buffer;
#endif

    public static void Raise(Il2CppException* ex) => Il2CppImports.il2cpp_raise_exception(ex);

    public static Il2CppException* New(Il2CppImage* image, string @namespace, string name, string msg) => Il2CppImports.il2cpp_exception_from_name_msg(image, @namespace, name, msg);
    public static Il2CppException* NewArgumentNull(string arg) => Il2CppImports.il2cpp_get_exception_argument_null(arg);

    public static string Format(Il2CppException* ex)
    {
#if DISABLE_SHORTCUTS
        _buffer ??= new byte[65536];
        fixed (byte* message = _buffer)
        {
            Il2CppImports.il2cpp_format_exception(ex, message, _buffer.Length);
            return Marshal.PtrToStringUTF8((IntPtr)message)!;
        }
#else
        var klass = ex->Object->Class;
        var fullName = klass->Namespace + "." + klass->Name;

        if (ex->Message != default)
        {
            return fullName + ": " + ex->Message->ToString();
        }

        return fullName;
#endif
    }

    public static string FormatStackTrace(Il2CppException* ex)
    {
#if DISABLE_SHORTCUTS
        _buffer ??= new byte[65536];
        fixed (byte* message = _buffer)
        {
            Il2CppImports.il2cpp_format_stack_trace(ex, message, _buffer.Length);
            return Marshal.PtrToStringUTF8((IntPtr)message)!;
        }
#else
        if (ex->StackTrace != default)
        {
            return ex->StackTrace->ToString();
        }

        return string.Empty;
#endif
    }
}

public unsafe struct Il2CppObject
{
    private Il2CppClass* klass;
    private MonitorData monitor;

    public Il2CppClass* Class => klass;

    public static Il2CppObject* New(Il2CppClass* klass)
    {
        return Il2CppImports.il2cpp_object_new(klass);
    }

    public static void* Unbox(Il2CppObject* obj)
    {
#if DISABLE_SHORTCUTS
        return IL2CPP.il2cpp_object_unbox(obj);
#else
        void* val = (byte*)obj + sizeof(Il2CppObject);
        return val;
#endif
    }

    public static Il2CppObject* Box(Il2CppClass* klass, void* data)
    {
        return Il2CppImports.il2cpp_value_box(klass, data);
    }
}

public unsafe struct Il2CppReflectionMethod
{
    private Il2CppObject @object;
    private MethodInfo* method;
    private Il2CppString* name;
    private Il2CppReflectionType* reftype;
}

public unsafe struct Il2CppReflectionType
{
    private Il2CppObject @object;
    private Il2CppType* type;
}

public unsafe struct Il2CppString
{
    private Il2CppObject @object;
    private int length;
    private char* chars;

    public int Length => length;

    public ReadOnlySpan<char> Chars => new(chars, length);

    public override string ToString()
    {
        return new string(chars, 0, length);
    }

    public static Il2CppString* From(string value)
    {
        return Il2CppImports.il2cpp_string_new_utf16(value, value.Length);
    }

    public static Il2CppString* Intern(Il2CppString* str)
    {
        return Il2CppImports.il2cpp_string_intern(str);
    }

    public static Il2CppString* IsInterned(Il2CppString* str)
    {
        return Il2CppImports.il2cpp_string_is_interned(str);
    }
}

public unsafe struct Il2CppThread
{
    public static Il2CppThread* Current => Il2CppImports.il2cpp_thread_current();

    public static Il2CppThread* Attach(Il2CppDomain* domain) => Il2CppImports.il2cpp_thread_attach(domain);
    public static void Detach(Il2CppThread* thread) => Il2CppImports.il2cpp_thread_detach(thread);

    public static Il2CppThread** GetAllAttachedThreads(out nuint size)
    {
        size = 0;
        fixed (nuint* sizePointer = &size)
        {
            return Il2CppImports.il2cpp_thread_get_all_attached_threads(sizePointer);
        }
    }

    public static bool IsVmThread(Il2CppThread* thread) => Il2CppImports.il2cpp_is_vm_thread(thread);
}

public struct Il2CppCustomAttrInfo
{
}

public struct MonitorData
{
}

public unsafe struct Il2CppStackFrameInfo
{
    private MethodInfo* method;
}

public struct Il2CppMemoryCallbacks
{
}

public unsafe struct Il2CppRuntimeInterfaceOffsetPair
{
    private Il2CppClass* interfaceType;
    private int offset;
}

public unsafe struct VirtualInvokeData
{
    private void* methodPtr;
    private MethodInfo* method;
}
