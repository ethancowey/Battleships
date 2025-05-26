public class Destroyer : IShip
{
    public string Name { get; } = "Destroyer";
    public int Size { get; } = 4;
    public bool IsSunk { get; private set; } = false;
    public int HitsTaken { get; private set; } = 0;
    public List<(int X, int Y)> ShipCoordinates { get; private set; } = new List<(int X, int Y)>();
    public void Hit()
    {
        HitsTaken++;
        if (HitsTaken >= Size)
            IsSunk = true;
    }
    public Destroyer()
    { }
}