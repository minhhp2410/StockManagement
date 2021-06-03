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
    public partial class FormCreateStockinPlan : DevExpress.XtraEditors.XtraForm
    {
        public string planID="",quotationNumber="",note="";
        public FormStockinPlan f = new FormStockinPlan();
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.PlanDetail> planDetails = new List<Model.PlanDetail>();
        public FormCreateStockinPlan()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.UserAction.insertStockinPlanDetail(gridView1, Properties.Settings.Default.stockinPlanDetailsPath, txtNote.Text, txtSearch.Text, cbbStore.Text);
            f.reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(cbbProduct.Text!= "")
            {
                string partNumber = cbbProduct.Text.Split('-')[0];
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
            string res = Model.UserAction.getQuotationItems(Properties.Settings.Default.quotationItemsPath, RestSharp.Method.GET, int.Parse(txtSearch.Text));
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
                gridControl1.DataSource = Model.UserAction.getPlanList(Properties.Settings.Default.stockinPlanDetailsPath, planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text= "thông tin chi tiết " + planID;
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
                txtNote.Text = note;
                txtSearch.Text = quotationNumber;
            }
            else
            {
                gridControl1.DataSource = new List<Model.PlanDetail>();
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            ComboBoxItemCollection collection = cbbProduct.Properties.Items;
            inventories = Model.UserAction.getInventories();
            collection.AddRange(inventories.Select(s=> s.partNumber+"-"+s.partName as object).ToArray());
        }
    }
}