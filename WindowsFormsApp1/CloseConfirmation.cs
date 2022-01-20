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
    public partial class CloseConfirmation : Form
    {
        public CloseConfirmation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        public Point mouseLocation;
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            MainForm.option = 0;
            Hide();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            MainForm.option = 1;
            this.Close();
        }
    }
}
