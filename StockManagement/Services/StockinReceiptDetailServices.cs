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

        public  Model.StockinReceiptDetail _addStockinReceiptDetail(Model.StockinReceiptDetail stockinReceiptDetails)
        {
            try
            {
                return ((Model.StockinReceiptDetail)Post(env.stockinReceiptDetailsPath, stockinReceiptDetails, typeof(Model.StockinReceiptDetail)));
            }
            catch (Exception)
            {
                return new Model.StockinReceiptDetail();
                throw;
            }
        }
    }
}
