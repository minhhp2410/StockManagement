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

namespace StockManagement.Views
{
    public partial class FormDoStockout : DevExpress.XtraEditors.XtraForm
    {
        public string receiptID = "", poNumber = "", note = "";
        public FormStockout f = new FormStockout();
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.ReceiptDetail> receiptDetails = new List<Model.ReceiptDetail>();
        public FormDoStockout()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.ReceiptDetail.insertStockoutReceiptDetail(gridView1, "stockoutreceiptdetails", txtNote.Text, txtSearch.Text, cbbStore.Text);
            f.reLoad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void CreateStockoutReceipt_Load(object sender, EventArgs e)
        {
            if (receiptID != "")
            {
                gridControl1.DataSource = Model.ReceiptDetail.getReceiptList("stockoutreceiptdetails", receiptID);
                groupControl1.Text = "thông tin chi tiết " + receiptID;
                this.Text = "thông tin chi tiết " + receiptID;
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
                txtNote.Text = note;
                txtSearch.Text = poNumber;
            }
            else
            {
                gridControl1.DataSource = new List<Model.ReceiptDetail>();
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
                object row = gridView1.GetFocusedRow();
                gridView1.DeleteRow(gridView1.FindRow(row));
                receiptDetails.Remove(row as ReceiptDetail);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receiptDetails = new List<ReceiptDetail>();
            if (!txtSearch.Text.Contains("KHX"))
            {
                string res = Model.RestSharpC.execCommand5("poitems", RestSharp.Method.GET, int.Parse(txtSearch.Text));
                JsonHeadQuoationItem quoationItems = JsonConvert.DeserializeObject<JsonHeadQuoationItem>(res);
                quoationItems.Data.ToList().ForEach(i =>
                {
                    receiptDetails.Add(new Model.ReceiptDetail()
                    {
                        partNumber = i.PartNumber,
                        partName = i.PartName,
                        position = i.Position,
                        price = i.UnitPrice,
                        currency = i.Currency,
                        quantity = i.Quantity,
                        unit = i.Unit
                    });
                });
                gridControl1.DataSource = receiptDetails;
                gridControl1.Update();
            }
            else
            {
                List<ReceiptDetail> Items = ReceiptDetail.getReceiptList("stockoutplandetails", txtSearch.Text);
                Items.ForEach(i =>
                {
                    receiptDetails.Add(new Model.ReceiptDetail()
                    {
                        partNumber = i.partNumber,
                        partName = i.partName,
                        position = i.position,
                        price = i.price,
                        currency = i.currency,
                        quantity = i.quantity,
                        unit = i.unit
                    });
                });
                gridControl1.DataSource = receiptDetails;
                gridControl1.Update();
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["receiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }

    }
}