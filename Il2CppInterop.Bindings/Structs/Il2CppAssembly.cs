#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppAssembly
{
    public Il2CppImage* Image => Il2CppImports.il2cpp_assembly_get_image(Pointer);
}
