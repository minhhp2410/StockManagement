using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace StockManagement.Model
{
    class DataInventory
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
    class Inventory 
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<DataInventory> datum { get; set; }
        public List<DataInventory> getInventories()
        {
            try
            {
                RestClient client = new RestClient(Properties.Resources.apiEndPoint);
                RestRequest request = new RestRequest("inventorys", Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                Inventory inventory = JsonConvert.DeserializeObject<Inventory>(response.Content);
                if (inventory != null)
                {
                    return inventory.datum;
                }
                return new List<DataInventory>();
            }
            catch (Exception)
            {
                return new List<DataInventory>();
            }
        }
    }
}
