//Iniate Board and Players
Board board = new Board(10, 10);
HumanPlayer humanPlayer = new HumanPlayer("The Human");
ComputerPlayer computerPlayer = new ComputerPlayer(board);

board.AddShip(new Battleship());
board.AddShip(new Destroyer());
board.AddShip(new Destroyer());
//Iniate Game Fuction
GameEngine gameEngine = new GameEngine();

gameEngine.PlayGame(board, computerPlayer, humanPlayer);