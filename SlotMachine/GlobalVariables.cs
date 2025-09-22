using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class GlobalVariables
    {
        /// <summary>
        /// Game Modes Values
        /// </summary>
        public const string QUIT = "0";
        public const string CENTER_HORIZONTAL = "1";
        public const string CENTER_VERTICAL = "2";
        public const string ALL_HORIZONTAL = "3";
        public const string ALL_VERTICAL = "4";
        public const string TWO_DIAGONAL = "5";
        public const string ALL_LINES = "6";

        /// <summary>
        /// Slot Machine Upper and Lower limits for what can be used on the game
        /// </summary>
        public const int SLOT_MACHINE_LOWER_LIMIT = 0;
        public const int SLOT_MACHINE_UPPER_LIMIT = 2;

        /// <summary>
        /// Slot Machine size (MUST BE AN ODD NUMBER)
        /// </summary>
        public const int SLOT_MACHINE_SIZE = 3;

        /// <summary>
        /// Game Cost for one line (Each game mode cost is calculated based on this
        /// </summary>
        public const int ONE_LINE_COST = 1;

        /// <summary>
        /// Play Again Character
        /// </summary>
        public const char PLAY_AGAIN = 'y';
    }
}
