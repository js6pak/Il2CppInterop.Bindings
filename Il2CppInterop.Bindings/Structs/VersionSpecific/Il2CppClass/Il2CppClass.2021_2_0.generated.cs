// <auto-generated>

#nullable enable
#pragma warning disable CS0649

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Il2CppInterop.Bindings.Structs.VersionSpecific.Il2CppClass;

using Il2CppClass = Il2CppInterop.Bindings.Structs.Il2CppClass;

internal unsafe class NativeIl2CppClassStructHandler_2021_2_0 : INativeIl2CppClassStructHandler
{
    public int Size => sizeof(Il2CppClass_2021_2_0);

    private struct Il2CppClass_2021_2_0
    {
        public Il2CppImage* image;
        public void* gc_desc;
        public byte* name;
        public byte* namespaze;
        public Il2CppType byval_arg;
        public Il2CppType this_arg;
        public Il2CppClass* element_class;
        public Il2CppClass* castClass;
        public Il2CppClass* declaringType;
        public Il2CppClass* parent;
        public void* generic_class;
        public void* typeMetadataHandle;
        public void* interopData;
        public Il2CppClass* klass;
        public FieldInfo* fields;
        public EventInfo* events;
        public PropertyInfo* properties;
        public MethodInfo** methods;
        public Il2CppClass** nestedTypes;
        public Il2CppClass** implementedInterfaces;
        public Il2CppRuntimeInterfaceOffsetPair* interfaceOffsets;
        public void* static_fields;
        public void* rgctx_data;
        public Il2CppClass** typeHierarchy;
        public void* unity_user_data;
        public uint initializationExceptionGCHandle;
        public uint cctor_started;
        public uint cctor_finished_or_no_cctor;
        public nuint cctor_thread;
        public void* genericContainerHandle;
        public uint instance_size;
        public uint actualSize;
        public uint element_size;
        public int native_size;
        public uint static_fields_size;
        public uint thread_static_fields_size;
        public int thread_static_fields_offset;
        public uint flags;
        public uint token;
        public ushort method_count;
        public ushort property_count;
        public ushort field_count;
        public ushort event_count;
        public ushort nested_type_count;
        public ushort vtable_count;
        public ushort interfaces_count;
        public ushort interface_offsets_count;
        public byte typeHierarchyDepth;
        public byte genericRecursionDepth;
        public byte rank;
        public byte minimumAlignment;
        public byte naturalAligment;
        public byte packingSize;

        private byte __bitfield_0;

        public byte initialized_and_no_error 
        {
            get => (byte)((__bitfield_0 >> 0) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 0;
                var otherBits = __bitfield_0 & ~(0b1 << 0);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte initialized 
        {
            get => (byte)((__bitfield_0 >> 1) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 1;
                var otherBits = __bitfield_0 & ~(0b1 << 1);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte enumtype 
        {
            get => (byte)((__bitfield_0 >> 2) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 2;
                var otherBits = __bitfield_0 & ~(0b1 << 2);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte nullabletype 
        {
            get => (byte)((__bitfield_0 >> 3) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 3;
                var otherBits = __bitfield_0 & ~(0b1 << 3);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_generic 
        {
            get => (byte)((__bitfield_0 >> 4) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 4;
                var otherBits = __bitfield_0 & ~(0b1 << 4);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte has_references 
        {
            get => (byte)((__bitfield_0 >> 5) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 5;
                var otherBits = __bitfield_0 & ~(0b1 << 5);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte init_pending 
        {
            get => (byte)((__bitfield_0 >> 6) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 6;
                var otherBits = __bitfield_0 & ~(0b1 << 6);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte size_init_pending 
        {
            get => (byte)((__bitfield_0 >> 7) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 7;
                var otherBits = __bitfield_0 & ~(0b1 << 7);
                __bitfield_0 = (byte)(otherBits | shiftedValue);
            }
        }

        private byte __bitfield_1;

        public byte size_inited 
        {
            get => (byte)((__bitfield_1 >> 0) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 0;
                var otherBits = __bitfield_1 & ~(0b1 << 0);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte has_finalize 
        {
            get => (byte)((__bitfield_1 >> 1) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 1;
                var otherBits = __bitfield_1 & ~(0b1 << 1);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte has_cctor 
        {
            get => (byte)((__bitfield_1 >> 2) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 2;
                var otherBits = __bitfield_1 & ~(0b1 << 2);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_blittable 
        {
            get => (byte)((__bitfield_1 >> 3) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 3;
                var otherBits = __bitfield_1 & ~(0b1 << 3);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_import_or_windows_runtime 
        {
            get => (byte)((__bitfield_1 >> 4) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 4;
                var otherBits = __bitfield_1 & ~(0b1 << 4);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_vtable_initialized 
        {
            get => (byte)((__bitfield_1 >> 5) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 5;
                var otherBits = __bitfield_1 & ~(0b1 << 5);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public byte is_byref_like 
        {
            get => (byte)((__bitfield_1 >> 6) & 0b1);
            set
            {
                var shiftedValue = (value & 0b1) << 6;
                var otherBits = __bitfield_1 & ~(0b1 << 6);
                __bitfield_1 = (byte)(otherBits | shiftedValue);
            }
        }

        public VirtualInvokeData* vtable => (VirtualInvokeData*)((Il2CppClass_2021_2_0*)Unsafe.AsPointer(ref this) + sizeof(Il2CppClass_2021_2_0));
    }

    public string? GetName(Il2CppClass* klass)
    {
        var _ = (Il2CppClass_2021_2_0*)klass;
        return _->name == default ? null : Marshal.PtrToStringAnsi((IntPtr)_->name);
    }

    public void SetName(Il2CppClass* klass, string? value)
    {
        var _ = (Il2CppClass_2021_2_0*)klass;
        _->name = value == null ? default : (byte*)Marshal.StringToHGlobalAnsi(value);
    }

    public ref byte* GetNamePointer(Il2CppClass* klass)
    {
        var _ = (Il2CppClass_2021_2_0*)klass;
        return ref _->name;
    }
}
