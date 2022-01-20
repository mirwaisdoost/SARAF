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
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp1
{
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            FilldgvCompany(int.Parse(LoginForm.companyId));
        }

        public void FilldgvCompany(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            Connection.open();
            da = new MySqlDataAdapter("select date as Date, company_name as Company_Name,company_phone as Phone,company_email as Email_Address, company_address as Address, company_status,id from company where id="+id, Connection.con);
            
            sarafDB.Company.Rows.Clear();
            da.Fill(sarafDB.Company);
            dvgCompany.DataSource = sarafDB.Company;
            dvgCompany.Columns[5].Visible = false;
            dvgCompany.Columns[6].Visible = false;
        }

        int i;
        private void dvgCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dvgCompany.CurrentRow.Index;
            txtDate.Value = (DateTime)dvgCompany.Rows[i].Cells[0].Value;
            txtName.Text = dvgCompany.Rows[i].Cells[1].Value.ToString();
            txtPhone.Text = dvgCompany.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dvgCompany.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dvgCompany.Rows[i].Cells[4].Value.ToString();
            if (dvgCompany.Rows[i].Cells[5].Value.ToString() == "1")
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
                MySqlCommand command = new MySqlCommand();
                
                command = new MySqlCommand("call updateCompany(?,?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@status", check);
                command.Parameters.AddWithValue("@id", dvgCompany.Rows[i].Cells[6].Value);

                command.ExecuteNonQuery();
                
                MessageBox.Show("The selected Company is successfully updated!");
                FilldgvCompany(int.Parse(LoginForm.companyId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkActive.Checked)
                    check = 1;
                else
                    check = 0;
                Connection.open();
                MySqlCommand command = new MySqlCommand();

                command = new MySqlCommand("call insertCompany(?,?,?,?,?,?)", Connection.con);

                command.Parameters.AddWithValue("@date", txtDate.Value.Date.ToString("yy-MM-dd"));
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@status", check);

                command.ExecuteNonQuery();

                MessageBox.Show("New Company is successfully Added!");
                FilldgvCompany(int.Parse(LoginForm.companyId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ex.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtDate.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            checkActive.Checked = false;



            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("bcsqaleb18@gmail.com");
                message.To.Add(new MailAddress("mirwaisdoost@hotmail.com"));
                message.Subject = "Test";
                message.Body = "Content";

               // message.Attachments.Add(new Attachment(@"D:/saraf_codes.sql"));

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("bcsqaleb18@gmail.com", "Mirwais@123ToDoost");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }

            //https://myaccount.google.com/security?pli=1#connectedapps  Allows any google account for less secure
        }
    }
}
