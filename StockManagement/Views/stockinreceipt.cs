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
            createStockinReceipt.f = this;
            createStockinReceipt.ShowDialog();
        }
        public void reLoad()
        {
           gridControl1.DataSource= Model.StockinReceipts.getReceipts();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["isDeleted"]);
        }
        private void stockinreceipt_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockinReceiptData data = gridView1.GetFocusedRow() as StockinReceiptData;
            CreateStockinReceipt createStockinReceipt= new CreateStockinReceipt();
            createStockinReceipt.receiptID = data.receiptID;
            createStockinReceipt.note = data.note;
            createStockinReceipt.quotationNumber = data.quotationNumber;
            createStockinReceipt.StartPosition = FormStartPosition.CenterScreen;
            createStockinReceipt.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reLoad();
        }
        void deleteReceipt()
        {
            StockinReceiptData data = gridView1.GetFocusedRow() as StockinReceiptData;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa phiếu " + data.receiptID, "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (StockinReceipt.deleteStockinReceipt(data.receiptID))
                {

                }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            deleteReceipt();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Delete)
            {
                deleteReceipt();
            }    
        }
    }
}