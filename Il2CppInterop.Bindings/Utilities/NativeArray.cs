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
        private nuint? _index = null;

        public RefEnumerator(NativeArray<T> array)
        {
            _array = array;
        }

        public bool MoveNext()
        {
            if (_index == null)
            {
                _index = 0;
                return true;
            }

            return ++_index < _array.Size;
        }

        public void Reset() => _index = null;

        public readonly T* Current => _index != null ? _array[_index.Value] : null;
    }

    public RefEnumerator GetEnumerator()
    {
        return new RefEnumerator(this);
    }

    private class Enumerator : IEnumerator<T>
    {
        private readonly NativeArray<T> _array;
        private nuint? _index = null;

        public Enumerator(NativeArray<T> array)
        {
            _array = array;
        }

        public bool MoveNext()
        {
            if (_index == null)
            {
                _index = 0;
                return true;
            }

            return ++_index < _array.Size;
        }

        public void Reset() => _index = null;

        public T Current => _index != null ? *_array[_index.Value] : default;

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
