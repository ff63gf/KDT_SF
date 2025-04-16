using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string calculateText = "";
        List<string> history = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            labelNumber.Text = "";
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " + ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " - ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " * ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " / ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        { 
            if (labelNumber.Text.ToString().Length == 0) return;

            string content = labelResult.Text.ToString() + labelNumber.Text.ToString();

            labelResult.Text = content;

            string lastTxt = Regex.Replace(content, @",", "");

            DataTable table = new DataTable();
            object result = table.Compute(lastTxt, String.Empty);
            labelResult.Text += " =";
            labelNumber.Text = result.ToString();
            calculateText = "";

            history.Add(labelResult.Text + labelNumber.Text);
            if (history.Count > 5)
            {
                history.RemoveAt(0);
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            calculateText = "";
            labelNumber.Text = "";
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "0";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "2";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "3";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "4";
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "5";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "6";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "7";
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "8";
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text += "9";
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
        }

        private void buttonPercent_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            calculateText += labelNumber.Text + " % ";
            labelResult.Text = calculateText;
            labelNumber.Text = "";
        }

        private void buttonSign_Click(object sender, RoutedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            if (labelNumber.Text[0] == '-')
            {
                labelNumber.Text = labelNumber.Text.Remove(0, 1);
            }
            else
            {
                labelNumber.Text = labelNumber.Text.Insert(0, "-");
            }
        }

        private void buttonHistory_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            foreach (var str in history)
            {
                msg += str + "\r\n";
            }
            MessageBox.Show(msg);
        }

        private void labelNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (labelNumber.Text.Length == 0) return;
            labelNumber.Text = String.Format("{0:n0}", double.Parse(labelNumber.Text));
        }
    }
}