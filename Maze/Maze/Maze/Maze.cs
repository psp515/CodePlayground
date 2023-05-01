
using Maze.Rooms;

namespace Maze;

public class Maze
{
    private List<Room> rooms;
    private Room? startingRoom;
    private Room? endingRoom;
    public Room? EndingRoom { get => endingRoom; set => endingRoom = value; }
    public Room? StartingRoom { get => startingRoom; set => startingRoom = value; }
    public List<Room> Rooms { get => rooms; }
    public Maze()
    {
        rooms = new List<Room>();
        startingRoom = null;
        endingRoom = null;
    }
    public int getRoomCount() => rooms.Count;
}
