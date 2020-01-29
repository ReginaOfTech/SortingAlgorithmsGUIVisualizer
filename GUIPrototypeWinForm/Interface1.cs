using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIPrototypeWinForm
{
    //Parent class. Inheritance is used within this program.
    //Each of the sorts will have their own class that extends from this parent class.
    //Sort is a common method within each sort will is required in each child. 
    interface Interface1
    {
        void Sort(int[] arr, Graphics g, int maxVal, int brushWidth, int[] posArr);
    }
}
