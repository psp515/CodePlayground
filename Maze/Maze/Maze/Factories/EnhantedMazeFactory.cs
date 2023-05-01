
using Maze.Doors;
using Maze.Rooms;
using Maze.Walls;

namespace Maze.Factories;

public class EnhantedMazeFactory : IMazeFactory
{
    private static EnhantedMazeFactory? instance;

    public static EnhantedMazeFactory GetInstance()
    {
        if (instance == null)
            instance = new EnhantedMazeFactory();

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

    public Door CreateDoor(Room r1, Room r2) => new EnchantedDoor(r1, r2);
    
    public Room CreateRoom() => new EnhantedRoom(RoomCounter);
    
    public Wall CreateWall() => new EnhantedWall();
}
