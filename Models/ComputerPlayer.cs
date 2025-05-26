public class ComputerPlayer : IPlayer
{
    public string Name { get; } = "The Computer";
    public IBoard Board { get; private set; }
    public ComputerPlayer(IBoard board)
    {
        Board = board;
    }
}