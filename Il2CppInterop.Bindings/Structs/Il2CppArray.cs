#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using AssetRipper.VersionUtilities;

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppArray
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

    public static Il2CppClass* GetClass(Il2CppClass* elementClass, uint rank)
    {
        return Il2CppImports.il2cpp_array_class_get(elementClass, rank);
    }
}
