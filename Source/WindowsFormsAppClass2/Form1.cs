using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClass2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //MO mo = new MO();

            //textBox1.Text += mo.GetNumber(10).ToString() + "\r\n";
            //textBox1.Text += mo.GetNumber(10,20).ToString() + "\r\n";
            //textBox1.Text += mo.GetNumber(100L).ToString() + "\r\n";

            Square square = new Square();
            textBox1.Text += square.Say();
            textBox1.Text += square.Go();
            textBox1.Text += square.getShape();

            Shape shape = new Shape();
            textBox1.Text += shape.Say();
            textBox1.Text += shape.Go();
            textBox1.Text += shape.getShape();

            Shape shape2 = new Square();
            textBox1.Text += shape2.Say();
            textBox1.Text += shape2.Go();
            textBox1.Text += shape2.getShape()+"\r\n";

            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Square());
            shapes.Add(new Triangle());
            shapes.Add(new Circle());

            foreach (var s in shapes)
            {
                textBox1.Text += s.getShape();
            }

            List<IShape> ishapes = new List<IShape>();
            ishapes.Add(new Square2());
            ishapes.Add(new Triangle2());

            foreach (var s in ishapes)
            {
                textBox1.Text += s.GetShape();
            }

            //int a = 1;
            //if( a is int)
            //{
            //    textBox1.Text += "int";
            //} else if (a is string)
            //{
            //    textBox1.Text += "string";
            //}
        }
    }
}
