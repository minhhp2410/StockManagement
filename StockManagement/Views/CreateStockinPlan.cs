using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
using RestSharp;
using StockManagement.Model;
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
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.PlanDetail> planDetails = new List<Model.PlanDetail>();
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(comboBoxEdit2.Text!= "")
            {
                string partNumber = comboBoxEdit2.Text.Split('-')[0];
                Model.DataInventory data = inventories.Where(w => w.partNumber == partNumber).FirstOrDefault();
                List<Model.PlanDetail> planDetailss = new List<Model.PlanDetail>();
                planDetailss.AddRange(planDetails.ToArray());
                if (planDetails.FindIndex(a => a.partNumber == data.partNumber) < 0)
                {

                    planDetailss.Add(new Model.PlanDetail
                    {
                        partName = data.partName,
                        partNumber = data.partNumber,
                        position = data.position,
                        price = data.price,
                        quantity = 0,
                        currency = data.currency,
                        unit = data.unit
                    });
                    gridControl1.DataSource = planDetailss;
                    planDetails.Clear();
                    planDetails.AddRange(planDetailss.ToArray());
                    return;
                }
                MessageBox.Show("Săn phẩm đã tồn tại");
            }    
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Delete)
            {
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                planDetails.Remove(row as PlanDetail);
            }    
        }


        private void button1_Click(object sender, EventArgs e)
        {
            planDetails = new List<Model.PlanDetail>();
            string res = Model.RestSharpC.execCommand2("quotationitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadQuoationItem quoationItems = JsonConvert.DeserializeObject<JsonHeadQuoationItem>(res);
            
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
            if (planID!="")
            {
                gridControl1.DataSource = Model.PlanDetail.getPlanList("stockinplandetails", planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text= "thông tin chi tiết " + planID;
                button1.Enabled = false;
                simpleButton1.Enabled = false;
                textBox1.Text = note;
                textEdit1.Text = quotationNumber;
            }
            else
            {
                gridControl1.DataSource = new List<Model.PlanDetail>();
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            ComboBoxItemCollection collection = comboBoxEdit2.Properties.Items;
            inventories = Model.Inventory.getInventories();
            collection.AddRange(inventories.Select(s=> s.partNumber+"-"+s.partName as object).ToArray());
        }
    }
}