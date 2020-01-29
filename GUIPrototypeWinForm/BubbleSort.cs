using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace GUIPrototypeWinForm
{
    class BubbleSort : Interface1
    {
        private bool isSorted = false;
        private int[] arrToSort;
        private Graphics g;
        private int maxVal;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush purpleBrush = new SolidBrush(Color.DarkViolet);
        int brushWidth;
        private int[] posArr;

        public void Sort(int[] arr, Graphics g_, int maxVal_, int brushWidth_, int[] posArr_)
        {
            //Setting all local variables to passed variables
            arrToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            //loop that performs bubble sort
            while(!isSorted)
            {
                for (int i =0; i < arrToSort.Length - 1; i++)
                {                   
                    if (arrToSort[i] > arrToSort[i+1])
                    {
                        Swap(i, i+1);
                    }
                    else
                    {
                        //resets the color so that as it iterates through purple
                        //columns are not let behind
                        g.FillRectangle(whiteBrush, posArr[i], maxVal - arrToSort[i], brushWidth, maxVal);
                    }
                    //Thread sleeps for .01 of a second
                    //Slows it down enough to watch but not bore
                    Thread.Sleep(1);
                    //check to see if the array is sorted
                    isSorted = IsSorted();                    
                }               
            }
        }

        private void Swap(int curIndex, int prevIndex)
        {
            //Actual swap
            int temp = arrToSort[curIndex];
            arrToSort[curIndex] = arrToSort[curIndex + 1];
            arrToSort[curIndex + 1] = temp;

            //resetting of colors as the array is iterated through
            g.FillRectangle(blackBrush, posArr[curIndex], 0, 1, maxVal);
            g.FillRectangle(blackBrush, posArr[prevIndex], 0, 1, maxVal);

            g.FillRectangle(whiteBrush, posArr[curIndex], maxVal - arrToSort[curIndex], brushWidth, maxVal);
            g.FillRectangle(purpleBrush, posArr[prevIndex], maxVal - arrToSort[prevIndex], brushWidth, maxVal);
            
            //prevents the two graphic lines below from going beyond the scope of the array.
            if(curIndex != 0)
            {
                g.FillRectangle(blackBrush, posArr[curIndex - 1], 0, 1, maxVal);
                g.FillRectangle(whiteBrush, posArr[curIndex - 1], maxVal - arrToSort[curIndex - 1], brushWidth, maxVal);
            }
        }

        private bool IsSorted()
        {
            for(int i = 0; i < arrToSort.Length - 1; i++)
            {
                if(arrToSort[i] > arrToSort[i+1])
                {
                    return false;
                }
            }
            Console.WriteLine("Sorted");
            return true;
        }
    }
}
