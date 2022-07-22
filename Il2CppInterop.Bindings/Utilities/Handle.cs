namespace Il2CppInterop.Bindings.Utilities;

/// <summary>
/// Utility for using native pointer types in generics
/// </summary>
public unsafe struct Handle<T> where T : unmanaged
{
    public T* Value { get; }

    public Handle(T* value)
    {
        Value = value;
    }

    public static implicit operator T*(Handle<T> value) => value.Value;
    public static implicit operator Handle<T>(T* value) => new(value);

    public static explicit operator IntPtr(Handle<T> value) => (IntPtr)value.Value;
    public static explicit operator UIntPtr(Handle<T> value) => (UIntPtr)value.Value;
}
