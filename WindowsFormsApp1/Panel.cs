using System;
using System.Collections;
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
    public partial class panel : Panel
    {
        Label title = new Label();
        Label close = new Label();


        public panel()
        {
            AutoSize = true;


            Label lbl = new Label();
            lbl.Text = "Transaction";
            lbl.Dock = DockStyle.Left;
            lbl.Padding = new Padding(0, 5, 0, 5);
            Padding = new Padding(0, 10, 0, 10);
            Label cls = new Label();
            cls.Text = "                X";
            lbl.Dock = DockStyle.Right;

            Controls.Add(lbl);
            Controls.Add(cls);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
