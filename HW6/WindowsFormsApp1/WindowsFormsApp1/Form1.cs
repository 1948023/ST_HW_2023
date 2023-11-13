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
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        public Form1()
        {
            label1 = new Label { Text = "Enter P value (2 to 100): ", Location = new Point(30, 20) };
            label2 = new Label { Text = "Enter S value (20 to 100): ", Location = new Point(30, 60) };
            textBox1 = new TextBox { Location = new Point(250, 20) };
            textBox2 = new TextBox { Location = new Point(250, 60) };
            button1 = new Button { Text = "Calculate", Location = new Point(300, 100) };
            button1.Click += new EventHandler(button1_Click);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(button1);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(textBox1.Text);
            int s = Convert.ToInt32(textBox2.Text);
            if (p < 2 || p > 100 || s < 20 || s > 100)
            {
                MessageBox.Show("Please enter a valid P and S value!");
                return;
            }

            int totalAttacks = 0;
            int totalShielded = 0;
            Random random = new Random();
            while (true)
            {
                int securityScore = random.Next(-1, 2);
                if (securityScore == -1) totalAttacks++;
                if (securityScore == 1) totalShielded++;
                if (totalAttacks >= p || totalShielded >= s) break;
            }

            double probability = (double)totalAttacks / (totalAttacks + totalShielded);
            MessageBox.Show($"The probability of the system being discarded is {probability * 100:F2}%");
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
