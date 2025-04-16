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

namespace WindowsFormsAppAsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async void button_run_Click(object sender, EventArgs e)
        {
            //string result = await AsyncOperation3();

            textBox_print.Text = "Working..\r\n";

            // Task 인스턴스 생성 및 실행
            Task task = new Task(() =>
            {
                // 다른 스레드 영역
                Thread.Sleep(1000);
            });
            task.Start();
            await task; // task 종료까지 대기

            int result = await AsyncOperation1();
            textBox_print.Text += $"AO1 Done: {result}\r\n";

            result = await AsyncOperation2();
            textBox_print.Text += $"AO2 Done: {result}\r\n";
        }

        // Task.Delay() 및 Invoke 활용
        // async로 선언했기 때문에 await 사용 가능
        async Task<int> AsyncOperation1()
        {
            // Delay(): await과 함께 사용시 스레드를 멈추지 않고 시간만큼 대기
            await Task.Delay(1000); // 이 부분만 비동기 처리

            // 비동기 처리 중이어서 Invoke가 필요한 상황인지 판단
            if (textBox_print.InvokeRequired)
            {
                // Action은 입출력이 없는 delegate
                // 주로 람다식과 함께 간편하게 delegate를 표현하는데 사용
                this.Invoke((Action)(() =>
                {
                    // 비동기 처리되고 있으므로 UI 업데이트를 위해 Invoke 사용
                    textBox_print.Text += "Invoke Action\r\n";
                }));
            }
            else
            {
                textBox_print.Text += "Invoke Action\r\n";
            }

            return 88;
        }

        // Task 선언과 동시에 실행
        Task<int> AsyncOperation2()
        {
            return Task.Run(() =>
            {
                // 새 스레드에서 동작할 코드
                Thread.Sleep(1000); // 시간 만큼 스레드 멈춤
                return 99;
            });
        }

        async Task<string> AsyncOperation3()
        {
            string word = "";
            for (int i = 0; i < 12345678; i++)
            {
                word = i.ToString();
            }

            return word;
        }
    }
}
