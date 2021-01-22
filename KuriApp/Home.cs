using KuriApp.Reports;
using KuriApp.Sub_forms;
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
    public partial class Home :Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            Users _form = new Users();
            _form.Show();
            //this.Hide();
        }

        private void buttonKuriPayments_Click(object sender, EventArgs e)
        {
            
            KuriPayments _form = new KuriPayments();
            _form.Show();
           
        }

        private void buttonKuriMaster_Click(object sender, EventArgs e)
        {
            KuriMasterForm _form = new KuriMasterForm();
            _form.Show();
        }

        private void buttonCustomerReport_Click(object sender, EventArgs e)
        {
            CustomerReport _form = new CustomerReport();
            _form.Show();
        }

        private void buttonCallReport_Click(object sender, EventArgs e)
        {
            AuctionHistory _form = new AuctionHistory();
            _form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void buttonAgents_Click(object sender, EventArgs e)
        {
            Agents f = new Agents();
            f.Show();
           // this.Hide();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonArea_Click(object sender, EventArgs e)
        {
            Area f = new Area();
            f.Show();
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            Division f = new Division();
            f.Show();
        }
    }
}
