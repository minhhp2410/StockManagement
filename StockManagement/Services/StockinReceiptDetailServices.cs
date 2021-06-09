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
            try
            {
                return _getStockinReceipts().Where(w => w.ReceiptNumber == receiptNumber).FirstOrDefault().StockinReceiptDetails;
            }
            catch (Exception)
            {
                return new List<Model.StockinReceiptDetail>();
                throw;
            }
        }

        public  List<Model.StockinReceiptDetail> _addStockinReceiptDetail(List<Model.StockinReceiptDetail> stockinReceiptDetails)
        {
            try
            {
                return ((Model.StockinReceiptDetails)Post(env.stockinReceiptDetailsPath, stockinReceiptDetails, typeof(Model.StockinReceiptDetails))).Data;
            }
            catch (Exception)
            {
                return new List<Model.StockinReceiptDetail>();
                throw;
            }
        }
    }
}
