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
                if(newArray)
                {
                    //Checking the drop down box for desired sorting algorithm
                    switch (comboBox1.SelectedItem.ToString())
                    {
                        //A new case for each sort.
                        case "Bubble Sort":
                            Console.WriteLine("Sorting by bubble");
                            newArray = false;
                            ComplexityLabel.Text = "Complexity: O(n ^ 2)";
                            //A parent class will be used so that the children can inherit from it.
                            Interface1 bubbleCall = new BubbleSort();
                            bubbleCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
                            break;
                        case "Quick Sort":
                            Console.WriteLine("Sorting by quick");
                            newArray = false;
                            ComplexityLabel.Text = "Complexity: O(n^2)";
                            Interface1 quickCall = new QuickSort();
                            quickCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
                            break;
                        case "Merge Sort":
                            Console.WriteLine("Sorting by merge");
                            newArray = false;
                            ComplexityLabel.Text = "Complexity: O(nLogn)";
                            Interface1 mergeCall = new MergeSort();
                            mergeCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
                            break;
                        case "Heap Sort":
                            Console.WriteLine("Sorting by heap.");
                            newArray = false;
                            ComplexityLabel.Text = ("Get Complexity");
                            Interface1 heapCall = new HeapSort();
                            heapCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
                            break;
                        //Default will catch for the sorts in the list, but not implemented.
                        default:
                            MessageBox m = new MessageBox("That Algorithm Has Not Been Created. Please Select Another.");
                            m.Show();
                            //MessageBox.Show("That Algorithm Has Not Been Created. Please Select Another.");
                            break;
                    }
                }
                else
                {
                    MessageBox m = new MessageBox("Please Create A New Array By Selecting A New Array Size.");
                    m.Show();
                    //MessageBox.Show("Please Create A New Array By Selecting A New Array Size.");
                }
                
            }
            else
            {
                MessageBox m = new MessageBox("Please Select A Sorting Algorithm.");
                m.Show();
                //MessageBox.Show("Please Select A Sorting Algorithm.");
            }
            
        }

        //event handler for when the 'create array' button is clicked
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool newArray = false;
        private void CreateAndDisplayArray()
        {
            //TODO: When window is changed, have array visual expand/decrease with it
            gObj = panel1.CreateGraphics();
            //panelwidth and maxval prevent the columns from extending past the 
            //panel's boundaries and crashing the program.
            int panelWidth = panel1.Width;
            int maxVal = panel1.Height;
            //Adding 10 allows for 0 to be used and set to 10
            int numOfEntries = trackBar1.Value * 10 + 10;

            //Finding number of pixels needed between each columns
            //for separation
            int pixelsForSpace = numOfEntries * 2;
            brushWidth = (panelWidth - pixelsForSpace) / numOfEntries;

            arrayToSort = new int[numOfEntries]; //panelWideth/brushWidth
            gObj.FillRectangle(new SolidBrush(Color.Black), 0, 0, panelWidth, maxVal);

            //Filling arrayToSort with random numbers that do not exceed panel height
            var rand = new Random();
            for (int i = 0; i < arrayToSort.Length; i++)
            {               
                arrayToSort[i] = rand.Next(20, maxVal);                
                Console.WriteLine(arrayToSort[i].ToString());
            }

            //Tracking position of columns for when the user can select the number of columns
            posOfCols = new int[arrayToSort.Length];
            int prevXPos = 0;
            for (int i = 0; i < arrayToSort.Length; i++)
            {                
                gObj.FillRectangle(new SolidBrush(Color.White), prevXPos, maxVal - arrayToSort[i], brushWidth, maxVal);
                posOfCols[i] = prevXPos;
                Console.WriteLine("Pos: " + posOfCols[i].ToString());
                prevXPos += brushWidth + 2;
            }
            newArray = true;
        }

        //Event handler for when the combo box is changed. Debugging purposes.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }

        //Event handler for the scroll bar.
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine(trackBar1.Value.ToString());
            CreateAndDisplayArray();
        }
    }
}
