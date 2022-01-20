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
    public partial class TransactionBill : Form
    {
        public TransactionBill()
        {
            InitializeComponent();
        }

        private void TransactionBill_Load(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from transactionview where id='"+Transaction.transactionID+"'",Connection.con);
            sarafDB.Transaction.Rows.Clear();
            da.Fill(sarafDB.Transaction);
            TransactionBillrpt cr = new TransactionBillrpt();
            cr.SetDataSource(sarafDB);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Zoom(1);
        }
    }
}
