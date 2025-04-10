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

namespace WindowsFormsAppThread
{
    public partial class Form1 : Form
    {
        static int sharedData = 0;
        static int sharedResult = 0;
        static object lockObject = new object();
        public Form1()
        {
            InitializeComponent();

            //textBox1.Text += "1번 스레드 시작!\r\n";

            //var new_thread = new Thread(new ThreadStart(MyThread));
            //new_thread.Start();

            //textBox1.Text += "1번 스레드 끝!\r\n";

            Thread thread1 = new Thread(UpdateData1);
            Thread thread2 = new Thread(UpdateData2);

            thread1.Start();
            thread2.Start();

            //Thread.Sleep(100);

            thread1.Join();
            textBox1.Text += "thread1.Join()\r\n";

            textBox1.Text += "thread2.Join() before \r\n";
            thread2.Join();
            textBox1.Text += "thread2.Join() after \r\n";


            Thread thread3 = new Thread(UpdateData3);
            thread3.Start();
            thread3.Join();

            textBox1.Text += $"thread3 {sharedResult} \r\n";
        }

        private void UpdateData3()
        {
            sharedResult = 1 + 2;
        }

        private void UpdateData1()
        {
            //lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10);
                    if (textBox1.InvokeRequired)
                    {
                        int a = 1;
                        textBox1.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.Text += $"1: {sharedData} {a}\r\n";
                        }));
                        a = 2;
                    } 
                    else
                    {
                        textBox1.Text += $"1: {sharedData}\r\n";
                    }
                }
            }
        }

        private void UpdateData2()
        {
            //lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10);
                    //textBox1.Text += $"2: {sharedData}\r\n";
                    if (textBox1.InvokeRequired)
                    {
                        int a = 1;
                        textBox1.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.Text += $"2: {sharedData} {a} \r\n";
                        }));
                        a = 2;
                    }
                    else
                    {
                        textBox1.Text += $"2: {sharedData}\r\n";
                    }
                }
            }
        }

        //private void MyThread()
        //{
        //    textBox1.Text += "2번 스레드 시작!\r\n";

        //    Thread.Sleep(1000);

        //    textBox1.Text += "2번 스레드 끝!\r\n";
        //}
    }
}
