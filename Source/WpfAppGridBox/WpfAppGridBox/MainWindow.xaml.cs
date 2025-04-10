using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppGridBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Data
    {
        public string name { get; set; }
        public string id { get; set; }
        public string major { get; set; }
        public int grade { get; set; }
        public string etc { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Data> list = new List<Data>();
            list.Add(new Data { name = "이지원", id = "210651", major = "컴퓨터공학", grade = 1, etc = "" });
            list.Add(new Data { name = "김현호", id = "210184", major = "컴퓨터공학", grade = 1, etc = "" });
            list.Add(new Data { name = "강희진", id = "210017", major = "컴퓨터공학", grade = 1, etc = "" });
            list.Add(new Data { name = "박서준", id = "210439", major = "컴퓨터공학", grade = 1, etc = "" });
            list.Add(new Data { name = "강나연", id = "210005", major = "컴퓨터공학", grade = 1, etc = "" });
            StudentList.ItemsSource = list;
        }

        private void StudentList_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Data selected = StudentList.SelectedItem as Data;
            //if (selected != null) 
            //{ 
            //    MessageBox.Show(selected.id);
            //}
            //string names = string.Empty;
            //foreach(Data data in StudentList.SelectedItems)
            //{
            //    names += data.name;
            //}
            //MessageBox.Show($"{names} 선택됨");
        }
    }
}