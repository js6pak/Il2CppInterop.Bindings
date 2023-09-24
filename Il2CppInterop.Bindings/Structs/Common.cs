#if DISABLE_SHORTCUTS
using System.Collections;
#endif
using Il2CppInterop.Bindings.Utilities;

#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
public partial struct Il2CppProperty
{
}

[NativeStruct]
public partial struct Il2CppParameter
{
}

[NativeStruct]
public partial struct Il2CppEvent
{
}

[NativeStruct]
public partial struct Il2CppCustomAttrInfo
{
}

[NativeStruct]
public partial struct MonitorData
{
}

[NativeStruct]
public unsafe partial struct Il2CppStackFrameInfo
{
    private Il2CppMethod* method;
}

[NativeStruct]
public partial struct Il2CppMemoryCallbacks
{
}

[NativeStruct]
public unsafe partial struct Il2CppRuntimeInterfaceOffsetPair
{
    private Il2CppClass* interfaceType;
    private int offset;
}

[NativeStruct]
public unsafe partial struct VirtualInvokeData
{
    private void* methodPtr;
    private Il2CppMethod* method;
}

[NativeStruct]
public partial struct Il2CppProfiler
{
}
