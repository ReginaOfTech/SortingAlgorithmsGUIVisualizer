using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush pivotBrush = new SolidBrush(Color.DarkViolet);
        Brush indexBrush = new SolidBrush(Color.DarkRed);
        Brush pointerBrush = new SolidBrush(Color.DodgerBlue);

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
            
            //See the sorted array until the real time visual is done
            Console.WriteLine("Done");
            g.FillRectangle(blackBrush, 0, 0, arrayToSort.Length, maxVal);

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine(arrayToSort[i].ToString());
                g.FillRectangle(blackBrush, 0, 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, i, maxVal - arrayToSort[i], brushWidth, maxVal);
            }
        }

        public int[] Quick_Sort(int[] array, int start, int end)
        {
            //check to make sure that left is definitively less than right
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                //g.FillRectangle(blackBrush, array[pivot], 0, brushWidth, maxVal);
                //g.FillRectangle(purpleBrush, array[pivot], maxVal - array[pivot], brushWidth, maxVal);
                if (pivot > 1)
                {
                    Quick_Sort(array, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    Quick_Sort(array, pivot + 1, end);
                }
            }
            return array;
        }

        private int Partition(int[] arr, int start, int end)
        {
            int pivotIndex = start;
            int pivotValue = arr[end];

            for (int i = start; i < end; i++)
            {
                g.FillRectangle(blackBrush, 0, 0, brushWidth, maxVal);
                g.FillRectangle(pointerBrush, posArr[i], maxVal - arr[i], brushWidth, maxVal);
                if (arr[i] < pivotValue)
                {                    
                    Swap(arr, i, pivotIndex);
                    g.FillRectangle(blackBrush, posArr[i], 0, brushWidth, maxVal);
                    g.FillRectangle(whiteBrush, posArr[i], maxVal - arr[i], brushWidth, maxVal);
                    g.FillRectangle(blackBrush, posArr[pivotIndex], 0, brushWidth, maxVal);
                    g.FillRectangle(whiteBrush, posArr[pivotIndex], maxVal - arr[pivotIndex], brushWidth, maxVal);
                    pivotIndex++;
                    g.FillRectangle(blackBrush, posArr[pivotIndex], 0, brushWidth, maxVal);
                    g.FillRectangle(pivotBrush, posArr[pivotIndex], maxVal - arr[pivotIndex], brushWidth, maxVal);
                }
                Thread.Sleep(1);
                g.FillRectangle(blackBrush, posArr[i], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[i], maxVal - arr[i], brushWidth, maxVal);
            }

            Swap(arr, pivotIndex, end);
            g.FillRectangle(blackBrush, posArr[pivotIndex], 0, brushWidth, maxVal);
            g.FillRectangle(whiteBrush, posArr[pivotIndex], maxVal - arr[pivotIndex], brushWidth, maxVal);

            return pivotIndex;
            //while (true)
            //{

                //while (arr[left] < pivot)
                //{
                //    g.FillRectangle(blackBrush, arr[left], 0, brushWidth, maxVal);
                //    g.FillRectangle(whiteBrush, arr[left], maxVal - arr[left], brushWidth, maxVal);
                //    left++;
                //    g.FillRectangle(blackBrush, arr[left], 0, brushWidth, maxVal);
                //    g.FillRectangle(redBrush, arr[left], maxVal - arr[left], brushWidth, maxVal);
                //}

                //while (arr[right] > pivot)
                //{
                //    g.FillRectangle(blackBrush, arr[right], 0, brushWidth, maxVal);
                //    g.FillRectangle(whiteBrush, arr[right], maxVal - arr[right], brushWidth, maxVal);
                //    right--;
                //    g.FillRectangle(blackBrush, arr[right], 0, brushWidth, maxVal);
                //    g.FillRectangle(whiteBrush, arr[right], maxVal - arr[right], brushWidth, maxVal);
                //}

                //if (left < right)
                //{
                //    if (arr[left] == arr[right]) return right;

                //    int temp = arr[left];
                //    arr[left] = arr[right];
                //    arr[right] = temp;
                //}
                //else
                //{
                //    return right;
                //}
            //}
        }

        private int[] Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            return arr;
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
