public class GameEngine
{
    public void PlayGame(Board board, ComputerPlayer computerPlayer, HumanPlayer humanPlayer)
    {
        board.ShowBoard();
        while (!board.IsGameOver()) // if game over is true the player has won
        {
            Console.WriteLine("Enter Coordinates to fire at the Computer:");
            string input = Console.ReadLine().ToUpper();
            string result = humanPlayer.FireAtComputer(computerPlayer, input);
            Console.WriteLine(result);
            board.ShowBoard();
        }
        Console.WriteLine("All ships Destroyed! You Win!");
    }
}