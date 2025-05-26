using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public static class GameUtilities
{
    public static (int, int) ConvertToCoordinates(string input)
    {
        char letter = input[0];
        int x = (int)letter - 'A';
        int y = input[1] - 48;
        return (x, y);
    }
    public static bool IsValidCoordinate(string input, int boardWidth, int boardHeight)
    {
        if (input.Length != 2)
        {
            Console.WriteLine("Input is of wrong length");
            return false;
        }
        if (!char.IsLetter(input[0]) || !int.TryParse(input.Substring(1), out int outNumber))
        {
            Console.WriteLine("Input is not a letter and a number");
            return false;
        }
        var (x, y) = ConvertToCoordinates(input);
        if (x > boardWidth || y > boardHeight)
        {
            Console.WriteLine(x + " " + y);
            Console.WriteLine("Input exceeds board height or width");
            return false;
        }
        return true;
    }
}