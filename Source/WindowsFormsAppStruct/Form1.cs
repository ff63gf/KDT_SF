using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppStruct
{
    struct Point
    {
        public int x; 
        internal int y;
        public int z;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Point point = new Point();

            point.x = 13;
            point.y = 21;
            point.z = -4;

            //textBox1.Text = $"point ({point.x}, {point.y}, {point.z})";

            //Point[] p = new Point[3];

            //for(int i = 0; i < p.Length; i++)
            //{
            //    p[i].x = i;
            //    p[i].y = i*i;
            //    p[i].z = -i;

            //    textBox1.Text += $"point ({p[i].x}, {p[i].y}, {p[i].z})\r\n";
            //}

            Hi();
            textBox1.Text += Add(4, 2).ToString();

            Class1 class1 = new Class1();
            class1.a = 1;
            class1.b = 2;
        }

        void Hi() => textBox1.Text += "Hi\r\n";

        int Add(int a, int b) => a + b;
    }
}
