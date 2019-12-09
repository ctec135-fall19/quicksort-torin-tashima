/*

Example:

Author: Torin Tashima
Date:   12/7/2019
CTEC 135: Microsoft Software Development with C#

Module 10, Program Quicksort

    Quicksort

1. Create a solution named "Sort"
2. Create a console app project named "QuickSort"
3. Create static methods as needed to program the algorithm provided in the
    slides for this module
4. To test your algorithm create a data structure with at least 10 elements
    filled with random int values. 
5. Print the initial values before calling your quick sort method
6. Print the final values after completion of your method. 
7. Print a count of the number of swaps required to sort the values.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        // Count class to keep track of number of swaps during sorting
        static class Count
        {
            public static int count;
        }

        #region quickSort
        // Method:      quickSort
        // Input:       An array of integers, a low index, and a high index
        // Behavior:    Sorts integer array in numerical order using the Divide
        //                  and Conquer algorithm and recursive calls
        // Output:      N/A
        public static void quickSort(int[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = partition(array, lo, hi);
                quickSort(array, lo, p);
                quickSort(array, p + 1, hi);
            }
        }
        #endregion

        #region partition
        // Method:      partition
        // Input:       An array of integers, a low index, and a high index
        // Behavior:    Performs the sorting of the array where every integer
        //                  greater than the pivot goes after and every integer
        //                  less than the pivot goes before
        // Output:      Index of pivot
        public static int partition(int[] array, int lo, int hi)
        {
            // Set pivot, low index, and high index
            int pivot = array[lo + (hi - lo) / 2];
            int i = lo - 1;
            int j = hi + 1;

            // Loop to perform sorting
            while (true)
            {
                // Find array element left of the pivot that is greater than
                //  the pivot
                do
                {
                    i += 1;
                } while (array[i] < pivot);

                // Find array element right of the pivot that is less than
                //  the pivot
                do
                {
                    j -= 1;
                } while (array[j] > pivot);
                // Check if array indices meet to stop loop

                if (i >= j)
                {
                    return j;
                }

                // Swap array elements and keep track of swaps
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                Count.count++;
            }
        }
        #endregion

        // Method:      Main
        // Input:       String of arguments technically
        // Behavior:    Call methods for quick sorting and display results
        // Output:      Writes unsorted array, sorted array, and swap count to
        //                  console
        static void Main(string[] args)
        {
            int[] ints = {3, 2, 0, 9, 7, 8, 5, 6, 4, 1};
            foreach (int n in ints)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            quickSort(ints, 0, 9);

            foreach (int n in ints)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Swaps required: " + Count.count);
        }
    }
}
