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
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //if(Model.UserAction.login(txtID.Text,txtPassword.Text))
            //{
            //    try
            //    {
            //        home.Show();
            //        this.Hide();
            //        txtPassword.Clear();
            //        return;
            //    }
            //    catch (Exception)
            //    {
            //        home = new FormHome();
            //        home.Show();
            //        this.Hide();
            //        txtPassword.Clear();
            //        return;
            //    }
                
            //}
            //txtPassword.Clear();
            //MessageBox.Show("email hoặc password không đúng");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            Services.QuotationItemsServices quotationItemsServices = new Services.QuotationItemsServices();
            var res = quotationItemsServices.getQuotationItems("QUO000001");
        }
    }
}