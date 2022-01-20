using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace WindowsFormsApp1
{
    public partial class RohullahFT : MaterialSkin.Controls.MaterialForm
    {
        public RohullahFT()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void RohullahFT_Load(object sender, EventArgs e)
        {
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn ("ID", typeof(int)),
            new DataColumn ("Full Name", typeof(string)),
            new DataColumn ("Passport", typeof(string)),
            new DataColumn ("Country", typeof(string)),
            new DataColumn ("Full Address", typeof(string)),
            new DataColumn ("From" , typeof(string)),
            new DataColumn("To", typeof(string))
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int a;
        int increment;
        public int selectedRow { get; private set; }

        private void newbtn_Click(object sender, EventArgs e)
        {
            try { a++;
                setnum.Text = a.ToString();
                dt.Rows.Add(idtext.Text, fultxt.Text, pastxt.Text, contxt.Text, addtxt.Text, comboBox1.Text, comboBox2.Text);
                this.dataGridView1.DataSource = dt;

                idtext.Text = "";
                fultxt.Text = "";
                pastxt.Text = "";
                contxt.Text = "";
                addtxt.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                increment++;
                idtext.Text = increment.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("you Can not Register Null");
            }

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            try { a--;
                setnum.Text = a.ToString();
                selectedRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedRow); }
            catch(Exception)
            {
                MessageBox.Show("you Do Not Select Row | Noting For Cancel");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

           
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fultxt.Text.Trim() == "")
                {
                    MessageBox.Show("Null is not allowable!");
                }
                else
                {

                    dt.Rows.Add(idtext.Text, fultxt.Text, pastxt.Text, contxt.Text, addtxt.Text, comboBox1.Text, comboBox2.Text);
                    this.dataGridView1.DataSource = dt;
                    a++;
                    setnum.Text = a.ToString();
                    idtext.Text = (int.Parse(idtext.Text) + 1).ToString();
                    fultxt.Text = "";
                    pastxt.Text = "";
                    contxt.Text = "";
                    addtxt.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }
            
            catch(Exception)
            {
                MessageBox.Show("You can not enter null or register it");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            try
            {
                a++;
                setnum.Text = a.ToString();
                dt.Rows.Add(saptnum.Text, namvta.Text, pasportnum.Text, keshwar.Text, address.Text, comboBox3.Text, comboBox4.Text);
                this.dataGridView1.DataSource = dt;
                a++;
                setnum.Text = a.ToString();
                saptnum.Text = (int.Parse(idtext.Text) + 1).ToString();
                namvta.Text = "";
                pasportnum.Text = "";
                keshwar.Text = "";
                address.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }

            catch (Exception)
            {
                MessageBox.Show("You can not enter null or register it");
            }
        }
    }
}
