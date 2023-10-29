using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            int sampleSize = 30;
            int numSamples = 1000;
            double[] sampleMeans = new double[numSamples];

            for (int i = 0; i < numSamples; i++)
            {
                double[] sample = new double[sampleSize];
                for (int j = 0; j < sampleSize; j++)
                {
                    sample[j] = rand.NextDouble();
                }
                sampleMeans[i] = CalculateMean(sample);
            }

            // Create a histogram chart to visualize the sample means
            Chart chart = new Chart();
            chart.Size = new System.Drawing.Size(400, 300);
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            Series series = new Series();
            chart.Series.Add(series);

            series.Points.DataBindY(sampleMeans);
            series.ChartType = SeriesChartType.Column;

            Controls.Add(chart);
            chart.Location = new System.Drawing.Point(10, 50);
        }

        // Calculate the mean of an array of values
        private double CalculateMean(double[] values)
        {
            double sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }
            return sum / values.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
