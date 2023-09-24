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