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
            arrToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            while(!isSorted)
            {
                int curXPos = 0;

                for (int i =0; i < arrToSort.Length - 1; i++)
                {                   
                    if (arrToSort[i] > arrToSort[i+1])
                    {
                        Swap(i, i+1, curXPos);
                    }
                    else
                    {
                        g.FillRectangle(whiteBrush, posArr[i], maxVal - arrToSort[i], brushWidth, maxVal);
                    }
                        
                    Thread.Sleep(1);
                    isSorted = IsSorted();
                    
                }
                
            }
        }

        private void Swap(int curIndex, int prevIndex, int curXPos_)
        {
            int temp = arrToSort[curIndex];
            arrToSort[curIndex] = arrToSort[curIndex + 1];
            arrToSort[curIndex + 1] = temp;

            g.FillRectangle(blackBrush, posArr[curIndex], 0, 1, maxVal);
            g.FillRectangle(blackBrush, posArr[prevIndex], 0, 1, maxVal);

            g.FillRectangle(whiteBrush, posArr[curIndex], maxVal - arrToSort[curIndex], brushWidth, maxVal);
            g.FillRectangle(purpleBrush, posArr[prevIndex], maxVal - arrToSort[prevIndex], brushWidth, maxVal);
            
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
