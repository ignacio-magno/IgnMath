namespace IgnMath.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var combi = new Combinations<string>(new List<IEnumerable<string>>()
        {
            new List<string>() { "a", "b", "c" },
            new List<string>() { "d", "e", "f" },
            new List<string>() { "g", "h", "i" },
        });

        var res = combi.GetCombinations();

        foreach (var enumerable in res) Console.WriteLine(string.Join(", ", enumerable));
    }
}