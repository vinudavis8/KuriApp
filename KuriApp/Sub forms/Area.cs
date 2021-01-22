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
    public partial class Area : MetroFramework.Forms.MetroForm
    {
        int area_id = 0;
        int editRowIndex = 0;
        public Area()
        {
            InitializeComponent();
            LoadArea();
        }
        public void LoadArea()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dt = _users.GetAreas();
                dataGrid.DataSource = dt;
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Area Name";
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
            LoadArea();
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
                
                if( !string.IsNullOrEmpty( txtAreaName.Text))
                {
                    DALUsers _users = new DALUsers();
                    string name = txtAreaName.Text;
                   
                    var result = _users.SaveArea(area_id, name);

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Area Saved", "Success");
                        ClearForm();
                        LoadArea();
                        panelDataGrid.Show();
                        panelNew.Hide();
                    }
                    else
                        MessageBox.Show("Failed", "Warning");
                }
                else
                     MessageBox.Show("Please Enter area name", "Warning");

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void ClearForm()
        {
            area_id= 0;
            editRowIndex = 0;
            txtAreaName.Text = "";
            
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
                area_id = Convert.ToInt32(this.dataGrid.Rows[e.RowIndex].Cells[0].Value);
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
               
                txtAreaName.Text = name;
              
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
