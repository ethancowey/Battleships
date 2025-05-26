using Moq;

public static class TestSetup
{
    public static ComputerPlayer CreateMockComputerPlayerSmallShip()
    {
        Board board = new Board(10, 10);
        IShip ship = new Destroyer();
        
        board.AddShip(ship);

        ship.ShipCoordinates.Clear();
        ship.ShipCoordinates.Add((0, 0)); //force coordinates for test

        return new ComputerPlayer(board);
    }
}