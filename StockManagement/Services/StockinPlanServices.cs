using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinPlanServices :Http
    {
       public List<Model.StockinPlanDatum> _getStockinPlans()
        {
            try
            {
                return ((Model.StockinPlans)Get(env.stockinPlansPath, typeof(Model.StockinPlans))).Data;
            }
            catch (Exception)
            {
                return new List<Model.StockinPlanDatum>();
                throw;
            }
            
        }

        public Model.StockinPlanDatum _addStockinPlan(Model.StockinPlanDatum stockinPlan)
        {
            return (Model.StockinPlanDatum)Post(env.stockinPlansPath, stockinPlan, typeof(Model.StockinPlans));
        }
    }
}
