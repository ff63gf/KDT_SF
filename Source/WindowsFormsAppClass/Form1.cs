using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClass
{
    public partial class Form1 : Form
    {
        public string Name { get; set; } // 자동 속성
        public string Description { get; set; } = string.Empty; // 속성 초기화

        private int _num;
        private decimal _money;

        public int Num // 특별한 정의가 필요할 경우 사용
        {
            get { return _num; }
            set { _num = value; }
        }

        public decimal Money // 화살표 함수로 작성 가능
        {
            get => _money;
            set => _money = value;
        }

        public Form1()
        {
            InitializeComponent();

            MessageBox.Show("Form1 생성자");
            //int a = 0;

            //Square square = new Square();
            //textBox1.Text = square.GetName();

            //Square square = new Square("생성자 야호!");

            Square square = new Square();

            Num = 1;
            //textBox1.Text = Num.ToString()+"\r\n";
            int a = Num;
            textBox1.Text += a.ToString() + "\r\n";

            Num = 3;
            //textBox1.Text = Num.ToString()+"\r\n";
            a = Num;
            textBox1.Text += a.ToString();
        }
        ~Form1 ()
        {
            MessageBox.Show("Form1 소멸자");
        }
    }
}
