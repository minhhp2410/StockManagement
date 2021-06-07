using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RestSharp;
using Newtonsoft.Json;
using StockManagement.Properties;

namespace StockManagement
{
    public partial class UserLogin : DevExpress.XtraEditors.XtraForm
    {
        FormHome home = new FormHome();
        Services.AuthServices auth = new Services.AuthServices();
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Model.User user = new Model.User()
            {
                email = txtID.Text,
                password = txtPassword.Text
            };
            if(auth._login(user))
            {
                try
                {
                    home.Show();
                    this.Hide();
                    txtPassword.Clear();
                    return;
                }
                catch (Exception)
                {
                    home = new FormHome();
                    home.Show();
                    this.Hide();
                    txtPassword.Clear();
                    return;
                }
            }
            txtPassword.Clear();
            MessageBox.Show("email hoặc password không đúng");
            txtID.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("User name trống");
                }
                else
                    txtPassword.Select();
            }    
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password trống");
                }
                else
                    btnLogin.PerformClick();
            }
        }
    }
}