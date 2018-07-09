namespace BackupSQLServer {
    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtOut = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrows = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DateOfBackup = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDbServer = new System.Windows.Forms.TextBox();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.txtFtpServer = new System.Windows.Forms.TextBox();
            this.txtFtpPort = new System.Windows.Forms.TextBox();
            this.txtFtpUserName = new System.Windows.Forms.TextBox();
            this.txtFtpPasswd = new System.Windows.Forms.TextBox();
            this.gBoxDoIt = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlPasswd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSqlID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSqlAuth = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GBoxFtp = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFtpAuth = new System.Windows.Forms.Button();
            this.cbxFTP = new System.Windows.Forms.CheckBox();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.BtnDeleteProfile = new System.Windows.Forms.Button();
            this.BtnNewProfile = new System.Windows.Forms.Button();
            this.BtnSaveProfile = new System.Windows.Forms.Button();
            this.cbxDbName = new BackupSQLServer.CheckedComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gBoxDoIt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GBoxFtp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOut.ForeColor = System.Drawing.SystemColors.Window;
            this.txtOut.Location = new System.Drawing.Point(5, 507);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.Size = new System.Drawing.Size(403, 293);
            this.txtOut.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "DB\'s:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Info:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "D:\\";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Enabled = false;
            this.txtBackupPath.Location = new System.Drawing.Point(7, 76);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(227, 20);
            this.txtBackupPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local BackupPath:";
            // 
            // btnBrows
            // 
            this.btnBrows.Location = new System.Drawing.Point(240, 73);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(75, 23);
            this.btnBrows.TabIndex = 4;
            this.btnBrows.Text = "Brows Dir";
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(321, 73);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Backup Now";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DateOfBackup
            // 
            this.DateOfBackup.CustomFormat = "hh:mm:ss tt";
            this.DateOfBackup.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBackup.Location = new System.Drawing.Point(7, 123);
            this.DateOfBackup.Name = "DateOfBackup";
            this.DateOfBackup.Size = new System.Drawing.Size(103, 20);
            this.DateOfBackup.TabIndex = 7;
            this.toolTip1.SetToolTip(this.DateOfBackup, "Only Time");
            this.DateOfBackup.ValueChanged += new System.EventHandler(this.dtBackup_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Backup At Every:";
            // 
            // txtDbServer
            // 
            this.txtDbServer.Location = new System.Drawing.Point(6, 36);
            this.txtDbServer.Name = "txtDbServer";
            this.txtDbServer.Size = new System.Drawing.Size(167, 20);
            this.txtDbServer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtDbServer, "Server Domain Name Or IP");
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Location = new System.Drawing.Point(6, 80);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.Size = new System.Drawing.Size(92, 20);
            this.txtRemoteDir.TabIndex = 7;
            this.txtRemoteDir.Text = "D:\\";
            this.toolTip1.SetToolTip(this.txtRemoteDir, "THIS DIR WILL BE USED TO MAKE BACKUP FILES AT REMOTE SQL SERVER. WATCH OUT SQL WR" +
                    "ITE PERMITIONS FOR THE SELECTED PATH OF SERVER.");
            // 
            // txtFtpServer
            // 
            this.txtFtpServer.Location = new System.Drawing.Point(9, 41);
            this.txtFtpServer.Name = "txtFtpServer";
            this.txtFtpServer.Size = new System.Drawing.Size(101, 20);
            this.txtFtpServer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtFtpServer, "Domain or IP with Port eg: 111.222.333.444:22");
            // 
            // txtFtpPort
            // 
            this.txtFtpPort.Location = new System.Drawing.Point(116, 41);
            this.txtFtpPort.Name = "txtFtpPort";
            this.txtFtpPort.Size = new System.Drawing.Size(49, 20);
            this.txtFtpPort.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtFtpPort, "Domain or IP with Port eg: 111.222.333.444:22");
            this.txtFtpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFtpPort_KeyPress);
            // 
            // txtFtpUserName
            // 
            this.txtFtpUserName.Location = new System.Drawing.Point(186, 41);
            this.txtFtpUserName.Name = "txtFtpUserName";
            this.txtFtpUserName.Size = new System.Drawing.Size(102, 20);
            this.txtFtpUserName.TabIndex = 5;
            // 
            // txtFtpPasswd
            // 
            this.txtFtpPasswd.Location = new System.Drawing.Point(293, 41);
            this.txtFtpPasswd.Name = "txtFtpPasswd";
            this.txtFtpPasswd.Size = new System.Drawing.Size(95, 20);
            this.txtFtpPasswd.TabIndex = 7;
            this.txtFtpPasswd.UseSystemPasswordChar = true;
            // 
            // gBoxDoIt
            // 
            this.gBoxDoIt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gBoxDoIt.Controls.Add(this.button1);
            this.gBoxDoIt.Controls.Add(this.txtBackupPath);
            this.gBoxDoIt.Controls.Add(this.label3);
            this.gBoxDoIt.Controls.Add(this.cbxDbName);
            this.gBoxDoIt.Controls.Add(this.DateOfBackup);
            this.gBoxDoIt.Controls.Add(this.label17);
            this.gBoxDoIt.Controls.Add(this.btnBackup);
            this.gBoxDoIt.Controls.Add(this.label2);
            this.gBoxDoIt.Controls.Add(this.btnBrows);
            this.gBoxDoIt.Location = new System.Drawing.Point(5, 328);
            this.gBoxDoIt.Name = "gBoxDoIt";
            this.gBoxDoIt.Size = new System.Drawing.Size(403, 155);
            this.gBoxDoIt.TabIndex = 7;
            this.gBoxDoIt.TabStop = false;
            this.gBoxDoIt.Text = "Step 2:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Auto Backup: Enable/Disable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SQL Server:";
            // 
            // txtSqlPasswd
            // 
            this.txtSqlPasswd.Location = new System.Drawing.Point(275, 36);
            this.txtSqlPasswd.Name = "txtSqlPasswd";
            this.txtSqlPasswd.Size = new System.Drawing.Size(121, 20);
            this.txtSqlPasswd.TabIndex = 5;
            this.txtSqlPasswd.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(273, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "SQL Password:";
            // 
            // txtSqlID
            // 
            this.txtSqlID.Location = new System.Drawing.Point(178, 36);
            this.txtSqlID.Name = "txtSqlID";
            this.txtSqlID.Size = new System.Drawing.Size(92, 20);
            this.txtSqlID.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "SQL ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Remote Dir:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnSqlAuth);
            this.groupBox1.Controls.Add(this.txtRemoteDir);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSqlID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSqlPasswd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDbServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(5, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1:";
            // 
            // btnSqlAuth
            // 
            this.btnSqlAuth.Location = new System.Drawing.Point(284, 78);
            this.btnSqlAuth.Name = "btnSqlAuth";
            this.btnSqlAuth.Size = new System.Drawing.Size(112, 23);
            this.btnSqlAuth.TabIndex = 8;
            this.btnSqlAuth.Text = "Sql Auth / Step 2";
            this.btnSqlAuth.UseVisualStyleBackColor = true;
            this.btnSqlAuth.Click += new System.EventHandler(this.btnSqlAuth_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(290, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "FTP Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(184, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "FTP UserName:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "FTP Server:";
            // 
            // GBoxFtp
            // 
            this.GBoxFtp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GBoxFtp.Controls.Add(this.label11);
            this.GBoxFtp.Controls.Add(this.txtFtpPort);
            this.GBoxFtp.Controls.Add(this.btnFtpAuth);
            this.GBoxFtp.Controls.Add(this.txtFtpUserName);
            this.GBoxFtp.Controls.Add(this.label8);
            this.GBoxFtp.Controls.Add(this.txtFtpPasswd);
            this.GBoxFtp.Controls.Add(this.txtFtpServer);
            this.GBoxFtp.Controls.Add(this.label10);
            this.GBoxFtp.Controls.Add(this.label9);
            this.GBoxFtp.Location = new System.Drawing.Point(5, 203);
            this.GBoxFtp.Name = "GBoxFtp";
            this.GBoxFtp.Size = new System.Drawing.Size(403, 101);
            this.GBoxFtp.TabIndex = 6;
            this.GBoxFtp.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(113, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "FTP Port:";
            // 
            // btnFtpAuth
            // 
            this.btnFtpAuth.Location = new System.Drawing.Point(313, 67);
            this.btnFtpAuth.Name = "btnFtpAuth";
            this.btnFtpAuth.Size = new System.Drawing.Size(75, 23);
            this.btnFtpAuth.TabIndex = 8;
            this.btnFtpAuth.Text = "FTP Auth";
            this.btnFtpAuth.UseVisualStyleBackColor = true;
            this.btnFtpAuth.Click += new System.EventHandler(this.btnFtpAuth_Click);
            // 
            // cbxFTP
            // 
            this.cbxFTP.AutoSize = true;
            this.cbxFTP.Location = new System.Drawing.Point(11, 185);
            this.cbxFTP.Name = "cbxFTP";
            this.cbxFTP.Size = new System.Drawing.Size(49, 17);
            this.cbxFTP.TabIndex = 5;
            this.cbxFTP.Text = "FTP:";
            this.cbxFTP.UseVisualStyleBackColor = true;
            this.cbxFTP.CheckedChanged += new System.EventHandler(this.cbxFTP_CheckedChanged);
            // 
            // cboProfile
            // 
            this.cboProfile.DisplayMember = "SqlServer";
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Location = new System.Drawing.Point(11, 26);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(121, 21);
            this.cboProfile.TabIndex = 0;
            this.cboProfile.ValueMember = "SrNo";
            this.cboProfile.SelectedIndexChanged += new System.EventHandler(this.cboProfile_SelectedIndexChanged);
            // 
            // BtnDeleteProfile
            // 
            this.BtnDeleteProfile.Location = new System.Drawing.Point(143, 24);
            this.BtnDeleteProfile.Name = "BtnDeleteProfile";
            this.BtnDeleteProfile.Size = new System.Drawing.Size(89, 23);
            this.BtnDeleteProfile.TabIndex = 1;
            this.BtnDeleteProfile.Text = "Delete Profile";
            this.BtnDeleteProfile.UseVisualStyleBackColor = true;
            this.BtnDeleteProfile.Click += new System.EventHandler(this.BtnDeleteProfile_Click);
            // 
            // BtnNewProfile
            // 
            this.BtnNewProfile.Location = new System.Drawing.Point(232, 24);
            this.BtnNewProfile.Name = "BtnNewProfile";
            this.BtnNewProfile.Size = new System.Drawing.Size(89, 23);
            this.BtnNewProfile.TabIndex = 2;
            this.BtnNewProfile.Text = "New Profile";
            this.BtnNewProfile.UseVisualStyleBackColor = true;
            this.BtnNewProfile.Click += new System.EventHandler(this.BtnNewProfile_Click);
            // 
            // BtnSaveProfile
            // 
            this.BtnSaveProfile.Location = new System.Drawing.Point(321, 24);
            this.BtnSaveProfile.Name = "BtnSaveProfile";
            this.BtnSaveProfile.Size = new System.Drawing.Size(89, 23);
            this.BtnSaveProfile.TabIndex = 3;
            this.BtnSaveProfile.Text = "Save Profile";
            this.BtnSaveProfile.UseVisualStyleBackColor = true;
            this.BtnSaveProfile.Click += new System.EventHandler(this.BtnSaveProfile_Click);
            // 
            // cbxDbName
            // 
            this.cbxDbName.CheckOnClick = true;
            this.cbxDbName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxDbName.DropDownHeight = 1;
            this.cbxDbName.FormattingEnabled = true;
            this.cbxDbName.IntegralHeight = false;
            this.cbxDbName.Location = new System.Drawing.Point(7, 37);
            this.cbxDbName.Name = "cbxDbName";
            this.cbxDbName.Size = new System.Drawing.Size(389, 21);
            this.cbxDbName.TabIndex = 1;
            this.cbxDbName.ValueSeparator = ", ";
            this.cbxDbName.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Profile:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 812);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BtnSaveProfile);
            this.Controls.Add(this.BtnNewProfile);
            this.Controls.Add(this.BtnDeleteProfile);
            this.Controls.Add(this.cboProfile);
            this.Controls.Add(this.cbxFTP);
            this.Controls.Add(this.GBoxFtp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxDoIt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBoxDoIt.ResumeLayout(false);
            this.gBoxDoIt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBoxFtp.ResumeLayout(false);
            this.GBoxFtp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedComboBox cbxDbName;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrows;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker DateOfBackup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gBoxDoIt;
        private System.Windows.Forms.TextBox txtDbServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSqlPasswd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSqlID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemoteDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFtpServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFtpUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFtpPasswd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSqlAuth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox GBoxFtp;
        private System.Windows.Forms.CheckBox cbxFTP;
        private System.Windows.Forms.Button btnFtpAuth;
        private System.Windows.Forms.TextBox txtFtpPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.Button BtnDeleteProfile;
        private System.Windows.Forms.Button BtnNewProfile;
        private System.Windows.Forms.Button BtnSaveProfile;
        private System.Windows.Forms.Label label12;
    }
}

