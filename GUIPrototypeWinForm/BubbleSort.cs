using System.Drawing;
using System.Threading;

namespace GUIPrototypeWinForm
{
    //O(n^2) = as the array gets larger, its efficiency decreases
    //least efficient and not commonly used
    class BubbleSort : Interface1
    {
        private int[] arrToSort;
        private Graphics g;
        private int maxVal;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush purpleBrush = new SolidBrush(Color.DarkViolet);
        int brushWidth;
        private int[] posArr;
        int threadSleepTime = 300;

        public void Sort(int[] arr, Graphics g_, int maxVal_, int brushWidth_, int[] posArr_)
        {
            //Setting all local variables to passed variables
            arrToSort = arr;
            g = g_;
            maxVal = maxVal_;
            brushWidth = brushWidth_;
            posArr = posArr_;

            //loop that performs bubble sort
            while(!IsSorted())
            {
                for (int i = 0; i < arrToSort.Length; i++)
                {
                    g.FillRectangle(blackBrush, posArr[i], 0, brushWidth, maxVal);
                    g.FillRectangle(purpleBrush, posArr[i], maxVal - arrToSort[i], brushWidth, maxVal);

                    if (i + 1 < arrToSort.Length)
                    {
                        if (arrToSort[i] > arrToSort[i + 1])
                        {

                            Swap(i, i + 1);
                            if (i != 0)
                            {
                                g.FillRectangle(blackBrush, posArr[i - 1], 0, 1, maxVal);
                                g.FillRectangle(whiteBrush, posArr[i - 1], maxVal - arrToSort[i - 1], brushWidth, maxVal);
                            }

                            g.FillRectangle(blackBrush, posArr[i], 0, 1, maxVal);
                            g.FillRectangle(purpleBrush, posArr[i], maxVal - arrToSort[i], brushWidth, maxVal);

                        }

                        //Thread sleeps for .03 of a second
                        //Slows it down enough to watch but not bore
                        Thread.Sleep(threadSleepTime);                    
                    }
                    g.FillRectangle(blackBrush, posArr[i], 0, brushWidth, maxVal);
                    g.FillRectangle(whiteBrush, posArr[i], maxVal - arrToSort[i], brushWidth, maxVal);
                }          
            }
        }

        private void Swap(int curIndex, int nextIndex)
        {
            //Actual swap
            int temp = arrToSort[curIndex];
            arrToSort[curIndex] = arrToSort[nextIndex];
            arrToSort[nextIndex] = temp;
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
