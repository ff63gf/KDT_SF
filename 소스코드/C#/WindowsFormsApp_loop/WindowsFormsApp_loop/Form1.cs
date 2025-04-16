using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_loop
{
    public partial class Form1 : Form
    {
        #region
        // 매번 다른 랜덤 값을 받으려면 객체가 사라져서는 안됨
        Random rand = new Random();

        enum RSP
        {
            rock,
            scissors,
            paper
        }
        RSP userRSP;

        int user_score = 0;
        int com_score = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // 키보드 입력을 감지하기 위해 필요한 옵션

            #region 반복문 강의
            //string message = "";
            //for (int i = 0; i < 10; i++)
            //{
            //    message += "반복 횟수: " + i.ToString() + "\r\n";
            //}
            //textBox_result.Text = message;

            //int array_size = 10;
            //int[] loopCount = new int[array_size];
            //for (int i = 0; i < array_size; i++)
            //{
            //    loopCount[i] = i; // index로 i를 사용
            //}
            //textBox_result.Text = loopCount[loopCount.Length - 1].ToString();

            //int count = 0;
            //while(count < 100)
            //{
            //    // 반복할 소스코드
            //    count++;
            //}

            ////bool run = true;
            ////while (run)
            ////{
            ////    // 반복할 소스코드

            ////    if("반복을 종료하고 싶다면" == "")
            ////    {
            ////        run = false;
            ////    }
            ////}

            ////while (true)
            ////{
            ////    if ("반복을 종료하고 싶다면" == "")
            ////    {
            ////        break;
            ////    }
            ////}

            //for (int i = 0; i < 10; i++)
            //{
            //    if(i == 5)
            //    {
            //        // i가 5일때 반복문 다시 시작 
            //        // 결과적으로 i = 6 이 실행됨
            //        continue;
            //    }
            //}

            #endregion

            #region 실습.for문
            // button_input_Click() 이벤트 처리함수를 확인
            #endregion

            #region 실습.while문
            // button_rock, button_scissors, button_paper 확인
            #endregion
        }

        #region 실습코드
        private void button_input_Click(object sender, EventArgs e)
        {
            textBox_result.Text = ""; // 결과창 비우고 시작

            // 숫자를 입력했을 때만 실행
            int studentCount = 0;
            if(int.TryParse(textBox_input.Text, out studentCount))
            {
                string[] studentNames = new string[studentCount];
                int[] studentScore = new int[studentCount];

                for(int i = 0; i < studentCount; i++)
                {
                    studentNames[i] = "학생" + i.ToString();
                    studentScore[i] = rand.Next(0, 101);

                    textBox_result.Text += CombineNameAndScore(studentNames[i], studentScore[i]) + "\r\n";
                }
            }
            else
            {
                textBox_result.Text = "숫자를 입력하라고 했을텐데..?";
            }
        }

        private void button_scissors_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.scissors);
        }

        private void button_rock_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.rock);
        }

        private void button_paper_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.paper);
        }

        // 모든 게임 로직을 관리하는 함수
        void PlayRSPGame(RSP user)
        {
            if (RSPGame(user))
            {
                textBox_result.Text = "용사의 승리!\r\n";
                this.user_score++;
                textBox_userScore.Text = this.user_score.ToString();

                if (this.user_score >= 3)
                {
                    textBox_result.Text += "용사가 마왕을 무찔렀다~!\r\n(∩^o^)⊃━☆";
                    this.user_score = this.com_score = 0;
                }
            }
            else
            {
                textBox_result.Text = "마왕의 승리..! 으아아 분하다!!\r\n";
                this.com_score++;
                textBox_comScore.Text = this.com_score.ToString();

                if (this.com_score >= 3)
                {
                    textBox_result.Text += "마왕이 우주를 정복했다...!\r\n(;´༎ຶД༎ຶ`)";
                    this.user_score = this.com_score = 0;
                }
            }

            
        }
        
        bool RSPGame(RSP user)
        {
            RSP pick = (RSP)this.rand.Next(0, 3);

            if(user == pick)
            {
                return true;
            }
            return false;
        }

        string CombineNameAndScore(string name, int score)
        {
            return name + "의 점수: " + score.ToString() + "점";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_input.PerformClick();
            }
        }
        #endregion
    }
}
