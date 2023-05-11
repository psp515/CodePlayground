using System;
namespace DesignPatterns.Adapter;

public class SquarePeg
{
    private double width;
    public double Width { get => width; set => width = value; }

    public SquarePeg(double width)
    {
        this.width = width;
    }
}

