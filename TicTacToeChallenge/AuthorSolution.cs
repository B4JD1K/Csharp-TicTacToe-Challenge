// See https://aka.ms/new-console-template for more information

// the playfield

//static char[,] playField

char[,] playField =
{
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
};

int player = 2;
int input = 0;
bool inputCorrect = true;

SetField();

do
{
    if (player == 2) player = 1;
    else if (player == 1) player = 2;

    switch (player)
    {
        case 1: // Player 1's ture
            switch (input)
            {
                case 1: playField[0, 0] = 'X'; break;
                case 2: playField[0, 1] = 'X'; break;
                case 3: playField[0, 2] = 'X'; break;

                case 4: playField[1, 0] = 'X'; break;
                case 5: playField[1, 1] = 'X'; break;
                case 6: playField[1, 2] = 'X'; break;

                case 7: playField[2, 0] = 'X'; break;
                case 8: playField[2, 1] = 'X'; break;
                case 9: playField[2, 2] = 'X'; break;
            }
            break;

        case 2: // Player 2's ture
            switch (input)
            {
                case 1: playField[0, 0] = 'O'; break;
                case 2: playField[0, 1] = 'O'; break;
                case 3: playField[0, 2] = 'O'; break;

                case 4: playField[1, 0] = 'O'; break;
                case 5: playField[1, 1] = 'O'; break;
                case 6: playField[1, 2] = 'O'; break;

                case 7: playField[2, 0] = 'O'; break;
                case 8: playField[2, 1] = 'O'; break;
                case 9: playField[2, 2] = 'O'; break;
            }
            break;
    }
    
    
    
} while (true);


return;

// public static void SetField()
void SetField()
{
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
    Console.WriteLine("     |     |     ");
}