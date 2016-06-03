using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace FanglisteLibrary
{
    public class Network
    {
        #region Variablen

        string servername;
        string passwort;

        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        #endregion

        #region Konstruktor

        public Network(string ServerName, string Passwort)
        {
            this.servername = ServerName;
            this.passwort = Passwort;

        }

        public Network()
        {
        }

        #endregion

        #region Methoden

        /// <summary>
        /// 
        /// </summary>
        /// <param name="http_Adresse"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public static void Download(string http_Adresse, string pfad, string dateiname)
        {
            try
            {
                WebClient _download = new WebClient();

                _download.DownloadFile(http_Adresse + dateiname, pfad + dateiname + ".online");
                File.Copy(pfad + dateiname + ".online", pfad + dateiname, true);
            }
            catch
            {
                //throw new ArgumentException("Datei konnte nicht Heruntergeladen werden.");
            }
        }

        public static void Download1(string dateinameSource, string dateinameDest)
        {
            try
            {
                WebClient _download = new WebClient();

                _download.DownloadFile(dateinameSource, dateinameDest);
            }
            catch
            {
                throw new ArgumentException("Datei konnte nicht Heruntergeladen werden.");
            }
        }

        public void Download_FTP_Request(string http_Adresse, string pfad, string dateiname)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(http_Adresse + dateiname);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(servername, passwort);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                ftpStream = ftpResponse.GetResponseStream();
                /* Open a File Stream to Write the Downloaded File */
                FileStream localFileStream = new FileStream(pfad + dateiname, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftp_Adresse"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public void Upload(string ftp_Adresse, string pfad, string dateiname)
        {
            WebClient _upload = new WebClient();
            _upload.Credentials = new System.Net.NetworkCredential(servername, passwort);

            _upload.UploadFileAsync(new Uri(ftp_Adresse + new FileInfo(dateiname).Name), "STOR", pfad + dateiname);
        }

        public void Upload_FTP_Request(string ftp_Adresse, string pfad, string dateiname)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(ftp_Adresse + "/" + dateiname);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(servername, passwort);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(pfad + dateiname, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftp_Adresse"></param>
        /// <param name="dateinameFtp"></param>
        /// <param name="dateinameLocal"></param>
        public void Upload_pfad_und_dateiname_in_einem_string(string ftp_Adresse, string dateinameFtp, string dateinameLocal)
        {
            try
            {
                WebClient _upload = new WebClient();
                _upload.Credentials = new System.Net.NetworkCredential(this.servername, this.passwort);
                _upload.BaseAddress = "ftp://ftp-web.funpic.de/";

                _upload.UploadFileAsync(new Uri(ftp_Adresse + new FileInfo(dateinameFtp).Name), "STOR", dateinameLocal);
            }
            catch
            {
                throw new Exception("Fehler beim hochladen der Datei.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftp_Adresse"></param>
        /// <param name="dateiname"></param>
        public void DateiLöschen(string ftp_Adresse, string dateiname)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_Adresse + dateiname);
                request.UseBinary = true;
                request.Credentials = new System.Net.NetworkCredential(servername, passwort);

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Proxy = null;
                request.KeepAlive = false;
                request.UsePassive = false;
                request.GetResponse();

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftp_Adresse"></param>
        /// <param name="dateiname_alt"></param>
        /// <param name="dateiname_neu"></param>
        public void DateiUmbenennen(string ftp_Adresse, string dateiname_alt, string dateiname_neu)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_Adresse + dateiname_alt);
                request.Credentials = new System.Net.NetworkCredential(servername, passwort);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                request.Method = WebRequestMethods.Ftp.Rename;

                request.RenameTo = dateiname_neu;

                FtpWebResponse r = (FtpWebResponse)request.GetResponse();
                r.Close();
                r = null;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public static bool Internetverbindung(string http_Adresse, string dateiname)
        {
            bool verbindung = false;

            try
            {
                WebClient _download = new WebClient();

                _download.DownloadFile(http_Adresse + dateiname, Path.GetTempPath() + "a.txt");

                verbindung = true;
            }
            catch
            {
            }

            return verbindung;
        }

        #endregion

        public class ftp
        {
            private string host = null;
            private string user = null;
            private string pass = null;
            private FtpWebRequest ftpRequest = null;
            private FtpWebResponse ftpResponse = null;
            private Stream ftpStream = null;
            private int bufferSize = 2048;

            /* Construct Object */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="hostIP"></param>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            public ftp(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }

            /* Download File */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="remoteFile"></param>
            /// <param name="localFile"></param>
            public void download(string remoteFile, string localFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Get the FTP Server's Response Stream */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Open a File Stream to Write the Downloaded File */
                    FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                    /* Buffer for the Downloaded Data */
                    byte[] byteBuffer = new byte[bufferSize];
                    int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                    try
                    {
                        while (bytesRead > 0)
                        {
                            localFileStream.Write(byteBuffer, 0, bytesRead);
                            bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    localFileStream.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { throw new Exception(ex.ToString()); }
                return;
            }

            /* Upload File */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="remoteFile"></param>
            /// <param name="localFile"></param>
            public void upload(string remoteFile, string localFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpRequest.GetRequestStream();
                    /* Open a File Stream to Read the File for Upload */
                    FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                    /* Buffer for the Downloaded Data */
                    byte[] byteBuffer = new byte[bufferSize];
                    int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                    try
                    {
                        while (bytesSent != 0)
                        {
                            ftpStream.Write(byteBuffer, 0, bytesSent);
                            bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    localFileStream.Close();
                    ftpStream.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { throw new Exception(ex.ToString()); }
                return;
            }

            /* Delete File */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="deleteFile"></param>
            public void delete(string deleteFile)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host + deleteFile);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ///* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }

            /* Rename File */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="currentFileNameAndPath"></param>
            /// <param name="newFileName"></param>
            public void rename(string currentFileNameAndPath, string newFileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                    /* Rename the File */
                    ftpRequest.RenameTo = newFileName;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }

            /* Create a New Directory on the FTP Server */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="newDirectory"></param>
            public void createDirectory(string newDirectory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftpRequest = null;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                return;
            }

            /* Get the Date/Time a File was Created */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            public string getFileCreatedDateTime(string fileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string fileInfo = null;
                    /* Read the Full Response Stream */
                    try { fileInfo = ftpReader.ReadToEnd(); }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return File Created Date Time */
                    return fileInfo;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return "";
            }

            /* Get the Size of a File */
            public string getFileSize(string fileName)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string fileInfo = null;
                    /* Read the Full Response Stream */
                    try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return File Size */
                    return fileInfo;
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return "";
            }

            /* List Directory Contents File/Folder Name Only */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="directory"></param>
            /// <returns></returns>
            public string[] directoryListSimple(string directory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return new string[] { "" };
            }

            /* List Directory Contents in Detail (Name, Size, Created, etc.) */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="directory"></param>
            /// <returns></returns>
            public string[] directoryListDetailed(string directory)
            {
                try
                {
                    /* Create an FTP Request */
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    /* Establish Return Communication with the FTP Server */
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    /* Establish Return Communication with the FTP Server */
                    ftpStream = ftpResponse.GetResponseStream();
                    /* Get the FTP Server's Response Stream */
                    StreamReader ftpReader = new StreamReader(ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Return an Empty string Array if an Exception Occurs */
                return new string[] { "" };
            }
        } 
    }
}
