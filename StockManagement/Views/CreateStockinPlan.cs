using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class CreateStockinPlan : DevExpress.XtraEditors.XtraForm
    {
        public string planID="",quotationNumber="",note="";

        public CreateStockinPlan()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.PlanDetail.insertStockinPlanDetail(gridView1, "stockinplandetails", textBox1.Text, textEdit1.Text, comboBoxEdit1.Text);
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Model.RestSharpC.execCommand2("quotationitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadQuoationItem quoationItems = JsonConvert.DeserializeObject<JsonHeadQuoationItem>(res);
            List<Model.PlanDetail> planDetails = new List<Model.PlanDetail>();
            quoationItems.Data.ToList().ForEach(i =>
            {
                planDetails.Add(new Model.PlanDetail() { 
                    partNumber=i.PartNumber,
                    partName=i.PartName,
                    position=i.Position,
                    price= i.UnitPrice,
                    currency=i.Currency,
                    quantity= i.Quantity,
                    unit=i.Unit
                });
            });
            gridControl1.DataSource = planDetails;
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]); 
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);


        }

        private void CreateStockinPlan_Load(object sender, EventArgs e)
        {
            if(planID!="")
            {
                gridControl1.DataSource = Model.PlanDetail.getPlanList("stockinplandetails", planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text= "thông tin chi tiết " + planID;
                button1.Enabled = false;
                simpleButton1.Enabled = false;
                textBox1.Text = note;
                textEdit1.Text = quotationNumber;
            }    
        }
    }
}