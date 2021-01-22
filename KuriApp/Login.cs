using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPos.Forms;

namespace KuriApp
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "abcd" || txtPassword.Text == "1234")
            {

                Home _form = new Home();
                _form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password", "Info");
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                ApplicationSettings _settings = new ApplicationSettings();
                _settings.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplicationSettings _settings = new ApplicationSettings();
            _settings.Show();
        }
    }
}
