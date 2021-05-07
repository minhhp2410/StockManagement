using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
   public class StockinPlanData
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
   public class StockinPlans
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<StockinPlanData> datum { get; set; }
    }
   public class StockinPlan
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public StockinPlanData data { get; set; }
    }
}
