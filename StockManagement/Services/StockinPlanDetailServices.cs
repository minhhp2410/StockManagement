using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinPlanDetailServices:StockinPlanServices
    {
        public List<Model.StockinPlanDetail> _getStockinPlanDetail(string planNumber)
        {
            return _getStockinPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockinPlanDetails;
        }
        public List<Model.StockinPlanDetail> _addStockinPlanDetail(List<Model.StockinPlanDetail> stockinPlanDetails)
        {
            return (List<Model.StockinPlanDetail>)Post(env.stockinPlanDetailsPath, stockinPlanDetails, typeof(List<Model.StockinPlanDetail>));
        }
    }
}
