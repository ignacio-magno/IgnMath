namespace IgnMath;

public class Combinations<T> where T : class
{
    private readonly List<Mark<T>> _values;
    private IEnumerable<T>? _first;

    public Combinations(IEnumerable<IEnumerable<T>> values)
    {
        _values = values.Select(x => new Mark<T>(x)).ToList();
    }

    public IEnumerable<IEnumerable<T>> GetCombinations()
    {
        while (true)
        {
            var x = GenerateCombinations().ToList();
            if (_first == null) _first = x;
            else if (EqualsArrays(_first, x)) break;

            yield return x;
        }
    }

    private IEnumerable<T> GenerateCombinations()
    {
        foreach (var enumerable in _values) yield return enumerable.Val();

        _values.Reverse();
        PassNext(_values);
        _values.Reverse();
    }

    private bool EqualsArrays(IEnumerable<T>? enumerable, IEnumerable<T> enumerable1)
    {
        if (enumerable == null) return false;

        var x = enumerable.ToArray();
        var y = enumerable1.ToArray();

        if (x.Length != y.Length) return false;

        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i]) return false;
        }

        return true;
    }

    private void PassNext(List<Mark<T>> x)
    {
        foreach (var mark in x)
        {
            if (!mark.Next()) break;

            var others = x.Skip(1).ToList();
            PassNext(others);
            break;
        }
    }
}