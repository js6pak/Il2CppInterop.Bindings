#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppDomain
{
    public static Il2CppDomain* Current => Il2CppImports.il2cpp_domain_get();

    public NativeArray<Handle<Il2CppAssembly>> GetAssemblies()
    {
        nuint size = 0;
        var array = Il2CppImports.il2cpp_domain_get_assemblies(Pointer, &size);
        return NativeArray.From(size, array);
    }
}
