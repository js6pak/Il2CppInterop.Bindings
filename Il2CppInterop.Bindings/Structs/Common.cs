#if DISABLE_SHORTCUTS
using System.Collections;
#endif
using System.Runtime.InteropServices;
using AssetRipper.VersionUtilities;
using Il2CppInterop.Bindings.Utilities;

#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

namespace Il2CppInterop.Bindings.Structs;

public unsafe struct Il2CppType
{
    private void* data;
    private ushort attrs;
    private byte type;
    private byte __bitfield_0;

    public static Il2CppObject* GetObject(Il2CppType* type)
    {
        return Il2CppImports.il2cpp_type_get_object(type);
    }
}

public struct Il2CppEvent
{
}

public unsafe partial struct Il2CppMethod
{
    public static uint GetToken(Il2CppMethod* method)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_method_get_token(method);
#else
        return method->Token;
#endif
    }
}

public unsafe struct Il2CppField
{
    private byte* name;
    private Il2CppType* type;
    private Il2CppType* parent;
    private int offset; // If offset is -1, then it's thread static
    private int token; // this was a CustomAttributeIndex in very old il2cpp versions

    public static string GetName(Il2CppField* field)
    {
#if DISABLE_SHORTCUTS
        return Marshal.PtrToStringUTF8((IntPtr)Il2CppImports.il2cpp_field_get_name(field))!;
#else
        return Marshal.PtrToStringUTF8((IntPtr)field->name)!;
#endif
    }

    public static int GetOffset(Il2CppField* field)
    {
#if DISABLE_SHORTCUTS
        return (int)Il2CppImports.il2cpp_field_get_offset(field);
#else
        return field->offset;
#endif
    }
}

public struct Il2CppProperty
{
}

public struct Il2CppParameter
{
}

public unsafe partial struct Il2CppClass
{
    public static Il2CppClass* FromName(Il2CppImage* image, string @namespace, string name)
    {
        return Il2CppImports.il2cpp_class_from_name(image, @namespace, name);
    }

    public static Il2CppType* GetType(Il2CppClass* klass)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_get_type(klass);
#else
        return klass->ByVal;
#endif
    }

    public static Il2CppClass* FromIl2CppType(Il2CppType* type)
    {
        return Il2CppImports.il2cpp_class_from_type(type);
    }

    public static Il2CppClass* FromReflectionType(Il2CppReflectionType* type)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_from_system_type(type);
#else
        return FromIl2CppType(type->Type);
#endif
    }

    public static bool IsInflated(Il2CppClass* klass)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_is_inflated(klass);
#else
        return klass->IsGeneric;
#endif
    }

    public static IEnumerable<Handle<Il2CppClass>> GetNestedTypes(Il2CppClass* klass)
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppClass>(klass, &Il2CppImports.il2cpp_class_get_nested_types);
#else
        if (klass->IsGeneric)
        {
            throw new ArgumentException("Can't get nested types for a generic class");
        }

        // Make sure Class::SetupNestedTypes was called
        if (klass->NestedTypes == default && klass->NestedTypeCount > 0)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_nested_types(klass, &iter);
        }

        return NativeArray.From(klass->NestedTypeCount, klass->NestedTypes);
#endif
    }

    public static IEnumerable<Handle<Il2CppMethod>> GetMethods(Il2CppClass* klass)
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppMethod>(klass, &Il2CppImports.il2cpp_class_get_methods);
#else
        // Make sure Class::SetupMethods was called
        if (klass->Rank > 0 || klass->MethodCount > 0)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_methods(klass, &iter);
        }

        return NativeArray.From(klass->MethodCount, klass->Methods);
