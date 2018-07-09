using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using RemoteBackupTool;
using System.Net;
using System.IO;
//using Utilities;
using System.IO.Compression;
using System.Data;

namespace BackupSQLServer
{
    public partial class FrmMain : Form
    {
        protected SQLLocalBackup _backupClass; // our backup class located in SQLLocalBackup.cs

        //private string[] DbsList = new BLL().GetDbNames();//gone into tick for fields usable..

        private string[] DbsList;

        private BackgroundWorker bw;

        public bool ErrorInBackup = false;

        //globalKeyboardHook gkh = new globalKeyboardHook();//to hide & show frm by key

        // ,"A very long string exceeding the dropdown width and forcing a scrollbar to appear to make the content viewable"};
        public FrmMain()
        {
            InitializeComponent();
            //backgroundWorker

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;


            // Manually add handler for when an item check state has been modified.
            cbxDbName.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheck);
        }
        //////////////
        private static DataSet ds = new DataSet();

        private static DataView dv = new DataView();
        
        //////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
                        
            WriteLog("Program Started");
            txtOut.AppendText("Program Started '"+DateTime.Now+"' \r\n");

            this.txtBackupPath.Text = this.folderBrowserDialog1.SelectedPath;
            
            this.gBoxDoIt.Enabled = false;
            this.GBoxFtp.Enabled = false;


            DateOfBackup.Format = DateTimePickerFormat.Time;
            DateOfBackup.ShowUpDown = true;
            
            ///register a key to show & hide
            //gkh.HookedKeys.Add(Keys.Insert);
            //gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);

