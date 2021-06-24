using DevExpress.XtraEditors.Controls;
using StockManagement.Model;
using StockManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class FormCreateStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        public FormStockoutPlan f = new FormStockoutPlan();
        public string note = "", planID = "", poNumber = "";
        //private List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        //private InventoryServices inventoryServices = new InventoryServices();
        private List<Model.StockoutPlanDetail> planDetails = new List<StockoutPlanDetail>();
        private PoItemsServices poItemsServices = new PoItemsServices();
        private StockoutPlanDetailServices stockoutPlanDetailServices = new StockoutPlanDetailServices();
        private StockoutPlanServices stockoutPlanServices = new StockoutPlanServices();
        public FormCreateStockoutPlan()
        {
            InitializeComponent();
        }

        bool insertDetail(List<Model.StockoutPlanDetail> detail)
        {
            try
            {
                detail.ForEach(rec => {
                    stockoutPlanDetailServices._addStockoutPlanDetail(rec);
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        void removeUnuseInfo()
        {
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }

        private void CreateStockoutPlan_Load(object sender, EventArgs e)
        {
            if (planID != "")
            {
                gridControl1.DataSource = stockoutPlanDetailServices._getStockoutPlanDetail(planID);
                groupControl1.Text = "thông tin chi tiết " + planID;
                this.Text = "thông tin chi tiết " + planID;
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                gridControl1.DataSource = new List<Model.StockoutPlanDetail>();
            }
            removeUnuseInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            planDetails = new List<Model.StockoutPlanDetail>();
            var items = poItemsServices._getPOItems(txtSearch.Text);

            items.ForEach(i =>
            {
                planDetails.Add(new Model.StockoutPlanDetail
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Model.StockoutPlanDetail> planDetails2 = new List<Model.StockoutPlanDetail>();
            Model.StockoutPlanDatum stockoutPlan = new StockoutPlanDatum()
            {
                isDeleted = false,
                isImported=false,
                Note = txtNote.Text,
                poNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy = "",
                PlanNumber = txtPlanNumber.Text,
                UpdatedAt = null,
                StockoutPlanDetails = null
            };
            stockoutPlan = stockoutPlanServices._addStockoutPlan(stockoutPlan);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Model.StockoutPlanDetail;
                row.PlanID = (int)stockoutPlan.Id;
                planDetails2.Add(row);
            }
            if (insertDetail(planDetails2))
                f.reLoad();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                planDetails.Remove(row as Model.StockoutPlanDetail);
            }
        }
    }
}