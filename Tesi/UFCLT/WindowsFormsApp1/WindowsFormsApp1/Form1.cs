using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<double> sampleMeans = new List<double>();
        private List<double> normalSample = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sampleMeans.Clear();
            normalSample.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int m = Convert.ToInt32(numericUpDown2.Value);
            double stdDev = Convert.ToDouble(numericUpDown3.Value);

            for (int i = 0; i < m; i++)
            {
                double[] sample = GetSample(n, stdDev);
                double sampleMean = sample.Average();
                sampleMeans.Add(sampleMean);

                double normalValue = ConvertToNormalDist(sampleMean, stdDev);
                normalSample.Add(normalValue);
            }

            chart1.Series["Samples"].Points.DataBindY(sampleMeans);
            chart1.Series["Normal"].Points.DataBindY(normalSample);
        }

        private double[] GetSample(int n, double stdDev)
        {
            Random rand = new Random();
            double[] sample = new double[n];

            for (int i = 0; i < n; i++)
            {
                sample[i] = stdDev * rand.NextGaussian();
            }

            return sample;
        }

        private double ConvertToNormalDist(double x, double stdDev)
        {
            return (x - mean) / stdDev;
        }
    }
}

