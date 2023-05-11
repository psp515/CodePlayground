namespace DesignPatterns.Adapter;

public class RoundPeg
{
	protected double radius;
	public double Radius { get => radius; set => radius = value; }
	public RoundPeg()
	{
		this.radius = 0;
	}
	public RoundPeg(double radius)
	{
		this.radius = radius;
	}
}

