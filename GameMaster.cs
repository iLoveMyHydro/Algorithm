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
        #endregion

        #region List

        public List<int> Liste = new List<int>();

        #endregion

        Algorithms algo = new Algorithms();

        public GameMaster()
        {

        }

        internal void IsListSorted()
        {
            var menu = new Menu();

            var algorithms = new Algorithms();

            do
            {
                isListRandom();

                HowListSort();

                algorithms.BubbleSort();

                algorithms.MergeSort();

                algorithms.HeapSort();

                algorithms.QuickSort();

                algorithms.GetTime();

                menu.PrintTitel();
                menu.MenuRequest();
            }
            while (true);
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

                Console.WriteLine($"{(option == 1 ? decorator : "   ")}" + TextSmallToBig);
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}" + TextBigToSmall);
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}" + TextZickzack);

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

            if (option == 1) algo.Possibility = 1;
            if (option == 2) algo.Possibility = 2;
            if (option == 3) algo.Possibility = 3;
        }

        private void isListRandom()
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

                Console.WriteLine($"{(option == 1 ? decorator : "   ")}" + TextLetCreate);
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}" + TextCreateOnOwn);

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

        private void ListUserInput()
        {
            Console.WriteLine("User Input Small to Big");
            Console.ReadKey();
        }

        private void ListRandom()
        {
            Random rng = new Random();

            for (int i = 0; i <= 50; i++)
            {
                Liste.Add((int)rng.NextInt64(-1000, 1001));
            }
        }
    }
}
