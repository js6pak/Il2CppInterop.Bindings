using Il2CppInterop.Bindings.Structs;

namespace Il2CppInterop.Bindings;

public unsafe class WrappedIl2CppException : Exception
{
    public Il2CppException* Pointer { get; }

    public WrappedIl2CppException(Il2CppException* pointer) : base(pointer->Format() + "\n" + pointer->FormatStackTrace())
    {
        Pointer = pointer;
    }
}
