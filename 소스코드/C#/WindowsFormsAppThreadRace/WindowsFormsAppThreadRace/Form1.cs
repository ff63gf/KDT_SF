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

using System.Threading;

namespace WindowsFormsAppThreadRace
{
    public partial class Form1 : Form
    {
        int[] progress = new int[5];
        Thread[] threads;
        const int MAX_PROGRESS = 10;
        DateTime[] startTimes = new DateTime[5];
        DateTime[] endTimes = new DateTime[5];
        bool[] ends = new bool[5];
        System.Windows.Forms.Timer checkTimer;
        private static Random rd = new Random();

        public Form1()
        {
            InitializeComponent();

            threads = new Thread[5];
            threads[0] = new Thread(() => RunThread(0));
            threads[1] = new Thread(() => RunThread(1));
            threads[2] = new Thread(() => RunThread(2));
            threads[3] = new Thread(() => RunThread(3));
            threads[4] = new Thread(() => RunThread(4));

            textBox1.Text += "준비 완료\r\n";

            checkTimer = new System.Windows.Forms.Timer();
            checkTimer.Interval = 300;
            checkTimer.Tick += new EventHandler(CheckTimer_Tick);
        }

        void RandomSleep()
        {
            int sleepTime = (int)(rd.NextDouble() * 1000.0);
            Thread.Sleep(sleepTime);
        }

        void RunThread(int index)
        {
            progress[index] = 0;
            startTimes[index] = DateTime.Now;
            while (progress[index] < MAX_PROGRESS)
            {
                progress[index]++;
                RandomSleep();                
            }
            endTimes[index] = DateTime.Now;
            ends[index] = true;

            TimeSpan duration = endTimes[index] - startTimes[index];

            if (progress[index] >= MAX_PROGRESS)
            {
                // UI 스레드에서 UI 업데이트
                if (textBox1.InvokeRequired)
                {
                    Action safeWrite = delegate
                    {
                        textBox1.Text += $"{index}번 차량 도착! {duration.TotalSeconds} 초\r\n";
                    };
                    textBox1.Invoke(safeWrite);
                }
                else
                {
                    textBox1.Text += $"{index}번 차량 도착! {duration.TotalSeconds} 초\r\n";
                }
            }
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            CheckAllThreadsCompleted();
        }

        void CheckAllThreadsCompleted()
        {
            bool allCompleted = true;
            for (int i = 0; i < ends.Length; i++)
            {
                if (!ends[i])
                {
                    allCompleted = false;
                    break;
                }
            }

            if (!allCompleted)
                return;

            checkTimer.Enabled = false; // 모든 스레드가 완료되면 타이머 중지

            TimeSpan totalDuration = endTimes[0] - startTimes[0];
            for (int i = 1; i < startTimes.Length; i++)
            {
                if (endTimes[i] - startTimes[i] > totalDuration)
                {
                    totalDuration = endTimes[i] - startTimes[i];
                }
            }

            // UI 스레드에서 UI 업데이트
            if(textBox1.InvokeRequired)
            {
                Action safeWrite = delegate
                {
                    textBox1.Text += $"모든 스레드 완료! 총 소요 시간: {totalDuration.TotalSeconds} 초\r\n";
                };
                textBox1.Invoke(safeWrite);
            }
            else
            {
                textBox1.Text += $"모든 스레드 완료! 총 소요 시간: {totalDuration.TotalSeconds} 초\r\n";
            }
            button_start.Enabled = true;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            textBox1.Text = $"시작 시간: {DateTime.Now}\r\n";
            foreach (Thread t in threads)
            {
                t.Start();
            }
            checkTimer.Enabled = true;
        }
    }
}
