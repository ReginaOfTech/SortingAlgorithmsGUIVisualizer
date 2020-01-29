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
        int brushWidth = 1;

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
                        Console.WriteLine("Sorting");
                        Interface1 bubbleCall = new BubbleSort();
                        bubbleCall.Sort(arrayToSort, gObj, panel1.Height, brushWidth, posOfCols);
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
            int panelWidth = panel1.Width;
            int maxVal = panel1.Height;
            arrayToSort = new int[panelWidth/brushWidth]; 
            gObj.FillRectangle(new SolidBrush(Color.Black), 0, 0, panelWidth, maxVal);

            var rand = new Random();
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = rand.Next(5, maxVal);
                Console.WriteLine(arrayToSort[i].ToString());
            }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(sender.ToString());
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }
    }
}
