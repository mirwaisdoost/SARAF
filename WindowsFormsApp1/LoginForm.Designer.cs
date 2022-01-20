namespace WindowsFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.imgFailed = new System.Windows.Forms.PictureBox();
            this.imgSuccess = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lblHelpBottom = new System.Windows.Forms.Label();
            this.lblAboutUsBottom = new System.Windows.Forms.Label();
            this.lblLoginBottom = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblAboutUs = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pnlAboutUs = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.sarafDB = new WindowsFormsApp1.sarafDB();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFailed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlAboutUs.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sarafDB)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLogin.Controls.Add(this.imgFailed);
            this.pnlLogin.Controls.Add(this.imgSuccess);
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.txtMessage);
            this.pnlLogin.Controls.Add(this.label6);
            this.pnlLogin.Controls.Add(this.btnCancel);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.panel4);
            this.pnlLogin.Controls.Add(this.panel5);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(35, 26);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(401, 364);
            this.pnlLogin.TabIndex = 1;
            // 
            // imgFailed
            // 
            this.imgFailed.Image = ((System.Drawing.Image)(resources.GetObject("imgFailed.Image")));
            this.imgFailed.Location = new System.Drawing.Point(12, 148);
            this.imgFailed.Name = "imgFailed";
            this.imgFailed.Size = new System.Drawing.Size(20, 21);
            this.imgFailed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFailed.TabIndex = 31;
            this.imgFailed.TabStop = false;
            // 
            // imgSuccess
            // 
            this.imgSuccess.Image = ((System.Drawing.Image)(resources.GetObject("imgSuccess.Image")));
            this.imgSuccess.Location = new System.Drawing.Point(12, 148);
            this.imgSuccess.Name = "imgSuccess";
            this.imgSuccess.Size = new System.Drawing.Size(20, 21);
            this.imgSuccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSuccess.TabIndex = 30;
            this.imgSuccess.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(233, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.txtMessage.Location = new System.Drawing.Point(38, 152);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(0, 15);
            this.txtMessage.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 33);
            this.label6.TabIndex = 27;
            this.label6.Text = "Login";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(122, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogin.Location = new System.Drawing.Point(203, 322);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 24;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 20);
            this.panel4.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(45, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Please enter your Username and Password";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lavender;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtPort);
            this.panel5.Controls.Add(this.txtServer);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtPassword);
            this.panel5.Controls.Add(this.txtUser);
            this.panel5.Location = new System.Drawing.Point(12, 199);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 108);
            this.panel5.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(221, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(73, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "3306";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(75, 67);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(111, 20);
            this.txtServer.TabIndex = 8;
            this.txtServer.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(75, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(75, 15);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(219, 20);
            this.txtUser.TabIndex = 4;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(33, 390);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(405, 2);
            this.panel11.TabIndex = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(35, 24);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(401, 2);
            this.panel8.TabIndex = 17;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.pnlLeft.ColumnCount = 3;
            this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.pnlLeft.Controls.Add(this.lblHelpBottom, 0, 2);
            this.pnlLeft.Controls.Add(this.lblAboutUsBottom, 0, 1);
            this.pnlLeft.Controls.Add(this.lblLoginBottom, 0, 0);
            this.pnlLeft.Controls.Add(this.lblLogin, 2, 0);
            this.pnlLeft.Controls.Add(this.pictureBox2, 1, 0);
            this.pnlLeft.Controls.Add(this.lblAboutUs, 2, 1);
            this.pnlLeft.Controls.Add(this.pictureBox3, 1, 1);
            this.pnlLeft.Controls.Add(this.lblHelp, 2, 2);
            this.pnlLeft.Controls.Add(this.pictureBox4, 1, 2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 24);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.RowCount = 4;
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.pnlLeft.Size = new System.Drawing.Size(33, 368);
            this.pnlLeft.TabIndex = 18;
            // 
            // lblHelpBottom
            // 
            this.lblHelpBottom.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblHelpBottom.Location = new System.Drawing.Point(1, 58);
            this.lblHelpBottom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 3);
            this.lblHelpBottom.Name = "lblHelpBottom";
            this.lblHelpBottom.Size = new System.Drawing.Size(2, 27);
            this.lblHelpBottom.TabIndex = 5;
            // 
            // lblAboutUsBottom
            // 
            this.lblAboutUsBottom.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblAboutUsBottom.Location = new System.Drawing.Point(1, 29);
            this.lblAboutUsBottom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 2);
            this.lblAboutUsBottom.Name = "lblAboutUsBottom";
            this.lblAboutUsBottom.Size = new System.Drawing.Size(2, 27);
            this.lblAboutUsBottom.TabIndex = 4;
            // 
            // lblLoginBottom
            // 
            this.lblLoginBottom.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblLoginBottom.Location = new System.Drawing.Point(1, 0);
            this.lblLoginBottom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lblLoginBottom.Name = "lblLoginBottom";
            this.lblLoginBottom.Size = new System.Drawing.Size(2, 27);
            this.lblLoginBottom.TabIndex = 3;
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLogin.Location = new System.Drawing.Point(33, 0);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblLogin.Size = new System.Drawing.Size(70, 27);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblAboutUs
            // 
            this.lblAboutUs.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblAboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutUs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAboutUs.Location = new System.Drawing.Point(33, 29);
            this.lblAboutUs.Margin = new System.Windows.Forms.Padding(0);
            this.lblAboutUs.Name = "lblAboutUs";
            this.lblAboutUs.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblAboutUs.Size = new System.Drawing.Size(70, 27);
            this.lblAboutUs.TabIndex = 1;
            this.lblAboutUs.Text = "About US";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 29);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHelp.Location = new System.Drawing.Point(33, 58);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblHelp.Size = new System.Drawing.Size(70, 27);
            this.lblHelp.TabIndex = 2;
            this.lblHelp.Text = "Help";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 58);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 24);
            this.panel1.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(33, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 366);
            this.panel6.TabIndex = 20;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(436, 24);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 366);
            this.panel7.TabIndex = 21;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 392);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(438, 24);
            this.panel9.TabIndex = 20;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(438, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(24, 416);
            this.panel10.TabIndex = 22;
            // 
            // pnlAboutUs
            // 
            this.pnlAboutUs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAboutUs.Controls.Add(this.label7);
            this.pnlAboutUs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAboutUs.Location = new System.Drawing.Point(35, 26);
            this.pnlAboutUs.Name = "pnlAboutUs";
            this.pnlAboutUs.Size = new System.Drawing.Size(401, 364);
            this.pnlAboutUs.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(22, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 33);
            this.label7.TabIndex = 28;
            this.label7.Text = "About US";
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHelp.Controls.Add(this.label8);
            this.pnlHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHelp.Location = new System.Drawing.Point(35, 26);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(401, 364);
            this.pnlHelp.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 33);
            this.label8.TabIndex = 28;
            this.label8.Text = "Help";
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHome.Controls.Add(this.label9);
            this.pnlHome.Controls.Add(this.pictureBox6);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(35, 26);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(401, 364);
            this.pnlHome.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(157, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 33);
            this.label9.TabIndex = 28;
            this.label9.Text = "SARAF";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(44, 35);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(310, 310);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 30;
            this.pictureBox6.TabStop = false;
            // 
            // sarafDB
            // 
            this.sarafDB.DataSetName = "sarafDB";
            this.sarafDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 416);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.pnlAboutUs);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SARAF-LOGIN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFailed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlAboutUs.ResumeLayout(false);
            this.pnlAboutUs.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            this.pnlHelp.PerformLayout();
            this.pnlHome.ResumeLayout(false);
            this.pnlHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sarafDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.PictureBox imgFailed;
        private System.Windows.Forms.PictureBox imgSuccess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TableLayoutPanel pnlLeft;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblAboutUs;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblHelpBottom;
        private System.Windows.Forms.Label lblAboutUsBottom;
        private System.Windows.Forms.Label lblLoginBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlAboutUs;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox6;
        public sarafDB sarafDB;
    }
}