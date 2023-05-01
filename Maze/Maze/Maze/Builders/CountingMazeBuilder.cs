

using Maze.Doors;
using Maze.Rooms;
using Maze.Utils;
using Maze.Walls;

namespace Maze.Builders;

public class CountingMazeBuilder : MazeBuilder
{
    private int walls;
    public int Walls { get => walls; }

    private int doors;
    public int Doors { get => doors; }

    private int rooms;
    public int Rooms { get => rooms; }

    public CountingMazeBuilder()
    {
        
    }

    public override void AddDoor(Door door, Direction direction)
    {
        IMapSite site = door.From.GetSide(direction);
        if (site != null)
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot place door on door");
            else if (site.GetType() == typeof(Wall))
                walls--;


        site = door.To.GetSide(direction);
        if (site != null)
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot place door on door");
            else if (site.GetType() == typeof(Wall))
                walls--;


        doors += 1;
        door.From.SetSide(direction, door);
        door.To.SetSide(direction.Opposite(), door);
    }

    public override void AddRoom(Room room)
    {
        rooms += 1;
        maze.Rooms.Add(room);
    }

    public override void AddWall(Wall wall, Room room, Direction direction)
    {
        IMapSite site = room.GetSide(direction);

        if (site != null)
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot change door for wall");

        walls += 1;
        room.SetSide(direction, wall);
    }

    public Maze BuildMaze()
    {
        Maze build = maze;
        maze = new Maze();
        return build;
    }
}
