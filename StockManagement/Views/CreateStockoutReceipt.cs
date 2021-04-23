using DevExpress.XtraEditors;
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
    public partial class CreateStockoutReceipt : DevExpress.XtraEditors.XtraForm
    {
        public string receiptID = "", poNumber = "", note = "";

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Model.ReceiptDetail.insertStockoutPlanDetail(gridView1, "stockoutreceiptdetails", textBox1.Text, textEdit1.Text, comboBoxEdit1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Model.RestSharpC.execCommand2("poitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadPOItem poItems = JsonConvert.DeserializeObject<JsonHeadPOItem>(res);
            List<Model.ReceiptDetail> ReceiptDetails = new List<Model.ReceiptDetail>();
            poItems.Data.ToList().ForEach(i =>
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
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["receiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["createdAt"]);
        }

        public CreateStockoutReceipt()
        {
            InitializeComponent();
        }
    }
}