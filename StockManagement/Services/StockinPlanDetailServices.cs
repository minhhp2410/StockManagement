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
        public Model.StockinPlanDetail _addStockinPlanDetail(Model.StockinPlanDetail stockinPlanDetails)
        {
            try
            {
                return ((Model.StockinPlanDetail)Post(env.stockinPlanDetailsPath, stockinPlanDetails, typeof(Model.StockinPlanDetail)));
            }
            catch (Exception)
            {
                return new Model.StockinPlanDetail();
                throw;
            }
        }
    }
}
