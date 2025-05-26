# Battleships

| Aurthor    | Ethan Cowey |
| Time Spent | 5 hours     |

## Future Developments

### New Types of Ship
Add new ships by utilizing the ship Interface IShip such as a SpeedBoat which could have a size of 1 on the board. This ship could have special abilities like being able to move during the game.
This is acheivable due to the usage of interfaces making it compatiable with existing code through polymorphism such as the function AddShip(IShip) that the Board uses to add new ships.

### Two sided games
The program was designed with extending the functionality in mind. To make the game two sided we can add a Board to the Human Player class like we already have for the Computer Player.Then we can add logic to the Computer Player to fire at the Human Players Board (The two types of player use the same interface so we can add common function definitions but with different implementations defined in the class to them). The flow of the game can then be dealt with by the GameEngine class which can loop through giving each player a turn to fire until one players board has had all the ships on it sunk.

## How to run this project

Run 'Program.cs' to start the project which will iniate the board and call the GameEngine class to begin the game

## Unit Tests

Can be found in the folder UnitTest
Running the test file will require the package Xunit

The unit tests set up a mock version of the game with a boat in a prredefined location. Then various inputs are tested to see if it would miss, hit, already fired in that location or is an invalid location to be fired at.