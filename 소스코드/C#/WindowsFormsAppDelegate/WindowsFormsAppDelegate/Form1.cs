using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDelegate
{
    public delegate void CallDelegate(string msg);

    public partial class Form1 : Form
    {
        public CallDelegate callDelegate;
        Thread thread;
        bool isRunning = false;

        void Print(string msg) => textBox_print.Text += msg;

        public Form1()
        {
            InitializeComponent();

            this.callDelegate = new CallDelegate(Print);
            this.callDelegate("Hello"); // Hi 메소드 실행
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            this.isRunning = true;
            this.thread = new Thread(ThreadMethod);
            this.thread.Start();
        }

        void ThreadMethod()
        {
            int count = 0;
            while (this.isRunning) 
            {
                // 이렇게 UI스레드와 다른 스레드에서 직접 UI스레드의 컨트롤을
                // 사용하려고 하면 크로스 스레드 오류가 발생함
                //textBox_print.Text += count.ToString();
                
                // Delegate 및 Invoke를 활용하여 호출해야 함
                // 두번 째 인자(입력 값)는 Print 메소드에 전달됨
                this.Invoke(this.callDelegate, count.ToString());
                count++;
                Thread.Sleep(500);
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            this.isRunning = false;
        }
    }
}
    