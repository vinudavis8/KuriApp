using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuriApp.common
{
   
        public static class ErrorLog
        {
            public static bool WriteErrorLog(string LogMessage)
            {
                bool Status = false;
                string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ErrorLog.txt";
                DateTime CurrentDateTime = DateTime.Now;
                string CurrentDateTimeString = CurrentDateTime.ToString();
                string logLine = BuildLogLine(CurrentDateTime, LogMessage);
                lock (typeof(ErrorLog))
                {
                    StreamWriter oStreamWriter = null;
                    try
                    {


                        oStreamWriter = File.AppendText(LogDirectory);
                        // FileStream fappend = File.Open(LogDirectory, FileMode.Append); // will append to end of file


                        // oStreamWriter = new StreamWriter(fappend);
                        oStreamWriter.WriteLine("");
                        oStreamWriter.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------------------------------");
                        oStreamWriter.WriteLine(logLine);
                        oStreamWriter.WriteLine("---------------------------------------*End*----------------------------------------------------");
                        oStreamWriter.WriteLine("");


                        Status = true;
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (oStreamWriter != null)
                        {
                            oStreamWriter.Close();
                        }
                    }
                }
                return Status;
            }


            private static bool CheckCreateLogDirectory(string LogPath)
            {
                bool loggingDirectoryExists = false;
                DirectoryInfo oDirectoryInfo = new DirectoryInfo(LogPath);
                if (oDirectoryInfo.Exists)
                {
                    loggingDirectoryExists = true;
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(LogPath);
                        loggingDirectoryExists = true;
                    }
                    catch
                    {
                        // Logging failure
                    }
                }
                return loggingDirectoryExists;
            }


            private static string BuildLogLine(DateTime CurrentDateTime, string LogMessage)
            {
                StringBuilder loglineStringBuilder = new StringBuilder();
                loglineStringBuilder.Append(LogMessage);
                return loglineStringBuilder.ToString();
            }


            public static string LogFileEntryDateTime(DateTime CurrentDateTime)
            {
                return CurrentDateTime.ToString("dd-MM-yyyy HH:mm:ss");
            }


            private static string LogFileName(DateTime CurrentDateTime)
            {
                return CurrentDateTime.ToString("dd_MM_yyyy");
            }
        }
    
}
