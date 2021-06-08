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
            try
            {
                return _getStockinPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockinPlanDetails;
            }
            catch (Exception)
            {
                return new List<Model.StockinPlanDetail>();
                throw;
            }
        }
        public List<Model.StockinPlanDetail> _addStockinPlanDetail(List<Model.StockinPlanDetail> stockinPlanDetails)
        {
            try
            {
                return (List<Model.StockinPlanDetail>)Post(env.stockinPlanDetailsPath, stockinPlanDetails, typeof(List<Model.StockinPlanDetail>));
            }
            catch (Exception)
            {
                return new List<Model.StockinPlanDetail>();
                throw;
            }
        }
    }
}
