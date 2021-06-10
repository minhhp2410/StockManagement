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
            try
            {
                return ((Model.StockoutReceipts)Get(env.stockoutReceiptsPath, typeof(Model.StockoutReceipts))).Data;
            }
            catch (Exception)
            {
                return new List<Model.StockoutReceiptDatum>();
                throw;
            }
        }
        public Model.StockoutReceiptDatum _addStockoutReceipt(Model.StockoutReceiptDatum stockoutReceipt)
        {
            try
            {
                return ((Model.StockoutReceipts)Post(env.stockoutReceiptsPath, stockoutReceipt, typeof(Model.StockoutReceipts))).Data[0];
            }
            catch (Exception)
            {
                return new Model.StockoutReceiptDatum();
                throw;
            }
        }

        public bool _deleteStockoutReceipt(string id)
        {
            try
            {
                return Delete(env.stockoutReceiptsPath, id);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
}
    }
}
