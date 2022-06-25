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

public struct Il2CppArray
{
}

public struct Il2CppDomain
{
}

public struct Il2CppImage
{
}

public struct Il2CppException
{
}

public unsafe struct Il2CppObject
{
    private Il2CppClass* klass;
    private MonitorData monitor;
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

    public static Il2CppString* From(string value)
    {
        return IL2CPP.il2cpp_string_new_utf16(value, value.Length);
    }

    public override string ToString()
    {
        return new string(Chars);
    }
}

public struct Il2CppThread
{
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
