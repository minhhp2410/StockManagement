using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinServices:Http
    {
        //Properties.Settings env = new Properties.Settings();
        public Model.DataInventory doStockin(Model.DataInventory product)
        {
            try
            {
                return (Model.DataInventory)Post(env.stockinPath, product, typeof(Model.DataInventory));

            }
            catch (Exception)
            {
                return new Model.DataInventory();
            }
        }
    }
}
