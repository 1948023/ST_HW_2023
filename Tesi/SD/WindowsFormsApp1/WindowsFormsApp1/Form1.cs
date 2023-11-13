using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            double userInput = Convert.ToDouble(inputTextBox.Text);

            if (radioButton1.Checked) // Normal Distribution
            {
                double result = calculateNormalDistribution(userInput);
                displayResult(result);
            }
            else if (radioButton2.Checked) // Uniform Distribution
            {
                double result = calculateUniformDistribution(userInput);
                displayResult(result);
            }
        }

        private double calculateNormalDistribution(double x)
        {
            double mean = 50;
            double standardDeviation = 10;
            double constant = 1 / (standardDeviation * Math.Sqrt(2 * Math.PI));
            double power = -1 * Math.Pow((x - mean) / standardDeviation, 2) / 2;
            double result = constant * Math.Exp(power);
            return result;
        }

        private double calculateUniformDistribution(double x)
        {
            double min = 0;
            double max = 100;
            double result = x >= min && x <= max ? 1 / (max - min) : 0;
            return result;
        }

        private void displayResult(double result)
        {
            resultLabel.Text = $"Result: {result.ToString("F2")}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
