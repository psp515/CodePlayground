

using Maze.Rooms;
using Maze.Utils;

namespace Maze.Doors;

public class EnchantedDoor : Door
{
    public EnchantedDoor(Room from, Room to) : base(from, to)
    {
    }

    public override void Enter(Player player)
    {
        player.EnhantPlayer("Door");
        base.Enter(player);
    }
}
