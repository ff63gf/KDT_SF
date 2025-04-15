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

        public int Diff_xy()
        {
            return x - y;
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // point1과 point2는 서로 같은 형태를 가졌으나
            // 서로 다른 객체 (다른 메모리 공간을 차지)
            Point point1 = new Point();
            Point point2 = new Point();

            // point1.x 와 point2.x는 서로 독립적으로 존재
            point1.x = 13;
            point2.x = 31;

            Point point = new Point();

            point.x = 10;
            point.y = 20;
            int diff = point.Diff_xy();

            //textBox1.Text = $"point ({point.x}, {point.y}, {point.z})";

            //Point[] p = new Point[3];

            //for(int i = 0; i < p.Length; i++)
            //{
            //    p[i].x = i;
            //    p[i].y = i*i;
            //    p[i].z = -i;

            //    textBox1.Text += $"point ({p[i].x}, {p[i].y}, {p[i].z})\r\n";
            //}

            //Hi();
            //textBox1.Text += Add(4, 2).ToString();

            //Class1 class1 = new Class1();
            //class1.a = 1;
            //class1.b = 2;
            //Add(1, 2);

            //this.button1.Click += new System.EventHandler(button1_Click);

            // 람다식을 사용하여 한 줄로 표현
            this.button1.Click += (sender, e) => ((Button)sender).BackColor = Color.Red;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ((Button)sender).BackColor = Color.Red;
        //}

        // 원래 함수
        //int Add(int a, int b)
        //{
        //    return a + b;
        //}

        // 람다식으로 표현한 함수
        //int Add(int a, int b) => a + b;

        void Hi() => textBox1.Text += "Hi\r\n";
    }
}
