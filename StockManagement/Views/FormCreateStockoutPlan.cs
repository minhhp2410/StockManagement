﻿using DevExpress.XtraEditors.Controls;
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
        private List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        private InventoryServices inventoryServices = new InventoryServices();
        private List<Model.StockoutPlanDetail> planDetails = new List<StockoutPlanDetail>();
        private PoItemsServices poItemsServices = new PoItemsServices();
        private StockoutPlanDetailServices stockoutPlanDetailServices = new StockoutPlanDetailServices();
        private StockoutPlanServices stockoutPlanServices = new StockoutPlanServices();
        public FormCreateStockoutPlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            //ComboBoxItemCollection collection = cbbProduct.Properties.Items;
            //inventories = inventoryServices._getInventoryItems();
            //if (inventories != null && inventories.Count > 0)
            //    collection.AddRange(inventories.Select(s => s.partNumber + "-" + s.partName as object).ToArray());
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (cbbProduct.Text != "")
            //{
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
            //}
        }
    }
}