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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            FillcomboUserType();
            FilldgvUser(int.Parse(LoginForm.companyId), int.Parse(LoginForm.branchId));
        }

        public void FilldgvUser(int companyId, int branchId)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            da = new MySqlDataAdapter("select* from user_view where companyId=" + companyId + " and branchId=" + branchId, Connection.con);

            sarafDB.userDetails.Rows.Clear();
            da.Fill(sarafDB.userDetails);
            dgvUser.DataSource = sarafDB.userDetails;
            dgvUser.Columns[0].Visible = false;
            dgvUser.Columns[1].Visible = false;
            dgvUser.Columns[2].Visible = false;
            dgvUser.Columns[7].Visible = false;
            dgvUser.Columns[8].Visible = false;
            dgvUser.Columns[9].Visible = false;
            dgvUser.Columns[13].Visible = false;
            dgvUser.Columns[15].Visible = false;
            dgvUser.Columns[16].Visible = false;
        }

        private void FillcomboUserType()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from usertype", Connection.con);

            da.Fill(sarafDB.userType);
            comboUserTpe.DataSource = sarafDB.userType;
            comboUserTpe.DisplayMember = "Name";
            comboUserTpe.ValueMember = "id";
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
                MySqlCommand command = new MySqlCommand("call updateUser(?,?,?,?,?,?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@lastName", txtLastName.Text);
                command.Parameters.AddWithValue("@userName", txtUsername.Text);
                command.Parameters.AddWithValue("@pass", txtPassword.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@usertYpe", comboUserTpe.SelectedValue);
                command.Parameters.AddWithValue("@status", check);
                command.Parameters.AddWithValue("@branchId", LoginForm.branchId);
                command.Parameters.AddWithValue("@id", dgvUser.Rows[i].Cells[0].Value);
                command.ExecuteNonQuery();

                MessageBox.Show("The selected User is successfully updated!");
                FilldgvUser(int.Parse(LoginForm.companyId),int.Parse(LoginForm.branchId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        int i = -1;
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            i = dgvUser.CurrentRow.Index;
            txtDate.Value = (DateTime)dgvUser.Rows[i].Cells[3].Value;
            txtName.Text = dgvUser.Rows[i].Cells[4].Value.ToString();
            txtLastName.Text = dgvUser.Rows[i].Cells[5].Value.ToString();
            txtUsername.Text = dgvUser.Rows[i].Cells[6].Value.ToString();
            txtPassword.Text = dgvUser.Rows[i].Cells[7].Value.ToString();
            txtPhone.Text = dgvUser.Rows[i].Cells[11].Value.ToString();
            txtEmail.Text = dgvUser.Rows[i].Cells[12].Value.ToString();
            txtAddress.Text = dgvUser.Rows[i].Cells[10].Value.ToString();
            comboUserTpe.Text = dgvUser.Rows[i].Cells[14].Value.ToString();
            if (dgvUser.Rows[i].Cells[13].Value.ToString() == "1")
                checkActive.Checked = true;
            else
                checkActive.Checked = false;
        }


        public static int option = 0;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.open();

                DeleteConfirmation delete = new DeleteConfirmation();
                delete.Message.Text = "Are you sure you want to delete the selected User?";
                delete.ShowDialog();

                if (option == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("delete from user where id=" + dgvUser.Rows[i].Cells[0].Value, Connection.con);
                    cmd.ExecuteNonQuery();
                    FilldgvUser(int.Parse(LoginForm.companyId), int.Parse(LoginForm.branchId));
                    option = 0;
                    i = -1;
                    btnDelete.Enabled = false;

                    txtName.Text = "";
                    txtLastName.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    comboUserTpe.SelectedIndex = -1;
                    checkActive.Checked = false;
                }
                option = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry the selected Branch is in use!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
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
                MySqlCommand command = new MySqlCommand("call insertUser(?,?,?,?,?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@lastName", txtLastName.Text);
                command.Parameters.AddWithValue("@userName", txtUsername.Text);
                command.Parameters.AddWithValue("@pass", txtPassword.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@usertYpe", comboUserTpe.SelectedValue);
                command.Parameters.AddWithValue("@status", check);
                command.Parameters.AddWithValue("@branchId", LoginForm.branchId);
                command.ExecuteNonQuery();

                MessageBox.Show("New User is successfully Added!");
                FilldgvUser(int.Parse(LoginForm.companyId), int.Parse(LoginForm.branchId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txtName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            comboUserTpe.SelectedIndex = -1;
            checkActive.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("call searchUser(?,?,?,?)", Connection.con);
            da.SelectCommand.Parameters.AddWithValue("@searchText", txtSearch.Text);
            da.SelectCommand.Parameters.AddWithValue("@saerchType", comboSearchType.Text);
            da.SelectCommand.Parameters.AddWithValue("@companyID", LoginForm.companyId);
            da.SelectCommand.Parameters.AddWithValue("@branchID", LoginForm.branchId);

            sarafDB.userDetails.Rows.Clear();
            da.Fill(sarafDB.userDetails);
            dgvUser.DataSource = sarafDB.userDetails;

            dgvUser.Columns[0].Visible = false;
            dgvUser.Columns[1].Visible = false;
            dgvUser.Columns[2].Visible = false;
            dgvUser.Columns[7].Visible = false;
            dgvUser.Columns[8].Visible = false;
            dgvUser.Columns[9].Visible = false;
            dgvUser.Columns[13].Visible = false;
            dgvUser.Columns[15].Visible = false;
            dgvUser.Columns[16].Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FilldgvUser(int.Parse(LoginForm.companyId), int.Parse(LoginForm.branchId));
        }
    }
}
