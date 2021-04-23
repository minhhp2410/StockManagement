using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class CreateStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        public string note = "", planID = "", poNumber = "";
        public CreateStockoutPlan()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.PlanDetail.insertStockoutPlanDetail(gridView1, "stockoutplandetails", textBox1.Text, textEdit1.Text, comboBoxEdit1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Model.RestSharpC.execCommand5("poitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadPOItem poItems = JsonConvert.DeserializeObject<JsonHeadPOItem>(res);
            List<Model.PlanDetail> planDetails = new List<Model.PlanDetail>();
            poItems.Data.ToList().ForEach(i =>
            {
                planDetails.Add(new Model.PlanDetail()
                {
                    partNumber = i.PartNumber,
                    partName = i.PartName,
                    position = i.Position,
                    price = i.UnitPrice,
                    currency = i.Currency,
                    quantity = i.Quantity,
                    unit = i.Unit
                });
            });
            gridControl1.DataSource = planDetails;
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            gridControl1.DataSource = planDetails;
        }

        private void CreateStockoutPlan_Load(object sender, EventArgs e)
        {
            if (planID != "")
            {
                gridControl1.DataSource = Model.PlanDetail.getPlanList("stockoutplandetails", planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text = "thông tin chi tiết " + planID;
                button1.Enabled = false;
                simpleButton1.Enabled = false;
                textBox1.Text = note;
                textEdit1.Text = poNumber;
            }
        }
    }
}