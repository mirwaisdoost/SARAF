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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            userDetails();
            FilldgvCurrency();
        }

        private void userDetails()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select name,last_name,Username,Address,phone,email_address,branch,company from user_view where id='" + LoginForm.userId+"'", Connection.con);
            da.Fill(sarafDB.userDetails);

            lblName.Text = sarafDB.userDetails.Rows[0][0].ToString();
            lblName.Text += " " + sarafDB.userDetails.Rows[0][1].ToString();

            lblUser.Text = sarafDB.userDetails.Rows[0][2].ToString();
            lblAddress.Text = sarafDB.userDetails.Rows[0][3].ToString();
            lblPhone.Text = sarafDB.userDetails.Rows[0][4].ToString();
            lblEmail.Text = sarafDB.userDetails.Rows[0][5].ToString();
            lblBranch.Text = sarafDB.userDetails.Rows[0][6].ToString();

        }

        private void FilldgvCurrency()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from currencyview", Connection.con);
            sarafDB.Exchange.Rows.Clear();
            da.Fill(sarafDB.Exchange);
            dgvCurrency.DataSource = sarafDB.Exchange;
            dgvCurrency.Columns[4].Visible = false;
            dgvCurrency.Columns[5].Visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {
            if (pnlUserDetails.Visible == true)
            {
                pnlUserDetails.Visible = false;
                lblUserDetailsCollaps.Text = "+";

            }else if(pnlUserDetails.Visible == false)
            {
                pnlUserDetails.Visible = true;
                lblUserDetailsCollaps.Text = "-";
            }
        }

        private void panel5_DoubleClick(object sender, EventArgs e)
        {
            if (pnlExchange.Visible == true)
            {
                pnlExchange.Visible = false;
                lblExchangeCollaps.Text = "+";

            }
            else if (pnlExchange.Visible == false)
            {
                pnlExchange.Visible = true;
                lblExchangeCollaps.Text = "-";
            }
        }

        private void lblUserDetailsCollaps_Click(object sender, EventArgs e)
        {
            if (pnlUserDetails.Visible == true)
            {
                pnlUserDetails.Visible = false;
                lblUserDetailsCollaps.Text = "+";

            }
            else if (pnlUserDetails.Visible == false)
            {
                pnlUserDetails.Visible = true;
                lblUserDetailsCollaps.Text = "-";
            }
        }

        private void lblExchangeCollaps_Click(object sender, EventArgs e)
        {
            if (pnlExchange.Visible == true)
            {
                pnlExchange.Visible = false;
                lblExchangeCollaps.Text = "+";

            }
            else if (pnlExchange.Visible == false)
            {
                pnlExchange.Visible = true;
                lblExchangeCollaps.Text = "-";
            }
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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CurrencyForm currency = new CurrencyForm();
            currency.btnSave.Enabled = false;
            currency.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CurrencyForm currncy = new CurrencyForm();
            currncy.ShowDialog();
        }

        private void Home_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void Home_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FilldgvCurrency();
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
