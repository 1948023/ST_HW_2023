using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly Random random = new Random();
        private const int numSteps = 100;
        private double integralResult = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void SimulateItoIntegration()
        {
            for (int i = 0; i < numSteps; i++)
            {
                double integrand = random.NextDouble(); // Replace with your specific integrand
                double dW = random.NextGaussian(); // Wiener increment

                integralResult += integrand * dW;

                // Update UI or perform other actions for each step
                UpdateIntegralResultLabel();

                // Optional: Add a delay to visualize the simulation
                Thread.Sleep(50);
            }
        }

        private void UpdateIntegralResultLabel()
        {
            if (integralResultLabel.InvokeRequired)
            {
                integralResultLabel.Invoke(new Action(UpdateIntegralResultLabel));
            }
            else
            {
                integralResultLabel.Text = $"Integral Result: {integralResult:F2}";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Start the Ito Integration simulation in a separate thread
            Thread simulationThread = new Thread(SimulateItoIntegration);
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
