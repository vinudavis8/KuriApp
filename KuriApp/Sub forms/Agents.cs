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
    public partial class Agents : MetroFramework.Forms.MetroForm
    {
        int agent_id = 0;
        int editRowIndex = 0;
        public Agents()
        {
            InitializeComponent();
            LoadAgents();
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
        public void LoadAgents()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dt = _users.GetAgents();
                dataGrid.DataSource = dt;
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[3].Visible = false;
                dataGrid.Columns[4].Visible = false;
                dataGrid.Columns[1].HeaderText = "Agent Name";
                dataGrid.Columns[2].HeaderText = "Phone";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isvalid())
                {

                    DALUsers _users = new DALUsers();
                    string name = txtAgentName.Text;
                    string phone = txtPhone.Text;
                    string address = txtAddress.Text;
                    int areaID = Convert.ToInt32(comboBoxArea.SelectedValue);
                    var result = _users.SaveAgents(agent_id, areaID, name, phone, address);

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Agent Saved", "Success");
                        ClearForm();
                        LoadAgents();
                        panelDataGrid.Show();
                        panelNew.Hide();
                    }
                    else
                        MessageBox.Show("Failed", "Warning");
                }

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void ClearForm()
        {
            agent_id = 0;
            editRowIndex = 0;
            txtAddress.Text = "";
            txtAgentName.Text = "";
            txtPhone.Text = "";
            comboBoxArea.SelectedIndex = -1;
        }
        public bool isvalid()
        {
            bool isvalid = true;
            try
            {
                if (string.IsNullOrEmpty(txtAgentName.Text) || string.IsNullOrEmpty(txtPhone.Text) || comboBoxArea.SelectedIndex == -1)
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

        private void buttonList_Click(object sender, EventArgs e)
        {
            panelDataGrid.Show();
            panelNew.Hide();
            LoadAgents();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {

            panelDataGrid.Hide();
            panelNew.Show();
            ClearForm();
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
                agent_id = Convert.ToInt32(this.dataGrid.Rows[e.RowIndex].Cells[0].Value);
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
                string phone = dataGrid.Rows[editRowIndex].Cells[2].Value.ToString();
                string address = dataGrid.Rows[editRowIndex].Cells[3].Value.ToString();
                int areaID = Convert.ToInt32(dataGrid.Rows[editRowIndex].Cells[4].Value);
                txtAgentName.Text = name;
                txtPhone.Text = phone;
                txtAddress.Text = address;
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
