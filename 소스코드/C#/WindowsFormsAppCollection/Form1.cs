using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region stack
            Stack stack = new Stack();

            // 자료형과 상관없이 값을 입력 가능
            stack.Push("일");
            stack.Push("이");
            stack.Push("삼");
            stack.Push(1);
            stack.Push(1f);

            try
            {
                int stack_size = stack.Count;
                for (int i = 0; i < stack_size + 1; i++)
                {
                    textBox1.Text += $"{stack.Peek()}\r\n";
                    textBox1.Text += $"{stack.Pop()}\r\n";
                }
            }
            catch (Exception e)
            {
                textBox1.Text += e.Message;
            }
            #endregion

            #region queue
            //Queue queue = new Queue();

            //queue.Enqueue(10);
            //queue.Enqueue(20);
            //queue.Enqueue(30);

            //try
            //{
            //    int queue_size = queue.Count;
            //    for (int i = 0; i < queue_size + 1; i++)
            //    {
            //        textBox1.Text += $"{queue.Dequeue()}\r\n";
            //    }
            //}
            //catch (Exception e)
            //{
            //    textBox1.Text += e.Message;
            //}
            #endregion

            #region hashtable
            Hashtable hashtable = new Hashtable();

            hashtable[0] = 999;
            hashtable["이름"] = 999;
            hashtable["취미"] = "게에이임";

            textBox1.Text += $"{hashtable[0]}\r\n";
            textBox1.Text += $"{hashtable["이름"]}\r\n";
            textBox1.Text += $"{hashtable["취미"]}\r\n";
            #endregion

            #region stack<T>
            //Stack<int> i_stack = new Stack<int>();
            //i_stack.Push(1);
            //int num = i_stack.Pop();
            //textBox1.Text += $"{num}\r\n";
            ////i_stack.Push(1f);
            #endregion

            #region List<T>
            //List list = new List();
            //List<double> d_list = new List<double>();
            //float f = 0.0f;
            //float ff = 1.0f / 2;
            //textBox1.Text += $"ff {ff}\r\n";
            //d_list.Add(f);
            //d_list.Add(30.409f);
            //d_list.Add(329.329f);

            //foreach (double d in d_list)
            //{
            //    textBox1.Text += $"{d}\r\n";
            //}
            #endregion

            #region Dictionary
            //IDictionary<string, string> data1 = new Dictionary<string, string>(); ;

            //var data2 = new Dictionary<string, string>();

            //data1.Add("오리온", "고래밥");
            //data1.Add("농심", "신라면");

            //data1.Remove("오리온");
            //data2["농심"] = "너구리";

            //try
            //{
            //    // 이미 존재하는 인덱스 추가시 오류
            //    data2.Add("농심", "짜파게티");
            //}
            //catch (Exception ex)
            //{
            //    textBox1.Text = ex.Message;
            //}
            //finally
            //{
            //    textBox1.Text = data2["농심"];
            //    //textBox1.Text = data2["해태"];
            //}

            //// Key 값을 기준으로 검색 가능
            //if(!data1.ContainsKey("오리온"))
            //{
            //    data1.Add("오리온", "초코파이");
            //}

            //// 오류 처리 기능이 포함된 Try 메소드가 존재함
            //if(data1.TryGetValue("해태", out string value))
            //{
            //    textBox1.Text = $"TryGetValue {value}\r\n";
            //}

            //// KeyValuePair 기능을 활용한 탐색
            //foreach(KeyValuePair<string, string> item in data1)
            //{
            //    textBox1.Text += $"{item.Key}에서 {item.Value}를 만든당.\r\n";
            //}

            //// var를 이용해 간단하게 표현하는 방법
            //foreach (var item in data1)
            //{
            //    textBox1.Text += $"{item.Key}에서 {item.Value}를 만든당.\r\n";
            //}
            #endregion
        }
    }
}
