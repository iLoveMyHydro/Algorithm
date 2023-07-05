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
        /// <summary>
        /// Code wurde mit einem Struktogramm erstellt
        /// </summary>
        /// <param name="Liste"></param>
        /// <param name="Possibility"></param>
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
                        if (Liste[i] > Liste[i + nextToIndex])  //Checks if the number on the right is bigger/smaller
                        {                                       //If so -> Numbers will be swapped
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
                        if (Liste[i] < Liste[i + nextToIndex])  //Checks if the Number on the right is bigger/smaller
                        {                                       //If so Numbers will be swapped
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

                var smallestIndex = Liste.Count - nextToIndex;

                var straightIteration = true;

                #endregion

                #region List

                List<int> result = new List<int>(Liste.Count);

                #endregion

                Liste.Sort();
                Liste.Reverse();

                while (largestIndex <= smallestIndex) //Checks if the largestIndex is smaller or equal the smallest 
                {
                    if (straightIteration)                      //Checks if we are in a straightIteration 
                    {                                           //->If so number will be added to largest Index number
                        result.Add(Liste[largestIndex]);
                        largestIndex++;
                    }
                    else                                        //If we are not in a straight Iteration the number 
                    {                                           //will be added to the smallest Index
                        result.Add(Liste[smallestIndex]);
                        smallestIndex--;
                    }
                    straightIteration = !straightIteration;     //Changes from true to false etc...
                }
                Liste = result;                                 //If we sorted the whole List now we give the           
            }                                                   //originally List the numbers in correct order
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
        /// <summary>
        /// Sorts the List from Small to Big
        /// MergeSortSB + MergeSB wurde durch die Morgenvorlesungen sowie folgendes Youtubevideo erstellt:
        /// https://youtu.be/3j0SWDX4AtU
        /// MergeSortBS + MergeBS wurden dann auf Basis der SB Version erstellt und angepasst!
        /// </summary>
        /// <param name="Liste"></param>
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
                if (i < middle) //Seperates the list in two different Lists
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
            MergeSortSB(left);                       //Seperates the left List in two more lists
            MergeSortSB(right);                     //Seperates the right List in two more lists
            MergeSB(left, right, Liste);            //Sorts now the left and the right array togehter again
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

            while (l < leftSize && r < rightSize) //Checks the condition for merging back
            {
                if (left[l] < right[r]) //Checking which number is smaller/bigger and adding it back to originally list
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
            while (l < leftSize)    //If no number left to compare 
            {
                Liste[i] = left[l];
                i++;
                l++;
            }
            while (r < rightSize)   //If no number left to compare
            {
                Liste[i] = right[r];
                i++;
                r++;
            }
        }
        #endregion

        #region Big to Small
        /// <summary>
        /// Sorts the List from Big to Small
        /// Code wurde von Small to Big auf Big to Small angepasst!
        /// </summary>
        /// <param name="Liste"></param>
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
                if (i < middle) //Seperates in two different Lists
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
            MergeSortBS(left);  //Seperates again in two different Lists
            MergeSortBS(right); //Sperates again in two different Lists
            MergeBS(left, right, Liste);    //Merging all Lists together in one List
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

            while (l < leftSize && r < rightSize) //Checking conditions for merging
            {
                if (left[l] > right[r])     //Checks if the number is smaller/bigger and add then to List
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
            while (l < leftSize)    //If no number to compare
            {
                Liste[i] = left[l];
                i++;
                l++;
            }
            while (r < rightSize)   //If no number to compare
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
        /// <summary>
        /// QuicksortSB Code von der Morgenvorlesung Teil 3 
        /// </summary>
        /// <param name="Liste"></param>
        /// <returns></returns>
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

            int pivot = Liste[Liste.Count - oneLeft]; //Pivot = last number in index of list

            for (; i < Liste.Count - oneLeft; i++)
            {
                if (Liste[i] <= pivot)  //Checking if the number is bigger then the pivot
                {
                    smaller.Add(Liste[i]);  //if smaller then added to smaller List
                }
                else
                {
                    bigger.Add(Liste[i]);   //if bigger then added to bigger List
                }
            }
            if (smaller.Count > nothingLeft) smaller = QuickSortSB(smaller);    //Will go through complete List 
            if (bigger.Count > nothingLeft) bigger = QuickSortSB(bigger);       //Will go through complete List
                                                                                //Till both are in right order
            smaller.Add(pivot);                                                 //Then pivot gets added 

            foreach (int element in bigger)
            {
                smaller.Add(element);                                           //List will be merged back in right 
            }                                                                   //order

            return smaller;
        }
        #endregion

        #region Big to Small
        /// <summary>
        /// Code von Small to Big wurde auf Big to Small angepasst!
        /// </summary>
        /// <param name="Liste"></param>
        /// <returns></returns>
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

            int pivot = Liste[Liste.Count - oneLeft]; //Pivot = Last number in index of List

            for (; i < Liste.Count - oneLeft; i++)
            {
                if (Liste[i] > pivot)       //If Number is bigger then pivot will be added to List 
                {
                    smaller.Add(Liste[i]);      //if Number is bigger then pivot will be added to smaller List
                }
                else
                {
                    bigger.Add(Liste[i]);       //if Number is smaller then pivot will be added to bigger List
                }
            }
            if (smaller.Count > nothingLeft) smaller = QuickSortBS(smaller);    //Will go through list
            if (bigger.Count > nothingLeft) bigger = QuickSortBS(bigger);       //Will go through list
                                                                                //Till both are in correct order
            smaller.Add(pivot);                                                 //Then pivot will be added

            foreach (int element in bigger)
            {
                smaller.Add(element);                                           //List will be then merged in correct order
            }

            return smaller;
        }
        #endregion

        #endregion
    }
}
