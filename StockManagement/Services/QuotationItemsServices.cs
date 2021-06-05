using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class QuotationItemsServices:Http
    {
        public List<Model.QuotationItem> getQuotationItems(string QuotationNo)
        {
            var Quos= (Model.Quotations)Get("quotations", typeof(Model.Quotations));
            return Quos.Data.Where(w => w.QuotationNo == QuotationNo).FirstOrDefault().QuotationItems;
        }
    }
}
