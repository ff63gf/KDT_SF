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
using Microsoft.Web.WebView2.Core;

namespace WpfAppWebView2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public enum FavOption
    {
        Add,
        Load
    }
    public partial class MainWindow : Window
    {
        FavOption option = FavOption.Add;
        public MainWindow()
        {
            InitializeComponent();
            LoadListBoxContent();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (webView != null && webView.CoreWebView2 != null && !string.IsNullOrWhiteSpace(addressBar.Text))
                {
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }
                else
                {
                    // URL이 비었거나, 유효하지 않은 경우에 대한 처리
                    MessageBox.Show("유효한 URL을 입력해 주세요.");
                }
            }
            catch (ArgumentException ex)
            {
                // URL 형식이 잘못된 경우에 대한 처리
                MessageBox.Show($"잘못된 URL 형식입니다: {ex.Message}");
            }

        }

        private void radioBtnAdd_Checked(object sender, RoutedEventArgs e)
        {
            option = FavOption.Add;
        }

        private void radioBtnLoad_Checked(object sender, RoutedEventArgs e)
        {
            option = FavOption.Load;
        }

        private void btnFavorite_Click(object sender, RoutedEventArgs e)
        {
            switch (option)
            {
                case FavOption.Add:
                    listBox.Items.Add(webView.CoreWebView2.Source.ToString());
                    SaveListBoxContent();
                    break;
                case FavOption.Load:
                    if (webView != null && webView.CoreWebView2 != null)
                        webView.CoreWebView2.Navigate(listBox.SelectedItem.ToString());
                    break;
                default:
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void SaveListBoxContent()
        {
            string outputPath = "favorite.fvr";
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                foreach (var item in listBox.Items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        private void LoadListBoxContent()
        {
            string inputPath = "favorite.fvr";

            if (!File.Exists(inputPath))
                return;

            listBox.Items.Clear(); // 기존 항목들을 지우고 시작

            using (StreamReader sr = new StreamReader(inputPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox.Items.Add(line);
                }
            }
        }


    }
}