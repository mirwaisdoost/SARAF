using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        int r1 = 0; //right side of the component
        int d1 = 2; //width of panel is being devided by this variable
        int t1 = 0; //number of intervals that a timer will spend
        private void timer1_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            if (r1 < width / d1)
            {
                label6.Left += 5;
                r1 += 5;
            }
            if(r1 > (width / d1))
            {
                if (d1 == 1)
                {
                    r1 = 0;
                    label6.Left = -50;
                    d1++;
                    d2 = 1;
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
                else if (d1 == 2)
                {
                    r2 = 0;
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
            }
        }

        int r2 = 0;
        int d2 = 2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            if (r2 < (width / d2) - 18)
            {
                label5.Left += 5;
                r2 += 5;
            }
            else if (r2 > (width / d2) - 18)
            {
                if (d2 == 1)
                {
                    timer2.Enabled = false;
                    label5.Left = -50;
                    d2++;
                    timer3.Enabled = true;
                    d3 = 1;
                }
                else if (d2 == 2)
                {
                    timer2.Enabled = false;
                    timer3.Enabled = true;
                    r3 = 0;
                }
            }
        }

        int r3 = 0;
        int d3 = 2;
        private void timer3_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            if (r3 < (width / d3) - 36)
            {
                label4.Left += 3;
                r3 += 3;
            }
            else if (r3 > (width / d3) - 36)
            {
                if (d3 == 1)
                {
                    timer3.Enabled = false;
                    label4.Left = -50;
                    d3++;
                    timer4.Enabled = true;
                    d4 = 1;
                }
                if (d3 == 2)
                {
                    r4 = 0;
                    timer3.Enabled = false;
                    timer4.Enabled = true;
                }
            }
        }

        int r4 = 0;
        int d4 = 2;
        private void timer4_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            if (r4 < (width / d4) - 54)
            {
                label3.Left += 5;
                r4 += 5;
                if (r4 == width)
                {
                    r4 = 0;
                    label3.Left = 0;
                }
            }
            else if (r4 > (width / d4) - 54)
            {
                if (d4 == 1)
                {
                    timer4.Enabled = false;
                    label3.Left = -50;
                    d4++;
                    timer5.Enabled = true;
                    d5 = 1;
                }
                if (d4 == 2)
                {
                    r5 = 0;
                    timer4.Enabled = false;
                    timer5.Enabled = true;
                }
            }
        }

        int r5 = 0;
        int d5 = 2;
        int interval = 0;
        LoginForm login = new LoginForm();
        private void timer5_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            if (r5 < (width / d5) - 72)
            {
                label2.Left += 3;
                r5 += 3;
            }
            else if (r5 > (width / d5) - 72)
            {
                if (d5 == 1)
                {
                    timer5.Enabled = false;
                    label2.Left = -50;
                    d5++;
                    interval++;
                }
                if (d5 == 2)
                {
                    label6.Left += 30;
                    label5.Left += 30;
                    label4.Left += 30;
                    label3.Left += 30;
                    label2.Left += 30;

                    t1++;
                    timer5.Enabled = false;
                    timer1.Enabled = true;
                    if (t1 % 2 == 0)
                    {
                        d1 = 2;
                    }
                    else
                        d1 = 1;
                }
            }
            if (interval == 2)
            {
                timer5.Enabled = false;
                this.Hide();
                login.Show();
                login.Activate();
            }
        }

        private void SplashScreen_Activated(object sender, EventArgs e)
        {

        }
    }
}
