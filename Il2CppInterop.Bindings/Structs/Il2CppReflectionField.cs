#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppReflectionField
{
    private Il2CppObject @object;
    private Il2CppClass* klass;
    private Il2CppField* field;
    private Il2CppString* name;
    private Il2CppReflectionType* type;
    private uint attrs;

    public Il2CppObject Object => @object;
    public Il2CppField* Field => field;
}
