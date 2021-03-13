using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;



namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double dt = 0.01;
        const double g = 9.81;

        double a;
        double v0;
        double y0;

        double t;
        double x;
        double y;

        int maxX;
        int maxY;

        public int pause_start = 0;
        
        private void btStart_Click(object sender, EventArgs e)
        {
            a = (double)edAngle.Value;
            v0 = (double)edSpeed.Value;
            y0 = (double)edHeight.Value;

            maxX = (int)numericUpDown2.Value;
            maxY = (int)numericUpDown1.Value;

            t = 0;
            x = 0;
            y = y0;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);
            chart1.ChartAreas[0].AxisX.Maximum = maxX;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;
            Stopwatch stopwatch = new Stopwatch();
            timer1.Start();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            t += dt;
            x = v0 * Math.Cos(a * Math.PI / 180) * t;
            y = y0 + v0 * Math.Sin(a * Math.PI / 180) * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            
            label4.Text = "Время: " + (t).ToString("0.00") + " сек";
            if (y <= 0)
            {
                
                timer1.Stop();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pause_start == 0)
            {
                timer1.Stop();
                pause_start = 1;
            }
            else
            {
                timer1.Start();
                pause_start = 0;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
