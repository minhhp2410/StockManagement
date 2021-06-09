using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class QuotationItemsServices:Http
    {
        public List<Model.QuotationItem> _getQuotationItems(string QuotationNo)
        {
            try
            {
                var Quos = (Model.Quotations)Get(env.quotationPath, typeof(Model.Quotations));
                return Quos.Data.Where(w => w.QuotationNo == QuotationNo.ToUpper()).FirstOrDefault().QuotationItems;
            }
            catch (Exception)
            {
                return new List<Model.QuotationItem>();
                throw;
            }
        }
    }
}
