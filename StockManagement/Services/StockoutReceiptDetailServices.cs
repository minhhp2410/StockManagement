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

        public List<Model.StockoutReceiptDetail> _addStockoutReceiptDetail(List<Model.StockoutReceiptDetail> stockoutReceiptDetails)
        {
            try
            {
                return (List<Model.StockoutReceiptDetail>)Post(env.stockoutReceiptDetailsPath, stockoutReceiptDetails, typeof(List<Model.StockoutReceiptDetail>));
            }
            catch (Exception)
            {
                return new List<Model.StockoutReceiptDetail>();
                throw;
            }
        }
    }
}
