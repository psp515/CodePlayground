namespace DesignPatternsTests;

using DesignPatterns.Adapter;

public class AdapterTests
{
    [Fact]
    public void SquarePegTest1()
    {
        var squarePeg = new SquarePeg(1);
        var hole = new RoundHole(3);

        var adapter = new SquarePegAdapter(squarePeg);

        var roundPeg = new RoundPeg(adapter.Radius);

        Assert.True(hole.Fits(roundPeg));
    }

    [Fact]
    public void SquarePegTest2()
    {
        var squarePeg = new SquarePeg(10);
        var hole = new RoundHole(1);

        var adapter = new SquarePegAdapter(squarePeg);

        var roundPeg = new RoundPeg(adapter.Radius);

        Assert.False(hole.Fits(roundPeg));
    }

    [Fact]
    public void RoundPegTest1()
    {
        var roundPeg = new RoundPeg(2);
        var hole = new RoundHole(3);

        Assert.True(hole.Fits(roundPeg));
    }

    [Fact]
    public void RoundPegTest2()
    {
        var roundPeg = new RoundPeg(2);
        var hole = new RoundHole(1);

        Assert.False(hole.Fits(roundPeg));
    }
}
