using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //int[] arr2 = new int[2];
            //arr2[4] = 0;

            try
            {
                int[] arr = new int[2];
                string a = "a";
                arr[4] = 0;
                int c = 0;
                int b = 2 / c;
                textBox1.Text += "Try 실행\r\n";
                int a = 2;
                if (a == 1)
                    throw new Microsoft.CSharp.RuntimeBinder.RuntimeBinderException("에러발생!");
                if (a == 2)
                    throw new Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException("뀨?");
            }
            catch(Exception ex)
            {
                textBox1.Text += ex.Message + "\r\n";
            }
            finally
            {
                textBox1.Text += "프로그램 종료\r\n";
            }
        }
    }
}
