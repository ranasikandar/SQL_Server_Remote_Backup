using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace BackupSQLServer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMain f = new FrmMain();
            Application.Run(f);
        }
    }
}