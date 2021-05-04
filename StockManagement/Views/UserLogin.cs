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

namespace StockManagement
{
    public partial class UserLogin : DevExpress.XtraEditors.XtraForm
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool login()
        {
            RestClient client = new RestClient(Properties.Resources.apiEndPoint+"auth/");
            RestRequest request = new RestRequest(Method.POST);
            Model.User Account = new Model.User
            {
                email = textBox1.Text,
                password = textBox2.Text
            };
            var userAccount = JsonConvert.SerializeObject(Account);
            request.AddParameter("application/json;charset=utf-8", userAccount, ParameterType.RequestBody);
            IRestResponse res = client.Execute(request);
            string token = "";
            try
            {
                token = JsonConvert.DeserializeObject<Model.GetToken>(res.Content).message;
            }
            catch
            {
                token = "";
            }
            if (token != "")
                return true;
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(login())
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
                textBox2.Clear();
                return;
            }
            textBox2.Clear();
            MessageBox.Show("email hoặc password không đúng");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}