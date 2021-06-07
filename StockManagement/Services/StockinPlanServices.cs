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
            return ((Model.StockinPlans)Get(env.stockinPlansPath, typeof(Model.StockinPlans))).Data;
        }

        //public List<Model.StockinPlanDetail>_getStockinPlanDetail(string planNumber)
        //{
        //    return _getStockinPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockinPlanDetails;
        //}

        public Model.StockinPlanDatum _addStockinPlan(Model.StockinPlanDatum stockinPlan)
        {
            return (Model.StockinPlanDatum)Post(env.stockinPlansPath, stockinPlan, typeof(Model.StockinPlans));
        }
    }
}
