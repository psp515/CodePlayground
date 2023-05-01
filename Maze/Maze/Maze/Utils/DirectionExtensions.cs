
namespace Maze.Utils;
public static class DirectionExtensions
{
    public static Direction Opposite(this Direction direction) =>
    direction switch
    {
        Direction.North => Direction.South,
        Direction.South => Direction.North,
        Direction.East => Direction.West,
        Direction.West => Direction.East,
        _ => throw new ArgumentException("Invalid direction value.", nameof(direction))
    };
}
