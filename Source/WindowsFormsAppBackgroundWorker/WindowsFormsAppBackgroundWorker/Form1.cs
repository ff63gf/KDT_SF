using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace WindowsFormsAppBackgroundWorker
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();

            // 프로그래스 바 초기설정
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            this.worker = new BackgroundWorker();
            // BackgroundWorker의 ReportProgress() 메소드 활용 여부, 보통 true
            this.worker.WorkerReportsProgress = true;
            // CancelAsync()로 BackgroundWorker를 멈출 수 있게 할지, 보통 true
            this.worker.WorkerSupportsCancellation = true;

            // BackgroundWorker가 UI스레드와 별개로 수행할 메소드
            this.worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            // ReportProgress() 메소드가 수행될때 실행될 메소드
            this.worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            // ReportProgress()가 100으로 호출되면 마지막에 한 번 실행되는 메소드
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_Complete);
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30); // 30ms
                this.worker.ReportProgress(i);
            }
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // ProgressPercentage는 0~100 사이의 값을 가짐
            progressBar1.Value = e.ProgressPercentage;
        }

        void Worker_Complete(object sender, EventArgs e) 
        {
            MessageBox.Show("Complete");
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //// while 문으로 처리 할 경우 UI 스레드 내부에서 실행되기 때문에 
            //// UI 스레드가 바쁠 경우 응답 없음 상태로 멈추고 순식간에 프로그래스 바가 가득 차게됨
            //while (true)
            //{
            //    progressBar1.Value += 1;

            //    if (progressBar1.Value >= 100) break;
            //}

            //BackgroundWorker가 실행 중이 아니라면 실행
            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }
        }
    }
}
