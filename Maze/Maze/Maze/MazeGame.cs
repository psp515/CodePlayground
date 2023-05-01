

using Maze.Builders;
using Maze.Factories;
using Maze.Rooms;

namespace Maze;

public class MazeGame
{
    public Maze CreateMaze(MazeBuilder builder, IMazeFactory factory)
    {
        List<Room> rooms = new List<Room>
        {
            factory.CreateRoom(),
            factory.CreateRoom(),
            factory.CreateRoom()
        };

        builder.SetStartingRoom(rooms[0]);
        builder.SetEndingRoom(rooms[2]);

        foreach (Room room in rooms) 
            builder.AddRoom(room);

        foreach (Room room in rooms)
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                builder.AddWall(factory.CreateWall(), room, direction);

        builder.AddDoor(factory.CreateDoor(rooms[0], rooms[1]), Direction.East);
        builder.AddDoor(factory.CreateDoor(rooms[1], rooms[2]), Direction.East);

        return builder.BuildMaze();
    }
}
