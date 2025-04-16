using System;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfAppMultiThread
{
    public partial class MainWindow : Window
    {
        int[] progress = new int[5];
        Thread[] threads;
        const int MAX_PROGRESS = 10;
        DateTime[] startTimes = new DateTime[5];
        DateTime[] endTimes = new DateTime[5];
        bool[] ends = new bool[5];
        DispatcherTimer checkTimer;
        private static Random rd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            threads = new Thread[5];

            threads[0] = new Thread(() => RunThread(0));
            threads[1] = new Thread(() => RunThread(1));
            threads[2] = new Thread(() => RunThread(2));
            threads[3] = new Thread(() => RunThread(3));
            threads[4] = new Thread(() => RunThread(4));

            txtBlock.Text += "준비 완료\r\n";

            checkTimer = new DispatcherTimer();
            checkTimer.Interval = TimeSpan.FromMilliseconds(500); // 500ms마다 확인
            checkTimer.Tick += CheckTimer_Tick;
        }

        void RandomSleep()
        {
            //Random rd = new Random();
            int sleepTime = (int)(rd.NextDouble() * 1000.0);
            Thread.Sleep(sleepTime);
            //this.Dispatcher.Invoke(() =>
            //{
            //    txtBlock.Text += $"sleep {sleepTime} 초\r\n";
            //});
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
            this.Dispatcher.Invoke(() =>
            {
                txtBlock.Text += $"{index + 1}번 완료! 완료 시간: {endTimes[index]:HH:mm:ss}\r\n";
                CheckAllThreadsCompleted();
            });
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            txtBlock.Text += $"시작 시간: {DateTime.Now}\r\n";
            foreach (Thread t in threads)
            {
                t.Start();
            }
            checkTimer.Start();
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

            checkTimer.Stop(); // 모든 스레드가 완료되면 타이머 중지

            TimeSpan totalDuration = endTimes[0] - startTimes[0];
            for (int i = 1; i < startTimes.Length; i++)
            {
                if (endTimes[i] - startTimes[i] > totalDuration)
                {
                    totalDuration = endTimes[i] - startTimes[i];
                }
            }

            // UI 스레드에서 UI 업데이트
            this.Dispatcher.Invoke(() =>
            {
                txtBlock.Text += $"모든 스레드 완료! 총 소요 시간: {totalDuration.TotalSeconds} 초\r\n";
            });
        }
    }
}
