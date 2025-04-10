using ScottPlot;
using System.Data;
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

namespace WpfAppScottPlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Start();
            SignalPlot();
            //Legend();
            //RightAxis();
            //MultiAxis();
            //ScatterPlotSample1();
            //ScatterPlotSample2();
            //ScatterPlotSample3();
            //ScatterPlotSample4();
            //ScatterPlotSample5();
            //ScatterPlotSample6();
            //ScatterPlotSample7();
            //ScatterPlotSample8();
            //ScatterPlotSample9();
            //ScatterPlotSample10();
            //ScatterPlotSample11();
            //ScatterPlotSample12();
            //ScatterPlotSample13();
            //ScatterPlotSample14();
            //ScatterPlotSample15();
            //ScatterPlotSample16();
            //ScatterPlotSample17();
            //ScatterPlotSample18();

        }

        void Start()
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            WpfPlot1.Refresh();
        }

        void SignalPlot()
        {
            ScottPlot.Plot myPlot = WpfPlot2.Plot;
            double[] sin = Generate.Sin(51);
            double[] cos = Generate.Cos(51);
            myPlot.Add.Signal(sin);
            myPlot.Add.Signal(cos);
        }

        void Legend()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;
            var sig1 = myPlot.Add.Signal(Generate.Sin(51));
            sig1.LegendText = "Sin";

            var sig2 = myPlot.Add.Signal(Generate.Cos(51));
            sig2.LegendText = "Cos";

            myPlot.ShowLegend();
        }

        void RightAxis()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;
            // plot data with very different scales
            var sig1 = myPlot.Add.Signal(Generate.Sin(mult: 0.01));
            var sig2 = myPlot.Add.Signal(Generate.Cos(mult: 100));

            // tell each signal plot to use a different axis
            sig1.Axes.YAxis = myPlot.Axes.Left;
            sig2.Axes.YAxis = myPlot.Axes.Right;

            // add additional styling options to each axis
            myPlot.Axes.Left.Label.Text = "Left Axis";
            myPlot.Axes.Right.Label.Text = "Right Axis";
            myPlot.Axes.Left.Label.ForeColor = sig1.Color;
            myPlot.Axes.Right.Label.ForeColor = sig2.Color;
        }

        void MultiAxis()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;
            // plottables use the standard X and Y axes by default
            var sig1 = myPlot.Add.Signal(ScottPlot.Generate.Sin(51, mult: 0.01));
            sig1.Axes.XAxis = myPlot.Axes.Bottom; // standard X axis
            sig1.Axes.YAxis = myPlot.Axes.Left; // standard Y axis
            myPlot.Axes.Left.Label.Text = "Primary Y Axis";

            // create a second axis and add it to the plot
            var yAxis2 = myPlot.Axes.AddLeftAxis();

            // add a new plottable and tell it to use the custom Y axis
            var sig2 = myPlot.Add.Signal(ScottPlot.Generate.Cos(51, mult: 100));
            sig2.Axes.XAxis = myPlot.Axes.Bottom; // standard X axis
            sig2.Axes.YAxis = yAxis2; // custom Y axis
            yAxis2.LabelText = "Secondary Y Axis";
        }

        void ScatterPlotSample1()
        {
            Coordinates[] coordinates =
            {
                new(1, 1),
                new(2, 4),
                new(3, 9),
                new(4, 16),
                new(5, 25),
            };

            WpfPlot1.Plot.Add.Scatter(coordinates);
        }

        void ScatterPlotSample2()
        {
            float[] xs = { 1, 2, 3, 4, 5 };
            int[] ys = { 1, 4, 9, 16, 25 };

            WpfPlot1.Plot.Add.Scatter(xs, ys);
        }

        void ScatterPlotSample3()
        {
            List<double> xs = new() { 1, 2, 3, 4, 5 };
            List<double> ys = new() { 1, 4, 9, 16, 25 };

            WpfPlot1.Plot.Add.Scatter(xs, ys);
        }

        void ScatterPlotSample4()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] sin = Generate.Sin(51);
            double[] cos = Generate.Cos(51);

            myPlot.Add.ScatterLine(xs, sin);
            myPlot.Add.ScatterLine(xs, cos);
        }

        void ScatterPlotSample5()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] sin = Generate.Sin(51);
            double[] cos = Generate.Cos(51);

            myPlot.Add.ScatterPoints(xs, sin);
            myPlot.Add.ScatterPoints(xs, cos);
        }

        void ScatterPlotSample6()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys1 = Generate.Sin(51);
            double[] ys2 = Generate.Cos(51);

            var sp1 = myPlot.Add.Scatter(xs, ys1);
            sp1.LegendText = "Sine";
            sp1.LineWidth = 3;
            sp1.Color = ScottPlot.Colors.Magenta;
            sp1.MarkerSize = 15;

            var sp2 = myPlot.Add.Scatter(xs, ys2);
            sp2.LegendText = "Cosine";
            sp2.LineWidth = 2;
            sp2.Color = ScottPlot.Colors.Green;
            sp2.MarkerSize = 10;

            myPlot.ShowLegend();
        }

        void ScatterPlotSample7()
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            LinePattern[] patterns = Enum.GetValues<LinePattern>();
            ScottPlot.Palettes.ColorblindFriendly palette = new();

            for (int i = 0; i < patterns.Length; i++)
            {
                double yOffset = patterns.Length - i;
                double[] xs = Generate.Consecutive(51);
                double[] ys = Generate.Sin(51, offset: yOffset);

                var sp = myPlot.Add.Scatter(xs, ys);
                sp.LineWidth = 2;
                sp.MarkerSize = 0;
                sp.LinePattern = patterns[i];
                sp.Color = palette.GetColor(i);

                var txt = myPlot.Add.Text(patterns[i].ToString(), 51, yOffset);
                txt.LabelFontColor = sp.Color;
                txt.LabelFontSize = 22;
                txt.LabelBold = true;
                txt.LabelAlignment = Alignment.MiddleLeft;
            }

            myPlot.Axes.Margins(.05, .5, .05, .05);
        }

        void ScatterPlotSample8()   //Scatter Generic
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            int[] xs = { 1, 2, 3, 4, 5 };
            float[] ys = { 1, 4, 9, 16, 25 };

            myPlot.Add.Scatter(xs, ys);
        }

        void ScatterPlotSample9()   //Scatter DateTime
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            DateTime[] xs = Generate.ConsecutiveDays(100);
            double[] ys = Generate.RandomWalk(xs.Length);

            myPlot.Add.Scatter(xs, ys);
            myPlot.Axes.DateTimeTicksBottom();
        }

        void ScatterPlotSample10()   //Step Plot
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(20);
            double[] ys1 = Generate.Consecutive(20, first: 10);
            double[] ys2 = Generate.Consecutive(20, first: 5);
            double[] ys3 = Generate.Consecutive(20, first: 0);

            var sp1 = myPlot.Add.Scatter(xs, ys1);
            sp1.ConnectStyle = ConnectStyle.Straight;
            sp1.LegendText = "Straight";

            var sp2 = myPlot.Add.Scatter(xs, ys2);
            sp2.ConnectStyle = ConnectStyle.StepHorizontal;
            sp2.LegendText = "StepHorizontal";

            var sp3 = myPlot.Add.Scatter(xs, ys3);
            sp3.ConnectStyle = ConnectStyle.StepVertical;
            sp3.LegendText = "StepVertical";

            myPlot.ShowLegend();
        }

        void ScatterPlotSample11()   //Scatter with Gaps
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            // long stretch of empty data
            for (int i = 10; i < 20; i++)
                ys[i] = double.NaN;

            // single missing data point
            ys[30] = double.NaN;

            // single floating data point
            for (int i = 35; i < 40; i++)
                ys[i] = double.NaN;
            for (int i = 40; i < 45; i++)
                ys[i] = double.NaN;

            myPlot.Add.Scatter(xs, ys);
        }

        void ScatterPlotSample12()   //Scatter Plot with Smooth Lines
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(10);
            double[] ys = Generate.RandomSample(10, 5, 15);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.Smooth = true;
            sp.LegendText = "Smooth";
            sp.LineWidth = 2;
            sp.MarkerSize = 10;
        }

        void ScatterPlotSample13()   //Smooth Line Tension
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.RandomWalk(10);
            double[] ys = Generate.RandomWalk(10);

            var mk = myPlot.Add.Markers(xs, ys);
            mk.MarkerShape = MarkerShape.OpenCircle;
            mk.Color = ScottPlot.Colors.Black;

            double[] tensions = { 0.3, 0.5, 1.0, 3.0 };

            foreach (double tension in tensions)
            {
                var sp = myPlot.Add.ScatterLine(xs, ys);
                sp.Smooth = true;
                sp.SmoothTension = tension;
                sp.LegendText = $"Tension {tension}";
                sp.LineWidth = 2;
            }

            myPlot.ShowLegend(Alignment.UpperLeft);
        }

        void ScatterPlotSample14()   //Smooth Line Tension
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(10);
            double[] ys = Generate.RandomSample(10, 5, 15);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.PathStrategy = new ScottPlot.PathStrategies.QuadHalfPoint();
            sp.LegendText = "Smooth";
            sp.LineWidth = 2;
            sp.MarkerSize = 10;
        }

        void ScatterPlotSample15()   //Smooth Line Tension
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.MinRenderIndex = 10;
            sp.MaxRenderIndex = 40;
        }

        void ScatterPlotSample16()   //Scatter Plot with Fill
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.FillY = true;
            sp.FillYColor = sp.Color.WithAlpha(.2);
        }

        void ScatterPlotSample17()   //Scatter Plot Filled to a Value
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.FillY = true;
            sp.FillYColor = sp.Color.WithAlpha(.2);
            sp.FillYValue = 0.6;
        }

        void ScatterPlotSample18()   //Scatter Plot Filled Above and Below
        {
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            var sp = myPlot.Add.Scatter(xs, ys);
            sp.FillY = true;
            sp.FillYValue = 0;
            sp.FillYAboveColor = ScottPlot.Colors.Green.WithAlpha(.2);
            sp.FillYBelowColor = ScottPlot.Colors.Red.WithAlpha(.2);
        }
    }
}