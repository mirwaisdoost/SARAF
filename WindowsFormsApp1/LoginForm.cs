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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public static string userId="1";
        public static string companyId="1";
        public static string branchId="1";

        private void LoginForm_Load(object sender, EventArgs e)
        {
            imgFailed.Visible = false;
            imgSuccess.Visible = false;

            pnlHome.Visible = true;
            pnlAboutUs.Visible = false;
            pnlHelp.Visible = false;
            pnlLogin.Visible = false;
            txtUser.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
            timer1.Enabled = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public Point mouseLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUser.Text == "" && txtPassword.Text == "")
                {
                    imgFailed.Visible = true;
                    txtMessage.ForeColor = Color.Red;
                    txtMessage.Text = "Username and Password can not be null !";
                }
                else if (txtUser.Text == "")
                {
                    imgFailed.Visible = true;
                    txtMessage.ForeColor = Color.Red;
                    txtMessage.Text = "Username can not be null !";
                }
                else if (txtPassword.Text == "")
                {
                    imgFailed.Visible = true;
                    txtMessage.ForeColor = Color.Red;
                    txtMessage.Text = "Password can not be null !";
                }
                else
                {
                    Connection.setServer(txtServer.Text, txtPort.Text);
                    Connection.open();

                    MySqlDataAdapter da = new MySqlDataAdapter("select * from user_view where Username=@name and" +
                    " Password=sha1(@pass) and user_status=1 and branch_Status=1 and company_status=1", Connection.con);
                    da.SelectCommand.Parameters.AddWithValue("@name", txtUser.Text);
                    da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);

                    da.Fill(sarafDB.userDetails);

                    int count = sarafDB.userDetails.Rows.Count;
                    da.Dispose();

                    if (count == 1)
                    {
                        userId = sarafDB.userDetails.Rows[0][0].ToString();
                        companyId = sarafDB.userDetails.Rows[0][1].ToString();
                        branchId = sarafDB.userDetails.Rows[0][2].ToString();

                        imgFailed.Visible = false;
                        imgSuccess.Visible = true;
                        txtMessage.ForeColor = Color.Green;
                        txtMessage.Text = "Login succeeded !";
                        MainForm main = new MainForm();
                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Username or Password is incorrect !";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pnlLeft.Width == 100 && lblLoginBottom.BackColor==Color.Black)
            {
                pnlLeft.Width = 33;
                lblLoginBottom.BackColor = Color.CornflowerBlue;
                pnlLogin.Visible = false;
                pnlHome.Visible = true;
            }
            else
            {
                lblLogin.Visible = true;
                pnlLeft.Width = 100;
                lblHelpBottom.BackColor = Color.CornflowerBlue;
                lblAboutUsBottom.BackColor = Color.CornflowerBlue;
                lblLoginBottom.BackColor = Color.Black;
                lblAboutUs.Visible = false;
                lblHelp.Visible = false;

                pnlAboutUs.Visible = false;
                pnlHelp.Visible = false;
                pnlLogin.Visible = true;
                pnlHome.Visible = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pnlLeft.Width == 100 && lblAboutUsBottom.BackColor == Color.Black)
            {
                pnlLeft.Width = 33;
                lblAboutUsBottom.BackColor = Color.CornflowerBlue;
                pnlAboutUs.Visible = false;
                pnlHome.Visible = true;
            }
            else
            {
                lblAboutUs.Visible = true;
                pnlLeft.Width = 100;
                lblHelpBottom.BackColor = Color.CornflowerBlue;
                lblAboutUsBottom.BackColor = Color.Black;
                lblLoginBottom.BackColor = Color.CornflowerBlue;
                lblLogin.Visible = false;
                lblHelp.Visible = false;

                pnlAboutUs.Visible = true;
                pnlHelp.Visible = false;
                pnlLogin.Visible = false;
                pnlHome.Visible = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pnlLeft.Width == 100 && lblHelpBottom.BackColor == Color.Black)
            {
                pnlLeft.Width = 33;
                lblHelpBottom.BackColor = Color.CornflowerBlue;
                pnlHelp.Visible = false;
                pnlHome.Visible = true;
            }
            else
            {
                lblHelp.Visible = true;
                pnlLeft.Width = 100;
                lblHelpBottom.BackColor = Color.Black;
                lblAboutUsBottom.BackColor = Color.CornflowerBlue;
                lblLoginBottom.BackColor = Color.CornflowerBlue;
                lblAboutUs.Visible = false;
                lblLogin.Visible = false;

                pnlAboutUs.Visible = false;
                pnlHelp.Visible = true;
                pnlLogin.Visible = false;
                pnlHome.Visible = false;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtUser.Text == "" && txtPassword.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Username and Password can not be null !";
                    }
                    else if (txtUser.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Username can not be null !";
                    }
                    else if (txtPassword.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Password can not be null !";
                    }
                    else
                    {
                        Connection.setServer(txtServer.Text, txtPort.Text);
                        Connection.open();

                        MySqlDataAdapter da = new MySqlDataAdapter("select * from user_view where Username=@name and" +
                        " Password=sha1(@pass) and user_status=1 and branch_Status=1 and company_status=1", Connection.con);
                        da.SelectCommand.Parameters.AddWithValue("@name", txtUser.Text);
                        da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);

                        da.Fill(sarafDB.userDetails);

                        int count = sarafDB.userDetails.Rows.Count;
                        da.Dispose();

                        if (count == 1)
                        {
                            userId = sarafDB.userDetails.Rows[0][0].ToString();
                            companyId = sarafDB.userDetails.Rows[0][1].ToString();
                            branchId = sarafDB.userDetails.Rows[0][2].ToString();

                            imgFailed.Visible = false;
                            imgSuccess.Visible = true;
                            txtMessage.ForeColor = Color.Green;
                            txtMessage.Text = "Login succeeded !";
                            MainForm main = new MainForm();
                            this.Hide();
                            main.Show();
                        }
                        else
                        {
                            imgFailed.Visible = true;
                            txtMessage.ForeColor = Color.Red;
                            txtMessage.Text = "Username or Password is incorrect !";
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtUser.Text == "" && txtPassword.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Username and Password can not be null !";
                    }
                    else if (txtUser.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Username can not be null !";
                    }
                    else if (txtPassword.Text == "")
                    {
                        imgFailed.Visible = true;
                        txtMessage.ForeColor = Color.Red;
                        txtMessage.Text = "Password can not be null !";
                    }
                    else
                    {
                        Connection.setServer(txtServer.Text, txtPort.Text);
                        Connection.open();

                        MySqlDataAdapter da = new MySqlDataAdapter("select * from user_view where Username=@name and" +
                        " Password=sha1(@pass) and user_status=1 and branch_Status=1 and company_status=1", Connection.con);
                        da.SelectCommand.Parameters.AddWithValue("@name", txtUser.Text);
                        da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);

                        da.Fill(sarafDB.userDetails);
                        int count = sarafDB.userDetails.Rows.Count;
                        da.Dispose();

                        if (count == 1)
                        {
                            userId = sarafDB.userDetails.Rows[0][0].ToString();
                            companyId = sarafDB.userDetails.Rows[0][1].ToString();
                            branchId = sarafDB.userDetails.Rows[0][2].ToString();

                            imgFailed.Visible = false;
                            imgSuccess.Visible = true;
                            txtMessage.ForeColor = Color.Green;
                            txtMessage.Text = "Login succeeded !";
                            MainForm main = new MainForm();
                            this.Hide();
                            main.Show();
                        }
                        else
                        {
                            imgFailed.Visible = true;
                            txtMessage.ForeColor = Color.Red;
                            txtMessage.Text = "Username or Password is incorrect !";
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
