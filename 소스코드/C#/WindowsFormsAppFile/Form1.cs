using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //string content = File.ReadAllText(@"C:\workspace\KDT_SF_Hard_2nd\code\CS\WindowsFormsAppFile\test.txt");
            string content = File.ReadAllText("test.txt");
            textBox1.Text = content;

            //string a = @"\";
            //textBox1.Text = a;
        }
    }
}
