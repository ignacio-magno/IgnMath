using FluentAssertions;

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
            new List<string>() { "a", "b", },
            new List<string>() { "d", },
        });

        var res = combi.GetCombinations().ToList();

        res.Should().HaveCount(2);
        res.Should().ContainEquivalentOf(new List<string>() { "a", "d" });
        res.Should().ContainEquivalentOf(new List<string>() { "b", "d" });
    }

    [Test]
    public void Test2()
    {
        var combi = new Combinations<string>(new List<IEnumerable<string>>()
        {
            new List<string>() { "a", "b", },
            new List<string>() { "d", "e", },
        });

        var res = combi.GetCombinations().ToList();

        res.Should().HaveCount(4);
        res.Should().ContainEquivalentOf(new List<string>() { "a", "d" });
        res.Should().ContainEquivalentOf(new List<string>() { "a", "e" });
        res.Should().ContainEquivalentOf(new List<string>() { "b", "d" });
        res.Should().ContainEquivalentOf(new List<string>() { "b", "e" });
    }
}