using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppClass2
{
    internal class MO
    {
        public int GetNumber(int n) => n;

        public int GetNumber(int n1, int n2) => n1+n2;

        public long GetNumber(long n) => n-99;
    }

    public class Shape
    {
        public string Say() => "Hi\r\n";
        public string Go()=> "Go\r\n";
        public virtual string getShape() => "Shape\r\n";
    }

    public class Square : Shape
    {
        public string Say() => "Hello\r\n";
        public new string Go() => "GoGoGo\r\n";
        public override sealed string getShape() => "Square\r\n";
    }

    public class Ring : Square
    {
        public override string getShape() => "Square\r\n";
    }

    public class Triangle : Shape
    {
        public string Say() => "Hello\r\n";
        public new string Go() => "GoGoGo\r\n";
        public override string getShape() => "Triangle\r\n";
    }

    public class Circle : Shape
    {
        public string Say() => "Hello\r\n";
        public new string Go() => "GoGoGo\r\n";
        public override string getShape() => "Circle\r\n";
    }

    public interface IShape
    {
        // 인터페이스 메서드 (순수 가상 함수와 유사)
        string GetShape();
    }

    public class Square2 : IShape
    {
        public string GetShape() => "Square2" + "\r\n";
    }

    public class Triangle2 : IShape
    {
        public string GetShape() => "Triangle2" + "\r\n";
    }
}
