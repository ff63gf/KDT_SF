using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 변수를 여러개를 하나의 배열로 처리
            int num1, num2, num3, num4, num5, num6, num7, num8;
            int[] nums = new int[8];

            // 입력되는 데이터의 크기를 알 수 없을 때, 배열로 처리
            int inputCount = 10; // 사용자가 입력했다고 가정
            int[] inputData = new int[inputCount];

            // 배열의 각 요소에 접근, Index는 0부터 시작
            inputData[0] = 20;
            int oneOfData = inputData[0];

            string myName = "Leader_" + "John" + " " + 999.ToString();            

            int[] array1 = new int[5];
            int[] array2 = { 1, 2, 3, 4, 5, 6 }; //new int[6];
            int[,] multiDimensionalArray1 = new int[2, 3];
            int[,] multiDimensionalArray2 = { { 1, 2, 3, }, { 4, 5, 6, } };//new int[2, 3];
            int[][] jaggedArray = new int[6][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[3] { 1, 2, 3 };

            for(int i = 0; i < array2.Length; i++)
            {
                textBox1.Text += array2[i].ToString() + "\r\n";
            }
            textBox1.Text = array2.Length.ToString() + "\r\n";
            textBox1.Text += multiDimensionalArray2.Length.ToString();
            textBox1.Text += "\r\n";
            multiDimensionalArray2.GetLength(0);
            textBox1.Text += multiDimensionalArray2.GetLength(0).ToString() + "\r\n";
            textBox1.Text += multiDimensionalArray2.GetLength(1).ToString() + "\r\n";
            for (int i = 0;i < multiDimensionalArray2.GetLength(0); i++)
            {
                for(int j=0; j< multiDimensionalArray2.GetLength(1); j++)
                {
                    textBox1.Text += multiDimensionalArray2[i,j].ToString() + "\r\n";
                }
            }

            string[] a = "1 2 3".Split(' ');
            textBox1.Text = a[0] + "\r\n";
            textBox1.Text += a[1] + "\r\n";
            textBox1.Text += a[2] + "\r\n";
            string codingon = "codingon";
            textBox1.Text = codingon.IndexOf('o').ToString();
            codingon.Replace("on", "off");

            string q = "string 5";
            string[] parsed = q.Split(' ');
            int count = int.Parse(parsed[1]);
            textBox1.Text = "";
            for (int i=0; i<count; i++)
            {
                textBox1.Text += parsed[0];
            }

            /* 
             * 함수
             */
            int num = 200;
            int result = Add(100, num);

            Nothing();

            float[] divAndRemain_result = DivAndRemain(5, 3);
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        void Nothing()
        {

        }

        // 함수 실습
        float[] DivAndRemain(int num, int div_num)
        {
            float[] result = new float[2];
            result[0] = num / div_num;
            result[1] = num % div_num;

            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