            //////////////////LOAD XML FILE, SHOW data in PROFILE
            this.cboProfile.DataSource = SelectAll();
        }

        //void gkh_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
        //    if (this.Visible)
        //    {
        //        WriteLog("Hiden");
        //        this.Hide();
        //    }
        //    else
        //    {
        //        WriteLog("Shown");
        //        this.Show();
        //    }

        //    e.Handled = true;
        //}

        private void ccb_DropDownClosed(object sender, EventArgs e)
        {
            //txtOut.AppendText("DropdownClosed\r\n");
            //txtOut.AppendText(string.Format("value changed: {0}\r\n", cbxDbName.ValueChanged));
            //txtOut.AppendText(string.Format("value: {0}\r\n", cbxDbName.Text));
            // Display all checked items.
            
            StringBuilder sb = new StringBuilder("Selected DB's: ");
            foreach (CCBoxItem item in cbxDbName.CheckedItems)
            {
                sb.Append(item.Name).Append(cbxDbName.ValueSeparator);
            }
            sb.Remove(sb.Length - cbxDbName.ValueSeparator.Length, cbxDbName.ValueSeparator.Length);
            txtOut.AppendText(sb.ToString());
            txtOut.AppendText("\r\n");

            WriteLog(sb.ToString());
        }

        private void ccb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = cbxDbName.Items[e.Index] as CCBoxItem;
            WriteLog(string.Format("DB '{0}' is selected for backup{1}\r\n", item.Name, " " + e.NewValue.ToString().ToUpper()));
            txtOut.AppendText(string.Format("DB '{0}' is selected for backup{1}\r\n", item.Name, " "+e.NewValue.ToString().ToUpper()));
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteLog("Program Exit\n\n");
            txtOut.AppendText("Program Exit at '" + DateTime.Now + "' \r\n");
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtBackupPath.Text = this.folderBrowserDialog1.SelectedPath;
                WriteLog("Local Backup Path has been set to '" + this.folderBrowserDialog1.SelectedPath + "'");
                txtOut.AppendText("Local Backup Path has been set to '" + this.folderBrowserDialog1.SelectedPath + "' \r\n");
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChkValidation())
                {
                    ////this.cbxDbName.Items.Clear();

                    //DbsList = new BLL().GetDbNames(AssignData());

                    //for (int i = 0; i < DbsList.Length; i++)
                    //{
                    //    CCBoxItem item = new CCBoxItem(DbsList[i], i);
                    //    cbxDbName.Items.Add(item);
                    //}

                    //// If more then 5 items, add a scroll bar to the dropdown.
                    //cbxDbName.MaxDropDownItems = 5;

                    //// Make the "Name" property the one to display, rather than the ToString() representation.
                    //cbxDbName.DisplayMember = "name";
                    //cbxDbName.ValueSeparator = ",";

                    WriteLog("Ok its time to Backup. Trying to Backup.");
                    txtOut.AppendText("Ok its time to Backup. Trying to Backup. at '" + DateTime.Now + "'\r\n");

                    if (!this.bw.IsBusy)
                    {
                        this.timer1.Enabled = false;
                        this.bw.RunWorkerAsync();
                    }
                    else
                    {
                        WriteLog("Backup is Already busy.");
                        txtOut.AppendText("Backup is Already busy. \r\n");
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorInBackup = true;
                this.timer1.Enabled = true;
                WriteLog("ERROR IN BACKUP.");
                txtOut.AppendText("ERROR IN BACKUP '" + DateTime.Now + "' \r\n " + ex.Message + " \r\n\n");
            }
        }


        private bool chkValidFTP()
        {
            if (this.txtFtpServer.Text.Trim() != "")
            {
                if (this.txtFtpUserName.Text.Trim() != "")
                {
                    if (this.txtFtpPasswd.Text.Trim() != "")
                    {
                        if (txtFtpPort.Text.Trim()!="")
                        {
                            //AssignData();
                            return true;
                        }
                        else
                        {
                            this.txtFtpPort.Focus();
                            MessageBox.Show("Invalid");
                        }
                        
                    }
                    else
                    {
                        this.txtFtpPasswd.Focus();
                        MessageBox.Show("Invalid");
                    }
                }
                else
                {
                    this.txtFtpUserName.Focus();
                    MessageBox.Show("Invalid");
                }
            }
            else
            {
                this.txtFtpServer.Focus();
                MessageBox.Show("Invalid");
            }
            
            return false;
        }

        private bool ChkValidation()
        {
            if (this.txtDbServer.Text.Trim() != "")
            {
                if (this.txtSqlID.Text.Trim()!="")
                {
                    if (this.txtSqlPasswd.Text.Trim()!="")
                    {
                        if (this.txtRemoteDir.Text.Trim()!="")
                        {
                            return true;
                        }
                        else
                        {
                            this.txtRemoteDir.Focus();
                            MessageBox.Show("Invalid");
                        }
                    }
                    else
                    {
                        this.txtSqlPasswd.Focus();
                        MessageBox.Show("Invalid");
                    }
                }
                else
                {
                    this.txtSqlID.Focus();
                    MessageBox.Show("Invalid");
                }
            }
            else
            {
                this.txtDbServer.Focus();
                MessageBox.Show("Invalid");
            }
            gBoxDoIt.Enabled = false;
            return false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //JUST FOT TESTING //DELETE IT
            //txtOut.AppendText("Checking if its time to Backup '" + DateTime.Now + "' \r\n");
            
                try
                {
                    ///set to only time DATE EXCLUDED
                    ///-1  if  t1 is shorter than t2.
                    //0   if  t1 is equal to t2.
                    //1   if  t1 is longer than t2.
                    //ErrorInBackup||

                    //JUST FOT TESTING //DELETE IT
                    //txtOut.AppendText("" + Convert.ToDateTime(DateTime.Now.ToLongTimeString()).TimeOfDay + "'," + Convert.ToDateTime(this.DateOfBackup.Value.ToLongTimeString()).TimeOfDay + " \r\n");



                    if (ErrorInBackup || ((TimeSpan.Compare(Convert.ToDateTime(DateTime.Now.ToLongTimeString()).TimeOfDay, Convert.ToDateTime(this.DateOfBackup.Value.ToLongTimeString()).TimeOfDay)) == 0))//TO DO MORE WORK FOR ACURACY
                    {

                        if (ChkValidation())
                        {
                            string dbMsg=new DAL().dbchk(AssignData());

                            if (dbMsg=="ok")
                            {
                                WriteLog("Ok its time to Backup. Trying to Backup.");
                                txtOut.AppendText("Ok its time to Backup. Trying to Backup. at '" + DateTime.Now + "'\r\n");

                                if (!this.bw.IsBusy)
                                {
                                    this.timer1.Enabled = false;
                                    this.bw.RunWorkerAsync();
                                }
                                else
                                {
                                    WriteLog("Backup is Already busy.");
                                    txtOut.AppendText("Backup is Already busy. " + DateTime.Now + " \r\n");
                                }
                            }
                            else
                            {
                                WriteLog(dbMsg + "\n");

                                txtOut.AppendText(dbMsg + ". " + DateTime.Now + " \r\n");
                                
                                gBoxDoIt.Enabled = false;

                                ErrorInBackup = true;
                            }

                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    ErrorInBackup = true;
                    this.timer1.Enabled = true;
                    WriteLog("ERROR IN BACKUP.");
                    txtOut.AppendText("ERROR IN BACKUP '" + DateTime.Now + "' \r\n " + ex.Message + " \r\n\n");
                }
            
        }

        private void dtBackup_ValueChanged(object sender, EventArgs e)
        {
            WriteLog("Backup Time has been set to '" + this.DateOfBackup.Value.ToLongTimeString() + "'.");
            txtOut.AppendText("Backup Time has been set to '" + this.DateOfBackup.Value.ToLongTimeString() + "' \r\n");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            try
            {
                Int32 qtyOfDb = cbxDbName.CheckedItems.Count + 1;
                string FileNameToUpload;

                foreach (CCBoxItem item in cbxDbName.CheckedItems)
                {
                    //make remote backup
                    _backupClass = new SQLLocalBackup(this.txtDbServer.Text, this.txtSqlID.Text, this.txtSqlPasswd.Text, item.Name);

                    //use remote backup to local drive
                    FileNameToUpload = _backupClass.DoLocalBackup(this.txtRemoteDir.Text, this.folderBrowserDialog1.SelectedPath);

                    ////compress file before uploading
                    BegingCompression(FileNameToUpload);

                    ////trim .bak from file name
                    //FileNameToUpload = FileNameToUpload.Replace(".bak", "");
                    File.Move(FileNameToUpload+".zip", FileNameToUpload.Replace(".bak", ".zip"));

                    if (cbxFTP.Checked)
                    {
                        ////upload to ftp
                        if (File.Exists(FileNameToUpload))
                        {

                            if (new FtpUpload().FTPUploadFile("ftp://" + this.txtFtpServer.Text + "/DBBackup/" + item.Name + "", "/"
                                + item.Name + Convert.ToString(DateTime.Now).Replace(':', '-').Replace('/', '-')
                                + ".zip", FileNameToUpload + ".zip", new NetworkCredential(this.txtFtpUserName.Text, this.txtFtpPasswd.Text)))
                            {
                                // report your progres
                                worker.ReportProgress(qtyOfDb = qtyOfDb - 1);

                                //delete .bak file we have .zip
                                File.Delete(FileNameToUpload);
                            }

                        }
                        else
                        {
                            // report your progres
                            worker.ReportProgress(0);
                        }
                    }
                    else
                    {

                    }

                }

                e.Result = "Backup Task Completed!";

            }
            catch (Exception ex)
            {
                ErrorInBackup = true;
                throw ex;
            }
            finally
            {
                //this.timer1.Enabled = true;
            }
        }

        private void BegingCompression(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);
            using (FileStream fs = new FileStream(fileName+".zip", FileMode.CreateNew))
            using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
            {
                zipStream.Write(bytes, 0, bytes.Length);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WriteLog("Backup has been completed successfuly of '" + e.ProgressPercentage.ToString() + "'DB. Total DB's to been backed up are '" + cbxDbName.CheckedItems.Count + "'.");
            txtOut.AppendText("Backup has been completed successfuly of '" + e.ProgressPercentage.ToString() + "'DB. Total DB's to been backed up are '" + cbxDbName.CheckedItems.Count + "'. at '" + DateTime.Now + "' \r\n");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WriteLog(e.Result.ToString()+"\n\n");
            txtOut.AppendText("" + e.Result.ToString() + " at '" + DateTime.Now + "' \r\n\n");
            this.timer1.Enabled = true;
            ErrorInBackup = false;
        }

        private static void WriteLog(string str, string filename="Log.txt")
        {
            File.AppendAllText(filename, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " - " + str + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                WriteLog("Auto Backup Disabled at " + DateTime.Now + "\n\n");
                txtOut.AppendText("Auto Backup Disabled at " + DateTime.Now + "\n\n");

                this.timer1.Enabled = false;
            }
            else
            {
                WriteLog("Auto Backup Enabled at " + DateTime.Now + "\n\n");
                txtOut.AppendText("Auto Backup Enabled at " + DateTime.Now + "\n\n");

                this.timer1.Enabled = true;
            }
            
        }

        private Obj AssignData()
        {
            Obj obj = new Obj();

            obj.ServerName = this.txtDbServer.Text;
            obj.SqlID = this.txtSqlID.Text;
            obj.SqlPasswd = this.txtSqlPasswd.Text;
            obj.RemoteDir = this.txtRemoteDir.Text;

            obj.FtpChk = this.cbxFTP.Checked;

            obj.ftpServerURI = this.txtFtpServer.Text;
            obj.ftpUserID = this.txtFtpUserName.Text;
            obj.ftpPassword = this.txtFtpPasswd.Text;

            obj.ftpPort = this.txtFtpPort.Text;

            return obj;
        }

        private Obj AssignEncData()
        {
            Obj obj = new Obj();

            obj.ServerName = this.txtDbServer.Text;
            obj.SqlID = Encrypt(this.txtSqlID.Text);
            obj.SqlPasswd = Encrypt(this.txtSqlPasswd.Text);
            obj.RemoteDir = Encrypt(this.txtRemoteDir.Text);

            obj.FtpChk = this.cbxFTP.Checked;

            obj.ftpServerURI = Encrypt(this.txtFtpServer.Text);
            obj.ftpUserID = Encrypt(this.txtFtpUserName.Text);
            obj.ftpPassword = Encrypt(this.txtFtpPasswd.Text);

            obj.ftpPort = Encrypt(this.txtFtpPort.Text);

            return obj;
        }


        //private void btnStep2_Click(object sender, EventArgs e)
        //{
        //    //this.cbxDbName.Items.Clear();

        //    if (ChkValidation())
        //    {
                

        //    }
        //}

        private void btnSqlAuth_Click(object sender, EventArgs e)
        {
            if (ChkValidation())
            {
                string chkDB = new DAL().dbchk(AssignData());

                if (chkDB == "ok")
                {
                    ////save profile
                    //sql data only
                    ////
                    WriteLog("DB is authanticated.\n");

                    txtOut.AppendText("Auth of SQL Server Successfuly! " + DateTime.Now + " \r\n");

                    gBoxDoIt.Enabled = true;

                    ////LOAD DROPDOWN WITH DBS.
                    DbsList = new BLL().GetDbNames(AssignData());
                    ////
                    this.cbxDbName.Items.Clear();
                    ////
                    for (int i = 0; i < DbsList.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(DbsList[i], i);
                        cbxDbName.Items.Add(item);
                    }

                    // If more then 5 items, add a scroll bar to the dropdown.
                    cbxDbName.MaxDropDownItems = 5;

                    // Make the "Name" property the one to display, rather than the ToString() representation.
                    cbxDbName.DisplayMember = "name";
                    cbxDbName.ValueSeparator = ",";

                    // Check the first 2 items.
                    //cbxDbName.SetItemChecked(0, true);
                    //cbxDbName.SetItemChecked(1, true);

                    //ccb.SetItemCheckState(1, CheckState.Indeterminate);

                    this.cbxDbName.Focus();
                    MessageBox.Show("plz select DB that you want to get backup of");
                                        
                }
                else
                {
                    WriteLog(chkDB + "\n");

                    txtOut.AppendText(chkDB + ". " + DateTime.Now + " \r\n");

                    this.cbxDbName.Items.Clear();

                    gBoxDoIt.Enabled = false;
                }
            }
        }


        private void cbxFTP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxFTP.Checked)
            {
                this.GBoxFtp.Enabled = true;
                WriteLog("FTP Enabled.\n");
                txtOut.AppendText("FTP Enabled. " + DateTime.Now + " \r\n");
            }
            else
            {
                this.GBoxFtp.Enabled = false;
                WriteLog("FTP Disabled.\n");
                txtOut.AppendText("FTP Disabled. " + DateTime.Now + " \r\n");
            }
        }

        private void btnFtpAuth_Click(object sender, EventArgs e)
        {
            if (chkValidFTP())
            {
                string ftpMsg=new DAL().chkFtpAuth(AssignData());

                if (ftpMsg=="ok")
                {
                    WriteLog("FTP Auth success.\n");
                    txtOut.AppendText("FTP Auth success. "+DateTime.Now+" \r\n");
                }
                else
                {
                    WriteLog(""+ftpMsg+" \n");
                    txtOut.AppendText(ftpMsg+". " + DateTime.Now + " \r\n");
                }
                
            }
        }

        private void txtFtpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ActiveControl == null)
                return;
            else if (ActiveControl.Name != cboProfile.Name)
                return;
            AssignToCtrl();
            this.BtnSaveProfile.Text = "Update Profile";
            btnSqlAuth_Click(sender, e);

        }

        private void AssignToCtrl()
        {
            this.txtDbServer.Text = dv[Convert.ToInt32(cboProfile.SelectedIndex)]["SqlServer"].ToString();
            this.txtSqlID.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["SqlUser"].ToString());
            this.txtSqlPasswd.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["SqlPassword"].ToString());
            this.txtRemoteDir.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["RemoteDIR"].ToString());

            if (dv[Convert.ToInt32(cboProfile.SelectedIndex)]["FtpChk"].ToString() == "1")
            {
                this.cbxFTP.Checked = true;
            }
            else
            {
                this.cbxFTP.Checked = false;
            }

            this.txtFtpServer.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["FtpServer"].ToString());
            this.txtFtpPort.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["FtpPort"].ToString());
            this.txtFtpUserName.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["FtpUser"].ToString());
            this.txtFtpPasswd.Text = Decrypt(dv[Convert.ToInt32(cboProfile.SelectedIndex)]["FtpPassword"].ToString());
        }

        public static DataView SelectAll()
        {
            ds.Clear();
            ds.ReadXml(Application.StartupPath + "\\DATA\\ProfileA.xml", XmlReadMode.ReadSchema);
            dv = ds.Tables[0].DefaultView;
            return dv;
        }

        public static void Delete(string categoryID)
        {

            dv.RowFilter = "SrNo='" + categoryID + "'";

            dv.Sort = "SrNo";

            dv.Delete(0);

            dv.RowFilter = "";

            save();

        }

        public static void save()
        {

            ds.WriteXml(Application.StartupPath + "\\DATA\\ProfileA.xml", XmlWriteMode.WriteSchema);

        }

        private void BtnDeleteProfile_Click(object sender, EventArgs e)
        {
            Delete(this.cboProfile.SelectedValue.ToString());
            this.cboProfile.Focus();

            if (cboProfile.SelectedIndex>=0)
            {
                cboProfile.SelectedIndex = 0;
            }
            
        }

        private void BtnNewProfile_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.BtnSaveProfile.Text = "Save Profile";
            this.cbxDbName.Items.Clear();
        }

        private void ClearFields()
        {
            this.txtDbServer.Text = string.Empty;
            this.txtSqlID.Text = string.Empty;
            this.txtSqlPasswd.Text = string.Empty;
            this.txtRemoteDir.Text = string.Empty;
            
            this.cbxFTP.Checked = true;

            this.txtFtpServer.Text = string.Empty;
            this.txtFtpPort.Text = string.Empty;
            this.txtFtpUserName.Text = string.Empty;
            this.txtFtpPasswd.Text = string.Empty;

            groupBox1.Enabled = true;
            this.txtDbServer.Focus();
        }

        //add new
        public static void Insert(Obj obj, Int32 srNo)//string categoryID, string CategoryName
        {

            DataRow dr = dv.Table.NewRow();

            dr["SrNo"] = srNo;
            dr["SqlServer"] = obj.ServerName;
            dr["SqlUser"] = Encrypt(obj.SqlID);
            dr["SqlPassword"] = Encrypt(obj.SqlPasswd);
            dr["RemoteDIR"] = Encrypt(obj.RemoteDir);

            if (obj.FtpChk)
            {
                dr["FtpChk"] = "1";
            }
            else
            {
                dr["FtpChk"] = "0";
            }

             
            dr["FtpServer"] = Encrypt(obj.ftpServerURI);
            dr["FtpPort"] = Encrypt(obj.ftpPort);
            dr["FtpUser"] = Encrypt(obj.ftpUserID);
            dr["FtpPassword"] = Encrypt(obj.ftpPassword);

            dv.Table.Rows.Add(dr);

            save();

        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            if (BtnSaveProfile.Text == "Save Profile")
            {
                if (ChkValidation())
                {
                    if (this.cbxFTP.Checked)
                    {
                        if (chkValidFTP())
                        {
                            ///get max from sr of profiles
                            DataTable firstTable = ds.Tables[0];

                            int minAccountLevel = int.MaxValue;
                            int maxAccountLevel = int.MinValue;
                            foreach (DataRow dr in firstTable.Rows)
                            {
                                int accountLevel = dr.Field<int>("SrNo");
                                minAccountLevel = Math.Min(minAccountLevel, accountLevel);
                                maxAccountLevel = Math.Max(maxAccountLevel, accountLevel);
                            }
                            ///get max from sr of profiles

                            //1 for first entry
                            if (maxAccountLevel < 0)
                            {
                                maxAccountLevel = 0;
                            }

                            ///insert entry.
                            Insert(AssignData(), maxAccountLevel + 1);
                            this.BtnSaveProfile.Text = "Save Profile";

                            ///auth check
                            btnSqlAuth_Click(sender, e);
                            btnFtpAuth_Click(sender, e);

                        }

                    }
                    else
                    {
                        ///get max from sr of profiles
                        DataTable firstTable = ds.Tables[0];

                        int minAccountLevel = int.MaxValue;
                        int maxAccountLevel = int.MinValue;
                        foreach (DataRow dr in firstTable.Rows)
                        {
                            int accountLevel = dr.Field<int>("SrNo");
                            minAccountLevel = Math.Min(minAccountLevel, accountLevel);
                            maxAccountLevel = Math.Max(maxAccountLevel, accountLevel);
                        }
                        ///get max from sr of profiles
                        ///insert entry.

                        if (maxAccountLevel<0)
                        {
                            maxAccountLevel = 0;
                        }

                        Insert(AssignData(), maxAccountLevel + 1);
                        this.BtnSaveProfile.Text = "Save Profile";

                        ///auth check
                        btnSqlAuth_Click(sender, e);
                    }

                }

            }
            else//update
            {
                if (ChkValidation())
                {
                    if (this.cbxFTP.Checked)
                    {
                        if (chkValidFTP())
                        {
                            Update(AssignEncData(), this.cboProfile.SelectedValue.ToString());
                            this.BtnSaveProfile.Text = "Save Profile";

                            ///auth check
                            btnSqlAuth_Click(sender, e);
                            btnFtpAuth_Click(sender, e);
                        }

                    }
                    else
                    {
                        Update(AssignEncData(), this.cboProfile.SelectedValue.ToString());
                        this.BtnSaveProfile.Text = "Save Profile";

                        ///auth check
                        btnSqlAuth_Click(sender, e);
                    }

                }
            }
            
        }

        public static void Update(Obj obj, string srNo)
        {

            DataRow dr = Select(srNo);

            dr["SrNo"] = srNo;
            dr["SqlServer"] = obj.ServerName;
            dr["SqlUser"] = obj.SqlID;
            dr["SqlPassword"] = obj.SqlPasswd;
            dr["RemoteDIR"] = obj.RemoteDir;

            if (obj.FtpChk)
            {
                dr["FtpChk"] = "1";
            }
            else
            {
                dr["FtpChk"] = "0";
            }
            
             
            dr["FtpServer"] = obj.ftpServerURI;
            dr["FtpPort"] = obj.ftpPort;
            dr["FtpUser"] = obj.ftpUserID;
            dr["FtpPassword"] = obj.ftpPassword;

            save();

        }

        //Search any data in dataview with specific primary key
        public static DataRow Select(string SrNo)
        {

            dv.RowFilter = "SrNo='" + SrNo + "'";

            dv.Sort = "SrNo";

            DataRow dr = null;

            if (dv.Count > 0)
            {
                dr = dv[0].Row;

            }

            dv.RowFilter = "";

            return dr;

        }

        public static string Encrypt(string input)
        {
            string sampleText = string.Empty;

            sampleText = EncDec.Encryption.Encrypt(input);

            sampleText = sampleText.Replace("+", "*1*2*");

            return (sampleText);
        }

        public static string Decrypt(string input)
        {
            string encryptedText = input;

            encryptedText = encryptedText.Replace("*1*2*", "+");

            return (EncDec.Encryption.Decrypt(encryptedText));
        }

    }
}