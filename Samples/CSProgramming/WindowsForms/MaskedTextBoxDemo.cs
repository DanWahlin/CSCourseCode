using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MaskedTextBoxDemo : Form
    {
        public MaskedTextBoxDemo()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new MaskedTextBoxDemo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked.");
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                toolTip1.ToolTipTitle = "Input Rejected - Too Much Data";
                toolTip1.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.", maskedTextBox1, maskedTextBox1.Location.X, maskedTextBox1.Location.Y, 5000);
            }
            else if (e.Position == maskedTextBox1.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Input Rejected - End of Field";
                toolTip1.Show("You cannot add extra characters to the end of this date field.", maskedTextBox1, maskedTextBox1.Location.X, maskedTextBox1.Location.Y, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Input Rejected";
                toolTip1.Show("You can only add numeric characters (0-9) into this date field.", maskedTextBox1, maskedTextBox1.Location.X, maskedTextBox1.Location.Y, 5000);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.label2.Text = this.maskedTextBox1.Text;
        }
    }
}