using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutPlanServices:Http
    {
        public List<Model.StockoutPlanDatum> _getStockoutPlans()
        {
            try
            {
                return ((Model.StockoutPlans)Get(env.stockoutPlansPath, typeof(Model.StockoutPlans))).Data;
            }
            catch (Exception)
            {
                return new List<Model.StockoutPlanDatum>();
                throw;
            }
        }

        public Model.StockoutPlanDatum _addStockoutPlan(Model.StockoutPlanDatum stockoutPlan)
        {
            try
            {
                return ((Model.StockoutPlans)Post(env.stockinPlansPath, stockoutPlan, typeof(Model.StockoutPlans))).Data[0];
            }
            catch (Exception)
            {
                return new Model.StockoutPlanDatum();
                throw;
            }
        }
    }
}
