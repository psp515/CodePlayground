namespace Maze.Walls;

public class Wall : IMapSite
{
    public virtual void Enter(Player player) => Console.WriteLine("You bumped into wall.");

    public override string ToString()
    {
        return "Some wall.";
    }
}
