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
            const string THREE_HORIZONTAL = "3";
            const string THREE_VERTICAL = "4";
            const string TWO_DIAGONAL = "5";
            const string ALL_LINES = "6";

            // Game Costs
            const int ONE_DOLLAR = 1;
            const int TWO_DOLLAR = 2;
            const int THREE_DOLLAR = 3;
            const int EIGHT_DOLLAR = 8;

            // Slot Machine Limits
            const int SLOT_MACHINE_LOWER_LIMIT = 0;
            const int SLOT_MACHINE_UPPER_LIMIT = 3;

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

                Console.WriteLine($"\nChoose which lines you would like to play (${ONE_DOLLAR} per line):");
                Console.WriteLine($"\t{QUIT}. QUIT");
                Console.WriteLine($"\t{CENTER_HORIZONTAL}. Center horizontal line\t(cost ${ONE_DOLLAR})");
                Console.WriteLine($"\t{CENTER_VERTICAL}. Center vertical line\t\t(cost ${ONE_DOLLAR})");
                Console.WriteLine($"\t{THREE_HORIZONTAL}. All three horizontal lines\t(cost ${THREE_DOLLAR})");
                Console.WriteLine($"\t{THREE_VERTICAL}. All three vertical lines\t(cost ${THREE_DOLLAR})");
                Console.WriteLine($"\t{TWO_DIAGONAL}. Both diagonals\t\t(cost ${TWO_DOLLAR})");
                Console.WriteLine($"\t{ALL_LINES}. All Lines\t\t\t(cost ${EIGHT_DOLLAR})");

                Console.WriteLine("Choose an option: ");
                string userGameChoice = Console.ReadLine();
                switch (userGameChoice)
                {
                    case QUIT:
                        Console.WriteLine("Thank you for playing!");
                        return;

                    case CENTER_HORIZONTAL:
                        gameCost = ONE_DOLLAR;
                        break;

                    case CENTER_VERTICAL:
                        gameCost = ONE_DOLLAR;
                        break;

                    case THREE_HORIZONTAL:
                        gameCost = THREE_DOLLAR;
                        break;

                    case THREE_VERTICAL:
                        gameCost = THREE_DOLLAR;
                        break;

                    case TWO_DIAGONAL:
                        gameCost = TWO_DOLLAR;
                        break;

                    case ALL_LINES:
                        gameCost = EIGHT_DOLLAR;
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
                int[,] slotMachine = new int[3, 3];
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
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
                        if (CheckRowWin(slotMachine, 1))
                        {
                            numWins++;
                        }
                        break;

                    case CENTER_VERTICAL:
                        if (CheckColWin(slotMachine, 1))
                        {
                            numWins++;
                        }
                        break;

                    case THREE_HORIZONTAL:
                        for (int row = 0; row < 3; row++)
                        {
                            if (CheckRowWin(slotMachine, row))
                            {
                                numWins++;
                            }
                        }
                        break;

                    case THREE_VERTICAL:
                        for (int col = 0; col < 3; col++)
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
                        for (int row = 0; row < 3; row++)
                        {
                            if (CheckRowWin(slotMachine, row))
                            {
                                numWins++;
                            }
                        }
                        // Check Columns
                        for (int col = 0; col < 3; col++)
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
            return (slotMachine[row, 0] == slotMachine[row, 1] && slotMachine[row, 1] == slotMachine[row, 2]);
        }

        // Check Column Win
        static bool CheckColWin(int[,] slotMachine, int col)
        {
            return (slotMachine[0, col] == slotMachine[1, col] && slotMachine[1, col] == slotMachine[2, col]);
        }

        // Check Diagonal1 Win (top left to bottom right)
        static bool CheckDiagonalWin1(int[,] slotMachine)
        {
            return (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 2]);
        }

        // Check Diagonal2 Win (top right to bottom left)
        static bool CheckDiagonalWin2(int[,] slotMachine)
        {
            return (slotMachine[0, 2] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 0]);
        }
    }
}
