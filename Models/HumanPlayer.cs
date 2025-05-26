public class HumanPlayer
{
    public string Name { get; private set; }

    public HumanPlayer(string name)
    {
        Name = name;
    }
    /// <summary>
    /// This Function returns a string on the action taken based on the input which aids in testing rather than writing to the console.
    /// If the input is invalid or a shot has already been fired at the inputed coordinates it will return a related message
    /// If valid input it will check if the coordinates have hit a ship on the board and will mark the location as a hit/record the hit on the ship object
    /// If the input is a miss it records those coordinates as a miss
    /// </summary>
    /// <param name="computerPlayer"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public string FireAtComputer(ComputerPlayer computerPlayer, string input)
    {
        if (!GameUtilities.IsValidCoordinate(input, computerPlayer.Board.Width, computerPlayer.Board.Height))
        {
            return "Invalid Input please use the format B4";
        }
        var (x, y) = GameUtilities.ConvertToCoordinates(input);
        if (computerPlayer.Board.HitCoordinates.Contains((x, y)) || computerPlayer.Board.MissCoordinates.Contains((x, y)))
        {
            return "You have fired here before";
        }
        foreach (IShip ship in computerPlayer.Board.Ships)
        {
            if (ship.ShipCoordinates.Contains((x, y)))
            {
                ship.Hit();
                computerPlayer.Board.HitCoordinates.Add((x, y));
                string succsess = "You Hit my " + ship.Name;
                if (ship.IsSunk)
                {
                    succsess = "You Hit and Sunk my " + ship.Name;
                }
                return succsess;
            }
        }
        computerPlayer.Board.MissCoordinates.Add((x, y));
        return "You Missed!";
    }
}