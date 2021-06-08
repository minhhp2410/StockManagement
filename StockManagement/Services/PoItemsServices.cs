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
           Model.POs pos= (Model.POs)Get(env.poPath, typeof(Model.POs));
            return pos.Data;
        }

        public List<Model.POItem> _getPOItems(string poNumber)
        {
            try
            {
                return getPOs().Where(w => w.PoNumber == poNumber).FirstOrDefault().POItems;
            }
            catch (Exception)
            {
                return new List<Model.POItem>();
                throw;
            }
        }
    }
}
