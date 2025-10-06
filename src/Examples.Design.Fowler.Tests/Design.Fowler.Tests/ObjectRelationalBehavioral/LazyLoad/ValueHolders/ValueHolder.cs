namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.ValueHolders;

// 値の遅延読み込みを担当する汎用クラス
public class ValueHolder<T>
{
    private T? _value;
    private readonly Func<T> _loader;
    private bool _isLoaded = false;

    public ValueHolder(Func<T> loader)
    {
        _loader = loader;
    }

    public T Value
    {
        get
        {
            if (!_isLoaded)
            {
                _value = _loader();
                _isLoaded = true;
            }
            return _value!;
        }
    }
}