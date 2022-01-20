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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        int i;
        private void DgvCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgvExpenses.CurrentRow.Index;
            txtName.Text = dgvExpenses.Rows[i].Cells[1].Value.ToString();
            comboType.Text = dgvExpenses.Rows[i].Cells[2].Value.ToString();
            txtBalance.Text = dgvExpenses.Rows[i].Cells[3].Value.ToString();
            txtDescription.Text = dgvExpenses.Rows[i].Cells[4].Value.ToString();
            dgvExpenses.Columns[0].Visible = false;
            btnDelete.Enabled = true;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlCommand cmd = new MySqlCommand("insert into expenses values(null,'"+txtName.Text+"','"+comboType.SelectedValue+"','"+txtBalance.Text+"','"+txtDescription.Text+"')",Connection.con);
            MessageBox.Show("New item has successfully inserted");
            fillDgvExpenses();
            cmd.ExecuteNonQuery();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            fillExpenseType();
            fillDgvExpenses();
        }

        private void fillDgvExpenses()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from expensesView", Connection.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvExpenses.DataSource = dt;
        }

        private void fillExpenseType()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from expensesType", Connection.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboType.DataSource = dt;
            comboType.DisplayMember = "Name";
            comboType.ValueMember = "ID";
        }

        private void Panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        public static int option = 0;
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Connection.open();
            DeleteConfirmation delete = new DeleteConfirmation();
            delete.ShowDialog();
            if (option == 1)
            {
                MySqlCommand cmd = new MySqlCommand("delete from Expenses where id='" + dgvExpenses.Rows[i].Cells[0] + "'", Connection.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The selected item has successfully deleted!");
                fillDgvExpenses();
            }
            option = 0;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Connection.open();
            MySqlCommand cmd = new MySqlCommand("update expenses set name='"+txtName.Text+"', expTypeID='"+comboType.SelectedValue+"', " +
                "Balance='"+txtBalance.Text+"', description='"+txtDescription.Text+"' where id='"+dgvExpenses.Rows[i].Cells[0].Value+"'",
                Connection.con);
            MessageBox.Show("The selected item has successfully updated!");
            cmd.ExecuteNonQuery();
            fillDgvExpenses();
        }
    }
}
