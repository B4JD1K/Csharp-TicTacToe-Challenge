// See https://aka.ms/new-console-template for more information

// game board preview

string[,] coordinates = new[,]
{
    { "1", "2", "3" },
    { "4", "5", "6" },
    { "7", "8", "9" }
};

// variables
int playerNumber = 1;
bool isGameStillActive = true;
int turnCount = 1;
int gamesCount = 1;
string playerMark = "X";

// game loop
do
{
    Console.WriteLine($"Game number {gamesCount}, turn number {turnCount}.");
    Console.WriteLine(PrintGameBoard(coordinates));
    Console.Write($"Player {playerNumber}, please choose your field: ");
    
    try
    {
        int input = Convert.ToInt32(Console.ReadLine());

        if (IsAvailable(input))
        {
            AssignPlayerMark();
            switch (input)
            {
                case 1:
                    coordinates[0, 0] = playerMark;
                    break;
                case 2:
                    coordinates[0, 1] = playerMark;
                    break;
                case 3:
                    coordinates[0, 2] = playerMark;
                    break;
                case 4:
                    coordinates[1, 0] = playerMark;
                    break;
                case 5:
                    coordinates[1, 1] = playerMark;
                    break;
                case 6:
                    coordinates[1, 2] = playerMark;
                    break;
                case 7:
                    coordinates[2, 0] = playerMark;
                    break;
                case 8:
                    coordinates[2, 1] = playerMark;
                    break;
                case 9:
                    coordinates[2, 2] = playerMark;
                    break;
                default:
                    Console.WriteLine("Unidentified input.");
                    break;
            }

            if (turnCount >= 5) CheckIsGameWon();

            if (playerNumber == 1 && isGameStillActive) playerNumber++;
            else if (playerNumber == 2 && isGameStillActive) playerNumber--;

            Console.Clear();

            if (turnCount % 9 == 0 && isGameStillActive)
            {
                ResetGameBoard();
                Console.WriteLine("Game board is full, but game is not finished yet. Resetting game board.");
                Console.WriteLine("PLayer {0} will start.", playerNumber);
            }

            if (isGameStillActive) turnCount++;
        }
        else Console.WriteLine("Incorrect pick. Try again.");
    }
    catch (FormatException)
    {
        Console.WriteLine("\tWrong input type, please provide an Integer from 1-9 range.\n");
    }
} while (isGameStillActive);

Console.WriteLine("Player {0} won the game after {1} turns and {2} games!", playerNumber, turnCount, gamesCount);
Console.WriteLine(PrintGameBoard(coordinates));

return; // end of Main()

/* Methods section */

string PrintGameBoard(string[,] coords)
{
    return $"""
               |   |   
             {coords[0, 0]} | {coords[0, 1]} | {coords[0, 2]} 
            ___|___|___
               |   |   
             {coords[1, 0]} | {coords[1, 1]} | {coords[1, 2]} 
            ___|___|___
               |   |   
             {coords[2, 0]} | {coords[2, 1]} | {coords[2, 2]} 
               |   |   
            """;
}

void CheckIsGameWon()
{
    // check horizontal
    if (coordinates[0, 0].Equals(coordinates[0, 1]) && coordinates[0, 1].Equals(coordinates[0, 2]) ||
        coordinates[1, 0].Equals(coordinates[1, 1]) && coordinates[1, 1].Equals(coordinates[1, 2]) ||
        coordinates[2, 0].Equals(coordinates[2, 1]) && coordinates[2, 1].Equals(coordinates[2, 2]))
        isGameStillActive = false;

    // check vertical
    else if (coordinates[0, 0].Equals(coordinates[1, 0]) && coordinates[1, 0].Equals(coordinates[2, 0]) ||
             coordinates[0, 1].Equals(coordinates[1, 1]) && coordinates[1, 1].Equals(coordinates[2, 1]) ||
             coordinates[0, 2].Equals(coordinates[1, 2]) && coordinates[1, 2].Equals(coordinates[2, 2]))
        isGameStillActive = false;

    // check diagonal
    else if (coordinates[0, 0].Equals(coordinates[1, 1]) && coordinates[1, 1].Equals(coordinates[2, 2]) ||
             coordinates[0, 2].Equals(coordinates[1, 1]) && coordinates[1, 1].Equals(coordinates[2, 0]))
        isGameStillActive = false;

    // the game is not finished
    else isGameStillActive = true;
}

void AssignPlayerMark()
{
    if (playerNumber == 1) playerMark = "X";
    else if (playerNumber == 2) playerMark = "O";
}

bool IsAvailable(int input)
{
    // Yes, I could just put this return to if statement, but this is more readable 
    return PrintGameBoard(coordinates).Contains(input.ToString());
}

void ResetGameBoard()
{
    coordinates[0, 0] = "1";
    coordinates[0, 1] = "2";
    coordinates[0, 2] = "3";
    coordinates[1, 0] = "4";
    coordinates[1, 1] = "5";
    coordinates[1, 2] = "6";
    coordinates[2, 0] = "7";
    coordinates[2, 1] = "8";
    coordinates[2, 2] = "9";
    gamesCount++;
}