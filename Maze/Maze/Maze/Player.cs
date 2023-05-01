
using Maze.Rooms;

namespace Maze;

public class Player
{
    public static int MaxHealth = 100;
    public static int MinHealth = 0;

    private Room? currentRoom;
    public Room? CurrentRoom { get => currentRoom; set => currentRoom = value; }

    public int health;

    private Maze maze;

    public Player(Maze maze)
    {
        currentRoom = maze.StartingRoom;
        health = MaxHealth;
        this.maze = maze;
    }

    public void ChangeHelath(int health)
    {
        this.health += health;
        this.health = Math.Max(Math.Min(MaxHealth, this.health), MinHealth);
    }

    public bool InGame() => currentRoom != maze.EndingRoom && health > MinHealth;

    public void MoveWest() => currentRoom?.GetSide(Direction.West)?.Enter(this);
    public void MoveEast() => currentRoom?.GetSide(Direction.East)?.Enter(this);
    public void MoveNorth() => currentRoom?.GetSide(Direction.North)?.Enter(this);
    public void MoveSouth() => currentRoom?.GetSide(Direction.South)?.Enter(this);

    public override string ToString()
    {
        return currentRoom?.ToString();
    }

}
