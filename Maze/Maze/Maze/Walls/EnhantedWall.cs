

using Maze.Utils;

namespace Maze.Walls;

public class EnhantedWall : Wall
{
    public override void Enter(Player player)
    {
        base.Enter(player);
        player.EnhantPlayer("Wall");
    }
}
