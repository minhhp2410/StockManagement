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
            return ((Model.StockinReceipts)Get(env.stockinReceiptsPath, typeof(Model.StockinReceipts))).Data;
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
