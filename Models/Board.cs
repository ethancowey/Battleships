public class Board : IBoard
{
    public int Height { get; private set; } = 0;
    public int Width { get; private set; } = 0;
    public List<IShip> Ships { get; private set; } = new List<IShip>();
    public List<(int X, int Y)> HitCoordinates { get; } = new List<(int X, int Y)>();
    public List<(int X, int Y)> MissCoordinates { get; } = new List<(int X, int Y)>();


    public Board(int height, int width)
    {
        Height = height;
        Width = width;
    }
    public bool AddShip(IShip newShip)
    {
        int startX;
        int startY;
        int randomOrientation = new Random().Next(0, 2);

        Random randomCoordinate = new Random();


        if (randomOrientation == 0) // Horizontal
        {
            startX = randomCoordinate.Next(0, Width - newShip.Size); // Ensures the ship fits
            startY = randomCoordinate.Next(0, Height);
        }
        else //vertical
        {
            startX = randomCoordinate.Next(0, Width);
            startY = randomCoordinate.Next(0, Height - newShip.Size);
        }
        newShip.ShipCoordinates.Add((startX, startY));
        for (int i = 1; i < newShip.Size; i++)
        {
            if (randomOrientation == 0) //Horizontal
            {
                newShip.ShipCoordinates.Add((startX + i, startY));
            }
            else
            {
                newShip.ShipCoordinates.Add((startX, startY + i));
            }
        }

        if (IsOccupied(newShip.ShipCoordinates, Ships))
        {
            return false;
        }
        else
        {
            Ships.Add(newShip);
            return true;
        }
    }

    public bool IsOccupied(List<(int X, int Y)> newShipCoords, List<IShip> existingShips)
    {
        foreach (var ship in existingShips)
        {
            if (ship.ShipCoordinates.Intersect(newShipCoords).Any())
            {
                return true; // Ship already here, position is occupied
            }
        }
        return false; // Position is free, this space can be used
    }

    public void ShowBoard()
    {
        Console.Write(" "); //Add space to fix allignment
        for (int i = 0; i < Width; i++)
        {
            Console.Write(" " + (char)('A' + i) + " "); // Will create labels A-Z for X axis
        }
        for (int y = 0; y < Height; y++)
        {
            Console.WriteLine("");
            Console.Write(y); //This is lables Y axis
            for (int x = 0; x < Width; x++)
            {
                if (HitCoordinates.Contains((x, y)))
                {
                    Console.Write("[H]"); // Mark square as hit
                }
                else if (MissCoordinates.Contains((x, y)))
                {
                    Console.Write("[M]"); // Mark square as miss
                }
                else
                {
                    Console.Write("[ ]");
                }
            }
        }
        Console.WriteLine("");
    }
    public bool IsGameOver()
    {
        foreach (IShip ship in Ships)
        {
            if (!ship.IsSunk)
            {
                return false;
            }
        }
        return true;
    }
}