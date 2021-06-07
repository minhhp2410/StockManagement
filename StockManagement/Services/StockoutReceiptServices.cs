using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutReceiptServices:Http
    {
        public List<Model.StockoutReceiptDatum> _getStockoutReceipts()
        {
            return ((Model.StockoutReceipts)Get(env.stockoutReceiptsPath, typeof(Model.StockoutReceipts))).Data;
        }
        public Model.StockoutReceiptDatum _addStockoutReceipt(Model.StockoutReceiptDatum stockoutReceipt)
        {
            return ((Model.StockoutReceiptDatum)Post(env.stockoutReceiptsPath, stockoutReceipt, typeof(Model.StockoutReceiptDatum)));
        }

        public bool _deleteStockoutReceipt(string id)
        {
            return Delete(env.stockoutReceiptsPath, id);
        }
    }
}
