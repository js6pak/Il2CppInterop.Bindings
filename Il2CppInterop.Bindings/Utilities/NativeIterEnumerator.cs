#if DISABLE_SHORTCUTS
using System.Collections;

namespace Il2CppInterop.Bindings.Utilities;

internal unsafe class NativeIterEnumerator<TOwner, TElement> : IEnumerator<Handle<TElement>>, IEnumerable<Handle<TElement>> where TOwner : unmanaged where TElement : unmanaged
{
    private readonly TOwner* _owner;
    private readonly delegate*<TOwner*, void**, TElement*> _func;
    private void* _iter;

    public NativeIterEnumerator(TOwner* owner, delegate*<TOwner*, void**, TElement*> func)
    {
        _owner = owner;
        _func = func;
    }

    public bool MoveNext()
    {
        fixed (void** iter = &_iter)
        {
            Current = _func(_owner, iter);
        }

        return Current.Value != default;
    }

    public void Reset()
    {
        _iter = default;
        Current = default;
    }

    public Handle<TElement> Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public IEnumerator<Handle<TElement>> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
#endif
