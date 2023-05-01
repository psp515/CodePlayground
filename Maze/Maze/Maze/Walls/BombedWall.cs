

using Maze.Utils;

namespace Maze.Walls;

public class BombedWall : Wall
{
    public override void Enter(Player player)
    {
        base.Enter(player);
        player.BombPlayer("Wall");
    }
}
