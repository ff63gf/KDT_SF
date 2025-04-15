using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                string content = File.ReadAllText(@"input.txt");
            }
            catch (IOException ex)
            {
                textBox1.Text += "파일이 없습니다.\r\n";
            }
            catch (Exception ex)
            {
                textBox1.Text += ex.Message + "\r\n";
            }
            finally
            { 
                try
                {
                    //string[] contents = getFileContents("./input.txt");
                    string[] contents;
                    getFileContents2(@"input.txt", out contents);

                    foreach (string line in contents)
                    {
                        textBox1.Text += line;
                    }
                }
                catch (Exception e)
                {
                    textBox1.Text += e.Message + "\r\n";
                }
                finally
                {
                    textBox1.Text += "완료\r\n";
                }
            }
        }

        string[] getFileContents(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            string content = File.ReadAllText(filePath);
            return content.Split('\n');
        }

        void getFileContents2(string filePath, out string[] result)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            string content = File.ReadAllText(filePath);
            result = content.Split('\n');

            for (int i = 0; i < result.Length; i++)
            {
                string word = result[i];
                try
                {
                    int number = int.Parse(word);
                    result[i] = $"숫자 {word}\r\n";
                }
                catch
                {
                    result[i] = $"문자 {word}\r\n";
                }
            }
        }
    }
}
