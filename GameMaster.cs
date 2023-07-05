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
        #region No Method - Only fields, const, list, constructor or properties

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
            "damit diese dann sortiert werden. \r\nGebe die Zahl ein und drücke dann " +
            "\u001b[32mEnter/Return\u001b[0m." +
            " Dann kannst du die nächste Zahl eingeben";

        private const string TextWhichAlgorithm = "Welchen Algorithmus wollen sie verwenden?";

        private const string TextBubbleSort = "Bubblesort\u001b[0m";

        private const string TextMergeSort = "Mergesort\u001b[0m";

        private const string TextQuickSort = "Quicksort\u001b[0m";

        private const string TextPressEnter = "\nBenutze ⬆️  und ⬇️  zum navigieren und drücke " +
                    "\u001b[32mEnter/Return\u001b[0m zum auswählen:";

        private const string TextParagraph = "\n";
        #endregion

        #region List

        public List<int> Liste = new List<int>();

        #endregion

        #region Properties

        public int Possibility { get; set; } = -1;

        #endregion

        #region Fields

        private int showArray = 0;

        private int howManyNumbers = 0;

        #endregion

        #region Standard constructor

        public GameMaster()
        {

        }

        #endregion

        #endregion


        #region Game Loop
        /// <summary>
        /// Loop of the "Game" 
        /// Restart after one List is sorted
        /// Loop can be stopped with the last option in the main menu
        /// </summary>
        internal void IsListSorted()
        {
            var menu = new Menu();

            //Infinity loop -> Can be stopped in the MenuRequest-Method with option 4
            do
            {
                HowListSort();

                howBigList();

                IsListRandom();

                ShowList(Liste);

                WhichAlgorithm(ref Liste);

                ShowList(Liste);

                menu.PrintTitle();
                menu.MenuRequest();
            }
            while (true);
        }
        #endregion

        #region Which Algorithm
        /// <summary>
        /// User decides which Algorithm he wants to use
        /// Can decide between Bubblesort, Mergesort or Quicksort
        /// </summary>
        /// <param name="Liste"></param>
        private void WhichAlgorithm(ref List<int> Liste)
        {
            #region Fields

            var Zickzack = 3;

            var option = 1;

            var decorator = "✅ \u001b[32m";

            bool isSelected = false;

            var maxOption = 3;

            var lowestOption = 1;

            var optionBubbleSort = 1;

            var optionMergeSort = 2;

            var optionQuickSort = 3;

            #endregion

            var algorithms = new Algorithms();

            if (Possibility == Zickzack)
            {
                algorithms.BubbleSort(ref Liste, Possibility);
            }
            else
            {
                //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
                //Wurde aber zum Teil auf das bestehende Programm umgeändert!
                //Ist nur in dieser Methode!
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.CursorVisible = false;
                Console.ResetColor();
                Console.WriteLine(TextPressEnter);
                Console.WriteLine($"{TextParagraph}{TextWhichAlgorithm}{TextParagraph}");
                (int left, int top) = Console.GetCursorPosition();
                ConsoleKeyInfo key;

                //Menu where the User can choose betweeen the 3 Sorting Algorithms -> With pressing Enter method 
                //will be stopped
                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine($"{(option == optionBubbleSort ? decorator : "  ")} {TextBubbleSort}");
                    Console.WriteLine($"{(option == optionMergeSort ? decorator : "  ")} {TextMergeSort}");
                    Console.WriteLine($"{(option == optionQuickSort ? decorator : "  ")} {TextQuickSort}");

                    key = Console.ReadKey(false);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            option = option == lowestOption ? maxOption : option - lowestOption;
                            break;

                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            option = option == maxOption ? lowestOption : option + lowestOption;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }
                Console.ResetColor();

                if (option == optionBubbleSort) algorithms.BubbleSort(ref Liste, Possibility);
                if (option == optionMergeSort) algorithms.WhichMergeSort(Liste, Possibility);
                if (option == optionMergeSort) algorithms.WhichQuickSort(ref Liste, Possibility);
            }
        }

        #endregion

        #region Display List

        /// <summary>
        /// Code aus der Morgenvorlesung Algorithmen & Datenstrukturen Chapter 2 
        /// </summary>
        /// <param name="Liste"></param>
        private void ShowList(List<int> Liste)
        {
            #region Fields

            var display = "[";

            var i = 0;

            var unsortedArray = 0;

            var one = 1;

            #endregion

            Console.Clear();

            if (showArray == unsortedArray)
            {
                Console.WriteLine(TextUnsortedList);

                for (; i < Liste.Count; i++)
                {
                    display += this.Liste[i] + ",";
                }
                display = display.Substring(unsortedArray, display.Length - one);
                display += "]";

                Console.WriteLine(display);

                Console.ReadKey(true);
                showArray++;
            }
            else
            {
                Console.WriteLine(TextSortedList);

                for (i = 0; i < Liste.Count; i++)
                {
                    display += this.Liste[i] + ",";
                }
                display = display.Substring(unsortedArray, display.Length - one);
                display += "]";

                Console.WriteLine(display);

                Console.ReadKey(true);
                showArray = 0;
            }
        }
        #endregion

        #region How is the List is Sorted
        /// <summary>
        /// User decide hwo the List will be sorted
        /// Can decide between
        /// Small to Big (1) -> 1,2,3,4,5,6,7,8,9,10
        /// Big to Small (2) -> 10,9,8,7,6,5,4,3,2,1
        /// or Zickzack (3) -> 10,1,9,2,8,3,7,4,6,5
        /// </summary>
        private void HowListSort()
        {
            #region Fields

            var option = 1;

            var decorator = "✅ \u001b[32m";

            var maxOption = 3;

            var lowestOption = 1;

            var optionSmallToBig = 1;

            var optionBigToSmall = 2;

            var optionZickZack = 3;

            bool isSelected = false;

            #endregion

            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine(TextPressEnter);
            Console.WriteLine($"{TextParagraph}{TextWhatIsList}{TextParagraph}");
            (int left, int top) = Console.GetCursorPosition();
            ConsoleKeyInfo key;

            //Menu where the User can choose how the List will be Sorted
            //-> Can stop the method with pressing Enter on the option
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == optionSmallToBig ? decorator : "  ")}{TextSmallToBig}");
                Console.WriteLine($"{(option == optionBigToSmall ? decorator : "  ")}{TextBigToSmall}");
                Console.WriteLine($"{(option == optionZickZack ? decorator : "  ")}{TextZickzack}");

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == lowestOption ? maxOption : option - lowestOption;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == maxOption ? lowestOption : option + lowestOption;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == optionSmallToBig) Possibility = optionSmallToBig;
            if (option == optionBigToSmall) Possibility = optionBigToSmall;
            if (option == optionZickZack) Possibility = optionZickZack;
        }
        #endregion

        #region Is the List Random or self generated
        /// <summary>
        /// User decide if he wants to make a own List or if the List will be automatically generated
        /// option 1 -> automatically generated
        /// option 2 -> user generated 
        /// </summary>
        private void IsListRandom()
        {
            #region Fields
            var option = 1;

            var decorator = "✅ \u001b[32m";

            bool isSelected = false;

            var maxOption = 2;

            var lowestOption = 1;
            #endregion


            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine(TextPressEnter);
            Console.WriteLine($"{TextParagraph}{TextListRandom}{TextParagraph}");
            (int left, int top) = Console.GetCursorPosition();
            ConsoleKeyInfo key;

            //Menu where the User can choose if he wants a own generated List or a automatically generated
            //Can stop the method with pressing enter on the option he wants
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == lowestOption ? decorator : "  ")}{TextLetCreate}");
                Console.WriteLine($"{(option == maxOption ? decorator : "  ")}{TextCreateOnOwn}");

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == lowestOption ? maxOption : option - lowestOption;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == maxOption ? lowestOption : option + lowestOption;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == lowestOption) ListRandom();
            if (option == maxOption) ListUserInput();
        }
        #endregion

        #region How Big Should the List be
        /// <summary>
        /// User can decide how big the list will be
        /// User hav 4 different options
        /// 5 numbers
        /// 10 numbers
        /// 15 numbers
        /// 20 numbers
        /// </summary>
        private void howBigList()
        {
            #region Fields

            var option = 1;

            var decorator = "✅ \u001b[32m";

            var isSelected = false;

            var maxOption = 4;

            var lowestOption = 1;

            var option10Number = 2;

            var option15Number = 3;

            #endregion

            //Code von -> https://www.youtube.com/watch?v=YyD1MRJY0qI&list=PLPHO1wRRC5Ltj9KK_XucIXoKGdNdMyZ11&index=9 
            //Wurde aber zum Teil auf das bestehende Programm umgeändert!
            //Ist nur in dieser Methode!
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine(TextPressEnter);
            Console.WriteLine($"{TextParagraph}{TextHowManyNumber}{TextParagraph}");
            (int left, int top) = Console.GetCursorPosition();
            ConsoleKeyInfo key;

            //Menu where the User can choose between 4 different List sizes
            //->Can stop method with pressing enter on the option he wants
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == lowestOption ? decorator : "  ")}{TextFiveNumber}");
                Console.WriteLine($"{(option == option10Number ? decorator : "  ")}{Text10Number}");
                Console.WriteLine($"{(option == option15Number ? decorator : "  ")}{Text15Number}");
                Console.WriteLine($"{(option == maxOption ? decorator : "  ")}{Text20Number}");

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        option = option == lowestOption ? maxOption : option - lowestOption;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        option = option == maxOption ? lowestOption : option + lowestOption;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            Console.ResetColor();

            if (option == lowestOption) howManyNumbers = 4;
            if (option == option10Number) howManyNumbers = 9;
            if (option == option15Number) howManyNumbers = 14;
            if (option == maxOption) howManyNumbers = 19;
        }
        #endregion

        #region User Generate List
        /// <summary>
        /// User generates his own list with his own numbers
        /// Can go from -1000 to 1000 
        /// </summary>
        private void ListUserInput()
        {
            #region Fields

            var result = -1;

            var i = 0;

            var maxOption = 1000;

            var lowestOption = -1000;

            #endregion

            Console.Clear();

            //Will go so long the User wanted to have the list
            for (; i <= howManyNumbers; i++)
            {
                Console.Clear();

                do
                {
                    Console.WriteLine(TextWhatNumber);
                    var canConvert = int.TryParse(Console.ReadLine(), out result);

                    //if the User presses no number 
                    if (!canConvert)
                    {
                        Console.Clear();
                        Console.WriteLine(TextNoLetter);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    //if the User wants a number that is to small 
                    else if (result < lowestOption)
                    {
                        Console.Clear();
                        Console.WriteLine(TextToSmallNumber);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    //if the User wants a number that is to big
                    else if (result > maxOption)
                    {
                        Console.Clear();
                        Console.WriteLine(TextToBigNumber);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    //if everything is fine the input will be added to the list
                    else
                    {
                        Liste.Add(result);
                    }
                }
                while (result < lowestOption || result > maxOption);
            }
        }
        #endregion

        #region Random Generate List
        /// <summary>
        /// List will be automatically created
        /// Numbers can go from -1000 to 1000
        /// </summary>
        private void ListRandom()
        {
            #region Fields

            var i = 0;

            var maxOption = 1001;

            var lowestOption = -1000;

            #endregion

            Random rng = new Random();

            //Will add that many numbers to the list how many numbers the User wanted to
            for (; i <= howManyNumbers; i++)
            {
                Liste.Add((int)rng.NextInt64(lowestOption, maxOption));
            }
        }
        #endregion
    }
}
