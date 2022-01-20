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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        public static int transferID;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                transferID = int.Parse(txtTransferID.Text);
                TransferBill bill = new TransferBill();
                bill.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show("Please specify a transafer#");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();
                MySqlCommand transaction_id = new MySqlCommand("select auto_increment from information_schema.tables" +
                    " where table_schema='saraf' and table_name='transfer'", Connection.con);
                MySqlDataReader dr = transaction_id.ExecuteReader();
                while (dr.Read())
                    txtTransferID.Text = dr.GetString(0);

                Connection.close();

                Connection.open();

                MySqlCommand command = new MySqlCommand("call insert_transaction(?,?,?,?,?,?,?,?,?,?)", Connection.con);

                if (checkManualRate.Checked == true && float.Parse(txtRate.Text) <= 0)
                {
                    MessageBox.Show("Please specify the rate");
                }
                else if (comboFromAccount.SelectedValue == comboToAccount.SelectedValue)
                {
                    MessageBox.Show("Both accounts can not be the same");
                }else if (comboFromAccount.SelectedValue == null || comboToAccount.SelectedValue == null)
                {
                    MessageBox.Show("Fields with asterisk can not be null");
                }
                else
                {
                    command.Parameters.AddWithValue("@date", date.Value);
                    command.Parameters.AddWithValue("@account_id", comboFromAccount.SelectedValue);
                    command.Parameters.AddWithValue("@credit", 0);
                    command.Parameters.AddWithValue("@cr_currency_id", comboToAccountType.SelectedValue);
                    command.Parameters.AddWithValue("@rate", txtRate.Text);
                    command.Parameters.AddWithValue("@debit", txtAmount.Text);
                    command.Parameters.AddWithValue("@db_currency_id", comboFromAccountType.SelectedValue);
                    command.Parameters.AddWithValue("@to_account", comboToAccount.SelectedValue);
                    command.Parameters.AddWithValue("@user_id", LoginForm.userId);
                    command.Parameters.AddWithValue("@description", txtDescription.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Transfer has succesfully don!");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillFromAccountType()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency", Connection.con);
            sarafDB.currency.Rows.Clear();
            da.Fill(sarafDB.currency);
            comboFromAccountType.DataSource = sarafDB.currency;
            comboFromAccountType.DisplayMember = "currency";
            comboFromAccountType.ValueMember = "id";
            comboFromAccountType.SelectedIndex = -1;
        }

        private void FillToAccountType()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency", Connection.con);
            sarafDB.accountType.Rows.Clear();
            da.Fill(sarafDB.accountType);
            comboToAccountType.DataSource = sarafDB.accountType;
            comboToAccountType.DisplayMember = "currency";
            comboToAccountType.ValueMember = "id";
            comboToAccountType.SelectedIndex = -1;
        }

        private void comboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,id,currency_id from accountview where currency_id=" +
                "'" + comboFromAccountType.SelectedValue + "'", Connection.con);
            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);

            comboFromAccount.DataSource = sarafDB.account;
            comboFromAccount.DisplayMember = "cust_name";
            comboFromAccount.ValueMember = "id";
            comboFromAccount.Text = "--Select--";
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            FillFromAccountType();
            FillToAccountType();
            FilldgvCurrency();

            dgvCurrency.Columns[4].Visible = false;
            dgvCurrency.Columns[5].Visible = false;
        }

        private void FilldgvCurrency()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from currencyview", Connection.con);
            sarafDB.Exchange.Rows.Clear();
            da.Fill(sarafDB.Exchange);
            dgvCurrency.DataSource = sarafDB.Exchange;
        }

        private void comboFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboToAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboToAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,id,currency_id from accountview where currency_id=" +
                "'" + comboToAccountType.SelectedValue + "'", Connection.con);

            sarafDB.ToAccount.Rows.Clear();
            da.Fill(sarafDB.ToAccount);

            comboToAccount.DataSource = sarafDB.ToAccount;
            comboToAccount.DisplayMember = "cust_name";
            comboToAccount.ValueMember = "id";
            comboToAccount.Text = "--Select--";
        }

        private void checkManualRate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkManualRate.Checked == true)
            {
                txtRate.Visible = true;
            }
            else
            {
                txtRate.Visible = false;
                txtRate.Text = "0.00";
            }
        }

        private void checkManualRate_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            txtRate.SelectAll();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (txtRate.Text.Trim() == "")
            {
                txtRate.Text = "0.00";
            }
        }

        private void txtRate_MouseClick(object sender, MouseEventArgs e)
        {
            txtRate.SelectAll();
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.SelectAll();
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
            {
                txtAmount.Text = "0.00";
            }
        }

        private void txtAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtAmount.SelectAll();
        }

        private void txtTransferID_Enter(object sender, EventArgs e)
        {
            txtTransferID.SelectAll();
        }

        private void txtTransferID_MouseClick(object sender, MouseEventArgs e)
        {
            txtTransferID.SelectAll();
        }

        private void txtTransferID_Leave(object sender, EventArgs e)
        {
            if (txtTransferID.Text.Trim() == "")
            {
                txtTransferID.Text = "--New--";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cn = dataGridView1.CurrentRow.Index;
            comboFromAccount.Text= dataGridView1.Rows[cn].Cells[0].Value.ToString();
            dataGridView1.Visible = false;
            comboFromAccount.Focus();
        }

        private void comboFromAccount_TextChanged(object sender, EventArgs e)
        {
            if (comboFromAccount.Text.Trim() == "--Select--")
            {
                dataGridView1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
            }
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'"+ comboFromAccountType.SelectedValue + "' and cust_name like '%" + comboFromAccount.Text + "%'", Connection.con);
            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dataGridView1.DataSource = sarafDB.Customer;

            MySqlCommand cmd = new MySqlCommand("select balance from account where id='" + comboFromAccount.SelectedValue + "'", Connection.con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (comboFromAccount.Text != "--Select--" && comboFromAccount.Text != "")
            {
                while (dr.Read())
                    txtFromAccountBalance.Text = dr[0].ToString();
            }
            else
                txtFromAccountBalance.Text = "0.00";
        }

        private void comboFromAccount_Enter(object sender, EventArgs e)
        {
            if(comboFromAccount.Text=="--Select--")
                comboFromAccount.Text = "";
            if(comboFromAccount.Text=="")
                dataGridView1.Visible = true;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'" + comboFromAccountType.SelectedValue + "' and cust_name like '%" + comboFromAccount.Text + "%'", Connection.con);
            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dataGridView1.DataSource = sarafDB.Customer;
        }

        private void comboFromAccount_Leave(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
                dataGridView1.Visible = true;
            else
                dataGridView1.Visible = false;

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;

                comboFromAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
                comboFromAccount.Focus();
            }
        }

        private void comboToAccount_TextChanged(object sender, EventArgs e)
        {
            if (comboToAccount.Text.Trim() == "--Select--")
            {
                dataGridView2.Visible = false;
            }
            else
            {
                dataGridView2.Visible = true;
            }

            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'" + comboToAccountType.SelectedValue + "' and cust_name like '%" + comboToAccount.Text + "%'", Connection.con);
            sarafDB.ToCustomer.Rows.Clear();
            da.Fill(sarafDB.ToCustomer);
            dataGridView2.DataSource = sarafDB.ToCustomer;

            MySqlCommand cmd = new MySqlCommand("select balance from account where id='" + comboToAccount.SelectedValue + "'", Connection.con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (comboToAccount.Text != "--Select--" && comboToAccount.Text != "")
            {
                while (dr.Read())
                    txtToAccountBalance.Text = dr[0].ToString();
            }
            else
                txtToAccountBalance.Text = "0.00";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cn = dataGridView2.CurrentRow.Index;
            comboToAccount.Text = dataGridView2.Rows[cn].Cells[0].Value.ToString();
            dataGridView2.Visible=false;
        }

        private void comboFromAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;
                comboFromAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                comboFromAccount.SelectAll();
                comboFromAccount.Text.Remove(0);
                comboFromAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
            }
        }

        private void comboFromAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridView1.Focus();
                int i = dataGridView1.CurrentRow.Index;
                if(dataGridView1.Visible==true)
                   dataGridView1.CurrentCell = dataGridView1.Rows[i+1].Cells[0];
            }
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboToAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int cn = dataGridView2.CurrentRow.Index;
                comboToAccount.Text = dataGridView2.Rows[cn].Cells[0].Value.ToString();
                dataGridView2.Visible = false;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void comboToAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridView2.Focus();
                int i = dataGridView2.CurrentRow.Index;
                if (dataGridView2.Visible == true)
                    dataGridView2.CurrentCell = dataGridView2.Rows[i + 1].Cells[0];
            }
            e.Handled = true;
        }

        private void comboToAccount_Leave(object sender, EventArgs e)
        {
            if (dataGridView2.Focused)
                dataGridView2.Visible = true;
            else
                dataGridView2.Visible = false;
        }

        private void comboToAccount_Enter(object sender, EventArgs e)
        {
            if (comboToAccount.Text == "--Select--")
                comboToAccount.Text = "";
            if (comboToAccount.Text == "")
                dataGridView2.Visible = true;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'" + comboToAccountType.SelectedValue + "' and cust_name like '%" + comboToAccount.Text + "%'", Connection.con);
            sarafDB.ToCustomer.Rows.Clear();
            da.Fill(sarafDB.ToCustomer);
            dataGridView2.DataSource = sarafDB.ToCustomer;
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int cn = dataGridView2.CurrentRow.Index;
                
                comboToAccount.Text = dataGridView2.Rows[cn].Cells[0].Value.ToString();
                dataGridView2.Visible = false;
                comboToAccount.Focus();
            }
        }


        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        int idPosition;
        private void dgvCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvCurrency.CurrentRow.Index;
            idPosition = (int)dgvCurrency.Rows[i].Cells[4].Value;

            CurrencyForm currency = new CurrencyForm();
            currency.btnSave.Enabled = false;
            currency.id = idPosition;
            currency.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CurrencyForm currncy = new CurrencyForm();
            currncy.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CurrencyForm currency = new CurrencyForm();
            currency.btnSave.Enabled = false;
            currency.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FilldgvCurrency();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboToAccount.SelectedValue.ToString());
        }
    }
}
