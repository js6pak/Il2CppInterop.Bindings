#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using System.Runtime.InteropServices;
using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public unsafe partial struct Il2CppField
{
    private byte* name;
    private Il2CppType* type;
    private Il2CppType* parent;
    private int offset; // If offset is -1, then it's thread static
    private int token; // this was a CustomAttributeIndex in very old il2cpp versions

    public string Name =>
#if DISABLE_SHORTCUTS
        Marshal.PtrToStringUTF8((IntPtr)Il2CppImports.il2cpp_field_get_name(Pointer))!;
#else
        Marshal.PtrToStringUTF8((IntPtr)name)!;
#endif

    public int Offset =>
#if DISABLE_SHORTCUTS
       (int)Il2CppImports.il2cpp_field_get_offset(Pointer);
#else
        offset;
#endif
}
