#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using System.Runtime.InteropServices;
using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppImage
{
    private byte* name;

    public string Name =>
#if DISABLE_SHORTCUTS
        Marshal.PtrToStringUTF8((IntPtr)Il2CppImports.il2cpp_image_get_name(Pointer))!;
#else
        Marshal.PtrToStringUTF8((IntPtr)name)!;
#endif

    public static Il2CppImage* Corlib => Il2CppImports.il2cpp_get_corlib();
}
