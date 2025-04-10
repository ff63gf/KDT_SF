using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    struct CalHistory
    {
        public int input1;
        public char op;
        public int input2;
    }

    public partial class Form1 : Form
    {
        string calculateText = "";
        List<string> history = new List<string>();
        public Form1()
        {
            InitializeComponent();
            labelNumber.Text = "";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " + ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " - ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void labelNumber_TextChanged(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            labelNumber.Text= String.Format("{0:n0}", double.Parse(labelNumber.Text));
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " * ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " / ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            labelResult.Text += labelNumber.Text;

            string lastTxt = Regex.Replace(labelResult.Text, @",", "");

            DataTable table = new DataTable();
            object result = table.Compute(lastTxt, String.Empty);
            labelResult.Text += " =";
            labelNumber.Text = result.ToString();
            calculateText = "";

            history.Add(labelResult.Text + labelNumber.Text);
            if(history.Count>5)
            {
                history.RemoveAt(0);
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " % ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            calculateText = "";
            labelNumber.Text = "";
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            string msg = "";
            foreach (var str in history) {
                msg += str + "\r\n";
            }
            MessageBox.Show(msg);
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            if (labelNumber.Text[0] == '-')
            {
                labelNumber.Text = labelNumber.Text.Remove(0,1);
            } else
            {
                labelNumber.Text = labelNumber.Text.Insert(0, "-");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e) => labelNumber.Text += "0";

        private void button1_Click(object sender, EventArgs e) => labelNumber.Text += "1";

        private void button2_Click(object sender, EventArgs e) => labelNumber.Text += "2";

        private void button3_Click(object sender, EventArgs e) => labelNumber.Text += "3";

        private void button4_Click(object sender, EventArgs e) => labelNumber.Text += "4";

        private void button5_Click(object sender, EventArgs e) => labelNumber.Text += "5";

        private void button6_Click(object sender, EventArgs e) => labelNumber.Text += "6";

        private void button7_Click(object sender, EventArgs e) => labelNumber.Text += "7";

        private void button8_Click(object sender, EventArgs e) => labelNumber.Text += "8";

        private void button9_Click(object sender, EventArgs e) => labelNumber.Text += "9";

        private void buttonBack_Click(object sender, EventArgs e) => labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
    }
}
