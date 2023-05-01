
using Maze;
using Maze.Builders;
using Maze.Factories;

Console.WriteLine("Hello, World!");

MazeGame game = new MazeGame();

var maze = game.CreateMaze(new StandardMazeBuilder(), EnhantedMazeFactory.GetInstance());

var player = new Player(maze);

Console.WriteLine("Game starting.\nA - move west\nS - move south\nW - move north\nD - move east");

int i = 0;

while (player.InGame())
{
    Console.WriteLine($"-------------- Round {++i} --------------");
    Console.WriteLine(player);

    var keyInfo = Console.ReadKey(true);

    Console.WriteLine($"-------------- Round Effects {i} --------------");

    if (keyInfo.Key == ConsoleKey.A)
        player.MoveWest();
    else if (keyInfo.Key == ConsoleKey.S)
        player.MoveSouth();
    else if (keyInfo.Key == ConsoleKey.W)
        player.MoveNorth();
    else if (keyInfo.Key == ConsoleKey.D)
        player.MoveEast();
    else
        Console.WriteLine("You pressed bad key.");
}

Console.WriteLine($"-------------- Game Finished --------------");
Console.WriteLine($"Player hp: {player.health}");
Console.WriteLine($"Rounds: {i}");