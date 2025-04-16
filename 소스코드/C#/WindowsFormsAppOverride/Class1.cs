using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppOverride
{
    public class Shape
    {
        public string getShape() => "Shape\r\n";
    }

    public class Square : Shape
    {
        public string getShape() => "Square\r\n";
    }

    public class Triangle : Shape
    {
        public string getShape() => "Triangle\r\n";
    }

    public class Circle : Shape
    {
        public string getShape() => "Circle\r\n";
    }
}
