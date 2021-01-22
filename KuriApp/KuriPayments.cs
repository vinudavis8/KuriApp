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
    public partial class KuriPayments : MetroFramework.Forms.MetroForm
    {
        DALKuri _context;
        long _id;
        int editRowIndex = 0;
        public KuriPayments()
        {
            InitializeComponent();
            BindComboBoxDivision();
            BindComboBoxAgents();
           
        }
        public void loadUserSummaryData(int KuriID,int userID)
        {
            string totalPaid="";
            string paymentAmount="";
            decimal amount_tobe_paid = 0;
            decimal received_amount = 0;
            decimal totalDueues = 0;
            DataSet dt = _context.GetKuriUserSummary(KuriID, userID);
            if (dt.Tables[0].Rows.Count > 0)
            {
                 paymentAmount = dt.Tables[0].Rows[0][0].ToString();
            }
            if (dt.Tables[1].Rows.Count > 0)
            {
                 totalPaid = dt.Tables[1].Rows[0][0].ToString();
            }
            labelCurrentKuriAmount.Text = paymentAmount;
            labelTotalReceived.Text = totalPaid;
            //if (dt.Tables[2].Rows.Count > 0)
            //{
            //     amount_tobe_paid = dt.Tables[2].AsEnumerable().Sum(x => x.Field<decimal>("amount_tobe_paid"));
            //     received_amount = dt.Tables[2].AsEnumerable().Sum(x => x.Field<decimal>("received_amount"));
            
            //}
            //if (received_amount < amount_tobe_paid)
            //{
            //    totalDueues = amount_tobe_paid - received_amount;
            //    labeTotalDues.Text = totalDueues.ToString();
            //}
        }
        public void BindComboBoxAgents()
        {
            try
            {
                DALUsers _users = new DALUsers();
                DataTable dtCategory = _users.GetAgents();
                if (dtCategory.Rows.Count > 0)
                {
                    comboBoxAgents.DataSource = dtCategory;
                    comboBoxAgents.DisplayMember = "name";
                    comboBoxAgents.ValueMember = "agent_id";
                    comboBoxAgents.SelectedIndex = -1;
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
        public void GetUsertsInKuri(int kuriID)
        {
            try
            {
                _context = new DALKuri();
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

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
      
            try
            {
                if (isvalid())
                {

                    int division =Convert.ToInt32( comboBoxDivision.SelectedValue );
                    int kuri = Convert.ToInt32(comboBoxKuri.SelectedValue);
                    int user = Convert.ToInt32(comboBoxUsers.SelectedValue);
                    int agent = Convert.ToInt32(comboBoxAgents.SelectedValue);
                    decimal paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                    DateTime paymentDate = dateTimePickerPaymentDate.Value;
                    var result = _context.SaveKuripayments(division, kuri, user, agent, paidAmount, paymentDate, _id);

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Payment Saved Successfully", "Success");
                        ClearForm();
                        LoadPaymentHistory(user, kuri);
                    }
                    else
                        MessageBox.Show("Payment Failed", "Warning");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed", "Warning");
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void LoadPaymentHistory(int userID,int kuriID)
        {
            try
            {
                _context = new DALKuri();
                dataGridViewPaymentHistory.DataSource = null;
                dataGridViewPaymentHistory.Rows.Clear();

                DataTable dt = _context.GetKuriPaymentsByUser(userID, kuriID);
                dataGridViewPaymentHistory.DataSource = dt;
                dataGridViewPaymentHistory.Columns[0].Visible = false;
                dataGridViewPaymentHistory.Columns[1].Visible = false;
                dataGridViewPaymentHistory.Columns[2].Visible = false;
                dataGridViewPaymentHistory.Columns[3].Visible = false;
                 dataGridViewPaymentHistory.Columns[4].Visible = false;


                 dataGridViewPaymentHistory.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                 dataGridViewPaymentHistory.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridViewPaymentHistory.Columns[5].HeaderText = "Amount";
                dataGridViewPaymentHistory.Columns[6].HeaderText = "Payment Date";


            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        public void ClearForm()
        {
            _id = 0;
            editRowIndex = 0;
            dateTimePickerPaymentDate.Value = DateTime.Today.Date;
            comboBoxDivision.SelectedIndex = -1;
            comboBoxKuri.SelectedIndex = -1;
            comboBoxUsers.SelectedIndex = -1;
            comboBoxAgents.SelectedIndex = -1;

            decimal paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
            DateTime paymentDate = dateTimePickerPaymentDate.Value;
            txtUserName.Text = "";
            labelCurrentKuriAmount.Text = "";
            labelTotalReceived.Text = "";
            labeTotalDues.Text = "";
            txtPaidAmount.Text = "";
        }
        public bool isvalid()
        {
            bool isvalid = true;
            try
            {
                if (string.IsNullOrEmpty(txtPaidAmount.Text) || comboBoxDivision.SelectedIndex == -1 || comboBoxKuri.SelectedIndex == -1 || comboBoxUsers.SelectedIndex == -1 || comboBoxAgents.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter required fields", "Warning");
                    isvalid = false;
                }
                if (!string.IsNullOrEmpty(labelCurrentKuriAmount.Text))
                {
                    if (Convert.ToDecimal(txtPaidAmount.Text) < Convert.ToDecimal(labelCurrentKuriAmount.Text))
                    {
                        MessageBox.Show("amount is less than actual amount to be Paid", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isvalid = false;
                    }
                    else
                    {
                        var confirmResult = MessageBox.Show("amount is greater  than actual amount to be Paid, click OK to Proceed..!!",
                                         "Confirm to proceed!!",
                                         MessageBoxButtons.OKCancel);
                        if (confirmResult != DialogResult.OK)
                        {
                            isvalid = false;
                        }
                    }
                }
            }
                
            catch (Exception ex)
            {
                throw ex;
            }
            return isvalid;
        }
        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                int divisionID=Convert.ToInt32(comboBoxDivision.SelectedValue);
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
                txtUserName.Text = "";
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                 try
            {
                int kuriID = Convert.ToInt32(comboBoxKuri.SelectedValue);
                int userID = Convert.ToInt32(comboBoxUsers.SelectedValue);
                LoadPaymentHistory(userID, kuriID);
              
               
                loadUserSummaryData(kuriID, userID);

             string kuriUserName=   _context.GetKuriUserName(userID, kuriID);
             txtUserName.Text = kuriUserName;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog(ex.ToString());
            }
        }

        private void dataGridViewPaymentHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewPaymentHistory.ClearSelection();
        }

        private void KuriPayments_Load(object sender, EventArgs e)
        {

        }

        private void labeTotalDues_Click(object sender, EventArgs e)
        {

        }
    }
}
