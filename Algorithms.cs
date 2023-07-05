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

        #region BubbleSort
        internal void BubbleSort(ref List<int> Liste, int Possibility)
        {
            bool finished = false;
            int j = Liste.Count;
            int saveNumber = 0;
            //Smallest to Biggest
            if (Possibility == 1)
            {
                do
                {
                    finished = false;
                    for (int i = 0; i < j - 1; i++)
                        if (Liste[i] > Liste[i + 1])
                        {
                            saveNumber = Liste[i];

                            Liste[i] = Liste[i + 1];

                            Liste[i + 1] = saveNumber;

                            finished = true;
                        }
                    j--;
                }
                while (finished);
            }
            //Biggest to Smallest
            if (Possibility == 2)
            {
                do
                {
                    finished = false;
                    for (int i = 0; i < j - 1; i++)
                        if (Liste[i] < Liste[i + 1])
                        {
                            saveNumber = Liste[i];

                            Liste[i] = Liste[i + 1];

                            Liste[i + 1] = saveNumber;

                            finished = true;
                        }
                    j--;
                }
                while (finished);
            }
            if (Possibility == 3)
            {
                //Algorithmus wurde von ChatGPT entworfen da die erste Idee zu kompliziert wurde!

                Liste.Sort();
                Liste.Reverse();

                // Initialisiere die Variablen und erstelle die Ergebnisliste
                int largestIndex = 0;
                int smallestIndex = Liste.Count - 1;
                List<int> result = new List<int>(Liste.Count);

                bool straightIteration = true;

                while (largestIndex <= smallestIndex)
                {
                    if (straightIteration)
                    {
                        result.Add(Liste[largestIndex]);
                        largestIndex++;
                    }
                    else
                    {
                        result.Add(Liste[smallestIndex]);
                        smallestIndex--;
                    }

                    straightIteration = !straightIteration;
                }
                Liste = result;
            }
        }
        #endregion

        #region MergeSort

        internal void WhichMergeSort(List<int> Liste, int Possibility)
        {
            if (Possibility == 1)
            {
                MergeSortSB(Liste);
            }
            if (Possibility == 2)
            {
                MergeSortBS(Liste);
            }
        }


        private void MergeSortSB(List<int> Liste)
        {
            int length = Liste.Count;
            if (length <= 1) return;

            int middle = length / 2;
            List<int> left = new List<int>(middle);
            List<int> right = new List<int>(length - middle);

            int i = 0;
            int j = 0;

            for (; i < length; i++)
            {
                if (i < middle)
                {
                    left.Add(Liste[i]);
                    j++;
                }
                else
                {
                    right.Add(Liste[j]);
                    j++;
                }
            }
            MergeSortSB(left);
            MergeSortSB(right);
            MergeSB(left, right, Liste);

        }
        internal void MergeSB(List<int> left, List<int> right, List<int> Liste)
        {
            int leftSize = Liste.Count / 2;
            int rightSize = Liste.Count - leftSize;
            int i = 0;
            int l = 0;
            int r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (left[l] < right[r])
                {
                    Liste[i] = left[l];
                    i++;
                    l++;
                }
                else
                {
                    Liste[i] = right[r];
                    i++;
                    r++;
                }
            }
            while (l < leftSize)
            {
                Liste[i] = left[l];
                i++;
                l++;
            }
            while (r < rightSize)
            {
                Liste[i] = right[r];
                i++;
                r++;
            }
        }

        internal void MergeSortBS(List<int> Liste)
        {
            int length = Liste.Count;
            if (length <= 1) return;

            int middle = length / 2;
            List<int> left = new List<int>(middle);
            List<int> right = new List<int>(length - middle);

            int i = 0;
            int j = 0;

            for (; i < length; i++)
            {
                if (i < middle)
                {
                    left.Add(Liste[i]);
                    j++;
                }
                else
                {
                    right.Add(Liste[j]);
                    j++;
                }
            }
            MergeSortBS(left);
            MergeSortBS(right);
            MergeBS(left, right, Liste);
        }
        internal void MergeBS(List<int> left, List<int> right, List<int> Liste)
        {
            int leftSize = Liste.Count / 2;
            int rightSize = Liste.Count - leftSize;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (left[l] > right[r])
                {
                    Liste[i] = left[l];
                    i++;
                    l++;
                }
                else
                {
                    Liste[i] = right[r];
                    i++;
                    r++;
                }
            }
            while (l < leftSize)
            {
                Liste[i] = left[l];
                i++;
                l++;
            }
            while (r < rightSize)
            {
                Liste[i] = right[r];
                i++;
                r++;
            }
        }
        #endregion

        #region QuickSort
        internal void WhichQuickSort(ref List<int> Liste, int Possibility)
        {
            if (Possibility == 1)
            {
                Liste = QuickSortSB(Liste);
            }
            if (Possibility == 2)
            {
                Liste = QuickSortBS(Liste);
            }
        }

        internal List<int> QuickSortSB(List<int> Liste)
        {
            if (Liste.Count == 1) return Liste;

            List<int> smaller = new List<int>();

            List<int> bigger = new List<int>();

            int pivot = Liste[Liste.Count - 1];

            for (int i = 0; i < Liste.Count - 1; i++)
            {
                if (Liste[i] <= pivot)
                {
                    smaller.Add(Liste[i]);
                }
                else
                {
                    bigger.Add(Liste[i]);
                }
            }
            if (smaller.Count > 0) smaller = QuickSortSB(smaller);
            if (bigger.Count > 0) bigger = QuickSortSB(bigger);

            smaller.Add(pivot);

            foreach (int element in bigger)
            {
                smaller.Add(element);
            }

            return smaller;
        }

        internal List<int> QuickSortBS(List<int> Liste)
        {
            if (Liste.Count == 1) return Liste;

            List<int> smaller = new List<int>();

            List<int> bigger = new List<int>();

            int pivot = Liste[Liste.Count - 1];

            for (int i = 0; i < Liste.Count - 1; i++)
            {
                if (Liste[i] > pivot)
                {
                    smaller.Add(Liste[i]);
                }
                else
                {
                    bigger.Add(Liste[i]);
                }
            }
            if (smaller.Count > 0) smaller = QuickSortBS(smaller);
            if (bigger.Count > 0) bigger = QuickSortBS(bigger);

            smaller.Add(pivot);

            foreach (int element in bigger)
            {
                smaller.Add(element);
            }

            return smaller;
        }
        #endregion
    }
}
