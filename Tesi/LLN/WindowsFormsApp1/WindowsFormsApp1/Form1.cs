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
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            // Numero di lanci del dado in ogni simulazione
            int numRolls = 100;

            // Numero di simulazioni
            int numSimulations = 1000;

            // Array per memorizzare le medie di ciascuna simulazione
            double[] means = new double[numSimulations];

            // Simulazione
            for (int i = 0; i < numSimulations; i++)
            {
                int[] rolls = new int[numRolls];

                // Simula il lancio del dado
                for (int j = 0; j < numRolls; j++)
                {
                    rolls[j] = random.Next(1, 7); // Un dado a 6 facce
                }

                // Calcola la media dei lanci e la salva nell'array delle medie
                means[i] = CalculateMean(rolls);
            }

            // Calcola la media delle medie
            double averageMean = CalculateMeand(means);

            // Visualizza il risultato nel label
            ResultLabel.Text = $"Media delle medie dopo {numRolls} lanci in {numSimulations} simulazioni: {averageMean:F4}";
        }

        // Calcola la media di un array di valori
        private double CalculateMean(int[] values)
        {
            double sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }
            return sum / values.Length;
        }

        private double CalculateMeand(double[] values)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
