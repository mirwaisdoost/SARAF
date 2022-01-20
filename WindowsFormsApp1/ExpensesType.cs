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
    public partial class ExpensesType : Form
    {
        public ExpensesType()
        {
            InitializeComponent();
        }

        private void ExpensesType_Load(object sender, EventArgs e)
        {
            FilldgvExpensesType();
        }

        public void FilldgvExpensesType()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from expensesType", Connection.con);
            sarafDB.ExpensesType.Rows.Clear();
            da.Fill(sarafDB.ExpensesType);
            dgvExpensesType.DataSource = sarafDB.ExpensesType;
            dgvExpensesType.Columns[0].Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlCommand cmd = new MySqlCommand("insert into expensesType values(null,'" + txtName.Text + "','" + txtDescription.Text + "')", Connection.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The new item has successfully added!");
            FilldgvExpensesType();
        }
        
        private void DgvExpensesType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static int option = 0;
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            DeleteConfirmation delete = new DeleteConfirmation();
            delete.Message.Text = "Are you sure you want to delete the selectd item?";
            delete.ShowDialog();

            if (option == 1)
            {
                MySqlCommand cmd = new MySqlCommand("delete from expensesType where id='" + dgvExpensesType.Rows[r].Cells[0].Value + "'", Connection.con);
                cmd.ExecuteNonQuery();
                FilldgvExpensesType();
                txtDescription.Text = "";
                txtName.Text = "";
            }
            option = 0;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlCommand cmd = new MySqlCommand("update expensesType set name='"+txtName.Text+"', description='"+txtDescription.Text+"' where id='"+dgvExpensesType.Rows[r].Cells[0].Value+"'",Connection.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The selected item has been successfully updated!");
            FilldgvExpensesType();
        }

        int r;
        private void DgvExpensesType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            r = dgvExpensesType.CurrentRow.Index;
            txtName.Text = dgvExpensesType.Rows[r].Cells[1].Value.ToString();
            txtDescription.Text = dgvExpensesType.Rows[r].Cells[2].Value.ToString();
        }
    }
}
