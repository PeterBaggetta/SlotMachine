using static SlotMachine.GlobalVariables;

namespace SlotMachine
{
    public static class UI
    {
        /// <summary>
        /// Displays the welcome message to the game
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Slot Machine!! Wager your money on a line! If you wager correctly, YOU WIN!");
        }

        /// <summary>
        /// Asks the player what their starting money/balance is for the game
        /// </summary>
        /// <returns>Starting player money</returns>
        public static int AskForStartingBalance()
        {
            int playerMoney;
            while (true)
            {
                Console.Write("What is your starting balance: $");
                if (!int.TryParse(Console.ReadLine(), out playerMoney) || playerMoney <= 0)
                {
                    Console.WriteLine("\n**** Please enter a number that is greater than zero. ****\n");
                    continue;
                }
                return playerMoney;
            }
        }

        /// <summary>
        /// Displays the player balance in the Menu of the console
        /// </summary>
        /// <param name="playerMoney">Players money throughout the game</param>
        public static void DisplayPlayerBalance(int playerMoney)
        {
            Console.WriteLine($"Your balance: ${playerMoney}");
        }

        /// <summary>
        /// Displays the game menu which displays all of the options that the player has to choose from
        /// </summary>
        public static void DisplayGameMenu()
        {
            Console.WriteLine($"\nChoose which lines you would like to play (${ONE_LINE_COST} per line):");
            Console.WriteLine($"\t{QUIT}. QUIT");
            Console.WriteLine($"\t{CENTER_HORIZONTAL}. Center horizontal line\t(cost ${ONE_LINE_COST})");
            Console.WriteLine($"\t{CENTER_VERTICAL}. Center vertical line\t\t(cost ${ONE_LINE_COST})");
            Console.WriteLine($"\t{ALL_HORIZONTAL}. All horizontal lines\t\t(cost ${ONE_LINE_COST * SLOT_MACHINE_SIZE})");
            Console.WriteLine($"\t{ALL_VERTICAL}. All vertical lines\t\t(cost ${ONE_LINE_COST * SLOT_MACHINE_SIZE})");
            Console.WriteLine($"\t{TWO_DIAGONAL}. Both diagonals\t\t(cost ${ONE_LINE_COST * 2})");
            Console.WriteLine($"\t{ALL_LINES}. All Lines\t\t\t(cost ${((SLOT_MACHINE_SIZE * 2) + 2) * ONE_LINE_COST})");

            Console.WriteLine("Choose an option: ");
        }

        /// <summary>
        /// Waits for a user input from the console
        /// </summary>
        /// <returns>The user input from the console</returns>
        public static string ReadChoice()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        /// <summary>
        /// Displays the exit message for the game if the player decides to exit
        /// </summary>
        public static void ExitGame()
        {
            Console.WriteLine("Thank you for playing!");
        }

        /// <summary>
        /// Displays an error message on the console to the user that their input was invalid
        /// </summary>
        public static void DisplayInvalidChoice()
        {
            Console.WriteLine("\n**** Please enter a valid choice. ****\n");
        }

        /// <summary>
        /// Displays to the player that they do not have enough money for the game mode they have chosen
        /// </summary>
        /// <param name="money">Amount of money the player is short for their game choice</param>
        public static void DisplayInsufficientFunds(int money)
        {
            Console.WriteLine($"You do not have enough money to play. Additional ${money} is needed.");

        }

        /// <summary>
        /// Displays the slot machine in the console
        /// </summary>
        /// <param name="slotMachine">The 2D array which holds the slot machine and its values to display</param>
        public static void DisplaySlotMachine(int[,] slotMachine)
        {
            Console.WriteLine();
            int rows = slotMachine.GetLength(0);
            int cols = slotMachine.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write($"{slotMachine[r, c]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the number of wins that the user has gotten in a single game
        /// </summary>
        /// <param name="numWins">The number of wins from a single play</param>
        public static void DisplayNumberOfWins(int numWins)
        {
            Console.WriteLine($"You won {numWins} time(s)!");
        }

        /// <summary>
        /// Displays that the player did not win on the last play of the slot machine
        /// </summary>
        public static void DisplayNoWins()
        {
            Console.WriteLine("You did not win on any line.");
        }

        /// <summary>
        /// Asks the player if they would like to continue playing or if they would like to exit the game
        /// </summary>
        /// <returns>False - Player does not want to play, True - Player wants to keep playing the game</returns>
        public static bool AskToPlayGameAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Want to spin again? (Y/N): ");
            ConsoleKeyInfo playAgainInput = Console.ReadKey();
            char playAgain = char.ToLower(playAgainInput.KeyChar);
            if (playAgain != PLAY_AGAIN)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Displays the final balance once the players exits the game
        /// </summary>
        /// <param name="playerMoney">Players money throughout the game</param>
        public static void DisplayFinalBalance(int playerMoney)
        {
            Console.WriteLine("\n******************************");
            Console.WriteLine($"Thank you for playing! Your final balance is: ${playerMoney}.");
            Console.WriteLine("******************************");

        }

        /// <summary>
        /// Displays to the player that they do not have any more money to play the game
        /// </summary>
        public static void DisplayOutOfMoney()
        {
            Console.WriteLine("\n******************************");
            Console.WriteLine("You do not have any money left.");
            Console.WriteLine("******************************");
        }
    }
}
