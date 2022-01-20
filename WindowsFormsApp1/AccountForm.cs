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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AccountForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            FilldgvAccount(int.Parse(LoginForm.companyId));
            FillAccount_Currency();
            FillCustomer();
        }

        private void FillCustomer()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,id from customerview where companyID='" + LoginForm.companyId + "'", Connection.con);
            sarafDB.ToAccount.Rows.Clear();
            da.Fill(sarafDB.ToAccount);
            comboCustomer.DataSource = sarafDB.ToAccount;
            comboCustomer.DisplayMember = "cust_name";
            comboCustomer.ValueMember = "id";
            comboCustomer.Text = "--Select--";
        }

        private void FillAccount_Currency()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency", Connection.con);
            da.Fill(sarafDB.currency);

            comboName.DataSource = sarafDB.currency;
            comboName.DisplayMember = "currency";
            comboName.ValueMember = "id";
            comboName.Text = "--Select--";
            comboName.SelectedIndex = -1;

            comboCurrency.DataSource = sarafDB.currency;
            comboCurrency.DisplayMember = "currency";
            comboCurrency.ValueMember = "id";
            comboCurrency.Text = "--Select--";
            comboCurrency.SelectedIndex = -1;
        }

        private void FilldgvAccount(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            da = new MySqlDataAdapter("select * from accountview  where companyID=" + id, Connection.con);

            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);
            dgvAccount.DataSource = sarafDB.account;
            dgvAccount.Columns[0].Visible = false;
            dgvAccount.Columns[3].Visible = false;
            dgvAccount.Columns[4].Visible = false;
            dgvAccount.Columns[5].Visible = false;
            dgvAccount.Columns[7].Visible = false;
            dgvAccount.Columns[10].Visible = false;
            dgvAccount.Columns[11].Visible = false;
            dgvAccount.Columns[12].Visible = false;
            dgvAccount.Columns[13].Visible = false;
            dgvAccount.Columns[14].Visible = false;
            dgvAccount.Columns[15].Visible = false;
        }

        int i;
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            i = dgvAccount.CurrentRow.Index;
            comboName.Text = dgvAccount.Rows[i].Cells[1].Value.ToString();
            comboCustomer.Text = dgvAccount.Rows[i].Cells[2].Value.ToString();
            comboCurrency.Text = dgvAccount.Rows[i].Cells[6].Value.ToString();
            txtDate.Value = (DateTime)dgvAccount.Rows[i].Cells[8].Value;
            txtBalance.Text = dgvAccount.Rows[i].Cells[9].Value.ToString();

            txtSearch.Focus();
            dataGridView1.Visible = false;
        }

        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Connection.open();
                MySqlCommand command = new MySqlCommand();

                command = new MySqlCommand("call updateAccount(?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", comboName.Text);
                command.Parameters.AddWithValue("@balance", txtBalance.Text);
                command.Parameters.AddWithValue("@currencyID", comboCurrency.SelectedValue);
                command.Parameters.AddWithValue("@customerID", comboCustomer.SelectedValue);
                command.Parameters.AddWithValue("@userID", LoginForm.userId);
                command.Parameters.AddWithValue("@id", dgvAccount.Rows[i].Cells[12].Value);

                command.ExecuteNonQuery();

                MessageBox.Show("The selected Account is successfully updated!");
                FilldgvAccount(int.Parse(LoginForm.companyId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static int option = 0;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();

                DeleteConfirmation delete = new DeleteConfirmation();
                delete.Message.Text = "Are you sure you want to delete the selected account?";
                delete.ShowDialog();

                if (option == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("delete from account where id=" + dgvAccount.Rows[i].Cells[6].Value, Connection.con);
                    cmd.ExecuteNonQuery();
                    FilldgvAccount(int.Parse(LoginForm.companyId));
                    option = 0;
                    i = -1;
                    btnDelete.Enabled = false;

                    comboName.SelectedIndex = -1;
                    comboCustomer.SelectedIndex = -1;
                    comboCurrency.SelectedIndex = -1;
                    txtBalance.Text = "0.00";
                }
                option = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry the selected Account is in use!");
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {

                Connection.open();
                MySqlCommand command = new MySqlCommand();

                command = new MySqlCommand("call insertAccount(?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", comboName.Text);
                command.Parameters.AddWithValue("@balance", txtBalance.Text);
                command.Parameters.AddWithValue("@currencyID", comboCurrency.SelectedValue);
                command.Parameters.AddWithValue("@customerID", comboCustomer.SelectedValue);
                command.Parameters.AddWithValue("@userID", LoginForm.userId);

                command.ExecuteNonQuery();

                MessageBox.Show("New Account is successfully Added!");
                FilldgvAccount(int.Parse(LoginForm.companyId));

                comboName.SelectedIndex = -1;
                comboCustomer.SelectedIndex = -1;
                comboCurrency.SelectedIndex = -1;
                txtBalance.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("call searchAccount(?,?)", Connection.con);
            da.SelectCommand.Parameters.AddWithValue("@searchText", txtSearch.Text);
            da.SelectCommand.Parameters.AddWithValue("@companyID", LoginForm.companyId);

            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);
            dgvAccount.DataSource = sarafDB.account;
            dgvAccount.Columns[0].Visible = false;
            dgvAccount.Columns[2].Visible = false;
            dgvAccount.Columns[4].Visible = false;
            dgvAccount.Columns[5].Visible = false;
            dgvAccount.Columns[6].Visible = false;
            dgvAccount.Columns[7].Visible = false;
            dgvAccount.Columns[8].Visible = false;
            dgvAccount.Columns[12].Visible = false;
        }

        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboCustomer_TextChanged(object sender, EventArgs e)
        {
            if (comboCustomer.Text.Trim() == "--Select--")
            {
                dataGridView1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
            }

            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from customerview where companyID=" +
                    "'" + LoginForm.companyId + "' and cust_name like '%" + comboCustomer.Text + "%'", Connection.con);
            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dataGridView1.DataSource = sarafDB.Customer;

        }

        private void comboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridView1.Focus();
                int i = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Visible == true)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[i + 1].Cells[0];
                }
            }
            e.Handled = true;
        }

        private void comboCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;
                comboCustomer.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
            }
        }

        private void comboCustomer_Enter(object sender, EventArgs e)
        {
            if (comboCustomer.Text == "--Select--")
                comboCustomer.Text = "";
            if (comboCustomer.Text == "")
                dataGridView1.Visible = true;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from customerview where companyID=" +
                "'" + LoginForm.companyId + "' and cust_name like '%" + comboCustomer.Text + "%'", Connection.con);

            sarafDB.ToCustomer.Rows.Clear();
            da.Fill(sarafDB.ToCustomer);
            dataGridView1.DataSource = sarafDB.ToCustomer;
        }

        private void comboCustomer_Leave(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
                dataGridView1.Visible = true;
            else if (comboCustomer.Text == "")
            {
                dataGridView1.Visible = false;
                comboCustomer.Text = "--Select--";
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;
                comboCustomer.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
                comboCustomer.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cn = dataGridView1.CurrentRow.Index;
            comboCustomer.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
            dataGridView1.Visible = false;
        }
    }
}
