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
    public partial class Martonis : Form
    {
        DataTable dt = new DataTable("Info Table");

        public Martonis()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Salary", typeof(int));
            dt.PrimaryKey=new DataColumn[]{ dt.Columns[0]};
            dataGridView1.DataSource = dt;
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = int.Parse(textBox1.Text);
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = int.Parse(textBox4.Text);
            dt.Rows.Add(dr);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


        }
    }
}
