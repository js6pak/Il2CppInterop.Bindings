// <auto-generated>

#nullable enable
#pragma warning disable CS0649

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Il2CppInterop.Bindings.Structs.VersionSpecific.Il2CppArrayHandlers;

internal unsafe class NativeIl2CppArrayStructHandler_5_2_2 : INativeIl2CppArrayStructHandler
{
    public int Size => sizeof(Il2CppArray_5_2_2);

    private struct Il2CppArray_5_2_2
    {
        public Il2CppObject obj;
        public void* bounds;
        public int max_length;
        public double* vector => (double*)((Il2CppArray_5_2_2*)Unsafe.AsPointer(ref this) + sizeof(Il2CppArray_5_2_2));
    }

    public int GetLength(Il2CppArray* o)
    {
        var _ = (Il2CppArray_5_2_2*)o;
        return _->max_length;
    }

    public void SetLength(Il2CppArray* o, int value)
    {
        var _ = (Il2CppArray_5_2_2*)o;
        _->max_length = value;
    }
}
