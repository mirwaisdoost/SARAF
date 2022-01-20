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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FilldgvCustomer(int.Parse(LoginForm.companyId));
        }

        private void FilldgvCustomer(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            da = new MySqlDataAdapter("select * from customerview where companyID=" + id, Connection.con);

            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dgvCustomer.DataSource = sarafDB.Customer;

            dgvCustomer.Columns[0].Visible = false;
            dgvCustomer.Columns[6].Visible = false;
            dgvCustomer.Columns[7].Visible = false;
            dgvCustomer.Columns[8].Visible = false;
            dgvCustomer.Columns[9].Visible = false;
        }

        int i = -1;
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            i = dgvCustomer.CurrentRow.Index;
            txtDate.Value = (DateTime)dgvCustomer.Rows[i].Cells[1].Value;
            txtName.Text = dgvCustomer.Rows[i].Cells[2].Value.ToString();
            txtPhone.Text = dgvCustomer.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text = dgvCustomer.Rows[i].Cells[4].Value.ToString();
            txtAddress.Text = dgvCustomer.Rows[i].Cells[5].Value.ToString();
            if (dgvCustomer.Rows[i].Cells[6].Value.ToString() == "1")
                checkActive.Checked = true;
            else
                checkActive.Checked = false;
        }


        int check;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkActive.Checked)
                    check = 1;
                else
                    check = 0;

                Connection.open();
                MySqlCommand command = new MySqlCommand("call updateCustomer(?,?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@id", dgvCustomer.Rows[i].Cells[0].Value);
                command.Parameters.AddWithValue("@user_id", LoginForm.userId);
                command.Parameters.AddWithValue("@status", check);

                command.ExecuteNonQuery();

                MessageBox.Show("The selected Customer is successfully updated!");
                FilldgvCustomer(int.Parse(LoginForm.companyId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txtDate.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            checkActive.Checked = false;
        }

        public static int option = 0;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();

                DeleteConfirmation delete = new DeleteConfirmation();
                delete.Message.Text = "Are you sure you want to delete the selected Customer?";
                delete.ShowDialog();

                if (option == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("delete from customer where id=" + dgvCustomer.Rows[i].Cells[0].Value, Connection.con);
                    cmd.ExecuteNonQuery();
                    FilldgvCustomer(int.Parse(LoginForm.companyId));
                    option = 0;
                    i = -1;
                    btnDelete.Enabled = false;

                    txtDate.Text = "";
                    txtName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    checkActive.Checked = false;
                }
                option = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry the selected Customer is in use!");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkActive.Checked)
                    check = 1;
                else
                    check = 0;

                Connection.open();
                MySqlCommand command = new MySqlCommand("call updateCustome(?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@user_id", LoginForm.userId);
                command.Parameters.AddWithValue("@status", check);

                command.ExecuteNonQuery();

                MessageBox.Show("New Customer is successfully Added!");
                FilldgvCustomer(int.Parse(LoginForm.companyId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txtDate.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            checkActive.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("call searchCustomer(?,?,?)", Connection.con);
            da.SelectCommand.Parameters.AddWithValue("@searchText", txtSearch.Text);
            da.SelectCommand.Parameters.AddWithValue("@saerchType", comboSearchType.Text);
            da.SelectCommand.Parameters.AddWithValue("@companyID", LoginForm.companyId);

            sarafDB.Customer.Rows.Clear();
            da.Fill(sarafDB.Customer);
            dgvCustomer.DataSource = sarafDB.Customer;

            dgvCustomer.Columns[0].Visible = false;
            dgvCustomer.Columns[6].Visible = false;
            dgvCustomer.Columns[7].Visible = false;
            dgvCustomer.Columns[8].Visible = false;
            dgvCustomer.Columns[9].Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FilldgvCustomer(int.Parse(LoginForm.companyId));
        }

        private void comboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
        }
    }
}
