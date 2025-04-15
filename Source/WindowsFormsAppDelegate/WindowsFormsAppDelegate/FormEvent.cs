using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDelegate
{
    public partial class FormEvent : Form
    {
        public FormEvent()
        {
            InitializeComponent();

            MyButton button = new MyButton();

            button.Click += new EventHandler(ButtonClick1);
            button.Click += new EventHandler(ButtonClick2);

            button.MouseButtonDown();
        }

        // event에 등록될 메소드는 object sender, EventArgs e를 가져야 함
        void ButtonClick1(object sender, EventArgs e)
        {
            MessageBox.Show("버튼1 클릭됨!");
        }

        void ButtonClick2(object sender, EventArgs e)
        {
            MessageBox.Show("버튼2 클릭됨!");
        }
    }

    internal class MyButton
    {        
        public event EventHandler Click;

        public void MouseButtonDown()
        {
            if(this.Click != null)
            {
                this.Click(this, EventArgs.Empty);
            }
        }
    }
}
