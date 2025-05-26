using Xunit;

public class HumanPlayerTests
{
    [Fact]
    public void FireAtComputer_HitMessage()
    {
        HumanPlayer humanPlayer = new HumanPlayer("Test User");
        ComputerPlayer computerPlayer = TestSetup.CreateMockComputerPlayerSmallShip();
        string result = humanPlayer.FireAtComputer(computerPlayer, "A0");

        Assert.Contains("You Hit my", result);
    }
    [Fact]
    public void FireAtComputer_MissMessage()
    {
        HumanPlayer humanPlayer = new HumanPlayer("Test User");
        ComputerPlayer computerPlayer = TestSetup.CreateMockComputerPlayerSmallShip();
        string result = humanPlayer.FireAtComputer(computerPlayer, "B0");

        Assert.Contains("Miss", result);
    }
    [Fact]
    public void FireAtComputer_InputErrMessage_OutOfRange()
    {
        HumanPlayer humanPlayer = new HumanPlayer("Test User");
        ComputerPlayer computerPlayer = TestSetup.CreateMockComputerPlayerSmallShip();
        string result = humanPlayer.FireAtComputer(computerPlayer, "Z0");

        Assert.Contains("Invalid Input", result);
    }
    [Fact]
    public void FireAtComputer_InputErrMessage_TooLong()
    {
        HumanPlayer humanPlayer = new HumanPlayer("Test User");
        ComputerPlayer computerPlayer = TestSetup.CreateMockComputerPlayerSmallShip();
        string result = humanPlayer.FireAtComputer(computerPlayer, "A99");

        Assert.Contains("Invalid Input", result);
    }
    [Fact]
    public void FireAtComputer_FiredHereAlready()
    {
        HumanPlayer humanPlayer = new HumanPlayer("Test User");
        ComputerPlayer computerPlayer = TestSetup.CreateMockComputerPlayerSmallShip();
        string result = humanPlayer.FireAtComputer(computerPlayer,"A0");
        result = humanPlayer.FireAtComputer(computerPlayer,"A0"); // fire same location as before
        Assert.Contains("You have fired here before", result);
    }
}