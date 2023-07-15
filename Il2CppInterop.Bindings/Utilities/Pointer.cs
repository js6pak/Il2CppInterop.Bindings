#pragma warning disable CS8500 // declares a pointer to a managed type
namespace Il2CppInterop.Bindings.Utilities;

/// <summary>
/// Utility for using native pointer types in generics
/// </summary>
public readonly unsafe struct Pointer<T> : IEquatable<Pointer<T>>
{
    public T* Value { get; }

    public Pointer(T* value)
    {
        Value = value;
    }

    public static implicit operator T*(Pointer<T> value) => value.Value;
    public static implicit operator Pointer<T>(T* value) => new(value);

    public static explicit operator IntPtr(Pointer<T> value) => (IntPtr)value.Value;
    public static explicit operator UIntPtr(Pointer<T> value) => (UIntPtr)value.Value;

    public override bool Equals(object? obj) => obj is Pointer<T> other && Equals(other);
    public bool Equals(Pointer<T> other) => Value == other.Value;

    public static bool operator ==(Pointer<T> left, Pointer<T> right) => left.Equals(right);
    public static bool operator !=(Pointer<T> left, Pointer<T> right) => !(left == right);

    public override int GetHashCode() => ((nuint)Value).GetHashCode();
    public override string ToString() => ((nuint)Value).ToString();
}
