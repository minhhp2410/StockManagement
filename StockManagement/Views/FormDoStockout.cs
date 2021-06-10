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
    public partial class FormDoStockout : DevExpress.XtraEditors.XtraForm
    {
        public string receiptID = "", poNumber = "", note = "";
        public FormStockout f = new FormStockout();
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.StockoutReceiptDetail> receiptDetails = new List<Model.StockoutReceiptDetail>();
        PoItemsServices poItemsServices = new PoItemsServices();
        Services.StockoutReceiptDetailServices stockoutReceiptDetailServices = new Services.StockoutReceiptDetailServices();
        Services.StockoutReceiptServices stockoutReceiptServices = new Services.StockoutReceiptServices();
        Services.StockoutPlanDetailServices stockoutPlanDetailServices = new Services.StockoutPlanDetailServices();
        public FormDoStockout()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Model.StockoutReceiptDetail> ReceiptDetails2 = new List<Model.StockoutReceiptDetail>();
            Model.StockoutReceiptDatum stockoutReceipt = new StockoutReceiptDatum()
            {
                isDeleted = false,
                Note = txtNote.Text,
                PoNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy = "",
                ReceiptNumber = "",
                UpdatedAt = null,
                StockoutReceiptDetails = null
            };
            stockoutReceipt = stockoutReceiptServices._addStockoutReceipt(stockoutReceipt);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Model.StockoutReceiptDetail;
                row.ReceiptID = (int)stockoutReceipt.Id;
                ReceiptDetails2.Add(row);
            }
            var res = stockoutReceiptDetailServices._addStockoutReceiptDetail(receiptDetails);
            if (res.Count > 0)
                f.reLoad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void CreateStockoutReceipt_Load(object sender, EventArgs e)
        {
            if (receiptID != "")
            {
                //gridControl1.DataSource = Model.UserAction.getReceiptList(Properties.Settings.Default.stockoutReceiptDetailsPath, receiptID);
                //groupControl1.Text = "thông tin chi tiết " + receiptID;
                //this.Text = "thông tin chi tiết " + receiptID;
                //btnSearch.Enabled = false;
                //btnSave.Enabled = false;
                //txtNote.Text = note;
                //txtSearch.Text = poNumber;
            }
            else
            {
                //gridControl1.DataSource = new List<Model.ReceiptDetail>();
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["receiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName != "actualQty")
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                }
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //object row = gridView1.GetFocusedRow();
                //gridView1.DeleteRow(gridView1.FindRow(row));
                //receiptDetails.Remove(row as ReceiptDetail);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receiptDetails = new List<StockoutReceiptDetail>();
            if (txtSearch.Text.ToUpper().Contains("KHX"))
            {
                var items = stockoutPlanDetailServices._getStockoutPlanDetail(txtSearch.Text.ToUpper());
                items.ForEach(i =>
                {
                    receiptDetails.Add(new Model.StockoutReceiptDetail
                    {
                        Currency = i.Currency,
                        PartName = i.PartName,
                        PartNumber = i.PartNumber,
                        Position = "",
                        Price = (int)i.Price,
                        Quantity = (int)i.Quantity,
                        Unit = i.Unit,
                    });
                });
            }
            else
            {
                var items = poItemsServices._getPOItems(txtSearch.Text.ToUpper());
                items.ForEach(i =>
                {
                    receiptDetails.Add(new Model.StockoutReceiptDetail
                    {
                        Currency = i.Currency,
                        PartName = i.PartName,
                        PartNumber = i.PartNumber,
                        Position = "",
                        Price = i.UnitPrice,
                        Quantity = i.Quantity,
                        Unit = ""
                    });
                });
            }
            gridControl1.DataSource = receiptDetails;
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["ReceiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }

    }
}