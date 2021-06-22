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
        public FormStockinPlan f = new FormStockinPlan();
        public string planID = "", quotationNumber = "", note = "";
        //List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        //Services.InventoryServices inventoryServices = new Services.InventoryServices();
        List<Model.StockinPlanDetail> planDetails = new List<Model.StockinPlanDetail>();
        Services.QuotationItemsServices quotationItemsServices = new Services.QuotationItemsServices();
        Services.StockinPlanDetailServices stockinPlanDetailServices = new Services.StockinPlanDetailServices();
        Services.StockinPlanServices stockinPlanServices = new Services.StockinPlanServices();
        public FormCreateStockinPlan()
        {
            InitializeComponent();
        }

        void removeUnuseInfo()
        {
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            planDetails = new List<Model.StockinPlanDetail>();
            var items = quotationItemsServices._getQuotationItems(txtSearch.Text);

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
            removeUnuseInfo();


        }

        private void CreateStockinPlan_Load(object sender, EventArgs e)
        {
            if (planID != "")
            {
                gridControl1.DataSource = stockinPlanDetailServices._getStockinPlanDetail(planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text = "thông tin chi tiết " + planID;
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                gridControl1.DataSource = new List<Model.StockinPlanDetail>();
            }
            removeUnuseInfo();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                planDetails.Remove(row as Model.StockinPlanDetail);
            }
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Model.StockinPlanDetail> planDetails2 = new List<Model.StockinPlanDetail>();
            Model.StockinPlanDatum stockinPlan = new StockinPlanDatum()
            {
                isDeleted = false,
                isImported= false,
                Note = txtNote.Text,
                QuotationNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy= "",
                PlanNumber=txtPlanNumber.Text,
                UpdatedAt=null,
                StockinPlanDetails=null,
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
    }
}