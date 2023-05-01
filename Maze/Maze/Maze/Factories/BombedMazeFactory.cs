

using Maze.Doors;
using Maze.Rooms;
using Maze.Walls;

namespace Maze.Factories;

public class BombedMazeFactory : IMazeFactory
{
    private static BombedMazeFactory? instance;

    public static BombedMazeFactory GetInstance() 
    {
        if (instance == null) 
            instance = new BombedMazeFactory();
        
        return instance; 
    }

    private int roomCounter = 0;
    private int RoomCounter
    {
        get
        {
            roomCounter+=1;
            return roomCounter;
        }
    }

    public Door CreateDoor(Room r1, Room r2) => new Door(r1, r2);

    public Room CreateRoom() => new BombedRoom(RoomCounter);

    public Wall CreateWall() => new BombedWall();
}
