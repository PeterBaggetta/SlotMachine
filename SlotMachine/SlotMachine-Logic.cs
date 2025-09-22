using static SlotMachine.GlobalVariables;

namespace SlotMachine
{
    public static class Logic
    {
        /// <summary>
        /// Calculates the game cost once the player has chosen which mode to play on.
        /// Each mode is calculated based on the price of the ONE_LINE_COST.
        /// </summary>
        /// <param name="choice">The users input from the console for which mode they would like to play</param>
        /// <returns>The cost of the game mode the player has chosen</returns>
        public static int CalculateGameCost(string choice)
        {
            if (choice == CENTER_HORIZONTAL || choice == CENTER_VERTICAL)
            {
                return ONE_LINE_COST;
            }

            if (choice == ALL_HORIZONTAL || choice == ALL_VERTICAL)
            {
                return SLOT_MACHINE_SIZE * ONE_LINE_COST;
            }

            if (choice == TWO_DIAGONAL)
            {
                return 2 * ONE_LINE_COST;
            }

            if (choice == ALL_LINES)
            {
                return ((SLOT_MACHINE_SIZE * 2) + 2) * ONE_LINE_COST;
            }

            // INVALID CHOICE
            return -1;
        }

        /// <summary>
        /// Generates the slot machine, based on the SLOT_MACHINE_SIZE it generates a grid.
        /// Also it fills in the slot machine array with random numbers from SLOT_MACHINE_LOWER_LIMIT to SLOT_MACHINE_UPPER_LIMIT.
        /// </summary>
        /// <param name="rand">Random variable for choosing a number between a lower and upper bounds</param>
        /// <returns>Slot Machine filled with randome numbers from the lower limit to upper limit.</returns>
        public static int[,] GenerateSlotMachine(Random rand)
        {
            int[,] slotMachine = new int[SLOT_MACHINE_SIZE, SLOT_MACHINE_SIZE];
            for (int i = 0; i < SLOT_MACHINE_SIZE; i++)
            {
                for (int j = 0; j < SLOT_MACHINE_SIZE; j++)
                {
                    slotMachine[i, j] = rand.Next(SLOT_MACHINE_LOWER_LIMIT, SLOT_MACHINE_UPPER_LIMIT);
                }
            }
            return slotMachine;
        }

        /// <summary>
        /// Counts the number of wins in a single game the player has won
        /// </summary>
        /// <param name="choice">The users input from the console for which mode they would like to play</param>
        /// <param name="slotMachine">The 2D array which holds all of the values for the game.</param>
        /// <returns>The number of wins in a single slot machine game based on the users choice.</returns>
        public static int CountWins(string choice, int[,] slotMachine)
        {
            int numWins = 0;

            switch (choice)
            {
                case CENTER_HORIZONTAL:
                    if (CheckRowWin(slotMachine, SLOT_MACHINE_SIZE / 2))
                    {
                        numWins++;
                    }
                    break;

                case CENTER_VERTICAL:
                    if (CheckColWin(slotMachine, SLOT_MACHINE_SIZE / 2))
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
            return numWins;
        }

        /// <summary>
        /// Checks a row win from the slot machine 2D array.
        /// </summary>
        /// <param name="slotMachine">The 2D array which holds all of the values for the game.</param>
        /// <param name="row">Middle row value based on the size of the 2D array.</param>
        /// <returns>False - There is no win on a row, True - There is a win on a row</returns>
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

        /// <summary>
        /// Checks a column win from the slot machine 2D array.
        /// </summary>
        /// <param name="slotMachine">The 2D array which holds all of the values for the game.</param>
        /// <param name="col">Middle column value based on the size of the 2D array.</param>
        /// <returns>False - There is no win on a column, True - There is a win on a column</returns>
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

        /// <summary>
        /// Checks the diagonal from top left to bottom right for a win
        /// </summary>
        /// <param name="slotMachine">The 2D array which holds all of the values for the game.</param>
        /// <returns>False - There is no win on the diagonal, True - There is a win on the diagonal</returns>
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

        /// <summary>
        /// Checks the diagonal from top right to bottom left for a win
        /// </summary>
        /// <param name="slotMachine">The 2D array which holds all of the values for the game.</param>
        /// <returns>False - There is no win on the diagonal, True - There is a win on the diagonal</returns>
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
