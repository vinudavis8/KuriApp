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

namespace KuriApp.Sub_forms
{
    public partial class Division : MetroFramework.Forms.MetroForm
    {
        int division_id = 0;
        int editRowIndex = 0;
        public Division()
        {
            InitializeComponent();
            LoadDivision();
            BindComboBox();
        }
        public void BindComboBox()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dtCategory = _users.GetAreas();
                if (dtCategory.Rows.Count > 0)
                {
                    comboBoxArea.DataSource = dtCategory;
                    comboBoxArea.DisplayMember = "area_name";
                    comboBoxArea.ValueMember = "area_id";
                    comboBoxArea.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void LoadDivision()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dt = _users.GetDivisions();
                dataGrid.DataSource = dt;
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[2].Visible = false;
                dataGrid.Columns[1].HeaderText = "Division Name";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            panelDataGrid.Show();
            panelNew.Hide();
             LoadDivision();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            panelDataGrid.Hide();
            panelNew.Show();
            ClearForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {

                if (!string.IsNullOrEmpty(txtDivisionName.Text))
                {
                    DALUsers _users = new DALUsers();
                    string name = txtDivisionName.Text;
                    int areaID = Convert.ToInt32(comboBoxArea.SelectedValue);
                    var result = _users.SaveDivision(division_id, name, areaID);

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Division Saved", "Success");
                        ClearForm();
                        LoadDivision();
                        panelDataGrid.Show();
                        panelNew.Hide();
                    }
                    else
                        MessageBox.Show("Failed", "Warning");
                }
                else
                    MessageBox.Show("Please Enter division name", "Warning");

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void ClearForm()
        {
            division_id = 0;
            editRowIndex = 0;
            txtDivisionName.Text = "";
            comboBoxArea.SelectedIndex = -1;
        }

        private void dataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGrid.ClearSelection();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                editRowIndex = e.RowIndex;
                division_id = Convert.ToInt32(this.dataGrid.Rows[e.RowIndex].Cells[0].Value);
                panelDataGrid.Hide();
                panelNew.Show();
                BindEditData();
            }
        }
        public void BindEditData()
        {
            try
            {
                string name = dataGrid.Rows[editRowIndex].Cells[1].Value.ToString();

                txtDivisionName.Text = name;
                int areaID = Convert.ToInt32(dataGrid.Rows[editRowIndex].Cells[2].Value);
                comboBoxArea.SelectedValue = areaID;
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
    }
}
