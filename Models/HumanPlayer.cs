public class HumanPlayer
{
    public string Name { get; private set; }

    public HumanPlayer(string name)
    {
        Name = name;
    }
    public string FireAtComputer(ComputerPlayer computerPlayer, string input)
    {
        if (!GameUtilities.IsValidCoordinate(input, computerPlayer.Board.Width, computerPlayer.Board.Height))
        {
            return "Invalid Input please use the format B4";
        }
        var (x, y) = GameUtilities.ConvertToCoordinates(input);
        if (computerPlayer.Board.HitCoordinates.Contains((x,y)) || computerPlayer.Board.MissCoordinates.Contains((x,y)))
        {
            return "You have fired here before";
        }
        //computerPlayer.Board.Ships
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