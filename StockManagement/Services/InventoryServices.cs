using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class InventoryServices:Http
    {
        public List<Model.DataInventory> _getInventoryItems()
        {
            try
            {
                var items = (Get(env.inventorysPath, typeof(Model.Inventory)) as Model.Inventory).datum;
                return items;
            }
            catch (Exception ex)
            {
                return new List<Model.DataInventory>();
                throw ex;
            }
        }
    }
}
