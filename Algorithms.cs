using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmus
{
    internal class Algorithms
    {
        GameMaster gameMaster = new GameMaster();

        #region Properties

        public int Possibility { get; set; } = 0;

        #endregion

        internal void BubbleSort()
        {
            bool finished = false;
            int j = gameMaster.Liste.Count;
            int saveNumber = 0;

            if (Possibility == 1)
            {
                do
                {
                    finished = false;
                    for(int i = 0; i < j - 1; i++)
                    if (gameMaster.Liste[i] > gameMaster.Liste[i + 1])
                    {
                        saveNumber = gameMaster.Liste[i];

                        gameMaster.Liste[i] = gameMaster.Liste[i + 1];

                        gameMaster.Liste[i + 1] = saveNumber;

                        finished = true;
                    }
                    j--;
                }
                while (finished);




                foreach (int wert in gameMaster.Liste)
                {
                    Console.WriteLine(wert);
                }
                Console.ReadKey();

            }
            else if (Possibility == 2)
            {
                while (!finished)
                {
                    j = 0;

                    finished = true;
                    for (int i = gameMaster.Liste.Count; i - 1 < j; i--)
                    {
                        if (gameMaster.Liste[i] > gameMaster.Liste[i + 1])
                        {
                            saveNumber = gameMaster.Liste[i];

                            gameMaster.Liste[i] = gameMaster.Liste[i + 1];

                            gameMaster.Liste[i + 1] = saveNumber;

                            finished = false;
                        }
                    }
                    j++;
                }
            }
            else
            {

            }
        }



        internal void HeapSort()
        {
            if (Possibility == 1)
            {

            }
            else if (Possibility == 2)
            {

            }
            else
            {

            }
        }

        internal void MergeSort()
        {
            if (Possibility == 1)
            {

            }
            else if (Possibility == 2)
            {

            }
            else
            {

            }
        }

        internal void QuickSort()
        {
            if (Possibility == 1)
            {

            }
            else if (Possibility == 2)
            {

            }
            else
            {

            }
        }

        internal void GetTime()
        {

        }
    }
}
