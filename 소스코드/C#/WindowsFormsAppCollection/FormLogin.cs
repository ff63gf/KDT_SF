using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppCollection
{
    public partial class FormLogin : Form
    {
        public struct Info
        {
            public string id;
            public string pw;
            public string contact;
        }
        Dictionary<string, string> idPws = new Dictionary<string, string>();
        Dictionary<string, string> idContacts = new Dictionary<string, string>();
        Dictionary<string, Info> infos = new Dictionary<string, Info>();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            // 파일 다이얼로그를 사용한 파일 선택 및 읽기
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                var fileStream = ofd.OpenFile();

                // using을 사용하여 객체의 생존범위 (중괄호)를 지정 가능
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    // 파일의 내용을 줄 단위로 읽어옴
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] info = line.Split(',');
                        idPws[info[0]] = info[1];
                        idContacts[info[0]] = null;
                        if (info.Length > 2)
                        {
                            idContacts[info[0]] = info[2];
                        }

                        Info info1 = new Info();
                        info1.id = info[0];
                        info1.pw = info[1];
                        info1.contact = null;
                        if (info.Length > 2)
                        {
                            info1.contact = info[2];
                        }
                        infos.Add(info1.id, info1);
                    }
                    MessageBox.Show("파일 불러오기 완료");
                }
            }
            //foreach (KeyValuePair<string, string> kvp in idPws)
            //{
            //    MessageBox.Show(kvp.Key + ", " + kvp.Value);
            //}
            //foreach (KeyValuePair<string, string> kvp in idContacts)
            //{
            //    MessageBox.Show(kvp.Key + ", " + kvp.Value);
            //}            
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string id = textBox_id.Text;
            string pw = textBox_pw.Text;

            if (idPws.ContainsKey(id))
            {
                if (idPws[id] == pw)
                {
                    MessageBox.Show($"로그인 성공\r\n{id} {idContacts[id]}");
                }
                else
                {
                    MessageBox.Show("비밀번호가 틀렸습니다.");
                }
            }
            else
            {
                MessageBox.Show("아이디가 존재하지 않습니다");
            }
        }
    }    
}
