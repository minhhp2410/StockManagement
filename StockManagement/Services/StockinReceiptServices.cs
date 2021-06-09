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
            try
            {
                return ((Model.StockinReceipts)Post(env.stockinReceiptsPath, stockinReceipt, typeof(Model.StockinReceipts))).Data[0];
            }
            catch (Exception)
            {
                return new Model.StockinReceiptDatum();
                throw;
            }
        }

        public bool _deleteStockinReceipt(string id)
        {
            try
            {
                return Delete(env.stockinReceiptsPath, id);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
