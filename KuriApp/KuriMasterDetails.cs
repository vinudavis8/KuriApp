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
    public partial class KuriMasterDetails : Form
    {
        int _kuriID;
        DALKuri _context;
        int _auctionID;
        int editRowIndex = 0;
        public KuriMasterDetails(int kuriID)
        {
            InitializeComponent();
            _kuriID = kuriID;
            LoadKuriAuctionHistory();
            LoadKuriUsers();
            GetUsertsInDivision();
            // var index = dataGridViewUsers.Rows.Add();
            //dataGridViewUsers.Rows[index].Cells["Users"].Value = "Jose";
            //txtNewCustomer.Text = "";


            //var index = dataGridView.Rows.Add();
            //dataGridView.Rows[index].Cells["Amount"].Value = 200;
            //dataGridView.Rows[index].Cells["CallPerson"].Value = "Vargheese";
            //dataGridView.Rows[index].Cells["CallAmount"].Value = "45000";
            //dataGridView.Rows[index].Cells["Date"].Value = DateTime.Now.Date.ToShortDateString();

            dataGridViewAuctionHistory.ClearSelection();
            dataGridViewUsers.ClearSelection();
            panelAddCustomers.Hide();
        }


        public void LoadKuriUsers()
        {
            try
            {
                _context = new DALKuri();
                dataGridViewUsers.DataSource = null;
                dataGridViewUsers.Rows.Clear();
                DataSet dt = _context.GetKuriUsers(_kuriID);

                comboBoxAuctionUsers.DataSource = dt.Tables[0];
                comboBoxAuctionUsers.DisplayMember = "name";
                comboBoxAuctionUsers.ValueMember = "user_id";
                comboBoxAuctionUsers.SelectedIndex = -1;
                foreach (DataRow row in dt.Tables[0].AsEnumerable())
                {

                    var index = dataGridViewUsers.Rows.Add();
                    dataGridViewUsers.Rows[index].Cells["user_id"].Value = row["user_id"].ToString();
                    dataGridViewUsers.Rows[index].Cells["name"].Value = row["name"].ToString();
                    dataGridViewUsers.Rows[index].Cells["kuri_user_name"].Value = row["kuri_user_name"].ToString();

                }

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void LoadKuriAuctionHistory()
        {
            try
            {
                _context = new DALKuri();
                dataGridViewAuctionHistory.DataSource = null;
                dataGridViewAuctionHistory.Rows.Clear();
                DataTable dt = _context.GetKuriAuctionHistory(_kuriID);
                dataGridViewAuctionHistory.DataSource = dt;
                dataGridViewAuctionHistory.Columns[0].HeaderText = "User";
                dataGridViewAuctionHistory.Columns[1].Visible = false;//_id
                dataGridViewAuctionHistory.Columns[2].Visible = false;
                dataGridViewAuctionHistory.Columns[3].Visible = false;

                dataGridViewAuctionHistory.Columns[4].HeaderText = "Auction Amount";
                dataGridViewAuctionHistory.Columns[5].HeaderText = "Auction Date";
                dataGridViewAuctionHistory.Columns[6].HeaderText = "Auction Payment Date";
                dataGridViewAuctionHistory.Columns[7].HeaderText = "New Term Amount";

            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void GetUsertsInDivision()
         {
             try
             {
                 _context = new DALKuri();
                 dataGridViewAllUsers.DataSource = null;
                 dataGridViewAllUsers.Rows.Clear();

                 DataTable dt = _context.GetUsertsInDivision(_kuriID);
                  foreach (DataRow row in dt.AsEnumerable())
                 {

                     var index = dataGridViewAllUsers.Rows.Add();
                     dataGridViewAllUsers.Rows[index].Cells[0].Value = row["user_id"].ToString();
                     dataGridViewAllUsers.Rows[index].Cells[1].Value = false;
                     dataGridViewAllUsers.Rows[index].Cells[2].Value = row["name"].ToString();
                 }

             }
             catch (Exception ex)
             {
                 ErrorLog.WriteErrorLog(ex.ToString());
             }
         }
        private void buttonAddCallDetails_Click(object sender, EventArgs e)
        {
            panelAddCallDetails.Show();
        }

        private void buttonSaveCallDetails_Click(object sender, EventArgs e)
        {


            try
            {
                //check validation
                bool isvalid = true;
                if (isvalid)
                {
                    decimal auctionAmount = Convert.ToDecimal(txtAuctionAmount.Text);
                    decimal newTermAmount = Convert.ToDecimal(txtNewAmount.Text);
                    int userID = Convert.ToInt32(comboBoxAuctionUsers.SelectedValue);
                    DateTime auctionPaymentDate = dateTimePickerAuctionPaymenDate.Value;
                    _context.SaveKuriAuctionHistory(_auctionID, _kuriID, userID, auctionAmount, auctionPaymentDate, newTermAmount);
                    MessageBox.Show("Auction details saved successfully", "Info");
                    clearForm();
                    LoadKuriAuctionHistory();
                    panelAddCallDetails.Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonClosePanelAddCallDetails_Click(object sender, EventArgs e)
        {
            panelAddCallDetails.Hide();
        }

        private void buttonSaveCustomer_Click(object sender, EventArgs e)
        {
            //var index = dataGridViewUsers.Rows.Add();
            //dataGridViewUsers.Rows[index].Cells["Users"].Value = txtNewCustomer.Text;
            //txtNewCustomer.Text = "";

            try
            {
                List<int> checkedUsers = new List<int>();
                foreach (DataGridViewRow row in dataGridViewAllUsers.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value) == true)
                    {
                        checkedUsers.Add(Convert.ToInt32(row.Cells[0].Value));
                    }
                }
                if (checkedUsers.Count > 0)
                {
                    _context.AddUsersToKuri(checkedUsers, _kuriID);
                    MessageBox.Show("Users added successfully", "Info");
                    LoadKuriUsers();
                    panelAddCustomers.Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            panelAddCustomers.Show();
        }

        private void buttonPanelAddCustomerClose_Click(object sender, EventArgs e)
        {
            panelAddCustomers.Hide();
        }

        public void clearForm()
        {

            editRowIndex = 0;
            _auctionID = 0;
            txtAuctionAmount.Text = "";
            txtNewAmount.Text = "";
            dateTimePickerAuctionPaymenDate.Value = DateTime.Today.Date;
        }

        private void dataGridViewAuctionHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewAuctionHistory.ClearSelection();
        }

        private void dataGridViewAuctionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editRowIndex = e.RowIndex;
            _auctionID = Convert.ToInt32(this.dataGridViewAuctionHistory.Rows[e.RowIndex].Cells[1].Value);


            BindEditData();
        }

        public void BindEditData()
        {
            try
            {

                txtAuctionAmount.Text = dataGridViewAuctionHistory.Rows[editRowIndex].Cells[4].Value.ToString();
                int userID = Convert.ToInt32(dataGridViewAuctionHistory.Rows[editRowIndex].Cells[3].Value);
                comboBoxAuctionUsers.SelectedValue = userID;
                txtNewAmount.Text = dataGridViewAuctionHistory.Rows[editRowIndex].Cells[7].Value.ToString();
                dateTimePickerAuctionPaymenDate.Value = Convert.ToDateTime(dataGridViewAuctionHistory.Rows[editRowIndex].Cells[6].Value);
                panelAddCallDetails.Show();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }



        }

      
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewAuctionHistory_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewAuctionHistory.ClearSelection();
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                editRowIndex = e.RowIndex;
               int user_id = Convert.ToInt32(this.dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value);
                //panelDataGrid.Hide();
                //panelNew.Show();
                //BindEditData();
            }
        }
    }
}
