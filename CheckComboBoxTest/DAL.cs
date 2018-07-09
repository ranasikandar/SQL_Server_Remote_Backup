using System;

using System.Data;
using System.Data.SqlClient;

using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Net;

namespace BackupSQLServer
{
    public class DAL
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;

       //public static string ServerName = "PRIMEIT-PC";//THIS CAN BE REMOTE SERVER TOO.//IN THAT CASE OF COURSE THE IP OR DOMAIN NAME
       //public static string SqlPasswd = "abc.123";
       // public static string SqlID = "sa";
       // public static string RemoteDir = @"D:\";//THIS DIR WILL BE USED TO MAKE BACKUP FILEs AT REMOTE SERVER. //WATCH OUT SQL WRITE PERMITIONS FOR THE SELECTED PATH OF SERVER.


       // public static string ftpServerURI = "173.212.205.20:21247"; // FTP server //const
       // public static string ftpUserID = ""; //FTP Username
       // public static string ftpPassword = ""; //FTP Password

        //protected static string ConnectionString = "server="+ServerName+";uid="+SqlID+";pwd="+SqlPasswd+";Connect Timeout=10000;";

        

        public DataTable GetDbNames(Obj obj)
        {
            con = new SqlConnection("server=" + obj.ServerName + ";uid=" + obj.SqlID + ";pwd=" + obj.SqlPasswd + ";Connect Timeout=10000;");

            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT name FROM master.dbo.sysdatabases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb', 'ReportServer', 'ReportServerTempDB');";

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
                cmd = null;

            }
        }

        /// <summary>
        /// delet it
        /// </summary>
        /// <param name="backUpFile"></param>
        //public void BackupDatabase(string backUpFile)
        //{
        //    ServerConnection con2 = new ServerConnection(@"" + ConnectionString + "");
        //    Server server = new Server(con2);
        //    Backup source = new Backup();
        //    source.Action = BackupActionType.Database;
        //    source.Database = "shopware";
        //    BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
        //    source.Devices.Add(destination);
        //    source.SqlBackup(server);
        //    con2.Disconnect();
        //}


        public string dbchk(Obj obj)
        {
            SqlConnection con = new SqlConnection("server=" + obj.ServerName + ";uid=" + obj.SqlID + ";pwd=" + obj.SqlPasswd + ";Connect Timeout=30;");
            try
            {
                con.Open();
                return "ok";
            }
            catch (SqlException ex)
            {
                //throw ex;
                switch (ex.Number)
                {
                    case 4060:
                        //return "few possibilities\nDatabase not found.\nserver temporary down.\nInvalid Database";
                        return ex.Message;
                    case 18456:
                        //return "few possibilities\nDatabase Login Failed\nInvalid Login\nadmin have changed Login.";
                        return ex.Message;
                    default: return Convert.ToString(ex.Message);
                }

            }
            finally { con.Close(); }
        }


        public string chkFtpAuth(Obj obj)
        {

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + obj.ftpServerURI + ":" + obj.ftpPort);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(obj.ftpUserID, obj.ftpPassword);
                request.GetResponse();
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
            return "ok";

        }


    }
}
