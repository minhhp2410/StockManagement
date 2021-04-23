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
    public partial class stockinreceipt : DevExpress.XtraEditors.XtraForm
    {
        public stockinreceipt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateStockinReceipt createStockinReceipt = new CreateStockinReceipt();
            createStockinReceipt.ShowDialog();
        }

        private void stockinreceipt_Load(object sender, EventArgs e)
        {
           gridControl1.DataSource= Model.StockinReceipts.getReceipts();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockinReceiptData data = gridView1.GetFocusedRow() as StockinReceiptData;
            CreateStockinReceipt createStockinReceipt= new CreateStockinReceipt();
            createStockinReceipt.receiptID = data.receiptID;
            createStockinReceipt.note = data.note;
            createStockinReceipt.quotationNumber = data.quotationNumber;
            createStockinReceipt.Show();
        }
    }
}