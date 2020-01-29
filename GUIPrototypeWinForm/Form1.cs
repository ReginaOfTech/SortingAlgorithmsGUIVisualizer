using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIPrototypeWinForm
{
    public partial class Form1 : Form
    {
        int[] arrayToSort;
        int[] posOfCols;
        Graphics gObj;
        //Tracking this for future element of user selecting num of columns.
        int brushWidth = 1;

        public Form1()
        {         
            InitializeComponent();

            //timer is used so that an array is created and displayed on initial window presence
            Timer myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += (o, ea) =>
            {
                CreateAndDisplayArray();
                //Timer is stopped once it has "ticked" once
                myTimer.Stop();
            };
            myTimer.Interval = 200;
            myTimer.Start();
            CreateAndDisplayArray();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Event handler for when the 'start' button is clicked
        private void StartSortButton_Click(object sender, EventArgs e)
        {
            //check to make sure that a sort is selected. If not a pop up message is presented. 
            if(comboBox1.SelectedItem != null)
            {
                //Checking the drop down box for desired sorting algorithm
                switch (comboBox1.SelectedItem.ToString())
                {
                    //A new case for each sort.
                    case "Bubble Sort":
                        Console.WriteLine("Sorting");
                        //A parent class will be used so that the children can inherit from it.
                        Interface1 bubbleCall = new BubbleSort();
                        bubbleCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
                        break;
                    //Default will catch for the sorts in the list, but not implemented.
                    default:
                        MessageBox.Show("That Algorithm Has Not Been Created. Please Select Another.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please Select A Sorting Algorithm.");
            }
            
        }

        //event handler for when the 'create array' button is clicked
        private void CreateArrayButton_Click(object sender, EventArgs e)
        {
            CreateAndDisplayArray();
        }

        private void CreateAndDisplayArray()
        {
            //TODO: When window is changed, have array visual expand/decrease with it
            gObj = panel1.CreateGraphics();
            //panelwidth and maxval prevent the columns from extending past the 
            //panel's boundaries and crashing the program.
            int panelWidth = panel1.Width;
            int maxVal = panel1.Height;
            //TODO: Implement number of column selection
            arrayToSort = new int[panelWidth/brushWidth]; 
            gObj.FillRectangle(new SolidBrush(Color.Black), 0, 0, panelWidth, maxVal);

            //Filling arrayToSort with random numbers that do not exceed panel height
            var rand = new Random();
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = rand.Next(5, maxVal);
                Console.WriteLine(arrayToSort[i].ToString());
            }

            //Tracking position of columns for when the user can select the number of columns
            posOfCols = new int[arrayToSort.Length];
            int prevXPos = 0;
            for (int i = 0; i < arrayToSort.Length; i++)
            {                
                gObj.FillRectangle(new SolidBrush(Color.White), prevXPos, maxVal - arrayToSort[i], brushWidth, maxVal);
                posOfCols[i] = prevXPos;
                Console.WriteLine(posOfCols[i].ToString());
                prevXPos += brushWidth;
            }
        }

        //Event handler for when the combo box is changed. Debugging purposes.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }
    }
}
