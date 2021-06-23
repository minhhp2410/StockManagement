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
        List<Model.StockinReceiptDetail> receiptDetails = new List<Model.StockinReceiptDetail>();
        StockinPlanDatum stockinPlan = new StockinPlanDatum();
        Services.QuotationItemsServices quotationItemsServices = new Services.QuotationItemsServices();
        Services.StockinReceiptDetailServices stockinReceiptDetailServices = new Services.StockinReceiptDetailServices();
        Services.StockinReceiptServices stockinReceiptServices = new Services.StockinReceiptServices();
        Services.StockinPlanServices stockinPlanServices = new Services.StockinPlanServices();
        Services.StockinServices stockinServices = new Services.StockinServices();

        public FormDoStockin()
        {
            InitializeComponent();
        }

        void removeUnuseInfo()
        {
            gridView1.Columns.Remove(gridView1.Columns["Id"]);
            gridView1.Columns.Remove(gridView1.Columns["ReceiptID"]);
            gridView1.Columns.Remove(gridView1.Columns["UpdatedAt"]);
            gridView1.Columns.Remove(gridView1.Columns["CreatedAt"]);
        }
        Model.DataInventory convertToInventoryProduct(Model.StockinReceiptDetail detail, string store)
        {
            if (detail.Id != null)
                return new DataInventory()
                {
                    partNumber=detail.PartNumber,
                    partName= detail.PartName,
                    store= store,
                    actualQty=detail.Quantity,
                    currency=detail.Currency,
                    price=detail.Price,
                    position=detail.Position,
                    unit= detail.Unit,
                    createdAt=null,
                    updatedAt=null,
                    id=null
                };
            return new DataInventory();
        }

        bool markPlanAsImported(StockinPlanDatum stockinPlan)
        {
            return stockinPlanServices._markImported(stockinPlan);
        }

        bool doStockin(List<Model.StockinReceiptDetail> detail)
        {
            try
            {
                detail.ForEach(d => {
                    var x = convertToInventoryProduct(d, cbbStore.Text);
                    if (x.id != null)
                    {
                        stockinServices.doStockin(x);
                    }
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool insertDetail(List<Model.StockinReceiptDetail> detail)
        {
            try
            {
                detail.ForEach(rec => {
                    stockinReceiptDetailServices._addStockinReceiptDetail(rec);
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }


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
            receiptDetails= new List<StockinReceiptDetail>();
            stockinPlan = stockinPlanServices._getStockinPlans().Where(w=>w.PlanNumber==txtSearch.Text).FirstOrDefault();
            var planItems = stockinPlan.StockinPlanDetails;
            var quoItems = quotationItemsServices._getQuotationItems(txtSearch.Text);
            if(planItems.Count>0)
            {
                planItems.ForEach(i =>
                {

                    receiptDetails.Add(new Model.StockinReceiptDetail
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
                if(quoItems.Count>0)
                {
                    quoItems.ForEach(i =>
                    {
                        receiptDetails.Add(new Model.StockinReceiptDetail
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

        private void CreateStockinReceipt_Load(object sender, EventArgs e)
        {

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

            List<Model.StockinReceiptDetail> receiptDetails2 = new List<Model.StockinReceiptDetail>();
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
            if (stockinReceipt.Id != null)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var row = gridView1.GetRow(i) as Model.StockinReceiptDetail;
                    row.ReceiptID = (int)stockinReceipt.Id;
                    receiptDetails2.Add(row);
                }
                if (insertDetail(receiptDetails2))
                    if (doStockin(receiptDetails2))
                    {
                        if (markPlanAsImported(stockinPlan))
                        {
                            f.reLoad();
                            MessageBox.Show("Đã nhập kho");
                        }
                    }
            }
        }
    }
}