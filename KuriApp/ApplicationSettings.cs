using KuriApp.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlLocalDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPos.Forms
{
    public partial class ApplicationSettings : MetroFramework.Forms.MetroForm
    {
        public ApplicationSettings()
        {
            InitializeComponent();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {


           

        }

        private async void initialize()
        {

            #region
            try
            {
                string initialized = ConfigurationManager.AppSettings["key"];
                if (!string.IsNullOrEmpty(initialized))
                {
                    MessageBox.Show("Initialized Already", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                  //  pictureBox2.Show();
                    await Task.Run(() => createInstance());
                    WriteWebconfig();
                  //  pictureBox2.Hide();
                    MessageBox.Show("Initialized Successfully,please restart application", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               // pictureBox2.Hide();
                ErrorLog.WriteErrorLog(ex.ToString());
                MessageBox.Show("Initialize Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            #endregion
        }


        public void WriteWebconfig()
        {
            try
            {
                //string exepath = AppDomain.CurrentDomain.BaseDirectory + "ExpenseManager.exe.config";
                //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                //fileMap.ExeConfigFilename = exepath;
                //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //config.AppSettings.Settings["init"].Value = "Y";

                //DateTime dt1 = DateTime.Today.AddDays(10);
                //string todayplus10 = dt1.Day.ToString("00") + "/" + dt1.Month.ToString("00") + "/" + dt1.Year.ToString("0000");

                //Crypto cr = new Crypto(true);

                //string SID = RandomString(4, true);
                //string encryptedSID = cr.Encrypt(SID, cr.mPassword);
                //string encryptedExpiryDate = cr.Encrypt(todayplus10, cr.mPassword);
                //config.AppSettings.Settings["Ex"].Value = encryptedExpiryDate;
                //config.AppSettings.Settings["SID"].Value = encryptedSID;

                //config.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
                throw ex;
            }
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public void createInstance()
        {
            string s = "";
            try
            {

                ISqlLocalDbProvider provider = new SqlLocalDbProvider();
                ISqlLocalDbInstance instance = provider.GetOrCreateInstance("kuriappInstance");

                instance.Start();
                clearFolder();
                using (SqlConnection connection = instance.CreateConnection())
                {
                    connection.Open();
                    //.....create database................//
                    string fileNameCreate = "script\\Create_db.sql";
                    string sourcePathcreate = AppDomain.CurrentDomain.BaseDirectory + fileNameCreate;
                    FileInfo filecreate = new FileInfo(sourcePathcreate);
                    string scriptcreate = filecreate.OpenText().ReadToEnd();

                    using (SqlCommand command1 = new SqlCommand())
                    {
                        command1.Connection = connection;

                        var scriptscreate = scriptcreate.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var splitScript in scriptscreate)
                        {
                            s = splitScript;
                            command1.CommandText = splitScript;
                            command1.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                }

                instance.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
                //if(ex.Message=="Cannot drop database "ExpenseManager" because it is currently in use.")
                //{

                //}
                throw ex;

            }
        }

        private void buttonInitialize_Click(object sender, EventArgs e)
        {

            initialize();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            panelSettings.Hide();
        }

    
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                labelFileupload.Text = openFileDialog1.SafeFileName;
            }
        }

        private void buttonrunscript_Click(object sender, EventArgs e)
        {
            //pictureBox1.Show();
            runscript();
          //  pictureBox1.Hide();
        }

        public async void runscript()
        {

            try
            {

                string file = openFileDialog1.FileName;
                string text = File.ReadAllText(file);
                string defaultConnection = ConfigurationManager.ConnectionStrings["ExpenseManagerEntities"].ToString();
                SqlConnection connection = new SqlConnection(defaultConnection);
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    var scripts = text.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var splitScript in scripts)
                    {
                        try
                        {
                            command.CommandText = splitScript;
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                            continue;
                        }

                    }
                }
                MessageBox.Show("Script Executed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Script Execution Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorLog.WriteErrorLog(ex.ToString());
            }


        }

        private void clearFolder()
        {
            try
            {
                //string targetPath = @"C:\Users\Public\lanapos";

                //if (Directory.Exists(targetPath))
                //{
                //    Directory.Delete(targetPath, true);
                //}

                string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


                if (File.Exists(UserPath + @"\kuriapp.mdf"))
                {
                    File.Delete(UserPath + @"\kuriapp.mdf");
                }
                if (File.Exists(UserPath + @"\kuriapp_log.ldf"))
                {
                    File.Delete(UserPath + @"\kuriapp_log.ldf");
                }
            }
            catch (Exception ex)
            {

               // log.WriteErrorLog(ex.ToString());
            }

        }
    }
}
