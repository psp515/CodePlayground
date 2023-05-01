using Maze.Doors;
using Maze.Rooms;
using Maze.Walls;

namespace Maze.Builders;

public abstract class MazeBuilder : IMazeBuilder
{
    protected Maze maze;

    public MazeBuilder()
    {
        maze = new Maze();
    }

    public abstract void AddDoor(Door door, Direction direction);
    public abstract void AddRoom(Room room);
    public abstract void AddWall(Wall wall, Room room, Direction direction);

    public Maze BuildMaze() 
    {
        if (maze.StartingRoom == null)
            throw new Exception("Lack of starting point in maze.");

        Maze build = maze;
        maze = new Maze();
        return build;
    }

    public void SetStartingRoom(Room room) => maze.StartingRoom = room;
    public void SetEndingRoom(Room room) => maze.EndingRoom = room;
}
