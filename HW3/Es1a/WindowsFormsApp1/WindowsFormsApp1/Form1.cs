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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SimulateButton_Click(object sender, EventArgs e)
        {
            // Read input values
            int M = int.Parse(MTextBox.Text);
            int N = int.Parse(NTextBox.Text);
            double p = double.Parse(pTextBox.Text);

            // Clear the chart
            chart1.Series.Clear();

            // Simulate the score trajectories for M systems
            for (int systemIndex = 1; systemIndex <= M; systemIndex++)
            {
                Series series = new Series("System " + systemIndex);
                series.ChartType = SeriesChartType.Line;

                double score = 1.0;

                for (int attack = 1; attack <= N; attack++)
                {
                    // Simulate penetration with probability p
                    if (RandomNumberGenerator.NextDouble() < p)
                    {
                        score = -1.0;
                    }

                    series.Points.AddXY(attack, score);
                }

                chart1.Series.Add(series);
            }
        }

        private Random RandomNumberGenerator = new Random();

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
