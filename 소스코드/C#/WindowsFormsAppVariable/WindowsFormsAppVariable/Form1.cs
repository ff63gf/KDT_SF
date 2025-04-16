using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppVariable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 변수의 선언
            int numOfCrew;

            // 변수의 사용 (값 복사)
            numOfCrew = 19;

            // 변수의 초기화
            string className = "말하기 듣기";

            // 변수의 값 덮어쓰기
            className = "기술 가정";

            // 선언보다 밑에 줄에서 사용가능
            //lineCount = 10;
            int lineCount;


            // 같은 이름 사용 불가
            byte buffer;
            //float buffer;

            // 데이터 타입이 다르면 복사 불가
            int number = 10;
            string word = "안녕";
            //number = word;

            // 변수끼리 값 복사
            int var_x = 10;
            int var_y = var_x; // x->y로 복사

            // 사칙 연산 및 괄호 활용
            int var_z = var_x * var_y;
            int result = var_z + (var_x + 5);

            {
                int inside = 100;
            }

            // inside와 Scope가 달라서 사용 불가
            //int outside = inside + 50;


            /*
             * 실습. 변수 및 캐스팅
             */

            byte retroColorRed = 20;
            long distanceToCanada_cm = 4938719872918211231;

            textBox_print.Text += retroColorRed.GetType() + " retroColorRed: " + retroColorRed.ToString() + "\r\n";
            textBox_print.Text += distanceToCanada_cm.GetType() + " distanceToCanada_cm: " + retroColorRed.ToString() + "\r\n";
        }
    }
}
