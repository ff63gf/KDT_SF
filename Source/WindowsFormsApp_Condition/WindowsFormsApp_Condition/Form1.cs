using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Condition
{
    public partial class Form1 : Form
    {
        enum Food
        {
            Pizza,      // 0
            Burger,     // 1
            Pasta,      // 2
            Kimchi = 100 // 값 지정 가능
        }

        enum Week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
            Error = 999
        }


        public Form1()
        {
            InitializeComponent();


            #region 파일활용
            Class1 myFunctions = new Class1();
            int result = myFunctions.Sum(100, 300);

            double value = myFunctions.d_value;
            #endregion

            #region if 문 강의
            //int inputNum = 10;

            //if (inputNum > 20)
            //{
            //    // inputNum은 20보다 크지 않음: false
            //}
            //else if (inputNum < 5)
            //{
            //    // inputNum은 20보다 크지 않고, 5보다 작지 않음: false
            //}
            //else if (inputNum == 8)
            //{
            //    // inputNum은 20보다 크지 않고, 5보다 작지 않고, 8도 아님: false
            //}
            //else
            //{
            //    // 위 조건이 모두 false 일 경우 실행
            //}

            //bool is_true = inputNum == 10; // == 의 연산결과: true

            //// (조건1) OR (조건2)
            //bool compared = (inputNum > 10 || inputNum < 5);
            #endregion

            #region 실습. if 문
            //if (FrontOrBack(true))
            //{
            //    textBox_print.Text = "승리~!";
            //}
            //else
            //{
            //    textBox_print.Text = "패배ㅠㅠ";
            //}

            #endregion

            #region switch 문 강의

            string animal = "Cat";

            switch (animal)
            {
                case "Dog":
                    // animal == "Dog" 일때 실행되는 코드
                    break;

                case "Cat":
                    // animal == "Cat" 일때 실행되는 코드
                    break;

                default:
                    // 위 case들에 모두 해당되지 않는다면 실행
                    break;
            }

            Food food = Food.Kimchi;

            if (food > Food.Pizza)
            {
                // Pizza = 0, Kimchi = 100 이므로 true
            }

            switch (food)
            {
                case Food.Pizza:
                    break;

                case Food.Burger:
                    break;

                case Food.Pasta:
                    break;

                case Food.Kimchi:
                    // 간단하게 정수로 캐스팅해서 사용 가능
                    int price = (int)Food.Kimchi;
                    break;
            }

            #endregion
        }

        bool FrontOrBack(bool type)
        {
            Random randomObj = new Random();

            // 2로 나눈 나머지 값은 0 또는 1 뿐
            int frontOrBack = randomObj.Next() % 2;

            if ((frontOrBack == 1 && type == true) ||
                (frontOrBack == 0 && type == false))
            {
                return true;
            }

            // else에 들어가는 것도 상관없음
            // 개인적으로는 모든 return이 중괄호에 있는 것이 
            // 직관적이지 않다고 판단하여 else를 사용하지 않았음
            return false;
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            Week week = InputCheck(textBox_input.Text);

            switch (week)
            {
                case Week.Monday:
                    textBox_print.Text = "심근경색, 월요일이 가장 위험, 출근은 안 해야..";
                    break;
                case Week.Tuesday:
                    textBox_print.Text = "매일매일 변함없이 일하기 싫은 것을 보면, 난 참 꾸준한 사람이야!";
                    break;
                case Week.Wednesday:
                    textBox_print.Text = "A: 너무 힘들다.. 그래도 내일 금요일 이니까\r\n"
                        + "B: 오늘 수요일이야.";
                    break;
                case Week.Thursday:
                    textBox_print.Text = "금요일인 줄 착각했다가 억장 무너지는 날";
                    break;
                case Week.Friday:
                    textBox_print.Text = "오늘은 신나는 기분이야 ╰(*°▽°*)╯";
                    break;
                case Week.Saturday:
                    textBox_print.Text = "내 토요일 내놔!";
                    break;
                case Week.Sunday:
                    textBox_print.Text = "현실 부정중인 1인";
                    break;
                case Week.Error:
                    textBox_print.Text = "요일이 뭔지 모르시나보군요?";
                    break;
            }            
        }

        Week InputCheck(string message)
        {
            Week week;

            switch (message)
            {
                case "월요일":
                    return Week.Monday;
                case "화요일":
                    return Week.Tuesday;
                case "수요일":
                    return Week.Wednesday;
                case "목요일":
                    return Week.Thursday;
                case "금요일":
                    return Week.Friday;
                case "토요일":
                    return Week.Saturday;
                case "일요일":
                    return Week.Sunday;
                default:
                    return Week.Error;
            }
        }
    }
}
