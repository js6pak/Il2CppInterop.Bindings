#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppReflectionType
{
    private Il2CppObject @object;
    private Il2CppType* type;

    public Il2CppObject Object => @object;
    public Il2CppType* Type => type;

    public static Il2CppReflectionType* From(Il2CppType* type)
    {
        return (Il2CppReflectionType*)type->Object;
    }

    public static Il2CppReflectionType* From(Il2CppClass* klass)
    {
        return From(klass->Type);
    }
}

[NativeStruct]
public unsafe partial struct Il2CppReflectionMethod
{
    private Il2CppObject @object;
    private Il2CppMethod* method;
    private Il2CppString* name;
    private Il2CppReflectionType* reftype;

    public Il2CppObject Object => @object;
    public Il2CppMethod* Method => method;

    public static Il2CppReflectionMethod* From(Il2CppMethod* method)
    {
        return Il2CppImports.il2cpp_method_get_object(method, method->Class);
    }
}
