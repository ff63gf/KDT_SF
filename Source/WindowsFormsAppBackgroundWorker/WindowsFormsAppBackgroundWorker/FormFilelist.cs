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

/* 
 * < BackgroundWorker 즉석 실습문제 >
 * 1. 폼에 TextBox, Button, ListBox를 추가하세요.
 * 2. TextBox에 디렉토리 경로를 입력받고, Button을 클릭하면 그 디렉토리와 하위 디렉토리에서 특정 확장자의 파일을 검색하세요.
 * 3. 특정 확장자도 TextBox로 입력을 받아주세요.
 * 4. BackgroundWorker를 사용하여 파일 검색 작업을 비동기로 수행하세요.
 * 5. 검색된 파일 목록을 ListBox에 표시하세요.
 * 
 */



namespace WindowsFormsAppBackgroundWorker
{
    public partial class FormFilelist : Form
    {
        BackgroundWorker backgroundWorker;
        string path;

        public FormFilelist()
        {
            InitializeComponent();

            comboBox_format.SelectedIndex = 0;

            backgroundWorker = new BackgroundWorker(); 
            backgroundWorker.WorkerReportsProgress = true; 
            backgroundWorker.DoWork += backgroundWorker_DoWork; 
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged; 
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private void button_load_Click(object sender, EventArgs e)
        {          
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.path = folderBrowserDialog1.SelectedPath;
                textBox_path.Text = this.path;

                string format = comboBox_format.SelectedItem.ToString();
                string args = this.path + "," + format;

                if (!backgroundWorker.IsBusy)
                {
                    listBox_fileList.Items.Clear();
                    backgroundWorker.RunWorkerAsync(args);
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string directoryPathAndFormat = e.Argument as string;
            // 0: path, 1: file format
            string[] pathAndFormat = directoryPathAndFormat.Split(',');

            if (Directory.Exists(pathAndFormat[0]))
            {
                string[] files = Directory.GetFiles(pathAndFormat[0], pathAndFormat[1], SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    backgroundWorker.ReportProgress((i + 1) * 100 / files.Length, files[i]);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBox_fileList.Items.Add(e.UserState.ToString());
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("파일 검색이 완료되었습니다.");
        }
    }
}