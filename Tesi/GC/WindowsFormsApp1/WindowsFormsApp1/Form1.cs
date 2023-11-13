using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        List<double> xValues = new List<double>();
        List<double> yValues = new List<double>();
        List<double> cumulativeFrequencies = new List<double>();
        Random random = new Random();

        for (int i = 0; i < 1000; i++)
        {
            double randomValue = random.NextDouble();
            xValues.Add(randomValue);
            yValues.Add(1.0 / Math.Sqrt(12.0) * Math.Exp(-2.0 * Math.PI * Math.PI * randomValue * randomValue));
        cumulativeFrequencies.Add(i + 1);
    }

    pbPlot.Image = null;
            Bitmap plot = new Bitmap(pbPlot.Width, pbPlot.Height);
            using (Graphics graphics = Graphics.FromImage(plot))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                Rectangle chartArea = new Rectangle(0, 0, pbPlot.Width, pbPlot.Height);
    DrawChartArea(graphics, chartArea);
    DrawScatterPlot(graphics, chartArea, xValues, yValues);
    DrawLineOfBestFit(graphics, chartArea, xValues, yValues);
}

pbPlot.Image = plot;
        }

        private void DrawChartArea(Graphics graphics, Rectangle chartArea)
{
    graphics.DrawRectangle(Pens.LightGray, chartArea);
}

private void DrawScatterPlot(Graphics graphics, Rectangle chartArea, List<double> xValues, List<double> yValues)
{
    int width = chartArea.Width;
    int height = chartArea.Height;

    for (int i = 0; i < xValues.Count; i++)
    {
        double x = xValues[i];
        double y = yValues[i];

        int xCoordinate = chartArea.Left + (int)(x * width);
        int yCoordinate = chartArea.Bottom - (int)(y * height);

        graphics.FillEllipse(Brushes.Black, xCoordinate - 2, yCoordinate - 2, 4, 4);
    }
}

private void DrawLineOfBestFit(Graphics graphics, Rectangle chartArea, List<double> xValues, List<double> yValues)
{
    double xSum = xValues.Sum();
    double ySum = yValues.Sum();
    double xySum = 0.0;
    double xxSum = 0.0;

    for (int i = 0; i < xValues.Count; i++)
    {
        xySum += xValues[i] * yValues[i];
        xxSum += xValues[i] * xValues[i];
    }

    double slope = (xValues.Count * xySum - xSum * ySum) / (xValues.Count * xxSum - xSum * xSum);
    double intercept = (ySum - slope * xSum) / xValues.Count;

    PointF startPoint = new PointF(chartArea.Left, chartArea.Bottom - (float)(intercept * chartArea.Height));
PointF endPoint = new PointF(chartArea.Right, chartArea.Bottom - (float)((intercept + slope) * chartArea.Height));

graphics.DrawLine(Pens.Red, startPoint, endPoint);
        }
    }
}
