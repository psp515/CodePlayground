

namespace Maze.Utils;

public static class PlayerExtensions
{
    public static void EnhantPlayer(this Player player, string enhantingObject)
    {
        int random = new Random().Next(-10, 10);
        player.ChangeHelath(random);
        Console.WriteLine($"Magic {enhantingObject} enhanted Player for {random} hp. Left {player.health}.");
    }

    public static void BombPlayer(this Player player, string bombingObject)
    {
        int random = new Random().Next(-20, 0);
        player.ChangeHelath(random);
        Console.WriteLine($"{bombingObject} bombbed Player for {random} hp. Left {player.health}.");
    }
}
