// <auto-generated>

#nullable enable

using System.Runtime.CompilerServices;

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppException
{
    public static int Size => UnityVersionHandler.Il2CppException.Size;

    public Il2CppException* Pointer 
    {
        get
        {
            fixed (Il2CppException* pointer = &this) { return pointer; }
        }
    }

    public Il2CppObject* Object => UnityVersionHandler.Il2CppException.GetObject(Pointer);

    public Il2CppString* Message { get => UnityVersionHandler.Il2CppException.GetMessage(Pointer); set => UnityVersionHandler.Il2CppException.SetMessage(Pointer, value); }

    public Il2CppString* StackTrace { get => UnityVersionHandler.Il2CppException.GetStackTrace(Pointer); set => UnityVersionHandler.Il2CppException.SetStackTrace(Pointer, value); }
}
