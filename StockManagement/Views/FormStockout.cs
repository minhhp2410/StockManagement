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
    public partial class FormStockout : DevExpress.XtraEditors.XtraForm
    {
        public FormStockout()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormDoStockout createStockoutReceipt = new FormDoStockout();
            createStockoutReceipt.StartPosition = FormStartPosition.CenterScreen;
            createStockoutReceipt.f = this;
            createStockoutReceipt.ShowDialog();
        }

        public void reLoad()
        {
            gridControl1.DataSource = Model.StockoutReceipts.getReceipts();
            gridView1.Columns.Remove(gridView1.Columns["id"]);
            gridView1.Columns.Remove(gridView1.Columns["updatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["isDeleted"]);
        }
        private void stockoutreceipt_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StockoutReceiptData data = gridView1.GetFocusedRow() as StockoutReceiptData;
            FormDoStockout createStockoutReceipt = new FormDoStockout();
            createStockoutReceipt.receiptID = data.receiptID;
            createStockoutReceipt.note = data.note;
            createStockoutReceipt.poNumber = data.poNumber;
            createStockoutReceipt.StartPosition = FormStartPosition.CenterScreen;
            createStockoutReceipt.Show();
        }

        void deleteReceipt()
        {
            StockoutReceiptData data = gridView1.GetFocusedRow() as StockoutReceiptData;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa phiếu " + data.receiptID, "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (StockoutReceipt.deleteStockoutReceipt(data.receiptID))
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