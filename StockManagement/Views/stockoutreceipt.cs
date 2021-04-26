using DevExpress.XtraEditors;
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
    public partial class stockoutreceipt : DevExpress.XtraEditors.XtraForm
    {
        public stockoutreceipt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateStockoutReceipt createStockoutReceipt = new CreateStockoutReceipt();
            createStockoutReceipt.ShowDialog();
        }
        private void stockoutreceipt_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = Model.StockoutReceipts.getReceipts();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockoutReceiptData data = gridView1.GetFocusedRow() as StockoutReceiptData;
            CreateStockoutReceipt createStockoutReceipt = new CreateStockoutReceipt();
            createStockoutReceipt.receiptID = data.receiptID;
            createStockoutReceipt.note = data.note;
            createStockoutReceipt.poNumber = data.poNumber;
            createStockoutReceipt.Show();
        }
    }
}