using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    public class StockinReceiptDetail
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("receiptID")]
        public int ReceiptID { get; set; }

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

    public class StockinReceiptDatum
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("ReceiptNumber")]
        public string ReceiptNumber { get; set; }

        [JsonProperty("quotationNumber")]
        public string QuotationNumber { get; set; }

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

        [JsonProperty("StockinReceiptDetails")]
        public List<StockinReceiptDetail> StockinReceiptDetails { get; set; }
    }

    public class StockinReceipts
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<StockinReceiptDatum> Data { get; set; }
    }
    public class StockinReceiptDetails
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<StockinReceiptDetail> Data { get; set; }
    }
}
