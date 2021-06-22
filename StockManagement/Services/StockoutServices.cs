using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutServices:Http
    {
        public Model.DataInventory doStockout(Model.DataInventory product)
        {
            try
            {
                return (Model.DataInventory)Post(env.stockoutPath, product, typeof(Model.DataInventory));

            }
            catch (Exception)
            {
                return new Model.DataInventory();
            }
        }
    }
}
