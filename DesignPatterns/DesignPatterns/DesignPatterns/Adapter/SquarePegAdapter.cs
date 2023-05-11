using System;
namespace DesignPatterns.Adapter;

public class SquarePegAdapter : RoundPeg
{
	private SquarePeg peg;

	public SquarePegAdapter(SquarePeg peg)
	{
		this.peg = peg;
		this.radius = peg.Width * Math.Sqrt(2) / 2;
    }
}

