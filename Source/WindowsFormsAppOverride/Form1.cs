using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppOverride
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Triangle());
            shapes.Add(new Circle());
            shapes.Add(new Square());
            shapes.Add(new Triangle());
            shapes.Add(new Square());
            shapes.Add(new Circle());
            shapes.Add(new Square());
            shapes.Add(new Circle());
            shapes.Add(new Triangle());

            foreach(Shape shape in shapes)
            {
                textBox1.Text += shape.getShape() + "\r\n";
                if (shape is Triangle)
                {
                    Triangle triangle = (Triangle)shape;
                    textBox1.Text += triangle.getShape() + "\r\n";
                }
                else if (shape is Circle)
                {
                    Circle c = (Circle)shape;
                    textBox1.Text += c.getShape() + "\r\n";
                }
                else if (shape is Square)
                {
                    Square c = (Square)shape;
                    textBox1.Text += c.getShape() + "\r\n";
                }
            }
        }
    }
}
