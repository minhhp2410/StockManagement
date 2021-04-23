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
    public partial class CreateStockinReceipt : DevExpress.XtraEditors.XtraForm
    {
        public string receiptID = "", quotationNumber = "", note = "";

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Model.RestSharpC.execCommand2("quotationitems", RestSharp.Method.GET, int.Parse(textEdit1.Text));
            JsonHeadQuoationItem quoationItems = JsonConvert.DeserializeObject<JsonHeadQuoationItem>(res);
            List<Model.ReceiptDetail> ReceiptDetails = new List<Model.ReceiptDetail>();
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