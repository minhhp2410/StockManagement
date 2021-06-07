using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinReceiptDetailServices:StockinReceiptServices
    {
        public List<Model.StockinReceiptDetail> _getStockinReceiptDetail(string receiptNumber)
        {
            return _getStockinReceipts().Where(w => w.ReceiptNumber == receiptNumber).FirstOrDefault().StockinReceiptDetails;
        }

        public  List<Model.StockinReceiptDetail> _addStockinReceiptDetail(List<Model.StockinReceiptDetail> stockinReceiptDetails)
        {
            return (List<Model.StockinReceiptDetail>)Post(env.stockinReceiptDetailsPath, stockinReceiptDetails, typeof(List<Model.StockinReceiptDetail>));
        }
    }
}
