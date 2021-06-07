using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class StockoutReceiptDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("receiptID")]
        public string ReceiptID { get; set; }

        [JsonProperty("partNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("partName")]
        public string PartName { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    public class StockoutReceiptDatum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ReceiptNumber")]
        public string ReceiptNumber { get; set; }

        [JsonProperty("poNumber")]
        public string PoNumber { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("isDeleted")]
        public bool isDeleted { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("StockoutReceiptDetails")]
        public List<StockoutReceiptDetail> StockoutReceiptDetails { get; set; }

    }

    public class StockoutReceipts
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<StockoutReceiptDatum> Data { get; set; }
    }

}
