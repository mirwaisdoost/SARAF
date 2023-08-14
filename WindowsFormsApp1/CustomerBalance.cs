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
    public partial class CustomerBalance : Form
    {
        public CustomerBalance()
        {
            InitializeComponent();
        }

        private void CustomerBalance_Load(object sender, EventArgs e)
        {
            FillCustomer();
            comboAccount.SelectedIndex = -1;
            FillFullAccount();
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

        private void FillAccount()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,account_name from account where customer_id='" + comboCustomer.SelectedValue + "'"
                , Connection.con);
            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);
            comboAccount.DataSource = sarafDB.account;
            comboAccount.DisplayMember = "account_name";
            comboAccount.Text = "--Select--";
            comboAccount.ValueMember = "id";
            comboAccount.SelectedIndex = -1;
        }

        private void FillFullAccount()
        {
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select id,currency from currency", Connection.con);
            sarafDB.account.Rows.Clear();
            da.Fill(sarafDB.account);
            comboAccount.DataSource = sarafDB.account;
            comboAccount.DisplayMember = "currency";
            comboAccount.Text = "--Select--";
            comboAccount.ValueMember = "id";
            comboAccount.SelectedIndex = -1;
        }

        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAccount();
        }

        private void comboCustomer_Enter(object sender, EventArgs e)
        {
            if (comboCustomer.Text == "--Select--")
                comboCustomer.Text = "";
            if (comboCustomer.Text == "")
                dataGridView1.Visible = true;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter("select cust_name,cust_email,cust_add from customerview where companyID=" +
                "'" + LoginForm.companyId + "' and status=1 and cust_name like '%" + comboCustomer.Text + "%'", Connection.con);

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

            if (comboCustomer.Text == "--Select--")
                FillFullAccount();
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
                    "'" + LoginForm.companyId + "' and status=1 and cust_name like '%" + comboCustomer.Text + "%'", Connection.con);
            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dataGridView1.DataSource = sarafDB.Customer;
            FillAccount();
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

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.BorderStyle = BorderStyle.None;
            Connection.open();

            MySqlDataAdapter da = new MySqlDataAdapter();
            if (comboCustomer.Text == "--Select--" && comboAccount.Text == "" && comboStatus.Text == "")
            {
                da = new MySqlDataAdapter("select * from accountview where" +
                    " date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "' and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "'", Connection.con);
            }
            if (comboCustomer.Text != "--Select--")
            {
                da = new MySqlDataAdapter("select * from accountview where" +
                    " customer_id='" + comboCustomer.SelectedValue + "' and date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "'" +
                    " and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "'", Connection.con);
            }
            if (comboAccount.Text != "" && comboCustomer.Text == "--Select--")
            {
                da = new MySqlDataAdapter("select * from accountview where" +
                    " date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "' and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "'" +
                    " and currency_id='" + comboAccount.SelectedValue + "'", Connection.con);
            }
             if (comboAccount.Text != "" && comboCustomer.Text != "--Select--")
            {
                da = new MySqlDataAdapter("select * from accountview where" +
                    " customer_id='" + comboCustomer.SelectedValue + "' and date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "'" +
                    " and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "' and id='" + comboAccount.SelectedValue + "'", Connection.con);
            }
            if (comboStatus.Text != "")
            {
                da = new MySqlDataAdapter("select * from accountview where date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "'" +
                    " and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "' and customer_status='" + comboStatus.SelectedIndex + "'", Connection.con);
            }
            if (comboStatus.Text != "" && comboAccount.Text != "")
            {
                da = new MySqlDataAdapter("select * from accountview where date between '" + dateFrom.Value.Date.ToString("yy-MM-dd") + "'" +
                   " and '" + dateTo.Value.Date.ToString("yy-MM-dd") + "' and id='" + comboAccount.SelectedValue + "' " +
                   "and customer_status='" + comboStatus.SelectedIndex + "'", Connection.con);
            }

            sarafDB.Balance.Rows.Clear();
            da.Fill(sarafDB.Balance);
            CustomerBalancerpt ts = new CustomerBalancerpt();
            ts.SetDataSource(sarafDB);
            crystalReportViewer1.ReportSource = ts;
            crystalReportViewer1.Zoom(1);

            pnlFilter.Visible = false;
            lblCollaps.Text = "+";


        }

        private void lblCollaps_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible == true)
            {
                pnlFilter.Visible = false;
                lblCollaps.Text = "+";
            }
            else
            {
                pnlFilter.Visible = true;
                lblCollaps.Text = "-";
            }
        }

        private void pnlTitle_DoubleClick(object sender, EventArgs e)
        {
            if (pnlFilter.Visible == true)
            {
                pnlFilter.Visible = false;
                lblCollaps.Text = "+";
            }
            else
            {
                pnlFilter.Visible = true;
                lblCollaps.Text = "-";
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
