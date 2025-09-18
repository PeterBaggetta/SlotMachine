namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Game Modes
            const string QUIT = "0";
            const string CENTER_HORIZONTAL = "1";
            const string CENTER_VERTICAL = "2";
            const string ALL_HORIZONTAL = "3";
            const string ALL_VERTICAL = "4";
            const string TWO_DIAGONAL = "5";
            const string ALL_LINES = "6";

            // Slot Machine Limits
            const int SLOT_MACHINE_LOWER_LIMIT = 0;
            const int SLOT_MACHINE_UPPER_LIMIT = 2;

            // Slot Machine size (MUST BE AN ODD NUMBER)
            const int SLOT_MACHINE_SIZE = 5;

            // Game Costs
            const int ONE_LINE_COST = 1;
            const int TWO_LINE_COST = 2;
            const int ALL_HORIZONTAL_OR_VERTICAL_COST = SLOT_MACHINE_SIZE;
            const int ALL_LINES_COST = (SLOT_MACHINE_SIZE*2) + 2;


            Random rand = new Random();

            Console.WriteLine("Welcome to the Slot Machine!! Wager your money on a line! If you wager correctly, YOU WIN!");

            // --- Ask for the players starting balance --- //
            int playerMoney;
            while (true)
            {
                Console.Write("What is your starting balance: $");
                if (!int.TryParse(Console.ReadLine(), out playerMoney) || playerMoney <= 0)
                {
                    Console.WriteLine("\n**** Please enter a number that is greater than zero. ****\n");
                    continue;
                }
                break;
            }

            while (playerMoney > 0)
            {
                Console.Clear();

                Console.WriteLine($"Your balance: ${playerMoney}");
                int gameCost = 0;

                Console.WriteLine($"\nChoose which lines you would like to play (${ONE_LINE_COST} per line):");
                Console.WriteLine($"\t{QUIT}. QUIT");
                Console.WriteLine($"\t{CENTER_HORIZONTAL}. Center horizontal line\t(cost ${ONE_LINE_COST})");
                Console.WriteLine($"\t{CENTER_VERTICAL}. Center vertical line\t\t(cost ${ONE_LINE_COST})");
                Console.WriteLine($"\t{ALL_HORIZONTAL}. All horizontal lines\t\t(cost ${ALL_HORIZONTAL_OR_VERTICAL_COST})");
                Console.WriteLine($"\t{ALL_VERTICAL}. All vertical lines\t\t(cost ${ALL_HORIZONTAL_OR_VERTICAL_COST})");
                Console.WriteLine($"\t{TWO_DIAGONAL}. Both diagonals\t\t(cost ${TWO_LINE_COST})");
                Console.WriteLine($"\t{ALL_LINES}. All Lines\t\t\t(cost ${ALL_LINES_COST})");

                Console.WriteLine("Choose an option: ");
                string userGameChoice = Console.ReadLine();
                switch (userGameChoice)
                {
                    case QUIT:
                        Console.WriteLine("Thank you for playing!");
                        return;

                    case CENTER_HORIZONTAL:
                        gameCost = ONE_LINE_COST;
                        break;

                    case CENTER_VERTICAL:
                        gameCost = ONE_LINE_COST;
                        break;

                    case ALL_HORIZONTAL:
                        gameCost = ALL_HORIZONTAL_OR_VERTICAL_COST;
                        break;

                    case ALL_VERTICAL:
                        gameCost = ALL_HORIZONTAL_OR_VERTICAL_COST;
                        break;

                    case TWO_DIAGONAL:
                        gameCost = TWO_LINE_COST;
                        break;

                    case ALL_LINES:
                        gameCost = ALL_LINES_COST;
                        break;

                    default:
                        Console.WriteLine("\n**** Please enter a valid choice. ****\n");
                        continue;
                }


                // Check if the player has enough money
                if (playerMoney < gameCost)
                {
                    Console.WriteLine($"You do not have enough money to play. Additional ${gameCost - playerMoney} is needed.");
                    Thread.Sleep(2000);
                    continue;
                }

                // Player has enough money, subtract game cost from their balance
                playerMoney -= gameCost;

                // Print and Generate slot machine numbers
                int[,] slotMachine = new int[SLOT_MACHINE_SIZE, SLOT_MACHINE_SIZE];
                Console.WriteLine();
                for (int i = 0; i < SLOT_MACHINE_SIZE; i++)
                {
                    for (int j = 0; j < SLOT_MACHINE_SIZE; j++)
                    {
                        slotMachine[i, j] = rand.Next(SLOT_MACHINE_LOWER_LIMIT, SLOT_MACHINE_UPPER_LIMIT);
                        Console.Write($"{slotMachine[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                int numWins = 0;

                // Check for wins on the gamemode that the player chose
                switch (userGameChoice)
                {
                    case QUIT:
                        Console.WriteLine("Thank you for playing!");
                        return;

                    case CENTER_HORIZONTAL:
                        if (CheckRowWin(slotMachine, SLOT_MACHINE_SIZE/2))
                        {
                            numWins++;
                        }
                        break;

                    case CENTER_VERTICAL:
                        if (CheckColWin(slotMachine, SLOT_MACHINE_SIZE/2))
                        {
                            numWins++;
                        }
                        break;

                    case ALL_HORIZONTAL:
                        for (int row = 0; row < SLOT_MACHINE_SIZE; row++)
                        {
                            if (CheckRowWin(slotMachine, row))
                            {
                                numWins++;
                            }
                        }
                        break;

                    case ALL_VERTICAL:
                        for (int col = 0; col < SLOT_MACHINE_SIZE; col++)
                        {
                            if (CheckColWin(slotMachine, col))
                            {
                                numWins++;
                            }
                        }
                        break;

                    case TWO_DIAGONAL:
                        if (CheckDiagonalWin1(slotMachine))
                        {
                            numWins++;
                        }

                        if (CheckDiagonalWin2(slotMachine))
                        {
                            numWins++;
                        }
                        break;

                    case ALL_LINES:
                        // Check Rows
                        for (int row = 0; row < SLOT_MACHINE_SIZE; row++)
                        {
                            if (CheckRowWin(slotMachine, row))
                            {
                                numWins++;
                            }
                        }
                        // Check Columns
                        for (int col = 0; col < SLOT_MACHINE_SIZE; col++)
                        {
                            if (CheckColWin(slotMachine, col))
                            {
                                numWins++;
                            }
                        }
                        // Check Diagonal 1
                        if (CheckDiagonalWin1(slotMachine))
                        {
                            numWins++;
                        }
                        // Check Diagonal 2
                        if (CheckDiagonalWin2(slotMachine))
                        {
                            numWins++;
                        }
                        break;
                }

                // Tells player how many times they won
                if (numWins > 0)
                {
                    Console.WriteLine($"You won {numWins} time(s)!");
                    playerMoney += numWins * 2;
                }
                else
                {
                    Console.WriteLine("You did not win on any line.");
                }



                Console.WriteLine();
                Console.WriteLine("Want to spin again? (Y/N): ");
                ConsoleKeyInfo playAgainInput = Console.ReadKey();
                char playAgain = char.ToLower(playAgainInput.KeyChar);
                if (playAgain != 'y')
                {
                    Console.WriteLine($"Thank you for playing! Your final balance is: ${playerMoney}.");
                    return;
                }

            }

            // Player does not have any money
            Console.WriteLine("\n\nYou do not have any money left.");

        }

        // Check Row Win
        static bool CheckRowWin(int[,] slotMachine, int row)
        {
            int numCols = slotMachine.GetLength(1);
            int firstColNum = slotMachine[row, 0];

            for (int c = 1; c < numCols; c++)
            {
                if (slotMachine[row, c] != firstColNum)
                {
                    return false;
                }
            }
            return true;
        }

        // Check Column Win
        static bool CheckColWin(int[,] slotMachine, int col)
        {
            int numRows = slotMachine.GetLength(0);
            int firstRowNum = slotMachine[0, col];

            for (int r = 1; r < numRows; r++)
            {
                if (slotMachine[r, col] != firstRowNum)
                {
                    return false;
                }
            }
            return true;
        }

        // Check Diagonal1 Win (top left to bottom right)
        static bool CheckDiagonalWin1(int[,] slotMachine)
        {
            int numRows = slotMachine.GetLength(0);
            int firstNum = slotMachine[0, 0];

            for (int i = 1; i < numRows; i++)
            {
                if (slotMachine[i, i] != firstNum)
                {
                    return false;
                }
            }
            return true;
        }

        // Check Diagonal2 Win (top right to bottom left)
        static bool CheckDiagonalWin2(int[,] slotMachine)
        {
            int numRows = slotMachine.GetLength(0);
            int firstNum = slotMachine[0, numRows - 1];

            for (int i = 1; i < numRows; i++)
            {
                if (slotMachine[i, numRows - i - 1] != firstNum)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
