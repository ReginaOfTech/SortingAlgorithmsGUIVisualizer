using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIPrototypeWinForm
{
    class QuickSort: Interface1
    {
        int[] arrayToSort;
        Graphics g;
        int maxVal;
        int brushWidth;
        int[] posArr;
        private bool isSorted = false;

        public void Sort(int[] arr, Graphics g_, int maxVal_, int brushWidth_, int[] posArr_)
        {
            arrayToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            //picking the mid point to be our pivot point.
            //since this is a random array, the mid point has a chance of being a mid range number.
            while(!isSorted)
            {
                arrayToSort = Quick_Sort(arrayToSort, 0, arrayToSort.Length - 1);
                isSorted = IsSorted();
            }
            

            Console.WriteLine("Done");
            for(int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine(arrayToSort[i].ToString());
            }
        }

        public static int[] Quick_Sort(int[] array, int left, int right)
        {
            //check to make sure that left is definitively less than right
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(array, pivot + 1, right);
                }
            }
            return array;
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private bool IsSorted()
        {
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                if (arrayToSort[i] > arrayToSort[i + 1])
                {
                    return false;
                }
            }
            Console.WriteLine("Sorted");
            return true;
        }
    }
}
