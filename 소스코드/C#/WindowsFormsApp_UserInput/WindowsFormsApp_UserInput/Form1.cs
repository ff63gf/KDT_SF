using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_UserInput
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            // textBox_input.Text의 문자열을 
            // textBox_result.Text로 복사
            //textBox_result.Text = textBox_input.Text;

            bool input = false;

            // 문자열의 길이가 0보다 클 경우 == 뭐라도 적혀 있는 경우
            if (textBox_input.Text.Length > 0)
            {
                string inputText = textBox_input.Text;

                if (!(inputText == "true" || inputText == "false"))
                {
                    textBox_result.Text = "에러: true 또는 false 만 입력해주세요!";
                    // void 타입 함수에서 return을 사용하면 아무것도 반환하지 않고 함수 종료
                    return; 
                }
                else
                {
                    input = bool.Parse(inputText);
                }
            }
            else if(radioButton_true.Checked)
            {
                input = true;
            }   
            // 그냥 else를 써도 무방하지만
            // radioButton_false와 연관이 있다는 사실을 더 정확히 
            // 전달하기 위해서 else if를 사용함
            else if(radioButton_false.Checked)
            {
                input = false;
            }

            textBox_result.Text = "입력하신 값은 " + input.ToString() + " 입니다!\r\n";
            textBox_result.Text += "동전 던지기 결과...\r\n";

            string gameResultMessage;
            if (FrontAndBack(input) == true)
            {
                gameResultMessage = "승리~!";
            }
            // else if를 쓸 경우 FrontAndBack()이 한 번 더 실행되기 때문에
            // else if 대신 else를 사용
            else
            {
                gameResultMessage = "패배ㅠㅠ";
            }
            textBox_result.Text += gameResultMessage + "\r\n";
        }

        bool FrontAndBack(bool type)
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
    }
}
