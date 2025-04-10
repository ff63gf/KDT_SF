using ScottPlot;
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

namespace WpfAppScottPlotPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Plot myPlot;
        readonly ScottPlot.Plottables.Crosshair CH;

        public MainWindow()
        {
            InitializeComponent();

            //CH = WpfPlot1.Plot.Add.Crosshair(0, 0);
            //CH.TextColor = ScottPlot.Colors.White;
            //CH.TextBackgroundColor = CH.HorizontalLine.Color;

            Load();
        }

        public void Load()
        {
            myPlot = WpfPlot1.Plot;

            // plottables use the standard X and Y axes by default
            var sig1 = myPlot.Add.Signal(ScottPlot.Generate.Sin(51, mult: 0.01));
            sig1.Axes.XAxis = myPlot.Axes.Bottom; // standard X axis
            sig1.Axes.YAxis = myPlot.Axes.Left; // standard Y axis
            //myPlot.Axes.Left.Label.Text = "Primary Y Axis";

            // create a second axis and add it to the plot
            //var yAxis2 = myPlot.Axes.AddLeftAxis();

            // add a new plottable and tell it to use the custom Y axis
            var sig2 = myPlot.Add.Signal(ScottPlot.Generate.Cos(51, mult: 100));
            sig2.Axes.XAxis = myPlot.Axes.Bottom; // standard X axis
            //sig2.Axes.YAxis = yAxis2; // custom Y axis
            //yAxis2.LabelText = "Secondary Y Axis";

            myPlot.HideGrid();

            WpfPlot1.Refresh();

            WpfPlot1.MouseMove += (s, e) =>
            {
                Pixel mousePixel = new(e.MouseDevice.GetPosition(WpfPlot1).X, e.MouseDevice.GetPosition(WpfPlot1).Y);
                Coordinates mouseCoordinates = WpfPlot1.Plot.GetCoordinates(mousePixel);
                label1.Content = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}";
                label2.Content = $"X={mousePixel.X:N3}, Y={mousePixel.Y:N3}";
                //CH.Position = mouseCoordinates;
                //CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}";
                //CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}";
                WpfPlot1.Refresh();
            };

            //WpfPlot1.MouseDown += (s, e) =>
            //{
            //    Pixel mousePixel = new(e.GetPosition(WpfPlot1).X, e.GetPosition(WpfPlot1).Y);
            //    Coordinates mouseCoordinates = WpfPlot1.Plot.GetCoordinates(mousePixel);

            //    label1.Content = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3} (mouse down)";
            //    WpfPlot1.Refresh();
            //};
        }
    }
}