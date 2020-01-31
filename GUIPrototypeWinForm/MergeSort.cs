using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUIPrototypeWinForm
{
    class MergeSort : Interface1
    {
        //Complexity: O(nlogn)
        //stable but requires another copy of the data (high memory usage)
        int[] arrayToSort;
        Graphics g;
        int maxVal;
        int brushWidth;
        int[] posArr;
        private bool isSorted = false;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush blueBrush = new SolidBrush(Color.DodgerBlue);
        Brush redBrush = new SolidBrush(Color.Red);

        public void Sort(int[] arr, Graphics g_, int maxVal_, int brushWidth_, int[] posArr_)
        {
            arrayToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            arrayToSort = mergeSort(arrayToSort, 0, arrayToSort.Length - 1);

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine("Sorted: " + arrayToSort[i]);
            }
            Console.WriteLine("Done");
        }

        public int[] mergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Same as (l+r)/2, but avoids overflow for 
                // large l and h 
                int midPoint = low + (high - low) / 2;

                // Sort first and second halves 
                mergeSort(arr, low, midPoint);
                mergeSort(arr, midPoint + 1, high);

                arr = merge(arr, low, midPoint, high);
            }
            return arr;
        }

        int[] merge(int[] arr, int low, int midPoint, int high)
        {
            int i, j, k;
            int sizeL = midPoint - low + 1;
            int sizeR = high - midPoint;

            /* create temp arrays */
            int[] L = new int[sizeL];
            int[] R = new int[sizeR];

            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < sizeL; i++)
            {
                L[i] = arr[low + i];
                //g.FillRectangle(blackBrush, posArr[low + i], 0, brushWidth, maxVal);
                //g.FillRectangle(whiteBrush, posArr[low + i], maxVal - arr[low + i], brushWidth, maxVal);
            }

            for (j = 0; j < sizeR; j++)
            {
                R[j] = arr[midPoint + 1 + j];
                //g.FillRectangle(blackBrush, posArr[midPoint + j], 0, brushWidth, maxVal);
                //g.FillRectangle(whiteBrush, posArr[midPoint + j], maxVal - arr[midPoint + j], brushWidth, maxVal);
            }


            /* Merge the temp arrays back into arr[low..high]*/
            i = 0; // Initial index of first subarray 
            j = 0; // Initial index of second subarray 
            k = low; // Initial index of merged subarray 
            while (i < sizeL && j < sizeR)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                    
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                Thread.Sleep(100);
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                k++;
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
            }

            /* Copy the remaining elements of L[], if there 
               are any */
            while (i < sizeL)
            {
                arr[k] = L[i];
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                i++;
                k++;
            }

                /* Copy the remaining elements of R[], if there 
                   are any */
             while (j < sizeR)
             {
                arr[k] = R[j];
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                j++;
                k++;
             }
            
            return arr;
        }
    }


        
}
