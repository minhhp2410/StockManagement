using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    public class DataBarcode
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("barcodeNumber")]
        public string barcodeNumber { get; set; }
        [JsonProperty("quantity")]
        public int? quantity { get; set; }
        [JsonProperty("isChecked")]
        public Boolean isChecked { get; set; }       
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }


    }
    public class Barcode
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<DataBarcode> data { get; set; }
    }
}
