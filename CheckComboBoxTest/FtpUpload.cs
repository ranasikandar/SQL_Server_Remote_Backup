using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace BackupSQLServer
{
    public class FtpUpload
    {

        public bool FTPUploadFile(String serverPath, String serverFile, string LocalFile, NetworkCredential Cred)
        {
            bool retVal = true;
            FtpWebResponse response = null;
            try
            {
                FTPMakeDir(new Uri(serverPath + "/"), Cred);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverPath + serverFile);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = Cred;
                byte[] buffer = new byte[10240];    // Read/write 10kb   
                using (FileStream sourceStream = new FileStream(LocalFile.ToString(), FileMode.Open))
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        int bytesRead;
                        do
                        {
                            bytesRead = sourceStream.Read(buffer, 0, buffer.Length);
                            requestStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                    response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in FTPUploadFile - " + ex.Message);
                if (response != null)
                {
                    response.Close();
                }
                retVal = false;
            }
            return retVal;
        }

        private static bool FTPMakeDir(Uri serverUri, NetworkCredential Cred)
        {
            bool retVal = false;
            FtpWebResponse response = null;
            try
            {
                string[] ar = serverUri.ToString().Split('/');
                string makeDirUri = ar[0] + "//" + ar[2] + "/";
                for (int i = 3; i < ar.GetUpperBound(0); i++)
                {
                    makeDirUri += ar[i] + "/";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(makeDirUri));
                    request.KeepAlive = true;
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    request.Credentials = Cred;

                    try
                    {
                        response = (FtpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message != "The remote server returned an error: (550) File unavailable (e.g., file not found, no access).")
                        {
                            retVal = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in FTPMakeDir - " + ex.Message);

                retVal = false;
                if (response != null)
                {
                    response.Close();
                }
            }
            return retVal;
        }
    }
}
