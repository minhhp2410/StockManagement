using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    class StockinReceiptData
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
    class StockinReceipts
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<StockinReceiptData> datum { get; set; }
        public static List<StockinReceiptData> getReceipts()
        {
            try
            {
                RestClient client = new RestClient(Properties.Resources.apiEndPoint);
                RestRequest request = new RestRequest("stockinreceipts", Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinReceipts receipt = JsonConvert.DeserializeObject<StockinReceipts>(response.Content);
                if (receipt != null)
                    return receipt.datum;
                return new List<StockinReceiptData>();
            }
            catch { return new List<StockinReceiptData>(); }
        }
    }
    class StockinReceipt
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public StockinReceiptData data { get; set; }
        public static StockinReceipt addStockinReceipt(StockinReceiptData item)
        {
            try
            {
                var client = new RestClient(Properties.Resources.apiEndPoint);
                var request = new RestRequest("stockinreceipts", Method.POST);
                var json = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);  // Execute the Request
                return JsonConvert.DeserializeObject<StockinReceipt>(response.Content);
            }
            catch { return new StockinReceipt(); }
        }
        
        public static bool deleteStockinReceipt(string receiptID)
        {
            try
            {
                var client = new RestClient(Properties.Resources.apiEndPoint+ "stockinreceipts"+"/"+receiptID);
                var request = new RestRequest(Method.DELETE);
                IRestResponse response = client.Execute(request);  // Execute the Request
                
                return response.StatusCode == System.Net.HttpStatusCode.OK?true:false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
