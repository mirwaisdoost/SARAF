using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DeleteConfirmation : Form
    {
        public DeleteConfirmation()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BranchForm.option = 1;
            UserForm.option = 1;
            CustomerForm.option = 1;
            AccountForm.option = 1;
            CurrencyForm.option = 1;
            ExpensesType.option = 1;
            Expenses.option = 1;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BranchForm.option = 0;
            UserForm.option = 0;
            CustomerForm.option = 0;
            AccountForm.option = 0;
            CurrencyForm.option = 0;
            ExpensesType.option = 0;
            Expenses.option = 0;
            Close();
        }

        private void DeleteConfirmation_Load(object sender, EventArgs e)
        {

        }

        private void DeleteConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}
