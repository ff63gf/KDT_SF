using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDerived
{
    public class Shape
    {
        protected string getShape() => "Shape";
        public string getShape2() => "Shape2";
        private string getShape3() => "Shape3";
        internal string getShape4() => "Shape4";

        protected int a;
        public int b;

        public int c {  get; set; }
        private int d;
    }

    public class Square : Shape
    {
        public Square() => MessageBox.Show(getShape());

        void test()
        {
            a = 1;
            b = 2;
            c = 3;
        }
    }

}
