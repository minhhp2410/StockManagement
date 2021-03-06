using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using StockManagement.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using StockManagement.Views;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using StockManagement.Properties;

namespace StockManagement
{
    public partial class FormHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //private String URL = "http://localhost:8000/api/v1/";
        

       Form currentForm = new Form(); 

        public FormHome()
        {
            InitializeComponent();
        }
        #region user defined function
        //private string execCommand(string source, Method method)
        //{
        //    RestClient client = new RestClient(URL);
        //    RestRequest request = new RestRequest(source, method);
        //    IRestResponse response = client.Execute(request);
        //    request.RequestFormat = DataFormat.Json;// Execute the Request
        //    string content = response.Content;
        //    return content;
        //}
       public void openForm(Form f)
        {
            foreach (Form i in Application.OpenForms)
            {
                if (i.GetType() == f.GetType())
                    return;
            }
            if(currentForm!= null)
            {
                currentForm.Close();
            }    
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            panelControl1.Controls.Add(f);
            currentForm = f;
            f.Show();
        }
        #endregion
        void rolesToUI()
        {
            bool planUI = Settings.Default.roles.Contains(Settings.Default.stock);
            bool stockUI= Settings.Default.roles.Contains(Settings.Default.sale);
            ribbonPageGroup1.Visible = planUI;
            btnStockin.Visibility = btnStockout.Visibility = stockUI==true? BarItemVisibility.Always:BarItemVisibility.Never ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rolesToUI();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(new FormInventory());
        }

        private void btnStockinPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new FormStockinPlan());
        }

        private void btnStockoutPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new FormStockoutPlan());
        }

        private void btnStockinReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new FormStockin());
        }

        private void btnStockoutReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new FormStockout());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất", "Nhắc", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Settings.Default.token = "";
                Settings.Default.Save();
                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(UserLogin))
                        f.Show();
                }
            }
        }
    }
}
