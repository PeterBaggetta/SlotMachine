using static SlotMachine.GlobalVariables;

namespace SlotMachine
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Random rand = new Random();

            UI.DisplayWelcomeMessage();

            // --- Ask for the players starting balance --- //
            int playerMoney = UI.AskForStartingBalance();


            while (playerMoney > 0)
            {
                Console.Clear();

                UI.DisplayPlayerBalance(playerMoney);
                UI.DisplayGameMenu();

                string userGameChoice = UI.ReadChoice();

                // --- Player quits game --- //
                if (userGameChoice == QUIT)
                {
                    UI.ExitGame();
                    UI.DisplayFinalBalance(playerMoney);
                    return;
                }

                int gameCost = Logic.CalculateGameCost(userGameChoice);

                // Invalid option chosen by the player (allow them to re-enter)
                if (gameCost == -1)
                {
                    UI.DisplayInvalidChoice();
                    Thread.Sleep(2000);
                    continue;
                }

                // Check if the player has enough money
                if (playerMoney < gameCost)
                {
                    UI.DisplayInsufficientFunds(gameCost - playerMoney);
                    Thread.Sleep(2000);
                    continue;
                }

                // Player has enough money, subtract game cost from their balance
                playerMoney -= gameCost;

                // Print & Generate Slot Machine Numbers
                int[,] slotMachine = Logic.GenerateSlotMachine(rand);
                UI.DisplaySlotMachine(slotMachine);


                int numWins = Logic.CountWins(userGameChoice, slotMachine);

                // --- Tell the player how many times they won --- //
                if (numWins > 0)
                {
                    UI.DisplayNumberOfWins(numWins);
                    playerMoney += numWins * 2;
                }
                else
                {
                    UI.DisplayNoWins();
                }


                // --- Ask player if they want to continue playing the game --- //
                if (!UI.AskToPlayGameAgain())
                {
                    UI.DisplayFinalBalance(playerMoney);
                    return;
                }

            }

            // --- Player does not have any money --- //
            UI.DisplayOutOfMoney();
        }
    }
}
