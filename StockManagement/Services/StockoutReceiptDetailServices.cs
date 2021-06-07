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
            return _getStockoutReceipts().Where(w => w.ReceiptNumber == receiptNumber).FirstOrDefault().StockoutReceiptDetails;
        }

        public List<Model.StockoutReceiptDetail> _addStockoutReceiptDetail(List<Model.StockoutReceiptDetail> stockoutReceiptDetails)
        {
            return (List<Model.StockoutReceiptDetail>)Post(env.stockoutReceiptDetailsPath, stockoutReceiptDetails, typeof(List<Model.StockoutReceiptDetail>));
        }
    }
}
