using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmus
{
    internal class GameMaster
    {
        #region Const

        private const string TextLetCreate = "Erstellen lassen\u001b[0m";

        private const string TextCreateOnOwn = "Selber erstellen\u001b[0m";

        private const string TextListRandom = "Mochtest du die Liste selber erstellen oder erstellen lassen?";

        private const string TextSmallToBig = "Von unten nach oben (Kleinste zur größten Zahl)\u001b[0m";

        private const string TextBigToSmall = "Von oben nach unten (Größte zur kleinsten Zahl\u001b[0m";

        private const string TextZickzack = "Zickzack\u001b[0m";

        private const string TextWhatIsList = "Wollen sie die Liste von unten nach oben, oben nach unten " +
            "oder im Zickzack sortiert haben?";

        private const string TextUnsortedList = "Dies ist die unsortierte erstellte Liste";

        private const string TextSortedList = "Dies ist die erstellte Liste, jetzt sortiert";

        private const string TextFiveNumber = "5 Zahlen\u001b[0m";

        private const string Text10Number = "10 Zahlen\u001b[0m";

        private const string Text15Number = "15 Zahlen\u001b[0m";

        private const string Text20Number = "20 Zahlen\u001b[0m";

        private const string TextHowManyNumber = "Wie viele Zahlen möchten sie sortieren lassen?";

        private const string TextNoLetter = "Du hast einen Buchstaben eingegeben!\r\n" +
            "Es ist aber eine Zahl gefordert!";

        private const string TextToSmallNumber = "Du hast eine zu kleine Zahl eingegeben!\r\nDie Zahl muss" +
           " mindestens" +
           " " +
           "größer als -1000 sein!";

        private const string TextToBigNumber = "Du hast eine zu große Zahl eingegeben!\r\nDie zahl" +
            " darf nicht größer als 1000 sein!";

        private const string TextWhatNumber = "Gebe nun die Zahlen ein die in die Liste soll,\r\n" +
            "damit diese dann sortiert werden. \r\nGebe die Zahl ein und drücke dann \u001b[32mEnter/Return\u001b[0m." +
            " Dann kannst du die nächste Zahl eingeben";
        #endregion

        #region List

        public List<int> Liste = new List<int>();

        public List<int> Liste2 = new List<int>();

        public List<int> Liste3 = new List<int>();

        #endregion

        #region Properties

        public int Possibility { get; set; } = 0;

        #endregion

        #region Fields

        private int showArray = 0;

        private int howManyNumbers = 0;

        #endregion

        public GameMaster()
        {

        }

        internal void IsListSorted()
        {
            var menu = new Menu();

            var algorithms = new Algorithms();

            do
            {
                HowListSort();

                howBigList();

                IsListRandom();

                ShowList(Liste);

                algorithms.GetTime();

                //algorithms.BubbleSort(Liste, Possibility);

                algorithms.WhichMergeSort(Liste, Possibility);

                algorithms.WhichQuickSort(Liste, Possibility);

                ShowList(Liste);

                algorithms.ShowTime();

                menu.PrintTitle();
                menu.MenuRequest();
            }
            while (true);
        }

        /// <summary>
        /// Code aus der Morgenvorlesung Algorithmen & Datenstrukturen Chapter 2 
        /// </summary>
        /// <param name="liste"></param>
        private void ShowList(List<int> liste)
        {
            Console.Clear();

            string display = "[";

            if (showArray == 0)
            {
                Console.WriteLine(TextUnsortedList);

                for (int i = 0; i < liste.Count; i++)
                {
                    display += Liste[i] + ",";
                }
                display = display.Substring(0, display.Length - 1);
                display += "]";

                Console.WriteLine(display);

                Console.ReadKey(true);
                showArray = 1;
            }
            else
            {
                Console.WriteLine(TextSortedList);

                for (int i = 0; i < liste.Count; i++)
                {
                    display += Liste[i] + ",";
                }
                display = display.Substring(0, display.Length - 1);
                display += "]";

                Console.WriteLine(display);

                Console.ReadKey(true);
                showArray = 0;
            }


        }

        private void HowListSort()
        {
            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine("\nBenutze ⬆️  und ⬇️  zum navigieren und drücke " +
                "\u001b[32mEnter/Return\u001b[0m zum auswählen:");
            Console.WriteLine("\n" + TextWhatIsList + "\n");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : "  ")}" + TextSmallToBig);
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}" + TextBigToSmall);
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}" + TextZickzack);

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == 1 ? 3 : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == 3 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == 1) Possibility = 1;
            if (option == 2) Possibility = 2;
            if (option == 3) Possibility = 3;
        }

        private void IsListRandom()
        {

            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine("\nBenutze ⬆️  und ⬇️  zum navigieren und drücke " +
                "\u001b[32mEnter/Return\u001b[0m zum auswählen:");

            Console.WriteLine("\n" + TextListRandom + "\n");

            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : "  ")}" + TextLetCreate);
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}" + TextCreateOnOwn);

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == 1 ? 2 : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == 2 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == 1) ListRandom();
            if (option == 2) ListUserInput();
        }

        private void howBigList()
        {
            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine("\nBenutze ⬆️  und ⬇️  zum navigieren und drücke " +
                "\u001b[32mEnter/Return\u001b[0m zum auswählen:");

            Console.WriteLine("\n" + TextHowManyNumber + "\n");

            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : "  ")}" + TextFiveNumber);
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}" + Text10Number);
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}" + Text15Number);
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}" + Text20Number);

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

            if (option == 1) howManyNumbers = 4;
            if (option == 2) howManyNumbers = 9;
            if (option == 3) howManyNumbers = 14;
            if (option == 4) howManyNumbers = 19;
        }

        private void ListUserInput()
        {
            Console.Clear();

            int result = -1;


            for (int i = 0; i <= howManyNumbers; i++)
            {
                Console.Clear();

                do
                {
                    Console.WriteLine(TextWhatNumber);
                    var canConvert = int.TryParse(Console.ReadLine(), out result);

                    if (!canConvert)
                    {
                        Console.Clear();
                        Console.WriteLine(TextNoLetter);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (result < -1000)
                    {
                        Console.Clear();
                        Console.WriteLine(TextToSmallNumber);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (result > 1000)
                    {
                        Console.Clear();
                        Console.WriteLine(TextToBigNumber);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Liste.Add(result);
                    }
                }
                while (result < -1000 || result > 1000);
            }
        }

        private void ListRandom()
        {
            Random rng = new Random();

            for (int i = 0; i <= howManyNumbers; i++)
            {
                Liste.Add((int)rng.NextInt64(-1000, 1001));
            }
        }
    }
}
