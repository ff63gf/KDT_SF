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
using System.IO;
using Microsoft.Win32;

namespace WpfAppImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool btn_image_cat = true;
        Uri uriCatImage;
        Uri uriDogImage;

        public MainWindow()
        {
            InitializeComponent();

            this.uriCatImage = new Uri(@"pack://application:,,,/Resources/cat.jpg", UriKind.Absolute);
            this.uriDogImage = new Uri(@"pack://application:,,,/Resources/dog.jpg", UriKind.Absolute);
            //this.uriCatImage = new Uri("/Resources/cat.jpg", UriKind.Relative);
            //this.uriDogImage = new Uri("/Resources/dog.jpg", UriKind.Relative);
            //this.uriCatImage = new Uri(@"/WpfAppImage;component/Resources/cat.jpg", UriKind.Relative);
            //this.uriDogImage = new Uri(@"/WpfAppImage;component/Resources/dog.jpg", UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.btn_image_cat)
            {
                Btn1.Background = new ImageBrush(new BitmapImage(this.uriCatImage));
                ImageBox1.Source = new BitmapImage(this.uriDogImage);
                this.btn_image_cat = false;
            } else
            {
                Btn1.Background = new ImageBrush(new BitmapImage(this.uriDogImage));
                ImageBox1.Source = new BitmapImage(this.uriCatImage);
                this.btn_image_cat = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //MessageBox.Show(openFileDialog.FileName);
                Uri uri = new Uri(openFileDialog.FileName);
                BitmapImage bitmapImage = new BitmapImage(uri);
                Btn2.Background = new ImageBrush(bitmapImage);
                Btn2.Width = bitmapImage.Width / 4;
                Btn2.Height = bitmapImage.Height / 4;
            }
        }
    }
}