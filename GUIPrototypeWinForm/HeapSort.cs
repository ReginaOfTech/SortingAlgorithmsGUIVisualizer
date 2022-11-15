using System;
using System.Drawing;
using System.Threading;

namespace GUIPrototypeWinForm
{
    class HeapSort:Interface1
    {
        //Complexity: O(nLogn)
        int[] arrayToSort;
        Graphics g;
        int maxVal;
        int brushWidth;
        int[] posArr;
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

            heapSort(arrayToSort);

            //Debugging purposes
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine("Sorted: " + arrayToSort[i]);
            }
            Console.WriteLine("Done");
        }

        public int[] heapSort(int[] arr)
        {
            int lastNode = arr.Length - 1;

            //Building the heap
            for(int i = lastNode / 2; i >= 0; i--)
            {
                Sort(arr, lastNode, i);
            }
            //Checking heap one by one
            for(int i = lastNode; i >= 0; i--)
            {
                //current root is moved to the end
                Swap(arr, 0, i);
                //Sort the reduced heap
                Sort(arr, i, 0);
            }
            
            return arr;
        }

        private int[] Sort(int[] arr, int lastNode, int index)
        {
            int biggest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            //Check to make sure the child larger than the root
            if (left < lastNode && arr[left] > arr[biggest])
            {
                biggest = left;
            }
            if (right < lastNode && arr[right] > arr[biggest])
            {
                biggest = right;
            }
            //Make sure that the biggest is not he root
            if (biggest != index)
            {               
                Swap(arr, index, biggest);
                //Recursively handle the affected sub-tree
                Sort(arr, lastNode, biggest);
            }

            return arr;
        }

        private int[] Swap(int[] arr, int a, int b)
        {
            g.FillRectangle(blackBrush, posArr[a], 0, brushWidth, maxVal);
            g.FillRectangle(blueBrush, posArr[a], maxVal - arr[a], brushWidth, maxVal);
            g.FillRectangle(blackBrush, posArr[b], 0, brushWidth, maxVal);
            g.FillRectangle(redBrush, posArr[b], maxVal - arr[b], brushWidth, maxVal);
            Thread.Sleep(threadSleepTime);
            Console.WriteLine("A: " + a + "B: " + b);
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            g.FillRectangle(blackBrush, posArr[a], 0, brushWidth, maxVal);
            g.FillRectangle(redBrush, posArr[a], maxVal - arr[a], brushWidth, maxVal);
            g.FillRectangle(blackBrush, posArr[b], 0, brushWidth, maxVal);
            g.FillRectangle(blueBrush, posArr[b], maxVal - arr[b], brushWidth, maxVal);
            Thread.Sleep(threadSleepTime);
            g.FillRectangle(blackBrush, posArr[a], 0, brushWidth, maxVal);
            g.FillRectangle(whiteBrush, posArr[a], maxVal - arr[a], brushWidth, maxVal);
            g.FillRectangle(blackBrush, posArr[b], 0, brushWidth, maxVal);
            g.FillRectangle(whiteBrush, posArr[b], maxVal - arr[b], brushWidth, maxVal);
            return arr;
        }
    }
}
