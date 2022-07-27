// <auto-generated>

#nullable enable
#pragma warning disable CS0649

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Il2CppInterop.Bindings.Structs.VersionSpecific.Il2CppMethodHandlers;

internal unsafe class NativeIl2CppMethodStructHandler_2021_2_0 : INativeIl2CppMethodStructHandler
{
    public int Size => sizeof(Il2CppMethod_2021_2_0);

    private struct Il2CppMethod_2021_2_0
    {
        public void* methodPointer;
        public void* virtualMethodPointer;
        public void* invoker_method;
        public byte* name;
        public Il2CppClass* klass;
        public Il2CppType* return_type;
        public Il2CppType** parameters;
        public void* anon0;
        public void* anon1;
        public uint token;
        public ushort flags;
        public ushort iflags;
        public ushort slot;
        public byte parameters_count;

        private byte __bitfield_0;

        public byte is_generic 
        {
            get => (byte)((__bitfield_0 >> 0) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 0;
                var otherBits = __bitfield_0 & ~(0b1 << 0);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_inflated 
        {
            get => (byte)((__bitfield_0 >> 1) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 1;
                var otherBits = __bitfield_0 & ~(0b1 << 1);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte wrapper_type 
        {
            get => (byte)((__bitfield_0 >> 2) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 2;
                var otherBits = __bitfield_0 & ~(0b1 << 2);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte has_full_generic_sharing_signature 
        {
            get => (byte)((__bitfield_0 >> 3) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 3;
                var otherBits = __bitfield_0 & ~(0b1 << 3);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte indirect_call_via_invokers 
        {
            get => (byte)((__bitfield_0 >> 4) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 4;
                var otherBits = __bitfield_0 & ~(0b1 << 4);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }
    }

    public void* GetMethodPointer(Il2CppMethod* o)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        return _->methodPointer;
    }

    public void SetMethodPointer(Il2CppMethod* o, void* value)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        _->methodPointer = value;
    }

    public Il2CppClass* GetClass(Il2CppMethod* o)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        return _->klass;
    }

    public void SetClass(Il2CppMethod* o, Il2CppClass* value)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        _->klass = value;
    }

    public string? GetName(Il2CppMethod* o)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        return _->name == default ? null : Marshal.PtrToStringUTF8((IntPtr)_->name);
    }

    public void SetName(Il2CppMethod* o, string? value)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        _->name = value == null ? default : (byte*)Marshal.StringToHGlobalAnsi(value);
    }

    public ref byte* GetNamePointer(Il2CppMethod* o)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        return ref _->name;
    }

    public uint GetToken(Il2CppMethod* o)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        return _->token;
    }

    public void SetToken(Il2CppMethod* o, uint value)
    {
        var _ = (Il2CppMethod_2021_2_0*)o;
        _->token = value;
    }
}
