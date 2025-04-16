using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppScottPlot
{
    public partial class Form1 : Form
    {
        readonly ScottPlot.IYAxis YAxis1;

        readonly ScottPlot.IYAxis YAxis2;

        readonly ScottPlot.Plottables.Crosshair CH;

        public Form1()
        {
            InitializeComponent();

            var fp = new ScottPlot.WinForms.FormsPlot() { Dock = DockStyle.Fill };
            Controls.Add(fp);

            YAxis1 = fp.Plot.Axes.Left;

            // Create a second Y axis, add it to the plot, and save it for later
            YAxis2 = fp.Plot.Axes.AddLeftAxis();

            // plot random data to start
            double[] data1 = ScottPlot.RandomDataGenerator.Generate.RandomWalk(count: 51, mult: 1);
            var sig1 = fp.Plot.Add.Signal(data1);
            sig1.Axes.YAxis = YAxis1;
            YAxis1.Label.Text = "YAxis1";
            YAxis1.Label.ForeColor = sig1.Color;

            double[] data2 = ScottPlot.RandomDataGenerator.Generate.RandomWalk(count: 51, mult: 1000);
            var sig2 = fp.Plot.Add.Signal(data2);
            sig2.Axes.YAxis = YAxis2;
            YAxis2.Label.Text = "YAxis2";
            YAxis2.Label.ForeColor = sig2.Color;

            fp.Plot.Axes.AutoScale();
            fp.Plot.Axes.Zoom(.8, .7); // zoom out slightly

            fp.Plot.HideGrid();

            CH = fp.Plot.Add.Crosshair(0, 0);
            CH.TextColor = Colors.White;
            CH.TextBackgroundColor = CH.HorizontalLine.Color;

            fp.Plot.Add.Callout("Hello",
                textLocation: new Coordinates(2, 5),
                tipLocation: new Coordinates(1, 3));

            fp.Plot.Add.Callout("World",
                textLocation: new Coordinates(19, 0),
                tipLocation: new Coordinates(20, 5));


            fp.Refresh();

            fp.MouseMove += (s, e) =>
            {
                Pixel mousePixel = new Pixel(e.X, e.Y);
                Coordinates mouseCoordinates = fp.Plot.GetCoordinates(mousePixel);
                this.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}";
                CH.Position = mouseCoordinates;
                CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}";
                CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}";
                fp.Refresh();
            };

            fp.MouseDown += (s, e) =>
            {
                Pixel mousePixel = new Pixel(e.X, e.Y);
                Coordinates mouseCoordinates = fp.Plot.GetCoordinates(mousePixel);
                Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3} (mouse down)";
            };

        }
    }
}
