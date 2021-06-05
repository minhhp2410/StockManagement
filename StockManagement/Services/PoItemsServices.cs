using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class PoItemsServices:Http
    {
        //Http http = new Http();

        List<Model.PoDatum> getPOs()
        {
           Model.POs pos= (Model.POs)Get("pos", typeof(Model.POs));
            return pos.Data;
        }

        public List<Model.POItem> GetPOItems(string poNumber)
        {
            return getPOs().Where(w=>w.PoNumber==poNumber).FirstOrDefault().POItems;
        }
    }
}