#endif
    }

    public static Il2CppMethod* GetMethodByToken(Il2CppClass* klass, uint token)
    {
        foreach (var method in GetMethods(klass))
        {
            if (Il2CppMethod.GetToken(method) == token)
            {
                return method;
            }
        }

        return default;
    }

    public static IEnumerable<Handle<Il2CppField>> GetFields(Il2CppClass* klass)
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppField>(klass, &Il2CppImports.il2cpp_class_get_fields);
#else
        // Make sure Class::SetupFields was called
        if (!klass->IsSizeInitialized)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_fields(klass, &iter);
        }

        return new NativeArray<Il2CppField>(klass->FieldCount, klass->Fields).GetHandles();
#endif
    }

    public static Il2CppField* GetFieldByName(Il2CppClass* klass, string name)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_get_field_from_name(klass, name);
#else
        foreach (var field in GetFields(klass))
        {
            if (Il2CppField.GetName(field) == name)
            {
                return field;
            }
        }

        return default;
#endif
    }

    public static bool IsValueType(Il2CppClass* klass)
    {
        return Il2CppImports.il2cpp_class_is_valuetype(klass);
    }

    public static int GetValueSize(Il2CppClass* klass)
    {
        if (!IsValueType(klass)) throw new ArgumentException("GetValueSize can only be called on ValueTypes");
        return Il2CppImports.il2cpp_class_value_size(klass, default);
    }
}

public unsafe struct Il2CppAssembly
{
    public static Il2CppImage* GetImage(Il2CppAssembly* assembly)
    {
        return Il2CppImports.il2cpp_assembly_get_image(assembly);
    }
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

public unsafe struct Il2CppDomain
{
    public static Il2CppDomain* Current => Il2CppImports.il2cpp_domain_get();

    public static NativeArray<Handle<Il2CppAssembly>> GetAssemblies(Il2CppDomain* domain, out nuint size)
    {
        size = 0;
        fixed (nuint* sizePointer = &size)
        {
            var array = Il2CppImports.il2cpp_domain_get_assemblies(domain, sizePointer);
            return NativeArray.From(size, array);
        }
    }
}

public unsafe struct Il2CppImage
{
    private byte* name;

    public static Il2CppImage* Corlib => Il2CppImports.il2cpp_get_corlib();

    public static string GetName(Il2CppImage* image)
    {
#if DISABLE_SHORTCUTS
        return Marshal.PtrToStringUTF8((IntPtr)Il2CppImports.il2cpp_image_get_name(image))!;
#else
        return Marshal.PtrToStringUTF8((IntPtr)image->name)!;
#endif
    }
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
        return Il2CppImports.il2cpp_object_unbox(obj);
#else
        void* val = (byte*)obj + sizeof(Il2CppObject);
        return val;
#endif
    }

    public static Il2CppObject* Box(Il2CppClass* klass, void* data)
    {
        return Il2CppImports.il2cpp_value_box(klass, data);
    }

    public static void* GetClass(Il2CppObject* obj)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_object_get_class(obj);
#else
        return obj->Class;
#endif
    }
}

public unsafe struct Il2CppReflectionMethod
{
    private Il2CppObject @object;
    private Il2CppMethod* method;
    private Il2CppString* name;
    private Il2CppReflectionType* reftype;
}

public unsafe struct Il2CppReflectionType
{
    private Il2CppObject @object;
    private Il2CppType* type;

    public Il2CppType* Type => type;

    public static Il2CppReflectionType* From(Il2CppType* type)
    {
        return (Il2CppReflectionType*)Il2CppType.GetObject(type);
    }

    public static Il2CppReflectionType* From(Il2CppClass* klass)
    {
        return From(Il2CppClass.GetType(klass));
    }
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

    public static NativeArray<Handle<Il2CppThread>> GetAllAttachedThreads(out nuint size)
    {
        size = 0;
        fixed (nuint* sizePointer = &size)
        {
            var array = Il2CppImports.il2cpp_thread_get_all_attached_threads(sizePointer);
            return NativeArray.From(size, array);
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
    private Il2CppMethod* method;
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
    private Il2CppMethod* method;
}
