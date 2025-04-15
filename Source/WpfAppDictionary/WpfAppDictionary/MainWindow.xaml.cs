using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true) 
            { 
                string path = ofd.FileName;
                var fileStream = ofd.OpenFile();
                using (StreamReader sr = new StreamReader(fileStream))
                {
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
                }
            }
            foreach (KeyValuePair<string, string> kvp in idPws)
            {
                MessageBox.Show(kvp.Key + ", " + kvp.Value);
            }
            foreach (KeyValuePair<string, string> kvp in idContacts)
            {
                MessageBox.Show(kvp.Key + ", " + kvp.Value);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(idPws.ContainsKey(textBoxID.Text))
            {
                if (idPws[textBoxID.Text] == textBoxPW.Text)
                {
                    MessageBox.Show($"로그인 성공\r\n{textBoxID.Text} {idContacts[textBoxID.Text]}");
                } else
                {
                    MessageBox.Show("비밀번호가 틀렸습니다.");
                }
            }
            else
            {
                MessageBox.Show("아이디가 존재하지 않습니다");
            }

            if (infos.ContainsKey(textBoxID.Text))
            {
                if (infos[textBoxID.Text].pw == textBoxPW.Text)
                {
                    MessageBox.Show($"로그인 성공\r\n{textBoxID.Text} {infos[textBoxID.Text].contact}");
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