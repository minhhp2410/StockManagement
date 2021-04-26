using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
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
    public partial class CreateStockinReceipt : DevExpress.XtraEditors.XtraForm
    {
        public string receiptID = "", quotationNumber = "", note = "";
        List<Model.DataInventory> inventories = new List<Model.DataInventory>();
        List<Model.ReceiptDetail> ReceiptDetails = new List<Model.ReceiptDetail>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.ReceiptDetail.insertStockinReceiptDetail(gridView1, "stockinreceiptdetails", textBox1.Text, textEdit1.Text, comboBoxEdit1.Text);
        }

        private void CreateStockinReceipt_Load(object sender, EventArgs e)
        {
            if (receiptID != "")
            {
                gridControl1.DataSource = Model.PlanDetail.getPlanList("stockinreceiptdetails", receiptID);
                groupControl1.Text = "thông tin chi tiết " + receiptID;
                this.Text = "thông tin chi tiết " + receiptID;
                button1.Enabled = false;
                simpleButton1.Enabled = false;
                textBox1.Text = note;
                textEdit1.Text = quotationNumber;
            }
            else
            {
                gridControl1.DataSource = new List<Model.ReceiptDetail>();
            }
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["planID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
            ComboBoxItemCollection collection = comboBoxEdit2.Properties.Items;
            inventories = Model.Inventory.getInventories();
            collection.AddRange(inventories.Select(s => s.partNumber + "-" + s.partName as object).ToArray());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text != "")
            {
                string partNumber = comboBoxEdit2.Text.Split('-')[0];
                Model.DataInventory data = inventories.Where(w => w.partNumber == partNumber).FirstOrDefault();
                ReceiptDetails.Add(new Model.ReceiptDetail
                {
                    partName = data.partName,
                    partNumber = data.partNumber,
                    position = data.position,
                    price = data.price,
                    quantity = 0,
                    currency = data.currency,
                    unit = data.unit
                });
                gridControl1.DataSource = ReceiptDetails;
                gridControl1.Update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReceiptDetails.Clear();
            string res = Model.RestSharpC.execCommand2("quotationitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadQuoationItem quoationItems = JsonConvert.DeserializeObject<JsonHeadQuoationItem>(res);
            quoationItems.Data.ToList().ForEach(i =>
            {
                ReceiptDetails.Add(new Model.ReceiptDetail()
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
            gridControl1.DataSource = ReceiptDetails;
            gridControl1.Update();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["receiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }

        public CreateStockinReceipt()
        {
            InitializeComponent();
        }
    }
}