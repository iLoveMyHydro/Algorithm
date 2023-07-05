using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmus
{
    internal class Algorithms
    {
        #region Fields

        private int smallToBig = 1;

        private int bigToSmall = 2;

        private int zickZack = 3;

        #endregion

        #region BubbleSort
        internal void BubbleSort(ref List<int> Liste, int Possibility)
        {
            #region Fields

            var finished = false;

            var j = Liste.Count;

            var saveNumber = 0;

            var nextToIndex = 1;

            #endregion

            #region Small To Big

            //Smallest to Biggest
            if (Possibility == smallToBig)
            {
                do
                {
                    finished = false;
                    for (int i = 0; i < j - nextToIndex; i++)
                        if (Liste[i] > Liste[i + nextToIndex])
                        {
                            saveNumber = Liste[i];

                            Liste[i] = Liste[i + nextToIndex];

                            Liste[i + nextToIndex] = saveNumber;

                            finished = true;
                        }
                    j--;
                }
                while (finished);
            }

            #endregion

            #region Big To Small

            //Biggest to Smallest
            if (Possibility == bigToSmall)
            {
                do
                {
                    finished = false;
                    for (int i = 0; i < j - nextToIndex; i++)
                        if (Liste[i] < Liste[i + nextToIndex])
                        {
                            saveNumber = Liste[i];

                            Liste[i] = Liste[i + nextToIndex];

                            Liste[i + nextToIndex] = saveNumber;

                            finished = true;
                        }
                    j--;
                }
                while (finished);
            }

            #endregion

            #region ZickZack

            if (Possibility == zickZack)
            {
                //Algorithmus wurde von ChatGPT entworfen da die erste Idee zu kompliziert wurde!

                #region Fields

                var largestIndex = 0;

                int smallestIndex = Liste.Count - nextToIndex;

                bool straightIteration = true;

                #endregion

                List<int> result = new List<int>(Liste.Count);

                Liste.Sort();
                Liste.Reverse();

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
            #endregion
        }
        #endregion

        #region MergeSort

        #region Which MergeSort

        internal void WhichMergeSort(List<int> Liste, int Possibility)
        {
            if (Possibility == smallToBig)
            {
                MergeSortSB(Liste);
            }
            if (Possibility == bigToSmall)
            {
                MergeSortBS(Liste);
            }
        }

        #endregion

        #region Small to Big

        private void MergeSortSB(List<int> Liste)
        {
            #region Fields

            var noList = 1;

            var divideThrough2 = 2;

            var i = 0;

            var j = 0;

            var length = Liste.Count;

            var middle = length / divideThrough2;
            #endregion

            #region List

            List<int> left = new List<int>(middle);

            List<int> right = new List<int>(length - middle);

            #endregion

            if (length <= noList) return;

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
            #region Fields

            var divideThrough2 = 2;

            var leftSize = Liste.Count / divideThrough2;

            var rightSize = Liste.Count - leftSize;

            var i = 0;

            var l = 0;

            var r = 0;

            #endregion

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
        #endregion

        #region Big to Small

        internal void MergeSortBS(List<int> Liste)
        {
            #region Fields

            var length = Liste.Count;

            var noList = 1;

            var divideThrough2 = 2;

            var middle = length / divideThrough2;

            var i = 0;

            var j = 0;

            #endregion

            #region List

            List<int> left = new List<int>(middle);

            List<int> right = new List<int>(length - middle);

            #endregion

            if (length <= noList) return;

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
            #region Fields
            var divideThrough2 = 2;

            var leftSize = Liste.Count / divideThrough2;

            var rightSize = Liste.Count - leftSize;

            var i = 0;

            var l = 0;

            var r = 0;
            #endregion

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

        #endregion

        #region QuickSort

        #region Which QuickSort

        internal void WhichQuickSort(ref List<int> Liste, int Possibility)
        {
            if (Possibility == smallToBig)
            {
                Liste = QuickSortSB(Liste);
            }
            if (Possibility == bigToSmall)
            {
                Liste = QuickSortBS(Liste);
            }
        }

        #endregion

        #region Small to Big

        internal List<int> QuickSortSB(List<int> Liste)
        {
            #region Fields

            var nothingLeft = 0;

            var oneLeft = 1;

            var i = 0;

            #endregion

            #region List

            List<int> smaller = new List<int>();

            List<int> bigger = new List<int>();

            #endregion

            if (Liste.Count == oneLeft) return Liste;

            int pivot = Liste[Liste.Count - oneLeft];

            for (; i < Liste.Count - oneLeft; i++)
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
            if (smaller.Count > nothingLeft) smaller = QuickSortSB(smaller);
            if (bigger.Count > nothingLeft) bigger = QuickSortSB(bigger);

            smaller.Add(pivot);

            foreach (int element in bigger)
            {
                smaller.Add(element);
            }

            return smaller;
        }
        #endregion

        #region Big to Small

        internal List<int> QuickSortBS(List<int> Liste)
        {
            #region Fields

            var nothingLeft = 0;

            var oneLeft = 1;

            var i = 0;

            #endregion

            #region List

            List<int> smaller = new List<int>();

            List<int> bigger = new List<int>();

            #endregion

            if (Liste.Count == oneLeft) return Liste;

            int pivot = Liste[Liste.Count - oneLeft];

            for (; i < Liste.Count - oneLeft; i++)
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
            if (smaller.Count > nothingLeft) smaller = QuickSortBS(smaller);
            if (bigger.Count > nothingLeft) bigger = QuickSortBS(bigger);

            smaller.Add(pivot);

            foreach (int element in bigger)
            {
                smaller.Add(element);
            }

            return smaller;
        }
        #endregion

        #endregion
    }
}
