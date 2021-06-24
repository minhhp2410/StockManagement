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
            try
            {
                return ((Model.StockinPlans)Post(env.stockinPlansPath, stockinPlan, typeof(Model.StockinPlans))).Data[0];
            }
            catch (Exception)
            {
                return new Model.StockinPlanDatum();
                throw;
            }
        }
        public bool _markImported(Model.StockinPlanDatum stockinPlan)
        {
            try
            {
                var res= (Model.StockinPlans)Put(env.stockinPlansPath,stockinPlan.PlanNumber, typeof(Model.StockinPlans));
                if(res.Message== "Stock in plan imported!")
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
