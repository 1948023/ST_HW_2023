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
        private void SimulateButton_Click(object sender, EventArgs e)
        {
            int M = int.Parse(MTextBox.Text);
            int N = int.Parse(NTextBox.Text);
            int T = int.Parse(TTextBox.Text);
            double lambda = double.Parse(LambdaTextBox.Text);
            int simulations = int.Parse(SimulationsTextBox.Text);

            // Initialize a chart for visualization
            chart1.Series.Clear();
            chart1.Series.Add("Histogram");
            chart1.Series.Add("Instant");
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[1].ChartType = SeriesChartType.Point;

            Random random = new Random();
            int[] attackCounts = new int[simulations];

            for (int i = 0; i < simulations; i++)
            {
                int[] serverStatus = new int[M];
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        double randomValue = random.NextDouble();
                        if (randomValue < lambda * (T / N))
                        {
                            serverStatus[k]++;
                        }
                    }
                }
                attackCounts[i] = serverStatus[0]; // Store the attack count for the first server
                chart1.Series[1].Points.AddXY(i, attackCounts[i]); // Display the instantaneous value
            }

            // Plot histogram
            int maxAttacks = attackCounts.Max();
            for (int i = 0; i <= maxAttacks; i++)
            {
                chart1.Series[0].Points.AddXY(i, attackCounts.Count(count => count == i));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
