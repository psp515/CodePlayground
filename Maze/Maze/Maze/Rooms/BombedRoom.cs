
using Maze.Utils;

namespace Maze.Rooms;

public class BombedRoom : Room
{
    public BombedRoom(int number) : base(number)
    {
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        player.BombPlayer("StartingRoom");
    }
}
