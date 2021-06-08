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
        public List<Model.StockoutPlanDetail> _addStockoutPlanDetail(List<Model.StockoutPlanDetail> stockoutPlanDetails)
        {
            try
            {
                return (List<Model.StockoutPlanDetail>)Post(env.stockoutPlanDetailsPath, stockoutPlanDetails, typeof(List<Model.StockoutPlanDetail>));
            }
            catch (Exception) 
            {
                return new List<Model.StockoutPlanDetail>();    
                throw; 
            }
        }
    }
}
