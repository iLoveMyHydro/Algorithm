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

        #region Fields

        DateTime time = DateTime.Now;

        #endregion

        #region BubbleSort
        internal void BubbleSort(List<int> Liste, int Possibility)
        {
            bool finished = false;
            int j = Liste.Count;
            int saveNumber = 0;

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
            //else
            //{
            //    do
            //    {
            //        Liste.Max();

            //        finished = false;
            //        for (int i = 0; i < j - 1; i++)
            //            if (Liste[i] < Liste[i + 1])
            //            {
            //                saveNumber = Liste[i];

            //                Liste[i] = Liste[i + 1];

            //                Liste[i + 1] = saveNumber;

            //                finished = true;
            //            }
            //        j--;
            //    }
            //    while (finished);
            //}
        }
        #endregion

        #region MergeSort

        internal void WhichMergeSort(List<int> Liste, int Possibility)
        {
            if (Possibility == 1)
            {
                MergeSortSB(Liste);
            }
            else if (Possibility == 2)
            {
                MergeSortBS(Liste);
            }
            else
            {
                MergeSortZ(Liste);
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
            int i = 0, l = 0, r = 0;

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

        internal void MergeSortZ(List<int> Liste)
        {

        }

        internal void MergeZ(List<int> left, List<int> right, List<int> Liste)
        {

        }
        #endregion

        #region QuickSort
        internal void WhichQuickSort(List<int> Liste, int Possibility)
        {
            if (Possibility == 1)
            {
                QuickSortSB(Liste);
            }
            else if (Possibility == 2)
            {
                QuickSortBS(Liste);
            }
            else
            {
                QuickSortZ(Liste);
            }
        }

        internal void QuickSortSB(List<int> Liste)
        {

        }
        internal void QuickSB(List<int> left, List<int> right)
        {

        }
        
        internal void QuickSortBS(List<int> Liste)
        {

        }
        internal void QuickBS(List<int> left, List<int> right)
        {

        }

        internal void QuickSortZ(List<int> Liste)
        {

        }
        internal void QuickZ(List<int> left, List<int> right)
        {

        }
        #endregion

        #region GetTime
        internal void GetTime()
        {
            time = DateTime.Now;
        }
        #endregion

        internal void ShowTime()
        {
            Console.WriteLine("BubbleSort:" + (DateTime.Now - time).TotalSeconds);
            Console.ReadKey();
        }
    }
}
