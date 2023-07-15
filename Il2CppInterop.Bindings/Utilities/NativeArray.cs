using System.Collections;

namespace Il2CppInterop.Bindings.Utilities;

public static unsafe class NativeArray
{
    public static NativeArray<Pointer<T>> From<T>(nuint size, T** array) where T : unmanaged
    {
        return new NativeArray<Pointer<T>>(size, (Pointer<T>*)array);
    }
}

public readonly unsafe struct NativeArray<T> : IEnumerable<T>
    where T : unmanaged
{
    private readonly nuint _size;
    private readonly T* _array;

    public NativeArray(nuint size, T* array)
    {
        _size = size;
        _array = array;
    }

    public nuint Size => _size;

    public T* this[nuint index] => &_array[index];

    public ref struct RefEnumerator
    {
        private readonly NativeArray<T> _array;
        private nuint _index = 0;

        public RefEnumerator(NativeArray<T> array)
        {
            _array = array;
        }

        public bool MoveNext() => _index++ < _array.Size;
        public void Reset() => _index = 0;

        public readonly T* Current => _array[_index];
    }

    public RefEnumerator GetEnumerator()
    {
        return new RefEnumerator(this);
    }

    private class Enumerator : IEnumerator<T>
    {
        private readonly NativeArray<T> _array;
        private nuint _index;

        public Enumerator(NativeArray<T> array)
        {
            _array = array;
        }

        public bool MoveNext() => _index++ < _array.Size;
        public void Reset() => _index = 0;

        public T Current => *_array[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }
}
