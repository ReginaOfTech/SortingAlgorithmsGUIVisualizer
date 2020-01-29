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
        Graphics gObj;

        public Form1()
        {         
            InitializeComponent();
            Timer myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += (o, ea) =>
            {
                CreateAndDisplayArray();
                myTimer.Stop();
            };
            myTimer.Interval = 200; // 5 seconds
            myTimer.Start();
            CreateAndDisplayArray();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartSortButton_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Bubble Sort":
                        Interface1 bubbleCall = new BubbleSort();
                        bubbleCall.Sort(arrayToSort, gObj, panel1.Height);
                        break;
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

        private void CreateArrayButton_Click(object sender, EventArgs e)
        {
            CreateAndDisplayArray();
        }

        private void CreateAndDisplayArray()
        {
            //When window is changed, have array visual expand/decrease with it
            gObj = panel1.CreateGraphics();
            int numEntries = panel1.Width;
            int maxVal = panel1.Height;
            arrayToSort = new int[numEntries];
            gObj.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxVal);
            var rand = new Random();
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = rand.Next(5, maxVal);
                Console.WriteLine(arrayToSort[i].ToString());
            }
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                gObj.FillRectangle(new SolidBrush(Color.White), i, maxVal - arrayToSort[i], 1, maxVal);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }
    }
}
