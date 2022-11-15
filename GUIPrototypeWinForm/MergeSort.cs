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
        int threadSleepTime = 300;

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
            /* create temp arrays */
            int[] L = new int[midPoint - low + 1];
            int[] R = new int[high - midPoint];

            //Copy arr over to new arrays
            Array.Copy(arr, low, L, 0, midPoint - low + 1);
            Array.Copy(arr, midPoint + 1, R, 0, high - midPoint);
            
            /* Merge the temp arrays back into arr[low..high]*/
            int i = 0; // Initial index of first subarray 
            int j = 0; // Initial index of second subarray 
            int k = low; // Initial index of merged subarray 
            while (i < L.Length && j < R.Length)
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
                
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(blueBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                k++;
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(redBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                for(int a = 0; a < arr.Length; a++)
                {
                    if(a != k && a != (k-1))
                    {
                        g.FillRectangle(blackBrush, posArr[a], 0, brushWidth, maxVal);
                        g.FillRectangle(whiteBrush, posArr[a], maxVal - arr[a], brushWidth, maxVal);
                    }
                }

                Thread.Sleep(threadSleepTime);
            }

            /* Copy the remaining elements of L[], if there 
               are any */
            while (i < L.Length)
            {
                arr[k] = L[i];
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                i++;
                k++;
                Thread.Sleep(threadSleepTime);
            }

                /* Copy the remaining elements of R[], if there 
                   are any */
             while (j < R.Length)
             {
                arr[k] = R[j];
                g.FillRectangle(blackBrush, posArr[k], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[k], maxVal - arr[k], brushWidth, maxVal);
                j++;
                k++;
                Thread.Sleep(threadSleepTime);
            }
            
             for(int pos = 0; pos < arr.Length; pos++)
            {
                g.FillRectangle(blackBrush, posArr[pos], 0, brushWidth, maxVal);
                g.FillRectangle(whiteBrush, posArr[pos], maxVal - arr[pos], brushWidth, maxVal);
            }

            return arr;
        }
    }


        
}
