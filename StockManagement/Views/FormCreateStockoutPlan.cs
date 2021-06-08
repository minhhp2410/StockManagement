using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
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
using StockManagement.Services;

namespace StockManagement.Views
{
    public partial class FormCreateStockoutPlan : DevExpress.XtraEditors.XtraForm
    {
        public string note = "", planID = "", poNumber = "";
        public FormStockoutPlan f = new FormStockoutPlan();
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.StockoutPlanDetail> planDetails = new List<StockoutPlanDetail>();
        StockoutPlanServices stockoutPlanServices = new StockoutPlanServices();
        StockoutPlanDetailServices stockoutPlanDetailServices = new StockoutPlanDetailServices();
        InventoryServices inventoryServices = new InventoryServices();
        PoItemsServices poItemsServices = new PoItemsServices();
        public FormCreateStockoutPlan()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            planDetails.Clear();
            Model.StockoutPlanDatum stockoutPlan = new StockoutPlanDatum()
            {
                isDeleted = false,
                Note = txtNote.Text,
                poNumber = txtSearch.Text,
                Store = cbbStore.Text
            };
            stockoutPlan = stockoutPlanServices._addStockoutPlan(stockoutPlan);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Model.StockoutPlanDetail;
                row.PlanID = stockoutPlan.Id;
                planDetails.Add(row);
            }
            var res = stockoutPlanDetailServices._addStockoutPlanDetail(planDetails);
            if (res.Count > 0)
                f.reLoad();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (cbbProduct.Text != "")
            {
                //string partNumber = cbbProduct.Text.Split('-')[0];
                //Model.DataInventory data = inventories.Where(w => w.partNumber == partNumber).FirstOrDefault();
                //List<Model.PlanDetail> planDetailss = new List<Model.PlanDetail>();
                //planDetailss.AddRange(planDetails.ToArray());
                //if (planDetails.FindIndex(a => a.partNumber == data.partNumber) < 0)
                //{

                //    planDetailss.Add(new Model.PlanDetail
                //    {
                //        partName = data.partName,
                //        partNumber = data.partNumber,
                //        position = data.position,
                //        price = data.price,
                //        quantity = 0,
                //        currency = data.currency,
                //        unit = data.unit
                //    });
                //    gridControl1.DataSource = planDetailss;
                //    planDetails.Clear();
                //    planDetails.AddRange(planDetailss.ToArray());
                //    return;
                //}
                //MessageBox.Show("Săn phẩm đã tồn tại");
            }
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

        private void button1_Click(object sender, EventArgs e)
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
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
            ComboBoxItemCollection collection = cbbProduct.Properties.Items;
            inventories = inventoryServices._getInventoryItems();
            if (inventories != null && inventories.Count > 0)
                collection.AddRange(inventories.Select(s => s.partNumber + "-" + s.partName as object).ToArray());
        }
    }
}