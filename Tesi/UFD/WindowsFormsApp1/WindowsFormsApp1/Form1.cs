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
        private static readonly Random random = new Random();
        private const double mu = 0.05;   // Drift rate
        private const double sigma = 0.2; // Volatility
        private double assetPrice = 100;  // Initial asset price
        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateGBM()
        {
            double dt = 0.01; // Time increment
            double totalTime = 1; // Total simulation time
            int steps = (int)(totalTime / dt);

            for (int i = 0; i < steps; i++)
            {
                double dW = random.NextGaussian() * Math.Sqrt(dt);
                assetPrice *= Math.Exp((mu - 0.5 * sigma * sigma) * dt + sigma * dW);

                // Update UI or perform other actions for each step
                UpdateAssetPriceLabel();

                // Optional: Add a delay to visualize the simulation
                System.Threading.Thread.Sleep(50);
            }
        }
        private void UpdateAssetPriceLabel()
        {
            if (assetPriceLabel.InvokeRequired)
            {
                assetPriceLabel.Invoke(new Action(UpdateAssetPriceLabel));
            }
            else
            {
                assetPriceLabel.Text = $"Asset Price: {assetPrice:F2}";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Start the GBM simulation in a separate thread
            System.Threading.Thread simulationThread = new System.Threading.Thread(SimulateGBM);
            simulationThread.Start();
        }
    }

    // Extension method to generate random Gaussian values
    public static class RandomExtensions
    {
        public static double NextGaussian(this Random random)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        }
    }
}

