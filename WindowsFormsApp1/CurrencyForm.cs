using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class CurrencyForm : Form
    {
        public CurrencyForm()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            FilldgvCurrency(id);
        }

        public void FilldgvCurrency(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            if (id == 0)
                da = new MySqlDataAdapter("select * from currencyview", Connection.con);
            else
                da = new MySqlDataAdapter("select * from currencyview where id='" + id + "'", Connection.con);

            sarafDB.currency.Rows.Clear();
            da.Fill(sarafDB.currency);
            dgvCurrency.DataSource = sarafDB.currency;

            dgvCurrency.Columns[4].Visible = false;
            dgvCurrency.Columns[5].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        int i = -1;
        private void dgvCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            i = dgvCurrency.CurrentRow.Index;
            txtCurrency.Text = dgvCurrency.Rows[i].Cells[0].Value.ToString();
            txtBuyRate.Text = dgvCurrency.Rows[i].Cells[1].Value.ToString();
            txtSellRate.Text = dgvCurrency.Rows[i].Cells[2].Value.ToString();
            if (dgvCurrency.Rows[i].Cells[5].Value.ToString() == "1")
                checkBasic.Checked = true;
            else
                checkBasic.Checked = false;
            txtDescription.Text = dgvCurrency.Rows[i].Cells[3].Value.ToString();

            if (checkBasic.Checked == true)
                checkBasic.Enabled = false;
            else
                checkBasic.Enabled = true;
        }

        int check;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                if (checkBasic.Checked)
                    check = 1;
                else
                    check = 0;

                Connection.open();

                MySqlCommand command = new MySqlCommand("call updateCurrency(?,?,?,?,?,?)", Connection.con);
                
                command.Parameters.AddWithValue("@name", txtCurrency.Text);
                command.Parameters.AddWithValue("@isBasic", check);
                command.Parameters.AddWithValue("@buyRate", txtBuyRate.Text);
                command.Parameters.AddWithValue("@sellRate", txtSellRate.Text);
                command.Parameters.AddWithValue("@Desp", txtDescription.Text);
                command.Parameters.AddWithValue("@currencyID", dgvCurrency.Rows[i].Cells[4].Value);
                command.ExecuteNonQuery();

                MessageBox.Show("The selected Currency is successfully updated!");
                FilldgvCurrency(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txtCurrency.Text = "";
            txtSellRate.Text = "";
            txtBuyRate.Text = "";
            checkBasic.Checked = false;
            txtDescription.Text = "";

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            try
            {
                if (checkBasic.Checked)
                    check = 1;
                else
                    check = 0;
                Connection.open();

                MySqlCommand command = new MySqlCommand("call insertCurrency(?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@name", txtCurrency.Text);
                command.Parameters.AddWithValue("@sellRate", txtSellRate.Text);
                command.Parameters.AddWithValue("@buyRate", txtBuyRate.Text);
                command.Parameters.AddWithValue("@isBasic", check);
                command.Parameters.AddWithValue("@Desp", txtDescription.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("New Currency is successfully added!");
                FilldgvCurrency(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txtCurrency.Text = "";
            txtSellRate.Text = "";
            txtBuyRate.Text = "";           
            checkBasic.Checked = false;
            txtDescription.Text = "";

        }

        public static int option = 0;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();

                DeleteConfirmation delete = new DeleteConfirmation();
                delete.Message.Text = "Are you sure you want to delete the selected Branch?";
                delete.ShowDialog();

                if (option == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("delete from currency where id=" + dgvCurrency.Rows[i].Cells[4].Value, Connection.con);
                    cmd.ExecuteNonQuery();
                    FilldgvCurrency(id);
                    option = 0;
                    i = -1;

                    btnDelete.Enabled = false;
                    txtCurrency.Text = "";
                    txtSellRate.Text = "";
                    txtBuyRate.Text = "";
                    checkBasic.Checked = false;
                    txtDescription.Text = "";
                }
                option = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry the selected Branch is in use!");
            }
        }
    }
}
