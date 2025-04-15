using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Data;

namespace WpfApp3
{
    public class Data
    {
        public string name { get; set; }
        public string id { get; set; }
        public string major { get; set; }
        public int grade { get; set; }
        public string etc { get; set; }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Label_filePath.Content = openFileDialog.FileName;

                if (openFileDialog.FileName.Contains(".csv"))
                {
                    try
                    {
                        DataGrid_Person.ItemsSource = PersonalService.CSVtoDataGrid(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DataGrid_Person.SelectedItems.Count > 1)
                {
                    // 여러개의 행이 선택된 경우
                    string names = string.Empty;
                    foreach (Person person in DataGrid_Person.SelectedItems)
                    {
                        names += person.Name + "\r\n";
                    }
                    MessageBox.Show(names + "선택됨.");
                } else
                {
                    // 하나의 행만 가져오기
                    Person dataRow = (Person)DataGrid_Person.SelectedItem;
                    string data = dataRow.Name;
                    MessageBox.Show(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
