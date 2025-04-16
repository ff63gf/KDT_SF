using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppStatic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Dog dog1 = new Dog();
            //Dog dog2 = new Dog();
            //Dog dog3 = new Dog();

            //Dog.Num1 = 1;

            //textBox1.Text = Dog.Count.ToString();

            //int num = 1;
            ////textBox1.Text = minusOne(num).ToString();

            //setThreee(ref num);
            //textBox1.Text = num.ToString();

            int length = 10;
            int[] numbers;
            //int[] numbers = new int[lenth];
            makeInstance(out numbers, length);

            for(int i = 0; i < length; i++)
            {
                textBox1.Text += numbers[i].ToString() + " ";
            }
        }

        private void makeInstance(out int[] numbers, int length)
        {
            numbers = new int[length];
        }

        int minusOne(int x) => x - 1;

        void setThreee(ref int x) {
            int a = 1;
            //x = 3;
        }
    }
}
