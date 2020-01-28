using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Sort(int[] arr, Graphics g_, int maxVal_)
        {
            arrToSort = arr;
            g = g_;
            maxVal = maxVal_;

            while(!isSorted)
            {
                for(int i = 0; i < arrToSort.Length - 1; i++)
                {
                    if(arrToSort[i] > arrToSort[i+1])
                    {
                        Swap(i, i + 1);
                    }
                }
                isSorted = IsSorted();
            }
        }

        private void Swap(int curIndex, int prevIndex)
        {
            int temp = arrToSort[curIndex];
            arrToSort[curIndex] = arrToSort[curIndex + 1];
            arrToSort[curIndex + 1] = temp;

            //combine both into one and make it into 1 pixel wide
            g.FillRectangle(blackBrush, curIndex, 0, 1, maxVal);
            g.FillRectangle(blackBrush, prevIndex, 0, 1, maxVal);

            g.FillRectangle(whiteBrush, curIndex, maxVal - arrToSort[curIndex], 1, maxVal);
            g.FillRectangle(whiteBrush, prevIndex, maxVal - arrToSort[prevIndex], 1, maxVal);
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
            return true;
        }
    }
}
