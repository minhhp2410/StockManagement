using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    public class StockoutPlanDetail
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("planID")]
        public int? PlanID { get; set; }

        [JsonProperty("partNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("partName")]
        public string PartName { get; set; }

        [JsonProperty("price")]
        public int? Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class StockoutPlanDatum
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("planNumber")]
        public string PlanNumber { get; set; }

        [JsonProperty("poNumber")]
        public string poNumber { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("isDeleted")]
        public bool isDeleted { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("StockoutPlanDetails")]
        public List<StockoutPlanDetail> StockoutPlanDetails { get; set; }
    }

    public class StockoutPlans
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<StockoutPlanDatum> Data { get; set; }
    }
    public class StockoutPlanDetails
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<StockoutPlanDetail> Data { get; set; }
    }
}
