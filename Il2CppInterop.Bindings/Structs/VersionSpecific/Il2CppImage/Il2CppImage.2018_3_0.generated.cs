// <auto-generated>
#nullable enable

#pragma warning disable CS0649

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Il2CppInterop.Bindings.Structs.VersionSpecific.Il2CppImageHandlers;

internal unsafe class NativeIl2CppImageStructHandler_2018_3_0 : INativeIl2CppImageStructHandler
{
    public int Size => sizeof(Il2CppImage_2018_3_0);

    private struct Il2CppImage_2018_3_0
    {
        public byte* name;
        public byte* nameNoExt;
        public Il2CppAssembly* assembly;
        public int typeStart;
        public uint typeCount;
        public int exportedTypeStart;
        public uint exportedTypeCount;
        public int customAttributeStart;
        public uint customAttributeCount;
        public int entryPointIndex;
        public void* nameToClassHashTable;
        public uint token;
        public byte dynamic;
    }

    public string? GetName(Il2CppImage* o)
    {
        var _ = (Il2CppImage_2018_3_0*)o;
        return _->name == default ? null : Marshal.PtrToStringUTF8((IntPtr)_->name);
    }

    public void SetName(Il2CppImage* o, string? value)
    {
        var _ = (Il2CppImage_2018_3_0*)o;
        _->name = value == null ? default : (byte*)Marshal.StringToHGlobalAnsi(value);
    }

    public ref byte* GetNamePointer(Il2CppImage* o)
    {
        var _ = (Il2CppImage_2018_3_0*)o;
        return ref _->name;
    }

    public Il2CppAssembly* GetAssembly(Il2CppImage* o)
    {
        var _ = (Il2CppImage_2018_3_0*)o;
        return _->assembly;
    }
}
