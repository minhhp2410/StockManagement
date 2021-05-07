using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace StockManagement.Model
{
   public class DataInventory
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("partNumber")]
        public string partNumber { get; set; }
        [JsonProperty("partName")]
        public string partName { get; set; }
        [JsonProperty("price")]
        public float? price { get; set; }
        [JsonProperty("currency")]
        public string currency { get; set; }
        [JsonProperty("store")]
        public string store { get; set; }
        [JsonProperty("position")]
        public string position { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }
        [JsonProperty("actualQty")]
        public int? actualQty { get; set; }
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }


    }
   public class Inventory 
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<DataInventory> datum { get; set; }
    }
}
