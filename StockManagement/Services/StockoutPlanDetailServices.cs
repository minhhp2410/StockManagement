using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutPlanDetailServices:StockoutPlanServices
    {
        public List<Model.StockoutPlanDetail> _getStockoutPlanDetail(string planNumber)
        {
            return _getStockoutPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockoutPlanDetails;
        }
        public List<Model.StockoutPlanDetail> _addStockoutPlanDetail(List<Model.StockoutPlanDetail> stockoutPlanDetails)
        {
            return (List<Model.StockoutPlanDetail>)Post(env.stockoutPlanDetailsPath, stockoutPlanDetails, typeof(List<Model.StockoutPlanDetail>));
        }
    }
}
