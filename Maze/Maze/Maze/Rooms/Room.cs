using System.Numerics;
using System.Text;

namespace Maze.Rooms;

public class Room : IMapSite
{
    protected int roomNumber;
    public int RoomNumber { get => roomNumber; set => roomNumber = value; }

    public IDictionary<Direction, IMapSite> sides;

    public Room(int number)
    {
        roomNumber = number;
        sides = new Dictionary<Direction, IMapSite>();
    }

    public void SetSide(Direction direction, IMapSite site) => sides[direction] = site;

    public IMapSite? GetSide(Direction direction) 
    {
        var success = sides.TryGetValue(direction, out var site);

        return success ? site : null;
    }

    public virtual void Enter(Player player)
    {
        player.CurrentRoom = this;
        Console.WriteLine($"You entered room {roomNumber}.");
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Player in Room number {roomNumber}");
        stringBuilder.AppendLine($"North - {sides[Direction.North].ToString()}");
        stringBuilder.AppendLine($"East  - {sides[Direction.East].ToString()}");
        stringBuilder.AppendLine($"South - {sides[Direction.South].ToString()}");
        stringBuilder.Append($"West  - {sides[Direction.West].ToString()}");

        return stringBuilder.ToString();
    }
}
