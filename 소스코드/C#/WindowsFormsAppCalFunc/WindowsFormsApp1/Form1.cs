using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            double result = calculation(1, 2, '+');

            //MessageBox.Show("Hello world");
            textBox_print.Text = result.ToString();
            textBox_print.Text += "\r\n계산완료";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        public double calculation(int a, int b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default: return a;
            }
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
            textBox_print.Text += "\r\n"+textBox_input.Text;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
