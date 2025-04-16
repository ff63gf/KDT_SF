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

namespace WpfAppSlider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int option = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setGridBGColor()
        {
            int r = (int)SliderRed.Value;
            int g = (int)SliderGreen.Value;
            int b = (int)SliderBlue.Value;
            if (option == 1)
            {
                int mid = (r + g + b) / 3;
                r = g = b = mid;
            }else if (option == 2)
            {
                r = 255 - r;
                g = 255 - g;
                b = 255 - b;
            }
            MainGrid.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
        }

        private void SliderRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LabelRed == null) { return; }
                LabelRed.Content = e.NewValue;
            setGridBGColor();
        }

        private void SliderGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LabelGreen == null) { return; }
            LabelGreen.Content = e.NewValue;
            setGridBGColor();
        }

        private void SliderBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LabelBlue == null) { return; }
            LabelBlue.Content = e.NewValue;
            setGridBGColor();
        }

        private void RadioOrg_Checked(object sender, RoutedEventArgs e)
        {
            option = 0;
            setGridBGColor();
        }

        private void RadioGray_Checked(object sender, RoutedEventArgs e)
        {
            option = 1;
            setGridBGColor();
        }

        private void RadioInvert_Checked(object sender, RoutedEventArgs e)
        {
            option = 2;
            setGridBGColor();
        }
    }
}