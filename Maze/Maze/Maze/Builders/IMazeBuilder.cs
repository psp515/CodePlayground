using Maze.Doors;
using Maze.Rooms;
using Maze.Walls;

namespace Maze.Builders;

public interface IMazeBuilder
{
    void AddRoom(Room room);
    void AddDoor(Door door, Direction direction);
    void AddWall(Wall wall, Room room, Direction direction);
    void SetStartingRoom(Room room);
    void SetEndingRoom(Room room);
    Maze BuildMaze();
}
