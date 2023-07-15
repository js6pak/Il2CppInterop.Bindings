#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppImage
{
    public string NameWithoutExtension => Path.GetFileNameWithoutExtension(Name ?? throw new InvalidOperationException("Name can't be null"));

    public static Il2CppImage* Corlib => Il2CppImports.il2cpp_get_corlib();
}
