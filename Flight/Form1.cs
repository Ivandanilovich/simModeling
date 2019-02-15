using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const double g = 9.81, dt = 0.1;
        double t = 0, x = 0, y = 0, y0, alpha, v;

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            x = v * Math.Cos(alpha * Math.PI / 180) * t;
            y = y0 + v * Math.Sin(alpha * Math.PI / 180) * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            if (y < 0) timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = 0;
            chart1.Series[0].Points.Clear();

            v = (double)sControl.Value;
            alpha = (double)aControl.Value;
            y0 = (double)hControl.Value;
            chart1.Series[0].Points.AddXY(0, y0);

            if (!timer1.Enabled) timer1.Start();

        }
    }
}
