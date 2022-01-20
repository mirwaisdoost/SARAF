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
    public partial class TransferBill : Form
    {
        public TransferBill()
        {
            InitializeComponent();
        }

        private void TransferBill_Load(object sender, EventArgs e)
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from TransferTransactionView where id ='" + Transfer.transferID + "'", Connection.con);
            sarafDB.Transfer.Rows.Clear();
            da.Fill(sarafDB.Transfer);
            TransferBillrpt bill = new TransferBillrpt();
            bill.SetDataSource(sarafDB);
            crystalReportViewer1.ReportSource = bill;
            crystalReportViewer1.Zoom(1);
        }
    }
}
