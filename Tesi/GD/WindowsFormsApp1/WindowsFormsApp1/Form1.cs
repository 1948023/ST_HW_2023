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
        private Button _calculateButton;
        private TextBox _meanTextBox;
        private TextBox _stdDeviationTextBox;
        private TextBox _pointCountTextBox;
        private Panel _chartPanel;
        public Form1()
        {
            _calculateButton = new Button { Text = "Calculate", Left = 10, Top = 10 };
            _meanTextBox = new TextBox { Left = 100, Top = 10, Width = 50 };
            _stdDeviationTextBox = new TextBox { Left = 210, Top = 10, Width = 50 };
            _pointCountTextBox = new TextBox { Left = 320, Top = 10, Width = 50 };
            _chartPanel = new Panel { Left = 10, Top = 50, Width = 400, Height = 300, BorderStyle = BorderStyle.Fixed3D };

            _calculateButton.Click += (sender, args) => DrawChart();

            Controls.Add(_calculateButton);
            Controls.Add(_meanTextBox);
            Controls.Add(_stdDeviationTextBox);
            Controls.Add(_pointCountTextBox);
            Controls.Add(_chartPanel);
            InitializeComponent();
        }
        private void DrawChart()
        {
            int pointCount;
            double mean, stdDeviation;

            if (!int.TryParse(_pointCountTextBox.Text, out pointCount) || pointCount < 1)
            {
                MessageBox.Show("Invalid number of points!");
                return;
            }

            if (!double.TryParse(_meanTextBox.Text, out mean))
            {
                MessageBox.Show("Invalid mean!");
                return;
            }

            if (!double.TryParse(_stdDeviationTextBox.Text, out stdDeviation) || stdDeviation <= 0)
            {
                MessageBox.Show("Invalid standard deviation!");
                return;
            }

            using (Graphics g = _chartPanel.CreateGraphics())
            {
                g.Clear(Color.White);
                int width = _chartPanel.ClientSize.Width;
                int height = _chartPanel.ClientSize.Height;

                using (Pen pen = new Pen(Color.Black))
                {
                    for (int i = 0; i < pointCount; i++)
                    {
                        double x = i * 1.0 / (pointCount - 1);
                        double y = 1.0 / (stdDeviation * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * Math.Pow((x - mean) / stdDeviation, 2));

                        int yPos = (int)(height * (1 - y));
                        int xPos = (int)(width * i / (pointCount - 1));

                        g.DrawRectangle(pen, xPos, yPos, 1, 1);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
