using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    class StockoutPlanData
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("planID")]
        public string planID { get; set; }
        [JsonProperty("poNumber")]
        public string poNumber { get; set; }
        [JsonProperty("note")]
        public string note { get; set; }
        [JsonProperty("store")]
        public string store { get; set; }
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }
    class StockoutPlan
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public StockoutPlanData data { get; set; }
        public static StockoutPlan addStockoutPlan(StockoutPlanData item)
        {
            var client = new RestClient(Properties.Resources.apiEndPoint);
            var request = new RestRequest("stockoutplans", Method.POST);
            var json = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
            return JsonConvert.DeserializeObject<StockoutPlan>(response.Content);
        }
        public static StockoutPlanData getPlan(string planID)
        {
            try
            {
                RestClient client = new RestClient(Properties.Resources.apiEndPoint);
                RestRequest request = new RestRequest("stockoutplans/" + planID, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockoutPlan plan = JsonConvert.DeserializeObject<StockoutPlan>(response.Content);
                if (plan != null)
                    return plan.data;
                return new StockoutPlanData();
            }
            catch { return new StockoutPlanData(); }
        }
    }
    class StockoutPlans
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<StockoutPlanData> datum { get; set; }
        public static List<StockoutPlanData> getPlans()
        {
            RestClient client = new RestClient(Properties.Resources.apiEndPoint);
            RestRequest request = new RestRequest("stockoutplans", Method.GET);
            IRestResponse response = client.Execute(request);
            request.RequestFormat = DataFormat.Json;// Execute the Request
            StockoutPlans plan = JsonConvert.DeserializeObject<StockoutPlans>(response.Content);
            if (plan != null)
            return plan.datum;
            return new List<StockoutPlanData>();
        }
    }
}
