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
        List<Model.StockinPlanDetail> planDetails = new List<Model.StockinPlanDetail>();
        Services.QuotationItemsServices quotationItemsServices = new Services.QuotationItemsServices();
        Services.StockinPlanServices stockinPlanServices = new Services.StockinPlanServices();
        Services.InventoryServices inventoryServices = new Services.InventoryServices();
        Services.StockinPlanDetailServices stockinPlanDetailServices = new Services.StockinPlanDetailServices();
        public FormCreateStockinPlan()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Model.StockinPlanDetail> planDetails2 = new List<Model.StockinPlanDetail>();
            Model.StockinPlanDatum stockinPlan = new StockinPlanDatum()
            {
                isDeleted = false,
                Note = txtNote.Text,
                QuotationNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy= "",
                PlanNumber="",
                UpdatedAt=null,
                StockinPlanDetails=null
            };
            stockinPlan=stockinPlanServices._addStockinPlan(stockinPlan);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Model.StockinPlanDetail;
                row.PlanID = (int)stockinPlan.Id;
                planDetails2.Add(row);
            }
            var res= stockinPlanDetailServices._addStockinPlanDetail(planDetails);
            if(res.Count>0)
            f.reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(cbbProduct.Text!= "")
            {
                //    string partNumber = cbbProduct.Text.Split('-')[0];
                //    Model.DataInventory data = inventories.Where(w => w.partNumber == partNumber).FirstOrDefault();
                //    List<Model.PlanDetail> planDetailss = new List<Model.PlanDetail>();
                //    planDetailss.AddRange(planDetails.ToArray());
                //    if (planDetails.FindIndex(a => a.partNumber == data.partNumber) < 0)
                //    {

                //        planDetailss.Add(new Model.PlanDetail
                //        {
                //            partName = data.partName,
                //            partNumber = data.partNumber,
                //            position = data.position,
                //            price = data.price,
                //            quantity = 0,
                //            currency = data.currency,
                //            unit = data.unit
                //        });
                //        gridControl1.DataSource = planDetailss;
                //        planDetails.Clear();
                //        planDetails.AddRange(planDetailss.ToArray());
                //        return;
                //    }
                //    MessageBox.Show("Săn phẩm đã tồn tại");
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Delete)
            {
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                planDetails.Remove(row as Model.StockinPlanDetail);
            }    
        }


        private void button1_Click(object sender, EventArgs e)
        {
            planDetails = new List<Model.StockinPlanDetail>();
            var items=quotationItemsServices._getQuotationItems(txtSearch.Text);

            items.ForEach(i =>
            {
                planDetails.Add(new Model.StockinPlanDetail
                {
                    PartNumber = i.PartNumber,
                    PartName = i.PartName,
                    Currency = i.Currency,
                    Price = i.UnitPrice,
                    Quantity = i.Quantity,
                    Unit = "",
                    Position = cbbStore.Text
                });
            });

            gridControl1.DataSource = planDetails;
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);


        }

        private void CreateStockinPlan_Load(object sender, EventArgs e)
        {
            if (planID!="")
            {
                gridControl1.DataSource = stockinPlanDetailServices._getStockinPlanDetail(planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text= "thông tin chi tiết " + planID;
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                gridControl1.DataSource = new List<Model.StockinPlanDetail>();
            }
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
            ComboBoxItemCollection collection = cbbProduct.Properties.Items;
            inventories = inventoryServices._getInventoryItems();
            if(inventories!=null && inventories.Count>0)
            collection.AddRange(inventories.Select(s=> s.partNumber+"-"+s.partName as object).ToArray());
        }
    }
}