namespace IgnMath;

internal class Mark<T> where T : class
{
    private readonly IEnumerable<T> _values;
    private int _index = 0;

    public Mark(IEnumerable<T> values)
    {
        _values = values;
    }

    public T Val() => _values.ElementAt(_index);

    /// <summary>
    /// 
    /// </summary>
    /// <returns>If return true then the next must call to next</returns>
    public bool Next()
    {
        _index += 1;

        if (_index >= _values.Count())
        {
            _index = 0;
            return true;
        }

        return false;
    }
}