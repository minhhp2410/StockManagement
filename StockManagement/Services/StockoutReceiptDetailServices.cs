using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutReceiptDetailServices:StockoutReceiptServices
    {
        public List<Model.StockoutReceiptDetail> _getStockoutReceiptDetail(string receiptNumber)
        {
            try
            {
                return _getStockoutReceipts().Where(w => w.ReceiptNumber == receiptNumber).FirstOrDefault().StockoutReceiptDetails;
            }
            catch (Exception)
            {
                return new List<Model.StockoutReceiptDetail>();
                throw;
            }
        }

        public Model.StockoutReceiptDetail _addStockoutReceiptDetail(Model.StockoutReceiptDetail stockoutReceiptDetails)
        {
            try
            {
                return ((Model.StockoutReceiptDetail)Post(env.stockoutReceiptDetailsPath, stockoutReceiptDetails, typeof(Model.StockoutReceiptDetail)));
            }
            catch (Exception)
            {
                return new Model.StockoutReceiptDetail();
                throw;
            }
        }
    }
}
