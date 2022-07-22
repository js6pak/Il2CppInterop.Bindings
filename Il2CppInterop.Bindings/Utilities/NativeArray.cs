using System.Collections;
using System.Runtime.CompilerServices;

namespace Il2CppInterop.Bindings.Utilities;

public static unsafe class NativeArray
{
    public static NativeArray<Handle<T>> From<T>(nuint size, T** array) where T : unmanaged
    {
        return new NativeArray<Handle<T>>(size, (Handle<T>*)array);
    }
}

public readonly unsafe struct NativeArray<T> : IEnumerable<T> where T : unmanaged
{
    private readonly nuint _size;
    private readonly T* _array;

    public NativeArray(nuint size, T* array)
    {
        _size = size;
        _array = array;
    }

    public nuint Size => _size;

    public T this[nuint index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public T*[] GetPointers()
    {
        var pointers = new T*[_size];
        for (nuint i = 0; i < _size; i++)
        {
            pointers[i] = _array + i;
        }

        return pointers;
    }

    public Handle<T>[] GetHandles()
    {
        return Unsafe.As<Handle<T>[]>(GetPointers());
    }

    public struct Enumerator : IEnumerator<T>
    {
        private readonly NativeArray<T> _array;
        private nuint _index = 0;

        public Enumerator(NativeArray<T> array) : this()
        {
            _array = array;
        }

        public bool MoveNext()
        {
            if (_index < _array._size)
            {
                Current = _array[_index];
                _index++;
                return true;
            }

            Current = default;
            _index++;
            return false;
        }

        public void Reset()
        {
            _index = 0;
            Current = default;
        }

        public T Current { get; private set; } = default;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
