using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinReceiptServices:Http
    {
        public List<Model.StockinReceiptDatum> _getStockinReceipts()
        {
            try
            {
                return ((Model.StockinReceipts)Get(env.stockinReceiptsPath, typeof(Model.StockinReceipts))).Data;
            }
            catch (Exception)
            {
                return new List<Model.StockinReceiptDatum>();
                throw;
            }
        }
        public Model.StockinReceiptDatum _addStockinReceipt(Model.StockinReceiptDatum stockinReceipt)
        {
            return ((Model.StockinReceiptDatum)Post(env.stockinReceiptsPath, stockinReceipt, typeof(Model.StockinReceiptDatum)));
        }

        public bool _deleteStockinReceipt(string id)
        {
            return Delete(env.stockinReceiptsPath, id);
        }
    }
}
