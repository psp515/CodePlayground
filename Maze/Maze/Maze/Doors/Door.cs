using Maze.Rooms;

namespace Maze.Doors;

public class Door : IMapSite
{
    protected bool isOpen;
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    private readonly Room from;
    private readonly Room to;

    public Room From => from;
    public Room To => to;

    public Door(Room from, Room to)
    {
        this.from = from;
        this.to = to;
    }


    public virtual void Enter(Player player)
    {
        if (player.CurrentRoom == from)
        {
            Console.WriteLine($"Mooving from {from.RoomNumber} to {to.RoomNumber}.");
            to.Enter(player);
        }
        else 
        {
            Console.WriteLine($"Mooving from {to.RoomNumber} to {from.RoomNumber}.");
            from.Enter(player);
        }
    }

    public override string ToString()
    {
        return $"Door from {from.RoomNumber} to {to.RoomNumber}.";
    }
}
