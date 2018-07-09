using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackupSQLServer
{
    public class Obj
    {
        public string ServerName { get; set; }
        public string SqlPasswd { get; set; }
        public string SqlID { get; set; }
        public string RemoteDir { get; set; }

        public bool FtpChk { get; set; }

        public string ftpServerURI { get; set; }
        public string ftpUserID { get; set; }
        public string ftpPassword { get; set; }

        public string ftpPort { get; set; }
    }
}
