using Maze.Doors;
using Maze.Rooms;
using Maze.Walls;

namespace Maze.Factories;

public interface IMazeFactory
{
    Room CreateRoom();
    Wall CreateWall();
    Door CreateDoor(Room r1, Room r2);
}
