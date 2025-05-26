public interface IShip
{
    string Name { get; }
    int Size { get; }
    int HitsTaken { get; }
    bool IsSunk { get; }
    List<(int X, int Y)> ShipCoordinates { get; }
    void Hit(); 
    
}