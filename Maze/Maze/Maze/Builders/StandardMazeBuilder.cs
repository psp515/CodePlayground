

using Maze.Doors;
using Maze.Rooms;
using Maze.Utils;
using Maze.Walls;

namespace Maze.Builders;

public class StandardMazeBuilder : MazeBuilder
{
    public override void AddDoor(Door door, Direction direction)
    {
        IMapSite site = door.From.GetSide(direction);
        if (site != null)
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot place door on door");


        site = door.To.GetSide(direction);
        if (site != null)
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot place door on door");

        door.From.SetSide(direction, door);
        door.To.SetSide(direction.Opposite(), door);
    }

    public override void AddRoom(Room room) => maze.Rooms.Add(room);

    public override void AddWall(Wall wall, Room room, Direction direction)
    {
        IMapSite site = room.GetSide(direction);

        if (site != null) 
            if (site.GetType() == typeof(Door))
                throw new Exception("Cannot change door for wall");
        
        room.SetSide(direction, wall);
    }
}
