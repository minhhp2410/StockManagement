using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
   public class StockinReceiptData
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("receiptID")]
        public string receiptID { get; set; }
        [JsonProperty("quotationNumber")]
        public string quotationNumber { get; set; }
        [JsonProperty("note")]
        public string note { get; set; }
        [JsonProperty("store")]
        public string store { get; set; }
        [JsonProperty("isDeleted")]
        public bool isDeleted { get; set; }
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }
   public class StockinReceipts
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<StockinReceiptData> datum { get; set; }
    }
   public class StockinReceipt
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public StockinReceiptData data { get; set; }
    }
}
