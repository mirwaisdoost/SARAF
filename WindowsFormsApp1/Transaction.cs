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
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public static int transactionID;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                transactionID = int.Parse(txtTransactionID.Text);
                TransactionBill bill = new TransactionBill();
                bill.ShowInTaskbar = false;
                bill.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show("Please specify a transaction#");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboAccount.SelectedValue.ToString());
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            Connection.open();
            
            comboTransactionType.Text = "--Select--";
            FillCurrency();
            FillAccountType();
            txtDate.Focus();
            FilldgvCurrency();

            dgvCurrency.Columns[4].Visible = false;
            dgvCurrency.Columns[5].Visible = false;
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void FilldgvCurrency()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from currencyview", Connection.con);
            sarafDB.Exchange.Rows.Clear();
            da.Fill(sarafDB.Exchange);
            dgvCurrency.DataSource = sarafDB.Exchange;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
          
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void comboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboAccountType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,id,currency_id from accountview where currency_id='" + comboAccountType.SelectedValue + "'", Connection.con);
            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);
            comboAccount.DataSource = sarafDB.account;
            comboAccount.DisplayMember = "cust_name";
            comboAccount.ValueMember = "id";
            comboAccount.Text = "--Select--";
        }

        private void FillCurrency()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency",Connection.con);
            da.Fill(sarafDB.currency);
            comboCurrency.DataSource = sarafDB.currency;
            comboCurrency.DisplayMember = "currency";
            comboCurrency.ValueMember = "id";
            comboCurrency.Text = "--Select--";
            comboCurrency.SelectedIndex = -1;
        }

        private void FillAccountType()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency", Connection.con);
            sarafDB.accountType.Rows.Clear();
            da.Fill(sarafDB.accountType);
            comboAccountType.DataSource = sarafDB.accountType;
            comboAccountType.DisplayMember = "currency";
            comboAccountType.ValueMember = "id";
            comboAccountType.Text = "--Select--";
            comboAccountType.SelectedIndex = -1;
        }

        private void comboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();
                MySqlCommand transaction_id = new MySqlCommand("select auto_increment from information_schema.tables" +
                    " where table_schema='saraf' and table_name='transaction'", Connection.con);
                MySqlDataReader dr = transaction_id.ExecuteReader();
                while (dr.Read())
                    txtTransactionID.Text = dr.GetString(0);
                Connection.close();

                Connection.open();
                MySqlCommand command = new MySqlCommand("call insert_transaction(?,?,?,?,?,?,?,?,?,?)", Connection.con);
                if(checkManualRate.Checked==true && float.Parse(txtRate.Text) <= 0)
                {
                    MessageBox.Show("Please specify the Exchange Rate");
                }
                else if (comboTransactionType.SelectedIndex == 0)
                {
                    if (comboAccount.SelectedValue == null||comboCurrency.Text.Trim()=="")
                    {
                        MessageBox.Show("Fields with asterisk can not be null");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                        command.Parameters.AddWithValue("@account_id", comboAccount.SelectedValue);
                        command.Parameters.AddWithValue("@credit", txtAmount.Text);
                        command.Parameters.AddWithValue("@cr_currency_id", comboCurrency.SelectedValue);
                        command.Parameters.AddWithValue("@rate", txtRate.Text);
                        command.Parameters.AddWithValue("@debit", 0);
                        command.Parameters.AddWithValue("@db_currency_id", comboAccountType.SelectedValue);
                        command.Parameters.AddWithValue("@to_account", 0);
                        command.Parameters.AddWithValue("@user_id", 1);
                        command.Parameters.AddWithValue("@description", txtDescription.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Transaction has succesfully saved");
                        Connection.close();
                    }
                }
                else if (comboTransactionType.SelectedIndex == 1)
                {
                    if (comboAccount.SelectedValue == null||comboCurrency.Text.Trim()=="")
                    {
                        MessageBox.Show("Fields with asterisk can not be null");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                        command.Parameters.AddWithValue("@account_id", comboAccount.SelectedValue);
                        command.Parameters.AddWithValue("@credit", 0);
                        command.Parameters.AddWithValue("@cr_currency_id", comboAccountType.SelectedValue);
                        command.Parameters.AddWithValue("@rate", txtRate.Text);
                        command.Parameters.AddWithValue("@debit", txtAmount.Text);
                        command.Parameters.AddWithValue("@db_currency_id", comboCurrency.SelectedValue);
                        command.Parameters.AddWithValue("@to_account", 0);
                        command.Parameters.AddWithValue("@user_id", 1);
                        command.Parameters.AddWithValue("@description", txtDescription.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Transaction has succesfully saved");
                        Connection.close();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a transaction type");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolPost_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkManualRate.Checked == true)
            {
                txtRate.Visible = true;
            }
            else
            {
                txtRate.Visible = false;
                txtRate.Text = "0.00";
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTransactionID_Enter(object sender, EventArgs e)
        {
            if (txtTransactionID.Text.Trim() == "")
            {
                txtTransactionID.Text = "--New--";
            }
        }

        private void txtTransactionID_Leave(object sender, EventArgs e)
        {
            if (txtTransactionID.Text.Trim() == "")
            {
                txtTransactionID.Text = "--New--";
            }
        }

        private void comboTransactionType_Enter(object sender, EventArgs e)
        {
            if (comboTransactionType.Text.Trim() == "")
            {
                comboTransactionType.Text = "--Select--";
            }
        }

        private void comboTransactionType_Leave(object sender, EventArgs e)
        {
            if (comboTransactionType.Text.Trim() == "")
            {
                comboTransactionType.Text = "--Select--";
            }
        }

        private void comboAccountType_Enter(object sender, EventArgs e)
        {
            if (comboAccountType.Text.Trim() == "")
            {
                comboAccountType.Text = "--Select--";
            }
        }

        private void comboAccount_Enter(object sender, EventArgs e)
        {
           
            if (comboAccount.Text == "--Select--")
                comboAccount.Text = "";
            if (comboAccount.Text == "")
                dataGridView1.Visible = true;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'" + comboAccountType.SelectedValue + "' and cust_name like '%" + comboAccount.Text + "%'", Connection.con);
            sarafDB.ToCustomer.Rows.Clear();
            da.Fill(sarafDB.ToCustomer);
            dataGridView1.DataSource = sarafDB.ToCustomer;
        }

        private void comboAccount_Leave(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
                dataGridView1.Visible = true;
            else if(comboAccount.Text == "")
            {
                dataGridView1.Visible = false;
                comboAccount.Text = "--Select--";
            }
        }

        private void comboCurrency_Enter(object sender, EventArgs e)
        {
            if (comboCurrency.Text.Trim() == "")
            {
                comboCurrency.Text = "--Select--";
            }
        }

        private void comboCurrency_Leave(object sender, EventArgs e)
        {
            if (comboCurrency.Text.Trim() == "")
            {
                comboCurrency.Text = "--Select--";
            }
        }

        private void comboAccountType_Leave(object sender, EventArgs e)
        {
            if (comboAccountType.Text.Trim() == "")
            {
                comboAccountType.Text = "--Select--";
            }
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
            {
                txtAmount.Text = "0.00";
            }

            txtAmount.SelectAll();
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
            {
                txtAmount.Text = "0.00";
            }
        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            if (txtRate.Text.Trim() == "")
            {
                txtRate.Text = "0.00";
            }

            txtRate.SelectAll();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (txtRate.Text.Trim() == "")
            {
                txtRate.Text = "0.00";
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtAmount.SelectAll();
        }

        private void txtRate_MouseClick(object sender, MouseEventArgs e)
        {
            txtRate.SelectAll();
        }

        private void txtTransactionID_MouseClick(object sender, MouseEventArgs e)
        {
            txtTransactionID.SelectAll();
        }

        private void comboAccount_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void comboAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;
                comboAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cn = dataGridView1.CurrentRow.Index;
            comboAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
            dataGridView1.Visible = false;
        }

        private void comboAccount_TextChanged(object sender, EventArgs e)
        {
            if (comboAccount.Text.Trim() == "--Select--")
            {
                dataGridView1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
            }

            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from accountview where currency_id=" +
                "'" + comboAccountType.SelectedValue + "' and cust_name like '%" + comboAccount.Text + "%'", Connection.con);
            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dataGridView1.DataSource = sarafDB.Customer;

            MySqlCommand cmd = new MySqlCommand("select balance from account where id='" + comboAccount.SelectedValue + "'", Connection.con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (comboAccount.Text != "--Select--" && comboAccount.Text != "")
            {
                while (dr.Read())
                    txtAccountBalance.Text = dr[0].ToString();
            }else
                txtAccountBalance.Text = "0.00";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int cn = dataGridView1.CurrentRow.Index;
                comboAccount.Text = dataGridView1.Rows[cn].Cells[0].Value.ToString();
                dataGridView1.Visible = false;
                comboAccount.Focus();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CurrencyForm currncy = new CurrencyForm();
            currncy.ShowDialog();
        }

       
        private void dgvCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public int idPosition;
        private void toolStripButton7_Click(object sender, EventArgs e)
        { 
            CurrencyForm currency = new CurrencyForm();
            currency.btnSave.Enabled = false;
            currency.ShowDialog();
        }

        private void dgvCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvCurrency.CurrentRow.Index;
            idPosition = (int)dgvCurrency.Rows[i].Cells[4].Value;

            CurrencyForm currency = new CurrencyForm();
            currency.btnSave.Enabled = false;
            currency.id = idPosition;
            currency.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FilldgvCurrency();
        }
    }
}
