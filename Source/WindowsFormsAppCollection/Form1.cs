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

        public enum Weekday
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public Form1()
        {
            InitializeComponent();

            //Stack stack = new Stack();

            //stack.Push("일");
            //stack.Push("이");
            //stack.Push("삼");
            //stack.Push(1);
            //stack.Push(1f);

            //try
            //{
            //    int stack_size = stack.Count;
            //    for (int i = 0; i < stack_size + 1; i++)
            //    {
            //        textBox1.Text += $"{stack.Peek()}\r\n";
            //        textBox1.Text += $"{stack.Pop()}\r\n";
            //    }
            //}
            //catch (Exception e)
            //{
            //    textBox1.Text += e.Message;
            //}

            //printP(1);

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

            //Hashtable hashtable = new Hashtable();

            //hashtable[0] = 999;
            //hashtable["이름"] = 999;
            //hashtable["취미"] = "게에이임";

            //textBox1.Text += $"{hashtable[0]}\r\n";
            //textBox1.Text += $"{hashtable["이름"]}\r\n";
            //textBox1.Text += $"{hashtable["취미"]}\r\n";

            //Stack<int> i_stack = new Stack<int>();
            //i_stack.Push(1);
            //int num = i_stack.Pop();
            //textBox1.Text += $"{num}\r\n";
            ////i_stack.Push(1f);

            ////List list = new List();
            //List<double> d_list = new List<double>();
            //float f = 0.0f;
            //float ff = 1.0f / 2;
            //textBox1.Text += $"ff {ff}\r\n";
            //d_list.Add(f);
            //d_list.Add(30.409f);
            //d_list.Add(329.329f);

            //foreach(double d in d_list)
            //{
            //    textBox1.Text += $"{d}\r\n";
            //}

            //int monday = 1;
            //int tuesday = 2;

            //Weekday today = Weekday.Monday;
            //today = Weekday.Monday;
            ////today = 2;

            //int size = 10;
            //var numbers = Enumerable.Range(1, size);
            //var same_numbers = Enumerable.Repeat(0, size);
            //var numbers_array = Enumerable.Range(1, size).ToArray();

            //textBox1.Text += $"numbers {numbers}\r\n";
            //textBox1.Text += $"same_numbers {same_numbers}\r\n";

            //foreach ( var number in numbers )
            //{
            //    textBox1.Text += $"{number} ";
            //}
            //textBox1.Text += $"\r\n";
            //// string.Join() 써서 same_numbers 출력!

            //textBox1.Text += $"same_numbers {string.Join(", ", same_numbers)} ";

            //textBox1.Text += $"\r\n";
            //for (int i=1; i<=10; i++)
            //{
            //    textBox1.Text += $"{i} ";
            //}

            //textBox1.Text += $"\r\n";
            //foreach (var i in Enumerable.Range(1, 10).Reverse())
            //{
            //    textBox1.Text += $"{i} ";
            //}

            IDictionary<string, string> data1 = new Dictionary<string, string>(); ;

            var data2 = new Dictionary<string, string>();

            data1.Add("오리온", "고래밥");
            data1.Add("농심", "신라면");

            data1.Remove("오리온");
            data2["농심"] = "너구리";

            try
            {
                data2.Add("농심", "짜파게티");
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                textBox1.Text = data2["농심"];
                //textBox1.Text = data2["해태"];
            }

            if(!data1.ContainsKey("오리온"))
            {
                data1.Add("오리온", "초코파이");
            }

            if(data1.TryGetValue("해태", out string value))
            {
                textBox1.Text = $"TryGetValue {value}\r\n";
            }

            foreach(KeyValuePair<string, string> item in data1)
            {
                textBox1.Text += $"{item.Key}에서 {item.Value}를 만든당.\r\n";
            }

            foreach (var item in data1)
            {
                textBox1.Text += $"{item.Key}에서 {item.Value}를 만든당.\r\n";
            }
        }

        //void printP(int c)
        //{
        //    if (c == 4) { return; }
        //    printP(c + 1);
        //    switch (c)
        //    {
        //        case 1:
        //            textBox1.Text += "일\r\n";
        //            break;
        //        case 2:
        //            textBox1.Text += "이\r\n";
        //            break;
        //        case 3:
        //            textBox1.Text += "삼\r\n";
        //            break;
        //    }
        //}
    }
}
