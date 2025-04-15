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

namespace WindowsFormsAppAsyncAwait
{
    public partial class FormAsync : Form
    {
        public FormAsync()
        {
            InitializeComponent();
        }
                
        async void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                try
                {
                    // async로 선언되어 있지만 await로 호출될 일이 없도록 
                    // void를 출력으로 설정해 놨기 때문에 UI 컨트롤에 직접 접근
                    textBox1.Text = "File loading...\r\n";
                    string content = await ReadFileAsync(path);
                    textBox1.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        async Task<string> ReadFileAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
