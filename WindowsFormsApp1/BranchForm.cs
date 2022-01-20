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
    public partial class BranchForm : Form
    {
        public BranchForm()
        {
            InitializeComponent();
        }

        private void BranchForm_Load(object sender, EventArgs e)
        {
            FilldgvBranch(int.Parse(LoginForm.companyId));
        }

        public void FilldgvBranch(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            da = new MySqlDataAdapter("select date as Date, branch_name as Branch_Name,branch_phone as Phone,branch_email as Email_Address, branch_address as Address, branch_status,id from branch where company_id=" + id, Connection.con);

            sarafDB.Branch.Rows.Clear();
            da.Fill(sarafDB.Branch);
            dgvBranch.DataSource = sarafDB.Branch;
            dgvBranch.Columns[5].Visible = false;
            dgvBranch.Columns[6].Visible = false;
        }

        int i=-1;
        private void dgvBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            i = dgvBranch.CurrentRow.Index;
            txtDate.Value = (DateTime)dgvBranch.Rows[i].Cells[0].Value;
            txtName.Text = dgvBranch.Rows[i].Cells[1].Value.ToString();
            txtPhone.Text = dgvBranch.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dgvBranch.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dgvBranch.Rows[i].Cells[4].Value.ToString();
            if (dgvBranch.Rows[i].Cells[5].Value.ToString() == "1")
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

                MySqlCommand command = new MySqlCommand("call updateBranch(?,?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@status", check);
                command.Parameters.AddWithValue("@id", dgvBranch.Rows[i].Cells[6].Value);
                command.Parameters.AddWithValue("@company_id", LoginForm.companyId);
                command.ExecuteNonQuery();

                MessageBox.Show("The selected Branch is successfully updated!");
                FilldgvBranch(int.Parse(LoginForm.companyId));
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkActive.Checked)
                    check = 1;
                else
                    check = 0;
                Connection.open();

                MySqlCommand command = new MySqlCommand("call insertBranch(?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@status", check);
                command.Parameters.AddWithValue("@company_id", LoginForm.companyId);

                command.ExecuteNonQuery();

                MessageBox.Show("New Branch is successfully Added!");
                FilldgvBranch(int.Parse(LoginForm.companyId));
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        public static int option = 0;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();

                DeleteConfirmation delete = new DeleteConfirmation();
                delete.Message.Text = "Are you sure you want to delete the selected Branch?";
                delete.ShowDialog();

                if (option == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("delete from branch where id=" + dgvBranch.Rows[i].Cells[6].Value, Connection.con);
                    cmd.ExecuteNonQuery();
                    FilldgvBranch(int.Parse(LoginForm.companyId));
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
            catch(Exception)
            {
                MessageBox.Show("Sorry the selected Branch is in use!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("call searchBranch(?,?,?)", Connection.con);
            da.SelectCommand.Parameters.AddWithValue("@searchText", txtSearch.Text);
            da.SelectCommand.Parameters.AddWithValue("@saerchType", comboSearchType.Text);
            da.SelectCommand.Parameters.AddWithValue("@companyID", LoginForm.companyId);

            sarafDB.Branch.Rows.Clear();
            da.Fill(sarafDB.Branch);
            dgvBranch.DataSource = sarafDB.Branch;
            dgvBranch.Columns[5].Visible = false;
            dgvBranch.Columns[6].Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FilldgvBranch(int.Parse(LoginForm.companyId));
        }

        private void comboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
        }

        private void DgvBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
