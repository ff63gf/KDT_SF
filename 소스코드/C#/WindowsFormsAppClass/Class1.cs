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
            // 필드를 사용할 때는 this.를 사용하는 것이 예의
            this.MyName = "기본 생성자";
            MessageBox.Show(this.MyName);
        }

        public Square(string Text) 
        {
            this.MyName += Text;
            MessageBox.Show(Text);
        }
        ~Square() 
        { 
            MessageBox.Show("소멸자"); 
        }

    }
}
