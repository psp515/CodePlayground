using System;
namespace DesignPatterns.Adapter;

public class RoundHole
{
    private double radius;
    public double Radius { get => radius; set => radius = value; }
    public RoundHole(double radius)
    {
        this.radius = radius;
    }

    public bool Fits(RoundPeg peg) => peg.Radius < radius;
}

