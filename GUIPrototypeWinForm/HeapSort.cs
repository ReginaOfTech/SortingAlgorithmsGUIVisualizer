﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private bool isSorted = false;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush blueBrush = new SolidBrush(Color.DodgerBlue);
        Brush redBrush = new SolidBrush(Color.Red);
        int threadSleepTime = 100;

        public void Sort(int[] arr, Graphics g_, int maxVal_, int brushWidth_, int[] posArr_)
        {
            arrayToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            heapSort(arrayToSort);

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine("Sorted: " + arrayToSort[i]);
            }
            Console.WriteLine("Done");
        }

        public int[] heapSort(int[] arr)
        {
            int lastNode = arr.Length - 1;

            for(int i = lastNode / 2; i >= 0; i--)
            {
                Sort(arr, lastNode, i);
            }
            for(int i = lastNode; i >= 0; i--)
            {
                Swap(arr, 0, i);
                Sort(arr, i, 0);
            }
            
            return arr;
        }

        private int[] Sort(int[] arr, int lastNode, int index)
        {
            int biggest = index;// lastNode;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if(left < lastNode && arr[left] > arr[biggest])
            {
                biggest = left;
            }

            if(right < lastNode && arr[right] > arr[biggest])
            {
                biggest = right;
            }

            if(biggest != index)
            {
                Swap(arr, index, biggest);
                Sort(arr, lastNode, biggest);
            }

            return arr;
        }

        private int[] Swap(int[] arr, int a, int b)
        {
            Console.WriteLine("A: " + a + "B: " + b);
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            return arr;
        }
    }
}
