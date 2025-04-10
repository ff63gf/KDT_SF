using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsAppClass
{
    partial class Square
    {
        string MyName = "사각형";
        public string GetName() => MyName;

        public Square() 
        {
            MessageBox.Show("기본 생성자");
        }

        public Square(string Text) 
        { 
            MessageBox.Show(Text);
        }
        ~Square() 
        { 
            MessageBox.Show("소멸자"); 
        }

    }
}
