using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    class StockinPlanData
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("planID")]
        public string planID { get; set; }
        [JsonProperty("quotationNumber")]
        public string quotationNumber { get; set; }
        [JsonProperty("note")]
        public string note { get; set; }
        [JsonProperty("store")]
        public string store { get; set; }
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }
    class StockinPlans
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<StockinPlanData> datum { get; set; }
        public static List<StockinPlanData> getPlans()
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockinPlansPath, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinPlans plan = JsonConvert.DeserializeObject<StockinPlans>(response.Content);
                if(plan!=null)
                return plan.datum;
                return new List<StockinPlanData>();
            }
            catch { return new List<StockinPlanData>(); }
        }

    }
    class StockinPlan
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public StockinPlanData data { get; set; }
        public static StockinPlan addStockinPlan(StockinPlanData item)
        {
            try
            {
                var client = new RestClient(Properties.Settings.Default.apiEndPoint);
                var request = new RestRequest(Properties.Settings.Default.stockinPlansPath, Method.POST);
                var json = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);  // Execute the Request
                return JsonConvert.DeserializeObject<StockinPlan>(response.Content);
            }
            catch { return new StockinPlan(); }
        }
        public static StockinPlanData getPlan(string planID)
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockinPlansPath +"/" + planID, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinPlan plan = JsonConvert.DeserializeObject<StockinPlan>(response.Content);
                if (plan != null)
                    return plan.data;
                return new StockinPlanData();
            }
            catch { return new StockinPlanData(); }
        }
    }
}
