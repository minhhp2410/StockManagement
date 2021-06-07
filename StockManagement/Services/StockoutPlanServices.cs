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
            return ((Model.StockoutPlans)Get(env.stockoutPlansPath, typeof(Model.StockoutPlans))).Data;
        }

        //public List<Model.StockoutPlanDetail> _getStockoutPlanDetail(string planNumber)
        //{
        //    return _getStockoutPlans().Where(w => w.PlanNumber == planNumber).FirstOrDefault().StockoutPlanDetails;
        //}

        public Model.StockoutPlanDatum _addStockoutPlan(Model.StockoutPlanDatum stockoutPlan)
        {
            return (Model.StockoutPlanDatum)Post(env.stockoutPlansPath, stockoutPlan, typeof(Model.StockoutPlans));
        }
    }
}
