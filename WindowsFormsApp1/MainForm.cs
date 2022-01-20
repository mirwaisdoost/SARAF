using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            //NavigationPage.SetHasBackButton(this, false);

            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }

        private void mirwaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mirwais m = new Mirwais();
            m.ShowDialog();
        }

        private void rohullahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RohullahFT ft = new RohullahFT();
            ft.ShowDialog();
        }

        private void fatemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatema f = new fatema();
            f.ShowDialog();
        }

        private void martonisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Martonis martin = new Martonis();
            martin.ShowDialog();
        }

        private void splahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Visible = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            messagesBox.Controls.Add(messageText);
            messageText.Dock = DockStyle.Left;
            errorsBox.Controls.Add(errorText);
            errorText.Dock = DockStyle.Left;

            leftPanel.Visible = false;
            rightPanel.Visible = false;

            home();
            userDetails();
        }

        private void userDetails()
        {
            Connection.open();
            MySqlDataAdapter da = new MySqlDataAdapter("select name,last_name,Username,Address,phone,email_address,branch,company from user_view where id='" + LoginForm.userId + "'", Connection.con);
            da.Fill(sarafDB.userDetails);
            lblServer.Text = sarafDB.userDetails.Rows[0][2].ToString() + "@" + Connection.server + ":" + Connection.port;
            lblUserCompany.Text= sarafDB.userDetails.Rows[0][0].ToString() +" "+ sarafDB.userDetails.Rows[0][1].ToString() + " / " + sarafDB.userDetails.Rows[0][7].ToString();
        }
        
        private void home()
        {
            homeForm.Add(new Home());
            homeForm[hi].TopLevel = false;
            pnlCenter.Controls.Add(homeForm[hi]);
            homeForm[hi].Dock = DockStyle.Fill;
            homeForm[hi].Show();
            home_position.Add(tab_index);
            tabType.Add(0);
            tabTypeIndex.Add(hi);

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            homeForm[hi].Visible = true;

            home_btn.Add(new Label());
            home_lbl.Add(new Panel());
            home_cls.Add(new Label());
            home_isSelect.Add(0);
            home_btn[hi].AutoSize = true;
            home_btn[hi].Text = "Home";
            home_btn[hi].Margin = new Padding(0, 0, 0, 0);
            home_lbl[hi].Margin = new Padding(0, 0, 0, 0);
            home_btn[hi].Padding = new Padding(0, 5, 0, 5);
            home_lbl[hi].Padding = new Padding(0, 0, 0, 25);

            home_cls[hi].AutoSize = true;
            home_cls[hi].Text = "X";
            home_cls[hi].Margin = new Padding(0, 0, 0, 0);
            home_cls[hi].Padding = new Padding(5, 5, 5, 5);

            HorizontalTab.ColumnCount = tab_index + 1;
            home_btn[hi].TextAlign = ContentAlignment.MiddleCenter;
            home_btn[hi].ForeColor = Color.Black;
            home_btn[hi].BackColor = Color.FromArgb(209, 209, 225);
            home_btn[hi].FlatStyle = FlatStyle.Flat;

            home_cls[hi].TextAlign = ContentAlignment.MiddleCenter;
            home_cls[hi].ForeColor = Color.Black;
            home_cls[hi].BackColor = Color.FromArgb(209, 209, 225);
            home_cls[hi].FlatStyle = FlatStyle.Flat;

            lstTab.Items.Add(home_btn[hi].Text);
            lstTab.SelectedIndex = tab_index;

            home_btn[hi].MouseHover += new EventHandler(home_btn_MouseHover);

            home_btn[hi].MouseLeave += new EventHandler(home_btn_MouseLeave);

            home_btn[hi].Click += new EventHandler(home_btn_MouseClick);


            home_cls[hi].MouseHover += new EventHandler(home_cls_MouseHover);

            home_cls[hi].MouseLeave += new EventHandler(home_cls_MouseLeave);

            home_cls[hi].Click += new EventHandler(home_cls_MouseClick);


            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            home_btn[hi].BackColor = Color.CornflowerBlue;
            home_btn[hi].ForeColor = Color.White;
            home_isSelect[hi] = 1;

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;
            }

            home_cls[hi].BackColor = Color.CornflowerBlue;
            home_cls[hi].ForeColor = Color.White;
            home_isSelect[hi] = 1;

            home_cls[hi].AutoSize = true;
            home_btn[hi].Dock = DockStyle.Left;
            home_cls[hi].Dock = DockStyle.Right;
            home_lbl[hi].AutoSize = true;
            home_lbl[hi].Controls.Add(home_btn[hi]);
            home_lbl[hi].Controls.Add(home_cls[hi]);
            home_btn[hi].Dock = DockStyle.Left;
            home_cls[hi].Dock = DockStyle.Right;

            HorizontalTab.Controls.Add(home_lbl[hi], 0, tab_index);
            hi++;
            tab_index++;
        }

        void home_btn_MouseHover(object Sender, EventArgs E)
        {
            index = home_btn.IndexOf((Label)Sender);
            if (home_isSelect[index] == 0)
            {
                home_btn[index].BackColor = Color.FromArgb(202, 202, 220);
                home_cls[index].ForeColor = Color.Black;
                home_cls[index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void home_btn_MouseLeave(object Sender, EventArgs E)
        {
            try
            {
                index = home_btn.IndexOf((Label)Sender);
                if (home_isSelect[index] == 0)
                {
                    home_btn[index].BackColor = Color.FromArgb(209, 209, 225);
                    home_btn[index].ForeColor = Color.Black;
                    home_cls[index].ForeColor = Color.FromArgb(209, 209, 225);
                    home_cls[index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
            catch (Exception ex)
            {
                pnlMessage.Visible = true;
                errorsBox.Visible = true;
                messagesBox.Visible = false;
                errorText.Text = "";
                errorText.Text = ex.ToString();

                lblTitle.Text = "Errors";

                lblErrorButtom.BackColor = Color.Black;
            }
        }




        void home_btn_MouseClick(object Sender, EventArgs E)
        {
            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            home_lbl[0].Visible = true;
            homeForm[0].Visible = true;

            home_btn[0].BackColor = Color.CornflowerBlue;
            home_btn[0].ForeColor = Color.White;
            home_isSelect[0] = 1;
            homeForm[0].Visible = true;

            control_position = home_position[0];
            lstTab.SelectedIndex = control_position;

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            home_cls[index].BackColor = Color.CornflowerBlue;
            home_cls[index].ForeColor = Color.White;
            home_isSelect[index] = 1;

        }

        void home_cls_MouseHover(object Sender, EventArgs E)
        {
            index = home_cls.IndexOf((Label)Sender);
            if (home_isSelect[index] == 0)
            {
                home_btn[index].BackColor = Color.FromArgb(202, 202, 220);
                home_cls[index].ForeColor = Color.Black;
                home_cls[index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void home_cls_MouseLeave(object Sender, EventArgs E)
        {
            int new_index = home_cls.IndexOf((Label)Sender);
            if (new_index == index)
            {
                if (home_isSelect[index] == 0)
                {
                    home_btn[index].BackColor = Color.FromArgb(209, 209, 225);
                    home_btn[index].ForeColor = Color.Black;
                    home_cls[index].ForeColor = Color.FromArgb(209, 209, 225);
                    home_cls[index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
        }

        void home_cls_MouseClick(object Sender, EventArgs E)
        {
            index = home_cls.IndexOf((Label)Sender);

            control_position = home_position[index];

            home_lbl[0].Visible = false;
            homeForm[0].Visible = false;
            
            if (control_position == 0)
            {
                if(lstTab.Items.Count>1)
                    lstTab.SelectedIndex = control_position + 1;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public static Label messageText = new Label();
        public static Label errorText = new Label();

        int tab_index = 0;
        int control_position = 0;
        List<int> tabType = new List<int>(); //0 for home, 1 for transaction, 2 for transfer, 3 for transaction_statement
        List<int> tabTypeIndex = new List<int>();

        int ii = 0;
        int index;
        List<int> tran_position = new List<int>();
        List<Label> btn = new List<Label>();
        List<Panel> lbl = new List<Panel>();
        List<Label> cls = new List<Label>();
        List<int> isSelect = new List<int>();
        List<Transaction> tran = new List<Transaction>();

        int i = 0;
        int transfer_index;
        List<int> transfer_position = new List<int>();
        List<Label> transfer_btn = new List<Label>();
        List<Panel> transfer_lbl = new List<Panel>();
        List<Label> transfer_cls = new List<Label>();
        List<int> transfer_isSelect = new List<int>();
        List<Transfer> transfer = new List<Transfer>();

        int ri = 0;
        int transaction_statement_index;
        List<int> transaction_statement_position = new List<int>();
        List<Label> transaction_statement_btn = new List<Label>();
        List<Panel> transaction_statement_lbl = new List<Panel>();
        List<Label> transaction_statement_cls = new List<Label>();
        List<int> transaction_statement_isSelect = new List<int>();
        List<TransactionStatement> transaction_statement = new List<TransactionStatement>();

        int ci = 0;
        int customer_balance_index;
        List<int> customer_balance_position = new List<int>();
        List<Label> customer_balance_btn = new List<Label>();
        List<Panel> customer_balance_lbl = new List<Panel>();
        List<Label> customer_balance_cls = new List<Label>();
        List<int> customer_balance_isSelect = new List<int>();
        List<CustomerBalance> customer_balance = new List<CustomerBalance>();

        int hi = 0;
       // int home_index;
        List<int> home_position = new List<int>();
        List<Label> home_btn = new List<Label>();
        List<Panel> home_lbl = new List<Panel>();
        List<Label> home_cls = new List<Label>();
        List<int> home_isSelect = new List<int>();
        List<Home> homeForm = new List<Home>();


        private void transactionTab()
        {
            tran.Add(new Transaction());
            tran[ii].TopLevel = false;
            pnlCenter.Controls.Add(tran[ii]);
            tran[ii].Dock = DockStyle.Fill;
            tran[ii].Show();
            tran[ii].panel1.AutoScroll = true;
            tran_position.Add(tab_index);
            tabType.Add(1);
            tabTypeIndex.Add(ii);

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            tran[ii].Visible = true;

            btn.Add(new Label());
            lbl.Add(new Panel());
            cls.Add(new Label());
            isSelect.Add(0);
            btn[ii].AutoSize = true;
            btn[ii].Text = "Transaction-" + ii;
            btn[ii].Margin = new Padding(0, 0, 0, 0);
            lbl[ii].Margin = new Padding(0, 0, 0, 0);
            btn[ii].Padding = new Padding(0, 5, 0, 5);
            lbl[ii].Padding = new Padding(0, 0, 0, 25);

            cls[ii].AutoSize = true;
            cls[ii].Text = "X";
            cls[ii].Margin = new Padding(0, 0, 0, 0);
            cls[ii].Padding = new Padding(5, 5, 5, 5);

            HorizontalTab.ColumnCount = tab_index + 1;
            btn[ii].TextAlign = ContentAlignment.MiddleCenter;
            btn[ii].ForeColor = Color.Black;
            btn[ii].BackColor = Color.FromArgb(209, 209, 225);
            btn[ii].FlatStyle = FlatStyle.Flat;

            cls[ii].TextAlign = ContentAlignment.MiddleCenter;
            cls[ii].ForeColor = Color.Black;
            cls[ii].BackColor = Color.FromArgb(209, 209, 225);
            cls[ii].FlatStyle = FlatStyle.Flat;

            lstTab.Items.Add(btn[ii].Text);
            lstTab.SelectedIndex = tab_index;

            btn[ii].MouseHover += new EventHandler(btn_MouseHover);

            btn[ii].MouseLeave += new EventHandler(btn_MouseLeave);

            btn[ii].Click += new EventHandler(btn_MouseClick);


            cls[ii].MouseHover += new EventHandler(cls_MouseHover);

            cls[ii].MouseLeave += new EventHandler(cls_MouseLeave);

            cls[ii].Click += new EventHandler(cls_MouseClick);


            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            btn[ii].BackColor = Color.CornflowerBlue;
            btn[ii].ForeColor = Color.White;
            isSelect[ii] = 1;

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            cls[ii].BackColor = Color.CornflowerBlue;
            cls[ii].ForeColor = Color.White;
            isSelect[ii] = 1;

            cls[ii].AutoSize = true;
            btn[ii].Dock = DockStyle.Left;
            cls[ii].Dock = DockStyle.Right;
            lbl[ii].AutoSize = true;
            lbl[ii].Controls.Add(btn[ii]);
            lbl[ii].Controls.Add(cls[ii]);
            btn[ii].Dock = DockStyle.Left;
            cls[ii].Dock = DockStyle.Right;

            HorizontalTab.Controls.Add(lbl[ii], 0, tab_index);
            ii++;
            tab_index++;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            transactionTab();
        }

        void btn_MouseHover(object Sender, EventArgs E)
        {
            index = btn.IndexOf((Label)Sender);
            if (isSelect[index] == 0)
            {
                btn[index].BackColor = Color.FromArgb(202, 202, 220);
                cls[index].ForeColor = Color.Black;
                cls[index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void btn_MouseLeave(object Sender, EventArgs E)
        {
            try
            {
                index = btn.IndexOf((Label)Sender);
                if (isSelect[index] == 0)
                {
                    btn[index].BackColor = Color.FromArgb(209, 209, 225);
                    btn[index].ForeColor = Color.Black;
                    cls[index].ForeColor = Color.FromArgb(209, 209, 225);
                    cls[index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }catch(Exception ex)
            {
                pnlMessage.Visible = true;
                errorsBox.Visible = true;
                messagesBox.Visible = false;
                errorText.Text = "";
                errorText.Text = ex.ToString();

                lblTitle.Text = "Errors";

                lblErrorButtom.BackColor = Color.Black;
            }
        }


        void btn_MouseClick(object Sender, EventArgs E)
        {
            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            index = btn.IndexOf((Label)Sender);
            btn[index].BackColor = Color.CornflowerBlue;
            btn[index].ForeColor = Color.White;
            isSelect[index] = 1;
            tran[index].Visible = true;

            control_position = tran_position[index];
            lstTab.SelectedIndex = control_position;

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;
            }

            cls[index].BackColor = Color.CornflowerBlue;
            cls[index].ForeColor = Color.White;
            isSelect[index] = 1;

        }

        void cls_MouseHover(object Sender, EventArgs E)
        {
            index = cls.IndexOf((Label)Sender);
            if (isSelect[index] == 0)
            {
                btn[index].BackColor = Color.FromArgb(202, 202, 220);
                cls[index].ForeColor = Color.Black;
                cls[index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void cls_MouseLeave(object Sender, EventArgs E)
        {
            int new_index = cls.IndexOf((Label)Sender);
            if (new_index == index)
            {
                if (isSelect[index] == 0)
                {
                    btn[index].BackColor = Color.FromArgb(209, 209, 225);
                    btn[index].ForeColor = Color.Black;
                    cls[index].ForeColor = Color.FromArgb(209, 209, 225);
                    cls[index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
        }

        void cls_MouseClick(object Sender, EventArgs E)
        {
            index = cls.IndexOf((Label)Sender);

            control_position = tran_position[index];

            for (int t = 0; t < tran_position.Count; t++)
            {
                if (tran_position[t] > tran_position[index])
                {
                    tran_position[t]--;
                }
            }

            for (int t = 0; t < transfer_position.Count; t++)
            {
                if (transfer_position[t] > tran_position[index])
                {
                    transfer_position[t]--;
                }
            }

            for (int t = 0; t < transaction_statement_position.Count; t++)
            {
                if (transaction_statement_position[t] > tran_position[index])
                {
                    transaction_statement_position[t]--;
                }
            }

            for (int t = 0; t < customer_balance_position.Count; t++)
            {
                if (customer_balance_position[t] > tran_position[index])
                {
                    customer_balance_position[t]--;
                }
            }

            for (int t = 0; t < tabType.Count; t++)
            {
                if (tabType[t] == tabType[control_position])
                {
                    if (tabTypeIndex[t] > tabTypeIndex[control_position])
                    {
                        tabTypeIndex[t]--;
                    }
                }
            }

            btn.RemoveAt(index);
            cls.RemoveAt(index);
            lbl.RemoveAt(index);
            isSelect.RemoveAt(index);
            tran.RemoveAt(index);

            HorizontalTab.Controls.RemoveAt(control_position);
            pnlCenter.Controls.RemoveAt(control_position);
            lstTab.Items.RemoveAt(control_position);
            tabType.RemoveAt(control_position);
            tabTypeIndex.RemoveAt(control_position);

            if (control_position > 0)
            {
                lstTab.SelectedIndex = control_position-1;
            }

            ii--;
            tab_index--;
            tran_position.RemoveAt(index);
        }

        void transfer_btn_MouseHover(object Sender, EventArgs E)
        {
            transfer_index = transfer_btn.IndexOf((Label)Sender);
            if (transfer_isSelect[transfer_index] == 0)
            {
                transfer_btn[transfer_index].BackColor = Color.FromArgb(202, 202, 220);
                transfer_cls[transfer_index].ForeColor = Color.Black;
                transfer_cls[transfer_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void transfer_btn_MouseLeave(object Sender, EventArgs E)
        {
            try
            {
                transfer_index = transfer_btn.IndexOf((Label)Sender);
                if (transfer_isSelect[transfer_index] == 0)
                {
                    transfer_btn[transfer_index].BackColor = Color.FromArgb(209, 209, 225);
                    transfer_btn[transfer_index].ForeColor = Color.Black;
                    transfer_cls[transfer_index].ForeColor = Color.FromArgb(202, 202, 220);
                    transfer_cls[transfer_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }catch(Exception ex)
            {
                pnlMessage.Visible = true;
                errorsBox.Visible = true;
                messagesBox.Visible = false;
                errorText.Text = "";
                errorText.Text = ex.ToString();
                Errors.BackColor = Color.CornflowerBlue;
                Errors.ForeColor = Color.White;

                lblTitle.Text = "Errors";

                Messages.ForeColor = Color.Black;
                Messages.BackColor = Color.FromArgb(209, 209, 225);
            }
        }

        void transfer_cls_MouseHover(object Sender, EventArgs E)
        {
            transfer_index = transfer_cls.IndexOf((Label)Sender);
            if (transfer_isSelect[transfer_index] == 0)
            {
                transfer_btn[transfer_index].BackColor = Color.FromArgb(202, 202, 220);
                transfer_cls[transfer_index].ForeColor = Color.Black;
                transfer_cls[transfer_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void transfer_cls_MouseLeave(object Sender, EventArgs E)
        {
            int new_transfer_index = transfer_cls.IndexOf((Label)Sender);
            if (new_transfer_index == transfer_index)
            {
                if (transfer_isSelect[transfer_index] == 0)
                {
                    transfer_btn[transfer_index].BackColor = Color.FromArgb(209, 209, 225);
                    transfer_btn[transfer_index].ForeColor = Color.Black;
                    transfer_cls[transfer_index].ForeColor = Color.FromArgb(202, 202, 220);
                    transfer_cls[transfer_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
        }

        void transfer_btn_MouseClick(object Sender, EventArgs E)
        {
            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            transfer_index = transfer_btn.IndexOf((Label)Sender);
            transfer_btn[transfer_index].BackColor = Color.CornflowerBlue;
            transfer_btn[transfer_index].ForeColor = Color.White;
            transfer_isSelect[transfer_index] = 1;
            transfer[transfer_index].Visible = true;

            control_position = transfer_position[transfer_index];
            lstTab.SelectedIndex = control_position;

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }


            transfer_cls[transfer_index].BackColor = Color.CornflowerBlue;
            transfer_cls[transfer_index].ForeColor = Color.White;
            transfer_isSelect[transfer_index] = 1;

        }

        void transfer_cls_MouseClick(object Sender, EventArgs E)
        {
            transfer_index = transfer_cls.IndexOf((Label)Sender);

            control_position=transfer_position[transfer_index];

            for (int t = 0; t < transfer_position.Count; t++)
            {
                if (transfer_position[t] > transfer_position[transfer_index])
                {
                    transfer_position[t]--;
                }
            }

            for (int t = 0; t < tran_position.Count; t++)
            {
                if (tran_position[t] > transfer_position[transfer_index])
                {
                    tran_position[t]--;
                }
            }

            for (int t = 0; t < transaction_statement_position.Count; t++)
            {
                if (transaction_statement_position[t] > transfer_position[transfer_index])
                {
                    transaction_statement_position[t]--;
                }
            }

            for (int t = 0; t < customer_balance_position.Count; t++)
            {
                if (customer_balance_position[t] > transfer_position[transfer_index])
                {
                    customer_balance_position[t]--;
                }
            }

            for (int t = 0; t < tabType.Count; t++)
            {
                if (tabType[t] == tabType[control_position])
                {
                    if (tabTypeIndex[t] > tabTypeIndex[control_position])
                    {
                        tabTypeIndex[t]--;
                    }
                }
            }

            transfer_btn.RemoveAt(transfer_index);
            transfer_cls.RemoveAt(transfer_index);
            transfer_lbl.RemoveAt(transfer_index);
            transfer_isSelect.RemoveAt(transfer_index);
            transfer.RemoveAt(transfer_index);

            HorizontalTab.Controls.RemoveAt(control_position);
            pnlCenter.Controls.RemoveAt(control_position);
            lstTab.Items.RemoveAt(control_position);
            tabType.RemoveAt(control_position);
            tabTypeIndex.RemoveAt(control_position);

            if (control_position > 0)
            {
                lstTab.SelectedIndex = control_position - 1;
            }

            i--;
            tab_index--;
            transfer_position.RemoveAt(transfer_index);
        }

        private void transferTab()
        {
            transfer.Add(new Transfer());
            transfer[i].TopLevel = false;
            pnlCenter.Controls.Add(transfer[i]);
            transfer[i].Dock = DockStyle.Fill;
            transfer[i].Show();
            transfer[i].panel1.AutoScroll = true;
            transfer_position.Add(tab_index);
            tabType.Add(2);
            tabTypeIndex.Add(i);

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            transfer[i].Visible = true;

            transfer_btn.Add(new Label());
            transfer_lbl.Add(new Panel());
            transfer_cls.Add(new Label());
            transfer_isSelect.Add(0);
            transfer_btn[i].AutoSize = true;
            transfer_btn[i].Text = "Transfer to Account-" + i;
            transfer_btn[i].Margin = new Padding(0, 0, 0, 0);
            transfer_lbl[i].Margin = new Padding(0, 0, 0, 0);
            transfer_btn[i].Padding = new Padding(0, 5, 0, 5);
            transfer_lbl[i].Padding = new Padding(0, 0, 0, 25);

            transfer_cls[i].AutoSize = true;
            transfer_cls[i].Text = "X";
            transfer_cls[i].Margin = new Padding(0, 0, 0, 0);
            transfer_cls[i].Padding = new Padding(5, 5, 5, 5);

            HorizontalTab.ColumnCount = tab_index + 1;
            transfer_btn[i].TextAlign = ContentAlignment.MiddleCenter;
            transfer_btn[i].ForeColor = Color.Black;
            transfer_btn[i].BackColor = Color.FromArgb(209, 209, 225);
            transfer_btn[i].FlatStyle = FlatStyle.Flat;

            transfer_cls[i].TextAlign = ContentAlignment.MiddleCenter;
            transfer_cls[i].ForeColor = Color.Black;
            transfer_cls[i].BackColor = Color.FromArgb(209, 209, 225);
            transfer_cls[i].FlatStyle = FlatStyle.Flat;

            lstTab.Items.Add(transfer_btn[i].Text);
            lstTab.SelectedIndex = tab_index;

            transfer_btn[i].MouseHover += new EventHandler(transfer_btn_MouseHover);

            transfer_btn[i].MouseLeave += new EventHandler(transfer_btn_MouseLeave);

            transfer_btn[i].Click += new EventHandler(transfer_btn_MouseClick);



            transfer_cls[i].MouseHover += new EventHandler(transfer_cls_MouseHover);

            transfer_cls[i].MouseLeave += new EventHandler(transfer_cls_MouseLeave);

            transfer_cls[i].Click += new EventHandler(transfer_cls_MouseClick);

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_cls.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            transfer_btn[i].BackColor = Color.CornflowerBlue;
            transfer_btn[i].ForeColor = Color.White;
            transfer_isSelect[i] = 1;

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            transfer_cls[i].BackColor = Color.CornflowerBlue;
            transfer_cls[i].ForeColor = Color.White;
            transfer_isSelect[i] = 1;

            transfer_cls[i].AutoSize = true;
            transfer_btn[i].Dock = DockStyle.Left;
            transfer_cls[i].Dock = DockStyle.Right;
            transfer_lbl[i].AutoSize = true;
            transfer_lbl[i].Controls.Add(transfer_btn[i]);
            transfer_lbl[i].Controls.Add(transfer_cls[i]);
            transfer_btn[i].Dock = DockStyle.Left;
            transfer_cls[i].Dock = DockStyle.Right;
            HorizontalTab.Controls.Add(transfer_lbl[i], 0, tab_index);
            i++;
            tab_index++;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            transferTab();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int p = panel1.Controls.IndexOf();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Errors_Click(object sender, EventArgs e)
        {
            
        }

        private void Messages_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;

            lblMessageButtom.BackColor = Color.CornflowerBlue;
            lblErrorButtom.BackColor = Color.CornflowerBlue;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Black;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            buttomTab.Controls.Remove(Errors);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            buttomTab.Controls.Add(Errors, 0, 0);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 10);
            Brush myBrush = new SolidBrush(Color.Black);

            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(-270);

            e.Graphics.DrawString("Reports", myFont, myBrush, 0, 0);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (leftPanel.Visible == true && lblReportsButtom.BackColor == Color.Black)
            {
                leftPanel.Visible = false;
                lblReportsButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {
                pnlLeftpnlContentForms.Visible = false;
                pnlLeftpnlContentQuicklinks.Visible = false;
                pnlLeftpnlContentReports.Visible = true;
                leftPanel.Visible = true;

                label2.Text = "Reports";

                lblReportsButtom.BackColor = Color.Black;

                lblFormsButtom.BackColor = Color.CornflowerBlue;

                lblQuickLinksButtom.BackColor = Color.CornflowerBlue;
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            leftPanel.Visible = false;

            lblReportsButtom.BackColor = Color.CornflowerBlue;
            lblFormsButtom.BackColor = Color.CornflowerBlue;
            lblQuickLinksButtom.BackColor = Color.CornflowerBlue;
        }
       
        private void label1_Paint_1(object sender, PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 10);
            Brush myBrush = new SolidBrush(Color.Black);
            
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(-270);

            e.Graphics.DrawString("Forms", myFont, myBrush, 0, 0);
        }

        private void QuickLinks_Click(object sender, EventArgs e)
        {
            if (leftPanel.Visible == true && lblQuickLinksButtom.BackColor == Color.Black)
            {
                leftPanel.Visible = false;

                lblQuickLinksButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {

                pnlLeftpnlContentForms.Visible = false;
                pnlLeftpnlContentQuicklinks.Visible = true;
                pnlLeftpnlContentReports.Visible = false;

                leftPanel.Visible = true;

                label2.Text = "Quick Links";

                lblQuickLinksButtom.BackColor = Color.Black;

                lblReportsButtom.BackColor = Color.CornflowerBlue;

                lblFormsButtom.BackColor = Color.CornflowerBlue;
            }
        }

        private void QuickLinks_Paint(object sender, PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 10);
            Brush myBrush = new SolidBrush(Color.Black);

            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(-270);

            e.Graphics.DrawString("Quick Links", myFont, myBrush, 0, 0);
        }

        private void Forms_Click(object sender, EventArgs e)
        {
            if (leftPanel.Visible == true && lblFormsButtom.BackColor == Color.Black)
            {
                leftPanel.Visible = false;

                lblFormsButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {
                pnlLeftpnlContentForms.Visible = true;
                pnlLeftpnlContentQuicklinks.Visible = false;
                pnlLeftpnlContentReports.Visible = false;
                leftPanel.Visible = true; ;

                label2.Text = "Forms";

                lblFormsButtom.BackColor = Color.Black;

                lblReportsButtom.BackColor = Color.CornflowerBlue;

                lblQuickLinksButtom.BackColor = Color.CornflowerBlue;
            }
        }

        void transaction_statement_btn_MouseHover(object Sender, EventArgs E)
        {
            transaction_statement_index = transaction_statement_btn.IndexOf((Label)Sender);
            if (transaction_statement_isSelect[transaction_statement_index] == 0)
            {
                transaction_statement_btn[transaction_statement_index].BackColor = Color.FromArgb(202, 202, 220);
                transaction_statement_cls[transaction_statement_index].ForeColor = Color.Black;
                transaction_statement_cls[transaction_statement_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void transaction_statement_btn_MouseLeave(object Sender, EventArgs E)
        {
            try
            {
                transaction_statement_index = transaction_statement_btn.IndexOf((Label)Sender);
                if (transaction_statement_isSelect[transaction_statement_index] == 0)
                {
                    transaction_statement_btn[transaction_statement_index].BackColor = Color.FromArgb(209, 209, 225);
                    transaction_statement_btn[transaction_statement_index].ForeColor = Color.Black;
                    transaction_statement_cls[transaction_statement_index].ForeColor = Color.FromArgb(202, 202, 220);
                    transaction_statement_cls[transaction_statement_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
            catch (Exception ex)
            {
                pnlMessage.Visible = true;
                errorsBox.Visible = true;
                messagesBox.Visible = false;
                errorText.Text = "";
                errorText.Text = ex.ToString();
                Errors.BackColor = Color.CornflowerBlue;
                Errors.ForeColor = Color.White;

                lblTitle.Text = "Errors";

                Messages.ForeColor = Color.Black;
                Messages.BackColor = Color.FromArgb(209, 209, 225);
            }
        }

        void transaction_statement_cls_MouseHover(object Sender, EventArgs E)
        {
            transaction_statement_index = transaction_statement_cls.IndexOf((Label)Sender);
            if (transaction_statement_isSelect[transaction_statement_index] == 0)
            {
                transaction_statement_btn[transaction_statement_index].BackColor = Color.FromArgb(202, 202, 220);
                transaction_statement_cls[transaction_statement_index].ForeColor = Color.Black;
                transaction_statement_cls[transaction_statement_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void transaction_statement_cls_MouseLeave(object Sender, EventArgs E)
        {
            int new_transaction_statement_index = transaction_statement_cls.IndexOf((Label)Sender);
            if (new_transaction_statement_index == transaction_statement_index)
            {
                if (transaction_statement_isSelect[transaction_statement_index] == 0)
                {
                    transaction_statement_btn[transaction_statement_index].BackColor = Color.FromArgb(209, 209, 225);
                    transaction_statement_btn[transaction_statement_index].ForeColor = Color.Black;
                    transaction_statement_cls[transaction_statement_index].ForeColor = Color.FromArgb(202, 202, 220);
                    transaction_statement_cls[transaction_statement_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
        }

        void transaction_statement_btn_MouseClick(object Sender, EventArgs E)
        {
            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            transaction_statement_index = transaction_statement_btn.IndexOf((Label)Sender);
            transaction_statement_btn[transaction_statement_index].BackColor = Color.CornflowerBlue;
            transaction_statement_btn[transaction_statement_index].ForeColor = Color.White;
            transaction_statement_isSelect[transaction_statement_index] = 1;
            transaction_statement[transaction_statement_index].Visible = true;

            control_position = transaction_statement_position[transaction_statement_index];
            lstTab.SelectedIndex = control_position;

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            transaction_statement_cls[transaction_statement_index].BackColor = Color.CornflowerBlue;
            transaction_statement_cls[transaction_statement_index].ForeColor = Color.White;
            transaction_statement_isSelect[transaction_statement_index] = 1;

        }

        void transaction_statement_cls_MouseClick(object Sender, EventArgs E)
        {
            transaction_statement_index = transaction_statement_cls.IndexOf((Label)Sender);

            control_position = transaction_statement_position[transaction_statement_index];

            for (int t = 0; t < transaction_statement_position.Count; t++)
            {
                if (transaction_statement_position[t] > transaction_statement_position[transaction_statement_index])
                {
                    transaction_statement_position[t]--;
                }
            }

            for (int t = 0; t < transfer_position.Count; t++)
            {
                if (transfer_position[t] > transaction_statement_position[transaction_statement_index])
                {
                    transfer_position[t]--;
                }
            }

            for (int t = 0; t < tran_position.Count; t++)
            {
                if (tran_position[t] > transaction_statement_position[transaction_statement_index])
                {
                    tran_position[t]--;
                }
            }

            for (int t = 0; t < customer_balance_position.Count; t++)
            {
                if (customer_balance_position[t] > transaction_statement_position[transaction_statement_index])
                {
                    customer_balance_position[t]--;
                }
            }

            for (int t = 0; t < tabType.Count; t++)
            {
                if (tabType[t] == tabType[control_position])
                {
                    if (tabTypeIndex[t] > tabTypeIndex[control_position])
                    {
                        tabTypeIndex[t]--;
                    }
                }
            }

            transaction_statement_btn.RemoveAt(transaction_statement_index);
            transaction_statement_cls.RemoveAt(transaction_statement_index);
            transaction_statement_lbl.RemoveAt(transaction_statement_index);
            transaction_statement_isSelect.RemoveAt(transaction_statement_index);
            transaction_statement.RemoveAt(transaction_statement_index);

            HorizontalTab.Controls.RemoveAt(control_position);
            pnlCenter.Controls.RemoveAt(control_position);
            lstTab.Items.RemoveAt(control_position);
            tabType.RemoveAt(control_position);
            tabTypeIndex.RemoveAt(control_position);

            if (control_position > 0)
            {
                lstTab.SelectedIndex = control_position - 1;
            }

            ri--;
            tab_index--;
            transaction_statement_position.RemoveAt(transaction_statement_index);
        }
        private void customerStatement()
        {
            transaction_statement.Add(new TransactionStatement());
            transaction_statement[ri].TopLevel = false;
            pnlCenter.Controls.Add(transaction_statement[ri]);
            transaction_statement[ri].Dock = DockStyle.Fill;
            transaction_statement[ri].Show();
            transaction_statement_position.Add(tab_index);
            tabType.Add(3);
            tabTypeIndex.Add(ri);

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            transaction_statement[ri].Visible = true;

            transaction_statement_btn.Add(new Label());
            transaction_statement_lbl.Add(new Panel());
            transaction_statement_cls.Add(new Label());
            transaction_statement_isSelect.Add(0);
            transaction_statement_btn[ri].AutoSize = true;
            transaction_statement_btn[ri].Text = "Transaction Statement-" + ri;
            transaction_statement_btn[ri].Margin = new Padding(0, 0, 0, 0);
            transaction_statement_lbl[ri].Margin = new Padding(0, 0, 0, 0);
            transaction_statement_btn[ri].Padding = new Padding(0, 5, 0, 5);
            transaction_statement_lbl[ri].Padding = new Padding(0, 0, 0, 25);

            transaction_statement_cls[ri].AutoSize = true;
            transaction_statement_cls[ri].Text = "X";
            transaction_statement_cls[ri].Margin = new Padding(0, 0, 0, 0);
            transaction_statement_cls[ri].Padding = new Padding(5, 5, 5, 5);

            HorizontalTab.ColumnCount = tab_index + 1;
            transaction_statement_btn[ri].TextAlign = ContentAlignment.MiddleCenter;
            transaction_statement_btn[ri].ForeColor = Color.Black;
            transaction_statement_btn[ri].BackColor = Color.FromArgb(209, 209, 225);
            transaction_statement_btn[ri].FlatStyle = FlatStyle.Flat;

            transaction_statement_cls[ri].TextAlign = ContentAlignment.MiddleCenter;
            transaction_statement_cls[ri].ForeColor = Color.Black;
            transaction_statement_cls[ri].BackColor = Color.FromArgb(209, 209, 225);
            transaction_statement_cls[ri].FlatStyle = FlatStyle.Flat;

            lstTab.Items.Add(transaction_statement_btn[ri].Text);
            lstTab.SelectedIndex = tab_index;

            transaction_statement_btn[ri].MouseHover += new EventHandler(transaction_statement_btn_MouseHover);

            transaction_statement_btn[ri].MouseLeave += new EventHandler(transaction_statement_btn_MouseLeave);

            transaction_statement_btn[ri].Click += new EventHandler(transaction_statement_btn_MouseClick);


            transaction_statement_cls[ri].MouseHover += new EventHandler(transaction_statement_cls_MouseHover);

            transaction_statement_cls[ri].MouseLeave += new EventHandler(transaction_statement_cls_MouseLeave);

            transaction_statement_cls[ri].Click += new EventHandler(transaction_statement_cls_MouseClick);

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            transaction_statement_btn[ri].BackColor = Color.CornflowerBlue;
            transaction_statement_btn[ri].ForeColor = Color.White;
            transaction_statement_isSelect[ri] = 1;

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            transaction_statement_cls[ri].BackColor = Color.CornflowerBlue;
            transaction_statement_cls[ri].ForeColor = Color.White;
            transaction_statement_isSelect[ri] = 1;

            transaction_statement_cls[ri].AutoSize = true;
            transaction_statement_btn[ri].Dock = DockStyle.Left;
            transaction_statement_cls[ri].Dock = DockStyle.Right;
            transaction_statement_lbl[ri].AutoSize = true;
            transaction_statement_lbl[ri].Controls.Add(transaction_statement_btn[ri]);
            transaction_statement_lbl[ri].Controls.Add(transaction_statement_cls[ri]);
            transaction_statement_btn[ri].Dock = DockStyle.Left;
            transaction_statement_cls[ri].Dock = DockStyle.Right;
            HorizontalTab.Controls.Add(transaction_statement_lbl[ri], 0, tab_index);
            ri++;
            tab_index++;
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            customerStatement();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        public static int option = 0;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConfirmation close = new CloseConfirmation();
            close.ShowInTaskbar = false;
            close.ShowDialog();

            if (option == 1)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            rightPanel.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            rightPanel.Visible = false;
            lblTabListButtom.BackColor = Color.CornflowerBlue;
        }

        private void tabList_Click(object sender, EventArgs e)
        {
            if (lblTabListButtom.BackColor == Color.Black)
            {
                rightPanel.Visible = false;
                lblTabListButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {
                rightPanel.Visible = true;
                lblTabListButtom.BackColor = Color.Black;
                lblRightTitle.Text = "Tab List";
            }
        }

        private void tabList_Paint(object sender, PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 10);
            Brush myBrush = new SolidBrush(Color.Black);

            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(-270);

            e.Graphics.DrawString("Tabl List", myFont, myBrush, 0, 0);
        }

        private void lstTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p = 0;
            if (lstTab.SelectedIndex >= 0)
            {
                p = lstTab.SelectedIndex;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_cls.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < cls.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_cls.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_cls.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_cls.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            if (lstTab.Items.Count >= 1)
            {
                if (tabType[p] == 0)
                {
                    home_btn[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    home_btn[tabTypeIndex[p]].ForeColor = Color.White;
                    home_cls[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    home_cls[tabTypeIndex[p]].ForeColor = Color.White;

                    if(home_lbl[tabTypeIndex[p]].Visible==true)
                        homeForm[tabTypeIndex[p]].Visible = true;

                    home_isSelect[tabTypeIndex[p]] = 1;
                }
                else if (tabType[p] == 1)
                {
                    btn[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    btn[tabTypeIndex[p]].ForeColor = Color.White;
                    cls[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    cls[tabTypeIndex[p]].ForeColor = Color.White;
                    isSelect[tabTypeIndex[p]] = 1;
                    tran[tabTypeIndex[p]].Visible = true;

                }
                else if (tabType[p] == 2)
                {
                    transfer_btn[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    transfer_btn[tabTypeIndex[p]].ForeColor = Color.White;
                    transfer_cls[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    transfer_cls[tabTypeIndex[p]].ForeColor = Color.White;
                    transfer_isSelect[tabTypeIndex[p]] = 1;
                    transfer[tabTypeIndex[p]].Visible = true;

                }
                else if (tabType[p] == 3)
                {
                    transaction_statement_btn[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    transaction_statement_btn[tabTypeIndex[p]].ForeColor = Color.White;
                    transaction_statement_cls[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    transaction_statement_cls[tabTypeIndex[p]].ForeColor = Color.White;
                    transaction_statement_isSelect[tabTypeIndex[p]] = 1;
                    transaction_statement[tabTypeIndex[p]].Visible = true;
                }
                else if (tabType[p] == 4)
                {
                    customer_balance_btn[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    customer_balance_btn[tabTypeIndex[p]].ForeColor = Color.White;
                    customer_balance_cls[tabTypeIndex[p]].BackColor = Color.CornflowerBlue;
                    customer_balance_cls[tabTypeIndex[p]].ForeColor = Color.White;
                    customer_balance_isSelect[tabTypeIndex[p]] = 1;
                    customer_balance[tabTypeIndex[p]].Visible = true;
                }
            }
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabList_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void tabList_MouseLeave(object sender, EventArgs e)
        {

        }

        private void addEditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.ShowDialog();
        }

        private void addCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyForm company = new CompanyForm();
            company.ShowDialog();
        }

        private void addEditCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrencyForm currency = new CurrencyForm();
            currency.ShowDialog();
        }

        private void addBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BranchForm branch = new BranchForm();
            branch.ShowDialog();
        }

        private void addEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm account = new AccountForm();
            account.ShowDialog();
        }

        private void addEditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.ShowDialog();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Home home = new Home();
            if (Width < 740)
            {
                home.lblSaraf.Width = 85;
                home.lblSaraf.Height = 455;
            }
        }

        private void customerBalance()
        {
            customer_balance.Add(new CustomerBalance());
            customer_balance[ci].TopLevel = false;
            pnlCenter.Controls.Add(customer_balance[ci]);
            customer_balance[ci].Dock = DockStyle.Fill;
            customer_balance[ci].Show();
            customer_balance_position.Add(tab_index);
            tabType.Add(4);
            tabTypeIndex.Add(ci);

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            customer_balance[ci].Visible = true;

            customer_balance_btn.Add(new Label());
            customer_balance_lbl.Add(new Panel());
            customer_balance_cls.Add(new Label());
            customer_balance_isSelect.Add(0);
            customer_balance_btn[ci].AutoSize = true;
            customer_balance_btn[ci].Text = "Customaer Balance-" + ci;
            customer_balance_btn[ci].Margin = new Padding(0, 0, 0, 0);
            customer_balance_lbl[ci].Margin = new Padding(0, 0, 0, 0);
            customer_balance_btn[ci].Padding = new Padding(0, 5, 0, 5);
            customer_balance_lbl[ci].Padding = new Padding(0, 0, 0, 25);

            customer_balance_cls[ci].AutoSize = true;
            customer_balance_cls[ci].Text = "X";
            customer_balance_cls[ci].Margin = new Padding(0, 0, 0, 0);
            customer_balance_cls[ci].Padding = new Padding(5, 5, 5, 5);

            HorizontalTab.ColumnCount = tab_index + 1;
            customer_balance_btn[ci].TextAlign = ContentAlignment.MiddleCenter;
            customer_balance_btn[ci].ForeColor = Color.Black;
            customer_balance_btn[ci].BackColor = Color.FromArgb(209, 209, 225);
            customer_balance_btn[ci].FlatStyle = FlatStyle.Flat;

            customer_balance_cls[ci].TextAlign = ContentAlignment.MiddleCenter;
            customer_balance_cls[ci].ForeColor = Color.Black;
            customer_balance_cls[ci].BackColor = Color.FromArgb(209, 209, 225);
            customer_balance_cls[ci].FlatStyle = FlatStyle.Flat;

            lstTab.Items.Add(customer_balance_btn[ci].Text);
            lstTab.SelectedIndex = tab_index;

            customer_balance_btn[ci].MouseHover += new EventHandler(customer_balance_btn_MouseHover);

            customer_balance_btn[ci].MouseLeave += new EventHandler(customer_balance_btn_MouseLeave);

            customer_balance_btn[ci].Click += new EventHandler(customer_balance_btn_MouseClick);


            customer_balance_cls[ci].MouseHover += new EventHandler(customer_balance_cls_MouseHover);

            customer_balance_cls[ci].MouseLeave += new EventHandler(customer_balance_cls_MouseLeave);

            customer_balance_cls[ci].Click += new EventHandler(customer_balance_cls_MouseClick);


            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            customer_balance_btn[ci].BackColor = Color.CornflowerBlue;
            customer_balance_btn[ci].ForeColor = Color.White;
            customer_balance_isSelect[ci] = 1;

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            customer_balance_cls[ci].BackColor = Color.CornflowerBlue;
            customer_balance_cls[ci].ForeColor = Color.White;
            customer_balance_isSelect[ci] = 1;

            customer_balance_cls[ci].AutoSize = true;
            customer_balance_btn[ci].Dock = DockStyle.Left;
            customer_balance_cls[ci].Dock = DockStyle.Right;
            customer_balance_lbl[ci].AutoSize = true;
            customer_balance_lbl[ci].Controls.Add(customer_balance_btn[ci]);
            customer_balance_lbl[ci].Controls.Add(customer_balance_cls[ci]);
            customer_balance_btn[ci].Dock = DockStyle.Left;
            customer_balance_cls[ci].Dock = DockStyle.Right;

            HorizontalTab.Controls.Add(customer_balance_lbl[ci], 0, tab_index);
            ci++;
            tab_index++;
        }

        private void customerBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerBalance();
        }

        void customer_balance_btn_MouseHover(object Sender, EventArgs E)
        {
            customer_balance_index = customer_balance_btn.IndexOf((Label)Sender);
            if (customer_balance_isSelect[customer_balance_index] == 0)
            {
                customer_balance_btn[customer_balance_index].BackColor = Color.FromArgb(202, 202, 220);
                customer_balance_cls[customer_balance_index].ForeColor = Color.Black;
                customer_balance_cls[customer_balance_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void customer_balance_btn_MouseLeave(object Sender, EventArgs E)
        {
            try
            {
                customer_balance_index = customer_balance_btn.IndexOf((Label)Sender);
                if (customer_balance_isSelect[customer_balance_index] == 0)
                {
                    customer_balance_btn[customer_balance_index].BackColor = Color.FromArgb(209, 209, 225);
                    customer_balance_btn[customer_balance_index].ForeColor = Color.Black;
                    customer_balance_cls[customer_balance_index].ForeColor = Color.FromArgb(209, 209, 225);
                    customer_balance_cls[customer_balance_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
            catch (Exception ex)
            {
                pnlMessage.Visible = true;
                errorsBox.Visible = true;
                messagesBox.Visible = false;
                errorText.Text = "";
                errorText.Text = ex.ToString();

                lblTitle.Text = "Errors";

                lblErrorButtom.BackColor = Color.Black;
            }
        }


        void customer_balance_btn_MouseClick(object Sender, EventArgs E)
        {
            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_btn[t].ForeColor = Color.Black;
                customer_balance_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < customer_balance.Count; t++)
            {
                customer_balance[t].Visible = false;
            }

            customer_balance_index = customer_balance_btn.IndexOf((Label)Sender);
            customer_balance_btn[customer_balance_index].BackColor = Color.CornflowerBlue;
            customer_balance_btn[customer_balance_index].ForeColor = Color.White;
            customer_balance_isSelect[customer_balance_index] = 1;
            customer_balance[customer_balance_index].Visible = true;

            control_position = customer_balance_position[customer_balance_index];
            lstTab.SelectedIndex = control_position;

            for (int t = 0; t < customer_balance_btn.Count; t++)
            {
                customer_balance_isSelect[t] = 0;

                customer_balance_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                customer_balance_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                customer_balance_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                btn[t].TextAlign = ContentAlignment.MiddleCenter;
                btn[t].ForeColor = Color.Black;
                btn[t].BackColor = Color.FromArgb(209, 209, 225);
                btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_btn[t].ForeColor = Color.Black;
                transfer_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_btn[t].ForeColor = Color.Black;
                transaction_statement_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_btn[t].TextAlign = ContentAlignment.MiddleCenter;
                home_btn[t].ForeColor = Color.Black;
                home_btn[t].BackColor = Color.FromArgb(209, 209, 225);
                home_btn[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < tran.Count; t++)
            {
                tran[t].Visible = false;
            }

            for (int t = 0; t < transfer.Count; t++)
            {
                transfer[t].Visible = false;
            }

            for (int t = 0; t < transaction_statement.Count; t++)
            {
                transaction_statement[t].Visible = false;
            }

            for (int t = 0; t < homeForm.Count; t++)
            {
                homeForm[t].Visible = false;
            }

            for (int t = 0; t < btn.Count; t++)
            {
                isSelect[t] = 0;

                cls[t].TextAlign = ContentAlignment.MiddleCenter;
                cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                cls[t].BackColor = Color.FromArgb(209, 209, 225);
                cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transfer_btn.Count; t++)
            {
                transfer_isSelect[t] = 0;

                transfer_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transfer_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transfer_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < transaction_statement_btn.Count; t++)
            {
                transaction_statement_isSelect[t] = 0;

                transaction_statement_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                transaction_statement_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                transaction_statement_cls[t].FlatStyle = FlatStyle.Flat;
            }

            for (int t = 0; t < home_btn.Count; t++)
            {
                home_isSelect[t] = 0;

                home_cls[t].TextAlign = ContentAlignment.MiddleCenter;
                home_cls[t].ForeColor = Color.FromArgb(209, 209, 225);
                home_cls[t].BackColor = Color.FromArgb(209, 209, 225);
                home_cls[t].FlatStyle = FlatStyle.Flat;
            }

            customer_balance_cls[customer_balance_index].BackColor = Color.CornflowerBlue;
            customer_balance_cls[customer_balance_index].ForeColor = Color.White;
            customer_balance_isSelect[customer_balance_index] = 1;

        }

        void customer_balance_cls_MouseHover(object Sender, EventArgs E)
        {
            customer_balance_index = customer_balance_cls.IndexOf((Label)Sender);
            if (customer_balance_isSelect[customer_balance_index] == 0)
            {
                customer_balance_btn[customer_balance_index].BackColor = Color.FromArgb(202, 202, 220);
                customer_balance_cls[customer_balance_index].ForeColor = Color.Black;
                customer_balance_cls[customer_balance_index].BackColor = Color.FromArgb(202, 202, 220);
            }
        }

        void customer_balance_cls_MouseLeave(object Sender, EventArgs E)
        {
            int new_index = customer_balance_cls.IndexOf((Label)Sender);
            if (new_index == customer_balance_index)
            {
                if (customer_balance_isSelect[index] == 0)
                {
                    customer_balance_btn[customer_balance_index].BackColor = Color.FromArgb(209, 209, 225);
                    customer_balance_btn[customer_balance_index].ForeColor = Color.Black;
                    customer_balance_cls[customer_balance_index].ForeColor = Color.FromArgb(209, 209, 225);
                    customer_balance_cls[customer_balance_index].BackColor = Color.FromArgb(209, 209, 225);
                }
            }
        }

        void customer_balance_cls_MouseClick(object Sender, EventArgs E)
        {
            customer_balance_index = customer_balance_cls.IndexOf((Label)Sender);

            control_position = customer_balance_position[customer_balance_index];

            for (int t = 0; t < tran_position.Count; t++)
            {
                if (tran_position[t] > customer_balance_position[customer_balance_index])
                {
                    tran_position[t]--;
                }
            }

            for (int t = 0; t < transfer_position.Count; t++)
            {
                if (transfer_position[t] > customer_balance_position[customer_balance_index])
                {
                    transfer_position[t]--;
                }
            }

            for (int t = 0; t < transaction_statement_position.Count; t++)
            {
                if (transaction_statement_position[t] > customer_balance_position[customer_balance_index])
                {
                    transaction_statement_position[t]--;
                }
            }

            for (int t = 0; t < customer_balance_position.Count; t++)
            {
                if (customer_balance_position[t] > customer_balance_position[customer_balance_index])
                {
                    customer_balance_position[t]--;
                }
            }

            for (int t = 0; t < tabType.Count; t++)
            {
                if (tabType[t] == tabType[control_position])
                {
                    if (tabTypeIndex[t] > tabTypeIndex[control_position])
                    {
                        tabTypeIndex[t]--;
                    }
                }
            }

            customer_balance_btn.RemoveAt(customer_balance_index);
            customer_balance_cls.RemoveAt(customer_balance_index);
            customer_balance_lbl.RemoveAt(customer_balance_index);
            customer_balance_isSelect.RemoveAt(customer_balance_index);
            customer_balance.RemoveAt(customer_balance_index);

            HorizontalTab.Controls.RemoveAt(control_position);
            pnlCenter.Controls.RemoveAt(control_position);
            lstTab.Items.RemoveAt(control_position);
            tabType.RemoveAt(control_position);
            tabTypeIndex.RemoveAt(control_position);

            if (control_position > 0)
            {
                lstTab.SelectedIndex = control_position - 1;
            }

            ci--;
            tab_index--;
            customer_balance_position.RemoveAt(customer_balance_index);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (lblBalanceCollaps.Text == "+")
            {
                pnlBalances.Visible = true;
                lblBalanceCollaps.Text = " -";
            }
            else
            {
                pnlBalances.Visible = false; ;
                lblBalanceCollaps.Text = "+";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (lblStatementCollaps.Text == "+")
            {
                pnlStatements.Visible = true;
                lblStatementCollaps.Text = " -";
            }
            else
            {
                pnlStatements.Visible = false; ;
                lblStatementCollaps.Text = "+";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (lblBillCollaps.Text == "+")
            {
                pnlBills.Visible = true;
                lblBillCollaps.Text = " -";
            }
            else
            {
                pnlBills.Visible = false; ;
                lblBillCollaps.Text = "+";
            }
        }

        private void panel29_DoubleClick(object sender, EventArgs e)
        {
            if (lblBalanceCollaps.Text == "+")
            {
                pnlBalances.Visible = true;
                lblBalanceCollaps.Text = " -";
            }
            else
            {
                pnlBalances.Visible = false; ;
                lblBalanceCollaps.Text = "+";
            }
        }

        private void panel32_DoubleClick(object sender, EventArgs e)
        {
            if (lblStatementCollaps.Text == "+")
            {
                pnlStatements.Visible = true;
                lblStatementCollaps.Text = " -";
            }
            else
            {
                pnlStatements.Visible = false; ;
                lblStatementCollaps.Text = "+";
            }
        }

        private void panel33_DoubleClick(object sender, EventArgs e)
        {
            if (lblBillCollaps.Text == "+")
            {
                pnlBills.Visible = true;
                lblBillCollaps.Text = " -";
            }
            else
            {
                pnlBills.Visible = false; ;
                lblBillCollaps.Text = "+";
            }
        }

        private void lblTransactionCollaps_Click(object sender, EventArgs e)
        {
            if (lblTransactionCollaps.Text == "+")
            {
                pnlTransaction.Visible = true;
                lblTransactionCollaps.Text = " -";
            }
            else
            {
                pnlTransaction.Visible = false; ;
                lblTransactionCollaps.Text = "+";
            }
        }

        private void lblTransactionCollaps1_Click(object sender, EventArgs e)
        {
            if (lblTransactionCollaps1.Text == "+")
            {
                pnlTransaction1.Visible = true;
                lblTransactionCollaps1.Text = " -";
            }
            else
            {
                pnlTransaction1.Visible = false; ;
                lblTransactionCollaps1.Text = "+";
            }
        }

        private void lblTransactionCollaps2_Click(object sender, EventArgs e)
        {
            if (lblTransactionCollaps2.Text == "+")
            {
                pnlTransaction2.Visible = true;
                lblTransactionCollaps2.Text = " -";
            }
            else
            {
                pnlTransaction2.Visible = false; ;
                lblTransactionCollaps2.Text = "+";
            }
        }

        private void panel39_DoubleClick(object sender, EventArgs e)
        {
            if (lblTransactionCollaps.Text == "+")
            {
                pnlTransaction.Visible = true;
                lblTransactionCollaps.Text = " -";
            }
            else
            {
                pnlTransaction.Visible = false; ;
                lblTransactionCollaps.Text = "+";
            }
        }

        private void panel41_DoubleClick(object sender, EventArgs e)
        {
            if (lblTransactionCollaps1.Text == "+")
            {
                pnlTransaction1.Visible = true;
                lblTransactionCollaps1.Text = " -";
            }
            else
            {
                pnlTransaction1.Visible = false; ;
                lblTransactionCollaps1.Text = "+";
            }
        }

        private void panel37_DoubleClick(object sender, EventArgs e)
        {
            if (lblTransactionCollaps2.Text == "+")
            {
                pnlTransaction2.Visible = true;
                lblTransactionCollaps2.Text = " -";
            }
            else
            {
                pnlTransaction2.Visible = false; ;
                lblTransactionCollaps2.Text = "+";
            }
        }

        private void Errors_Click_1(object sender, EventArgs e)
        {
            if (pnlMessage.Visible == true && lblMessageButtom.BackColor == Color.CornflowerBlue)
            {
                pnlMessage.Visible = false;
                lblErrorButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {
                pnlMessage.Visible = true;
                lblErrorButtom.BackColor = Color.Black;

                lblTitle.Text = "Errors";
                errorsBox.Visible = true;
                messagesBox.Visible = false;

                lblMessageButtom.BackColor = Color.CornflowerBlue;
            }
        }

        private void Messages_Click_1(object sender, EventArgs e)
        {
            if (pnlMessage.Visible == true && lblErrorButtom.BackColor == Color.CornflowerBlue)
            {
                pnlMessage.Visible = false;
                lblMessageButtom.BackColor = Color.CornflowerBlue;
            }
            else
            {
                pnlMessage.Visible = true;
                lblMessageButtom.BackColor = Color.Black;

                lblTitle.Text = "Messages";

                errorsBox.Visible = false;
                messagesBox.Visible = true;

                lblErrorButtom.BackColor = Color.CornflowerBlue;
            }
        }

        private void ExpensesTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensesType expensesType = new ExpensesType();
            expensesType.ShowDialog();
        }

        private void ExpensesTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenNewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionTab();
        }

        private void OpentNewTransaferToAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionTab();
        }

        private void OpenNewTransactionStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerStatement();
        }
    }
}
