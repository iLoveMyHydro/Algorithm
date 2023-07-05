using System.Text;

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

        //Spielerklärung wurde von ChatGPT erstellt.
        private const string TextExplainMechanics = "Willkommen beim Zahlen-Sortierer!\r\n" +
            "Dies ist ein interaktives Programm, das Ihnen ermöglicht,\r\neine Reihe von Zahlen" +
            " auf verschiedene Weisen zu sortieren.\r\nSie haben die Möglichkeit,\r\nentweder eine " +
            "zufällige Menge von Zahlen generieren zu lassen oder\r\nselbst eine Reihe von Zahlen " +
            "einzugeben." +
            "\r\n \r\n" +
            "Schritt 1: Auswahl der Sortiermethode" +
            "\r\nBeim Start des Programms werden sie gefragt,\r\nwelchen Algorithmus sie benutzen wollen." +
            "\r\nEs stehen Ihnen verschiedene Algorithmen zur Verfügung,\r\nwie beispielsweise \r\n \r\n" +
            "Bubblesort\r\n" +
            "Mergesort\r\noder" +
            " Quicksort." +
            "\r\n \r\nSchritt 2: Generieren oder Eingeben der Zahlen \r\n" +
            "Danach werden sie gefragt, ob sie eine erstellte Liste haben möchten,\r\n" +
            "oder ob sie selber eine Liste erstellen möchten.\r\nSie haben dabei die Auswahl " +
            "zwischen 5\r\n" +
            "10\r\n15\r\noder 20 Zahlen \r\n \r\nSchritt 3: Auswahl der Sortierreihenfolge\r\n\r\n" +
            "Sobald der Sortieralgorithmus ausgewählt wurde," +
            "\r\nkönnen Sie die gewünschte Sortierreihenfolge festlegen." +
            "\r\nSie haben die Option, die Zahlen in \r\naufsteigender" +
            "\r\nabsteigender \r\noder zickzackartiger Reihenfolge \r\nsortieren zu lassen. \r\n" +
            "Die zickzackartige Reihenfolge bedeutet,\r\ndass zuerst die größte Zahl,\r\n" +
            "dann die kleinste Zahl \r\ndann die zweitgrößte Zahl" +
            "\r\ndann die zweitkleinste Zahl und so weiter angezeigt werden." +
            "\r\n\r\nSchritt 4: Ergebnis anzeigen" +
            "\r\n\r\nNachdem Sie die Sortiermethode und die Sortierreihenfolge festgelegt haben," +
            " wird das Programm die sortierte Reihe von Zahlen entsprechend ausgeben.\r\n\r\n" +
            "Das Zahlen-Sortierer-Projekt bietet Ihnen eine interaktive und benutzerfreundliche Möglichkeit\r\n" +
            "verschiedene Sortieralgorithmen auf Ihre eigenen Zahlen anzuwenden." +
            "\r\nSie können verschiedene Algorithmen und Sortierreihenfolgen ausprobieren," +
            "um die Unterschiede und Effizienz der Sortiermethoden zu erkunden." +
            "\r\n\r\nViel Spaß beim Sortieren Ihrer Zahlen mit dem Zahlen-Sortierer!";

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

                Console.WriteLine($"{(option == 1 ? decorator : "   ")}" + TextNewListButton);
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}" + TextGameExplanationButton);
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}" + TextGameCreditsButton);
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}" + TextGameQuitButton);

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

            Console.WriteLine(TextExplainMechanics);

            Console.WriteLine("\r\n" + TextGoMainMenu);

            Console.ReadKey();

            PrintTitle();
            MenuRequest();
        }
    }
}
