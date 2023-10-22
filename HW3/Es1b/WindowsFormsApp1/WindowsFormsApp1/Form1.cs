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
        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            // Read input values
            int M = int.Parse(MTextBox.Text);
            int N = int.Parse(NTextBox.Text);
            double p = double.Parse(pTextBox.Text);

            // Clear the chart
            chart1.Series.Clear();

            // Initialize variables for cumulative frequency and relative frequency
            int[] cumulativeFrequency = new int[N];
            double[] relativeFrequency = new double[N];
            double normalizedRatio = 0.0;

            // Simulate the score trajectories for M systems
            for (int systemIndex = 1; systemIndex <= M; systemIndex++)
            {
                double score = 1.0;

                for (int attack = 0; attack < N; attack++)
                {
                    // Simulate penetration with probability p
                    if (RandomNumberGenerator.NextDouble() < p)
                    {
                        score = -1.0;
                        cumulativeFrequency[attack]++;
                    }

                    relativeFrequency[attack] = (double)cumulativeFrequency[attack] / (attack + 1);
                    normalizedRatio = relativeFrequency[attack] / Math.Sqrt(attack + 1);
                }
            }

            // Display cumulative frequency, relative frequency, and normalized ratio in the chart
            Series cumulativeSeries = new Series("Cumulative Frequency");
            Series relativeSeries = new Series("Relative Frequency");
            Series normalizedSeries = new Series("Normalized Ratio");

            for (int attack = 0; attack < N; attack++)
            {
                cumulativeSeries.Points.AddXY(attack + 1, cumulativeFrequency[attack]);
                relativeSeries.Points.AddXY(attack + 1, relativeFrequency[attack]);
                normalizedSeries.Points.AddXY(attack + 1, normalizedRatio);
            }

            chart1.Series.Add(cumulativeSeries);
            chart1.Series.Add(relativeSeries);
            chart1.Series.Add(normalizedSeries);
        }

        private Random RandomNumberGenerator = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
