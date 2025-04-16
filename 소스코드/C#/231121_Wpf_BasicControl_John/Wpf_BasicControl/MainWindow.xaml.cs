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

namespace Wpf_BasicControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WebBrowser1.Navigate("http://www.naver.com");
            DataContext = new ViewModel();
            
        }

        // 라디오 버튼이 체크될 때 실행됨, 체크 해제 시 실행 안됨
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if(radioButton1.IsChecked == true)
            {
                // 라디오 버튼이 체크되었을 경우 실행될 코드
            }
        }

        // 체크 박스가 체크되면 실행됨, 체크 해제 시 실행 안됨
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBox1.IsChecked == true)
            {
                // 체크 박스가 체크 되었을 경우 실행될 코드
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {            
            comboBox.Items.Add(textBox.Text);
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Remove(comboBox.SelectedItem);
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label_sliderValue.Content = slider1.Value;
        }
    }
}