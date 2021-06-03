using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Model
{
   public class ReceiptDetail
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("receiptID")]
        public string receiptID { get; set; }
        [JsonProperty("partNumber")]
        public string partNumber { get; set; }
        [JsonProperty("partName")]
        public string partName { get; set; }
        [JsonProperty("price")]
        public float? price { get; set; }
        [JsonProperty("currency")]
        public string currency { get; set; }
        [JsonProperty("position")]
        public string position { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }
        [JsonProperty("quantity")]
        public int quantity { get; set; }
        [JsonProperty("createAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }

   public class getJson1
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<ReceiptDetail> datum { get; set; }
    }
}

