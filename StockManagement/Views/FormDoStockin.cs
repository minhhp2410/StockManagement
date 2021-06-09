using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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

namespace StockManagement.Views
{
    public partial class FormDoStockin : DevExpress.XtraEditors.XtraForm
    {
        public FormStockin f = new FormStockin();
        public string receiptID = "", quotationNumber = "", note = "";
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        Services.QuotationItemsServices quotationItemsServices = new Services.QuotationItemsServices();
        List<Model.StockinReceiptDetail> ReceiptDetails = new List<Model.StockinReceiptDetail>();
        Services.StockinReceiptDetailServices stockinReceiptDetailServices = new Services.StockinReceiptDetailServices();
        Services.StockinReceiptServices stockinReceiptServices = new Services.StockinReceiptServices();
        Services.StockinPlanDetailServices stockinPlanDetailServices = new Services.StockinPlanDetailServices();
        public FormDoStockin()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //string res = Model.UserAction.getBarcodeItems("13/05/2021");
            //Barcode BarcodeItems = JsonConvert.DeserializeObject<Barcode>(res);
            //BarcodeItems.data.ForEach(i =>
            //{
            //    Model.UserAction.updateBarcodeStatus(i);
            //});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReceiptDetails= new List<StockinReceiptDetail>();
            if(txtSearch.Text.ToUpper().Contains("KHN"))
            {
                var items = stockinPlanDetailServices._getStockinPlanDetail(txtSearch.Text.ToUpper());
                items.ForEach(i =>
                {
                    ReceiptDetails.Add(new Model.StockinReceiptDetail
                    {
                        Currency = i.Currency,
                        PartName=i.PartName,
                        PartNumber=i.PartNumber,
                        Position="",
                        Price=(int)i.Price,
                        Quantity=(int)i.Quantity,
                        Unit=i.Unit,
                    });
                });
            }
            else
            {
                var items = quotationItemsServices._getQuotationItems(txtSearch.Text.ToUpper());
                items.ForEach(i =>
                {
                    ReceiptDetails.Add(new Model.StockinReceiptDetail
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
            gridControl1.DataSource = ReceiptDetails;
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["ReceiptId"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }

        private void CreateStockinReceipt_Load(object sender, EventArgs e)
        {
            //if (receiptID != "")
            //{
            //    gridControl1.DataSource = Model.UserAction.getPlanList(Properties.Settings.Default.stockinReceiptDetailsPath, receiptID);
            //    groupControl1.Text = "thông tin chi tiết " + receiptID;
            //    this.Text = "thông tin chi tiết " + receiptID;
            //    btnSearch.Enabled = false;
            //    btnSave.Enabled = false;
            //    txtNote.Text = note;
            //    txtSearch.Text = quotationNumber;
            //}
            //else
            //{
            //    gridControl1.DataSource = new List<Model.ReceiptDetail>();
            //}
            //gridView1.Columns.Remove(gridView1.Columns["id"]);
            //gridView1.Columns.Remove(gridView1.Columns["receiptID"]);
            //gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            //gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            //for(int i=0;i<gridView1.Columns.Count;i++)
            //{
            //    if(gridView1.Columns[i].FieldName!="actualQty")
            //    {
            //        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            //    }    
            //}
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //object row = gridView1.GetFocusedRow();
                //gridView1.DeleteRow(gridView1.FindRow(row));
                //ReceiptDetails.Remove(row as ReceiptDetail);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Model.StockinReceiptDetail> ReceiptDetails2 = new List<Model.StockinReceiptDetail>();
            Model.StockinReceiptDatum stockinReceipt = new StockinReceiptDatum()
            {
                isDeleted = false,
                Note = txtNote.Text,
                QuotationNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy = "",
                ReceiptNumber = "",
                UpdatedAt = null,
                StockinReceiptDetails = null
            };
            stockinReceipt = stockinReceiptServices._addStockinReceipt(stockinReceipt);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Model.StockinReceiptDetail;
                row.ReceiptID = (int)stockinReceipt.Id;
                ReceiptDetails2.Add(row);
            }
            var res = stockinReceiptDetailServices._addStockinReceiptDetail(ReceiptDetails);
            if (res.Count > 0)
                f.reLoad();
        }
    }
}