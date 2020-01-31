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
    public partial class MessageBox : Form
    {
        public MessageBox(string text)
        {
            InitializeComponent();
            SetText(text);
        }

        private void SetText(string message)
        {
            MessageBoxLabel.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
