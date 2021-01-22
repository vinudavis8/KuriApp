using DAL;
using KuriApp.common;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuriApp.Reports
{
    public partial class CustomerReport : MetroFramework.Forms.MetroForm
    {
        public CustomerReport()
        {
            InitializeComponent();
            BindComboBoxDivision();
        }

        private void Customer_Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void BindComboBoxDivision()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dtCategory = _users.GetDivisions();
                if (dtCategory.Rows.Count > 0)
                {
                    comboBoxDivision.DataSource = dtCategory;
                    comboBoxDivision.DisplayMember = "division_name";
                    comboBoxDivision.ValueMember = "division_id";
                    comboBoxDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void BindKuriInDivision(int divisionID)
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dtCategory = _users.GetKuriInDivisions(divisionID);
                if (dtCategory.Rows.Count > 0)
                {
                    comboBoxKuri.DataSource = dtCategory;
                    comboBoxKuri.DisplayMember = "kuri_name";
                    comboBoxKuri.ValueMember = "kuri_id";
                    comboBoxKuri.SelectedIndex = -1;
                }
                else
                    comboBoxKuri.DataSource = null;

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void GetUsertsInKuri(int kuriID)
        {
            try
            {
                DALKuri _context = new DALKuri();
                DataSet dt = _context.GetKuriUsers(kuriID);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    comboBoxUsers.DataSource = dt.Tables[0];
                    comboBoxUsers.DisplayMember = "kuri_user_name";
                    comboBoxUsers.ValueMember = "user_id";
                    comboBoxUsers.SelectedIndex = -1;
                }
                else
                    comboBoxUsers.DataSource = null;
            }


            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                  BindReport();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        public void BindReport()
        {

            try
            {
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                string exeFolder = Application.StartupPath;

                DALKuri _cont = new DALKuri();
                int userID = Convert.ToInt32(comboBoxUsers.SelectedValue);
                int kuriID = Convert.ToInt32(comboBoxKuri.SelectedValue);
                dt = _cont.GetRptUserData(userID, kuriID);
                string reportPath = Path.Combine(exeFolder, @"Reports\userReport.rdlc");

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = reportPath;
                ReportDataSource rds1 = new ReportDataSource("dt", dt);


                reportViewer1.LocalReport.DataSources.Add(rds1);
                //  ReportParameter rp1 = new ReportParameter("paramFromDate", fromDate.ToString());
                // ReportParameter rp2 = new ReportParameter("paramToDate", toDate.ToString());
                // ReportParameter rp3 = new ReportParameter("paramReportName", rptName);
                // reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int divisionID = Convert.ToInt32(comboBoxDivision.SelectedValue);
                BindKuriInDivision(divisionID);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void comboBoxKuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int kuriID = Convert.ToInt32(comboBoxKuri.SelectedValue);
                GetUsertsInKuri(kuriID);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
