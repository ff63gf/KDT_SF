using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void down(object sender, KeyEventArgs e)
        {
            MessageBox.Show("안녕안녕");
        }

        private void button_input_click(object sender, EventArgs e)
        {
            textBox_print.Text += textBox_input.Text + "\r\n";
        }

        private void textBox_input_TextChanged(object sender, EventArgs e)
        {
            textBoxCopy.Text = textBox_input.Text;
        }
    }
}
