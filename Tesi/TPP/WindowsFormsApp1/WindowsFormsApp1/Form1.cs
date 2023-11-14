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
using System.Reflection.Emit;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        double rate = 5.0;
        List<int> time = new List<int>();
        int interArrivalTime = 0;
        int numberOfEvents = 0;
        Thread updateThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            time.Clear();
            interArrivalTime = Convert.ToInt32(Math.Floor(-Math.Log(rand.NextDouble()) / rate));
            time.Add(interArrivalTime);
            updateThread = new Thread(new ThreadStart(Update));
            updateThread.Start();
        }

        private void Update()
        {
            while (true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateDisplay();
                });
                Thread.Sleep(1000);
            }
        }

        private void UpdateDisplay()
        {
            label3.Text = time[time.Count - 1].ToString();
            numberOfEvents++;
            if (numberOfEvents >= 10)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                updateThread.Abort();
            }
            else
            {
                interArrivalTime = Convert.ToInt32(Math.Floor(-Math.Log(rand.NextDouble()) / rate));
                time.Add(time[time.Count - 1] + interArrivalTime);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            updateThread.Abort();
        }
    }
}
