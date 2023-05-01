

using Maze.Utils;

namespace Maze.Rooms;

public class EnhantedRoom : Room
{
    public EnhantedRoom(int number) : base(number)
    {
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        player.EnhantPlayer("StartingRoom");
    }

}
