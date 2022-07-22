// <auto-generated>

#nullable enable
#pragma warning disable CS0649

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Il2CppInterop.Bindings.Structs.VersionSpecific.Il2CppExceptionHandlers;

internal unsafe class NativeIl2CppExceptionStructHandler_2019_3_0 : INativeIl2CppExceptionStructHandler
{
    public int Size => sizeof(Il2CppException_2019_3_0);

    private struct Il2CppException_2019_3_0
    {
        public Il2CppObject @base;
        public Il2CppString* className;
        public Il2CppString* message;
        public Il2CppObject* _data;
        public Il2CppException* inner_ex;
        public Il2CppString* _helpURL;
        public Il2CppArray* trace_ips;
        public Il2CppString* stack_trace;
        public Il2CppString* remote_stack_trace;
        public int remote_stack_index;
        public Il2CppObject* _dynamicMethods;
        public int hresult;
        public Il2CppString* source;
        public Il2CppObject* safeSerializationManager;
        public Il2CppArray* captured_traces;
        public Il2CppArray* native_trace_ips;
    }

    public Il2CppObject* GetObject(Il2CppException* o)
    {
        var _ = (Il2CppException_2019_3_0*)o;
        return &_->@base;
    }

    public Il2CppString* GetMessage(Il2CppException* o)
    {
        var _ = (Il2CppException_2019_3_0*)o;
        return _->message;
    }

    public void SetMessage(Il2CppException* o, Il2CppString* value)
    {
        var _ = (Il2CppException_2019_3_0*)o;
        _->message = value;
    }

    public Il2CppString* GetStackTrace(Il2CppException* o)
    {
        var _ = (Il2CppException_2019_3_0*)o;
        return _->stack_trace;
    }

    public void SetStackTrace(Il2CppException* o, Il2CppString* value)
    {
        var _ = (Il2CppException_2019_3_0*)o;
        _->stack_trace = value;
    }
}
