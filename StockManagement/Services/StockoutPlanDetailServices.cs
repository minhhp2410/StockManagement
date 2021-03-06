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
            try
            {
                return _getStockoutPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockoutPlanDetails;
            }
            catch (Exception)
            {
                return new List<Model.StockoutPlanDetail>();
                throw;
            }
        }
        public Model.StockoutPlanDetail _addStockoutPlanDetail(Model.StockoutPlanDetail stockoutPlanDetail)
        {
            try
            {
                return ((Model.StockoutPlanDetail)Post(env.stockoutPlanDetailsPath, stockoutPlanDetail, typeof(Model.StockoutPlanDetail)));
            }
            catch (Exception)
            {
                return new Model.StockoutPlanDetail();
                throw;
            }
        }
    }
}
