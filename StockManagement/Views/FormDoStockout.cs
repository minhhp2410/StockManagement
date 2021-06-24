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
        public FormStockout f = new FormStockout();
        List<Model.StockoutReceiptDetail> receiptDetails = new List<Model.StockoutReceiptDetail>();
        StockoutPlanDatum stockoutPlan = new StockoutPlanDatum();
        PoItemsServices poItemsServices = new PoItemsServices();
        Services.StockoutReceiptDetailServices stockoutReceiptDetailServices = new Services.StockoutReceiptDetailServices();
        Services.StockoutReceiptServices stockoutReceiptServices = new Services.StockoutReceiptServices();
        Services.StockoutPlanServices stockoutPlanServices = new Services.StockoutPlanServices();
        Services.StockoutServices stockoutServices = new StockoutServices();
        public FormDoStockout()
        {
            InitializeComponent();
        }
        Model.DataInventory convertToInventoryProduct(Model.StockoutReceiptDetail detail, string store)
        {
            if (detail.Id != null)
                return new DataInventory()
                {
                    partNumber = detail.PartNumber,
                    partName = detail.PartName,
                    store = store,
                    actualQty = detail.Quantity,
                    currency = detail.Currency,
                    price = detail.Price,
                    position = detail.Position,
                    unit = detail.Unit,
                    createdAt = null,
                    updatedAt = null,
                    id = null
                };
            return new DataInventory();
        }

        bool doStockout(List<Model.StockoutReceiptDetail> detail)
        {
            try
            {
                detail.ForEach(d => {
                    var x = convertToInventoryProduct(d, cbbStore.Text);
                    if (x.id != null)
                    {
                        stockoutServices.doStockout(x);
                    }
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool insertDetail(List<Model.StockoutReceiptDetail> detail)
        {
            try
            {
                detail.ForEach(rec => {
                    stockoutReceiptDetailServices._addStockoutReceiptDetail(rec);
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void removeUnuseInfo()
        {
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["ReceiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Model.StockoutReceiptDetail> receiptDetails2 = new List<Model.StockoutReceiptDetail>();
            Model.StockoutReceiptDatum stockoutReceipt = new StockoutReceiptDatum()
            {
                isDeleted = false,
                Note = txtNote.Text,
                PoNumber = txtSearch.Text,
                Store = cbbStore.Text,
                Id = null,
                CreatedAt = null,
                CreatedBy = Properties.Settings.Default.PIC,
                ReceiptNumber = "",
                UpdatedAt = null,
                StockoutReceiptDetails = null
            };

            stockoutReceipt = stockoutReceiptServices._addStockoutReceipt(stockoutReceipt);
            if (stockoutReceipt.Id != null)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var row = gridView1.GetRow(i) as Model.StockoutReceiptDetail;
                    row.ReceiptID = (int)stockoutReceipt.Id;
                    receiptDetails2.Add(row);

                }
                if (insertDetail(receiptDetails2))
                    if (doStockout(receiptDetails2))
                    {
                        f.reLoad();
                        MessageBox.Show("Đã xuất kho");
                    }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void CreateStockoutReceipt_Load(object sender, EventArgs e)
        {
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
            stockoutPlan = stockoutPlanServices._getStockoutPlans().Where(w => w.PlanNumber == txtSearch.Text).FirstOrDefault();
            if (stockoutPlan.isImported)
            {
                MessageBox.Show("kế hoạch mã " + txtSearch.Text + " đã sử dụng");
                return;
            }
            var planItems = stockoutPlan.StockoutPlanDetails;
            var poItems = poItemsServices._getPOItems(txtSearch.Text);
            if (planItems.Count > 0)
            {
                planItems.ForEach(i =>
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
                if (poItems.Count > 0)
            {
                poItems.ForEach(i =>
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
            else
            {
                MessageBox.Show("Mã không tồn tại");
            }
            gridControl1.DataSource = receiptDetails;
            removeUnuseInfo();
        }

    }
}