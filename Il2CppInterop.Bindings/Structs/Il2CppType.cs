#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppType
{
    public void* Data { get; set; }
    private ushort attrs;
    public Il2CppTypeEnum Type { get; set; }
    private byte __bitfield_0;

    public Il2CppObject* Object => Il2CppImports.il2cpp_type_get_object(Pointer);
}
