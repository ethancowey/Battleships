public interface IBoard
{
    int Width { get; }
    int Height { get; }
    List<IShip> Ships { get; }
    public List<(int X, int Y)> HitCoordinates { get; }
    public List<(int X, int Y)> MissCoordinates { get; }


    bool AddShip(IShip newShip);
    bool IsOccupied(List<(int X, int Y)> newShipCoords, List<IShip> existingShips);
    void ShowBoard();
    bool IsGameOver();
}