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
    public partial class Users : MetroFramework.Forms.MetroForm
    {
        int user_id = 0;
        int editRowIndex = 0;
        public Users()
        {
            InitializeComponent();
            BindComboBox();
            LoadUsers();
        }
          public void LoadUsers()
        {
            try
            {
                DALUsers _users = new DALUsers();
              DataTable dt=  _users.GetUsers();
              dataGrid.DataSource = dt;
              dataGrid.Columns[0].Visible = false;
                  dataGrid.Columns[3].Visible = false;
                  dataGrid.Columns[5].Visible = false;
                  dataGrid.Columns[6].Visible = false;
                  dataGrid.Columns[7].Visible = false;
                  dataGrid.Columns[8].Visible = false;
                  dataGrid.Columns[1].HeaderText = "Name";
                  dataGrid.Columns[2].HeaderText = "Phone";
                  dataGrid.Columns[4].HeaderText = "Membership No.";

                  dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            LoadUsers();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            panelDataGrid.Hide();
            panelNew.Show();
            ClearForm();
        }
        public void BindComboBox()
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
                    comboBoxDivision.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try{
                if(isvalid())
                {

                    DALUsers _users = new DALUsers();
                    string name = txtName.Text;
                    string phone=txtPhone.Text;
                   string residAddress= txtResidAddress.Text;
                    string shopAddress= txtShopAddress.Text;
                    string membershipNo= txtMembershipno.Text;
                    DateTime dob=dateTimePickerdob.Value;
                    int divisionID=Convert.ToInt32( comboBoxDivision.SelectedValue);
                 var result =   _users.SaveUser(name, phone, dob, membershipNo, residAddress, shopAddress, divisionID, true, user_id);

                 if (Convert.ToInt32(result) > 0)
                 {
                    MessageBox.Show("User Saved","Success");
                    ClearForm();
                    LoadUsers();
                    panelDataGrid.Show();
                    panelNew.Hide();
                }
                 else
                     MessageBox.Show( "Failed","Warning");
                }
                
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        public bool isvalid()
        {
            bool isvalid =true;
                try
                {
                    if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) || comboBoxDivision.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please enter required fields","Warning");
                        isvalid=false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return isvalid;
        }
        public void ClearForm()
        {
            user_id = 0;
            editRowIndex = 0;
            txtName.Text = "";
            txtPhone.Text = "";
            txtResidAddress.Text = "";
            txtShopAddress.Text = "";
            txtMembershipno.Text = "";
            dateTimePickerdob.Value = DateTime.Today.Date;
           comboBoxDivision.SelectedIndex = -1;
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
                user_id = Convert.ToInt32(this.dataGrid.Rows[e.RowIndex].Cells[0].Value);
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
                string membershipNo = dataGrid.Rows[editRowIndex].Cells[4].Value.ToString();
                string residAddress = dataGrid.Rows[editRowIndex].Cells[5].Value.ToString();
                string shopAddress = dataGrid.Rows[editRowIndex].Cells[6].Value.ToString();
               DateTime dob =Convert.ToDateTime(dataGrid.Rows[editRowIndex].Cells[3].Value.ToString());
                int divisionID =Convert.ToInt32( dataGrid.Rows[editRowIndex].Cells[7].Value);
               
                txtName.Text = name;
                txtPhone.Text = phone;
                txtResidAddress.Text = residAddress;
                txtShopAddress.Text = shopAddress;
                txtMembershipno.Text = membershipNo;
                comboBoxDivision.SelectedValue = divisionID;
                dateTimePickerdob.Value = dob.Date;

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
