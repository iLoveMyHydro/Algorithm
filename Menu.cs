using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmus
{
    internal class Menu
    {

        #region Constant

        private const string TextMainMenu = " _   _                   _                " +
            "        _   _\r\n| | | |      " +
            "  " +
        "         | |            " +
        "          (_) (_)\r\n| |_| | __ _ _   _ _ __ | |_ _ __ ___   ___ _ __  _  " +
            " _\r\n|  _  |/ _` | | | | '_ \\| " +
        "__| '_ ` _ \\ " +
        "/ _ \\ '_ \\| | | |\r\n| | | | (_| | |_| | |_) | |_| | | | | |  __/ | | |" +
            " |_| |\r\n\\_| |_/\\__,_|\\__,_| ." +
        "__/ \\__|_| |_| |_|\\___|_| |_|\\__,_|\r\n    " +
        "              | |\r\n                  |_|";

        private const string TextNewListButton = "Neue Liste sortieren\u001b[0m";

        private const string TextGameExplanationButton = "Spielerklärung\u001b[0m";

        private const string TextGameCreditsButton = "Credits\u001b[0m";

        private const string TextGameQuitButton = "Spiel Beenden\u001b[0m";

        private const string TextGoMainMenu = "Drücke eine beliebige Taste um " +
            "zum Hauptmenü zurückzukehren!";

        private const string TextDesigner = "Designer: Kay Friese";

        private const string TextDeveloper = "Entwickler: Kay Friese";

        private const string TextGraphicDesigner = "Grafiker: Kay Friese";

        private const string TextProgrammer = "TextProgrammer: Kay Friese";

        private const string TextExplainMechanics = "In diesem Spiel geht es darum, " +
            "zwei Monster gegeneinander " +
            "antreten" +
            " zu lassen. " +
            " \r\nZu Beginn wirst du gefragt, welche beiden Monster gegeneinander antreten sollen." +
            " \r\nEs können nicht " +
            "dieselben Monster gegeneinander antreten. " +
            "\r\nDu hast die Wahl zwischen:\r\n\r\nOrk\r\nTroll\r\nGoblin\r\n" +
            "\r\nDu kannst dich zu Beginn " +
            "des Spiels " +
            "für eines der drei Monster entscheiden.\r\nDanach gibst du dem ersten " +
            "Monster die gewünschten Attribute." +
            "\r\nEs können keine negativen Attribute angegeben werden, sowie nicht höher als 5000." +
            " \r\nZuerst wählst du die Lebenspunkte, " +
            "dann die Angriffspunkte, die Verteidigungspunkte sowie die Schnelligkeit." +
            "\r\nHast du das beim ersten " +
            "Monster ausgewählt, darfst du das zweite " +
            "Monster auswählen und dessen Attribute festlegen." +
            "\r\nDanach kämpfen die Monster gegeneinander." +
            "\r\nWelches Monster den ersten Schlag ausführt, hängt " +
            "von der Geschwindigkeit ab.\r\n\r\nHat eines" +
            " der beiden Monster keine Lebenspunkte mehr, wird eine " +
            "Nachricht ausgegeben,\r\nwer gewonnen hat und wie" +
            " lange der Kampf gedauert hat. \r\n \r\n";

        #endregion

        GameMaster gameMaster = new GameMaster();

        /// <summary>
        /// Prints the titel "Hauptmenü" 
        /// </summary>
        public void PrintTitle()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(TextMainMenu);
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Query for Main Menu -> 1,2,3 or 4
        /// </summary>
        public void MenuRequest()
        {
            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine("\nBenutze ⬆️  und ⬇️  zum navigieren und drücke " +
                "\u001b[32mEnter/Return\u001b[0m zum auswählen:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : "  ")}" + TextNewListButton);
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}" + TextGameExplanationButton);
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}" + TextGameCreditsButton);
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}" + TextGameQuitButton);

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == 1) gameMaster.IsListSorted();
            if (option == 2) GameExplanation();
            if (option == 3) Credits();
            if (option == 4) Environment.Exit(0);
        }

        /// <summary>
        /// Just the credits of the game lol
        /// </summary>
        public void Credits()
        {
            ConsoleKey query = ConsoleKey.NoName;                //Input for any action

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(TextDesigner);
            Console.WriteLine(TextDeveloper);
            Console.WriteLine(TextGraphicDesigner);
            Console.WriteLine(TextProgrammer);

            Console.WriteLine("\n");

            Console.WriteLine(TextGoMainMenu);

            query = Console.ReadKey().Key;
            PrintTitle();
            MenuRequest();
        }

        /// <summary>
        /// Explains the Mechanics and the game in general for the player 
        /// </summary>
        public void GameExplanation()
        {
            Console.Clear();

            Console.WriteLine("\n");

            Console.WriteLine(TextExplainMechanics);

            Console.WriteLine(TextGoMainMenu);

            Console.ReadKey();

            PrintTitle();
            MenuRequest();
        }
    }
}
