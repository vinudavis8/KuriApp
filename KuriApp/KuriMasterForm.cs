using DAL;
using KuriApp.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuriApp
{
    public partial class KuriMasterForm : Form
    {
        DALKuri _context;
        int kuri_id = 0;
        int editRowIndex = 0;
        DateTime tempDate;
        public KuriMasterForm()
        {
            InitializeComponent();
            BindComboBox();
            LoadKuriList();
            dataGridView.ClearSelection();
            _context = new DALKuri();
        }
        public void LoadKuriList()
        {
            try
            {
                 _context = new DALKuri();
                 dataGridView.DataSource = null;
                 dataGridView.Rows.Clear();
                DataTable dt = _context.GetKuriList();
               // [division_id],[kuri_name],[kuri_amount],[terms],[start_date]
                foreach(DataRow row in dt.AsEnumerable())
                {
                    
            var index = dataGridView.Rows.Add();
            dataGridView.Rows[index].Cells["kuriID"].Value = row["kuri_id"].ToString();
            dataGridView.Rows[index].Cells["KuriName"].Value = row["kuri_name"].ToString();
            dataGridView.Rows[index].Cells["Amount"].Value =row["kuri_amount"].ToString();
            dataGridView.Rows[index].Cells["Terms"].Value = row["terms"].ToString();
            dataGridView.Rows[index].Cells["Customers"].Value = "view";
            dataGridView.Rows[index].Cells["AuctionHistory"].Value = "view";

                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void BindComboBox()
        {
            try
            {
                DALUsers _us = new DALUsers();

              DataTable dtCategory = _us.GetDivisions();
                if (dtCategory.Rows.Count > 0)
                {
                    comboBoxDivision.DataSource = dtCategory;
                    comboBoxDivision.DisplayMember = "division_name";
                    comboBoxDivision.ValueMember = "division_id";
                    comboBoxDivision.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        private void buttonSaveData_Click(object sender, EventArgs e)
        {
           // var index = dataGridView.Rows.Add();

            try
            {
                if (isvalid())
                {

                    string KuriName = txtKuriName.Text;
                    string kuriAmount =  txtKuriAmount.Text;
                    decimal kuriTermAmount=Convert.ToDecimal(txtTermAmount.Text);
                    int kuriTerms = Convert.ToInt32( txtTerms.Text);
                    DateTime startDate = dateTimePicker1.Value;
                    int divisionID = Convert.ToInt32(comboBoxDivision.SelectedValue);
                    bool reschedule=false;
                    if (tempDate != startDate)
                        reschedule = true;
                    var result = _context.SaveKuriMaster(divisionID, KuriName, Convert.ToDecimal(kuriAmount), kuriTerms, startDate, kuri_id, kuriTermAmount, reschedule);

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Kuri Saved", "Success");
                        ClearForm();
                        LoadKuriList();
                    }
                    else
                        MessageBox.Show("Failed", "Warning");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed", "Warning");
                ErrorLog.WriteErrorLog(ex.ToString());
            }
            
        }
        public void ClearForm()
        {
            kuri_id = 0;
            editRowIndex = 0;
            txtKuriName.Text = "";
            txtKuriAmount.Text = "";
            txtTerms.Text = "";
            txtTermAmount.Text = "";
            dateTimePicker1.Value = DateTime.Today.Date;
            comboBoxDivision.SelectedIndex = -1;
        }
        public bool isvalid()
        {
            bool isvalid = true;
            try
            {
                if (string.IsNullOrEmpty(txtTermAmount.Text) || string.IsNullOrEmpty(txtKuriName.Text) || string.IsNullOrEmpty(txtKuriAmount.Text) || comboBoxDivision.SelectedIndex == -1 || string.IsNullOrEmpty(txtTerms.Text))
                {
                    MessageBox.Show("Please enter required fields", "Warning");
                    isvalid = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isvalid;
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editRowIndex = e.RowIndex;
            kuri_id = Convert.ToInt32(this.dataGridView.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                KuriMasterDetails _details = new KuriMasterDetails(kuri_id);
                _details.Show();
            }
            else
            {
                if (e.RowIndex != -1)
                {
                   
                    BindEditData();
                }
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView.ClearSelection();
        }
        public void BindEditData()
        {
            try
            {
               DataTable dt= _context.GetKuriData(kuri_id);

               string name = dt.Rows[0][2].ToString();
               string amount = dt.Rows[0][3].ToString();
               string terms = dt.Rows[0][4].ToString();
               string startdate = dt.Rows[0][5].ToString();
               string termAmount = dt.Rows[0][6].ToString();
                int divisionID = Convert.ToInt32(dt.Rows[0][1].ToString());

                tempDate =  Convert.ToDateTime(startdate);
                txtTermAmount.Text = termAmount;
              txtKuriName.Text=name;
                txtKuriAmount.Text=amount;
                txtTerms.Text = terms;
                dateTimePicker1.Value = Convert.ToDateTime(startdate);
              comboBoxDivision.SelectedValue=divisionID;

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Home);
            if (formToShow != null)
            {
                formToShow.Show();
                formToShow.BringToFront();
            }
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
