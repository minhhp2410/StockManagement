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
    class ReceiptDetail
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
        public static void insertStockinReceiptDetail(GridView grid, string table, string note, string quotationNumber, string store)
        {
            try
            {
                Model.StockinReceipt stockinPlan = Model.StockinReceipt.addStockinReceipt(new Model.StockinReceiptData
                {
                    note = note,
                    quotationNumber = quotationNumber
                    ,
                    store = store,
                    isDeleted= false
                });
                List<Model.ReceiptDetail> item = new List<Model.ReceiptDetail>();
                for (int i = 0; i < grid.RowCount; i++)
                {
                    Model.ReceiptDetail plan = grid.GetRow(i) as Model.ReceiptDetail;
                    item.Add(new Model.ReceiptDetail
                    {
                        id = null,
                        currency = plan.currency,
                        partName = plan.partName,
                        partNumber = plan.partName,
                        receiptID = stockinPlan.data.receiptID,
                        position = plan.position,
                        price = plan.price,
                        quantity = plan.quantity,
                        unit = plan.unit,
                        createdAt = null,
                        updatedAt = null,
                    });

                }
                addReceiptDetail(item, table);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void insertStockoutPlanDetail(GridView grid, string table, string note, string poNumber, string store)
        {
            try
            {
                Model.StockoutReceipt stockoutReceipt = Model.StockoutReceipt.addStockoutReceipt(new Model.StockoutReceiptData
                {
                    note = note,
                    poNumber = poNumber,
                    store = store,
                    isDeleted = false
                });
                List<Model.ReceiptDetail> item = new List<Model.ReceiptDetail>();
                for (int i = 0; i < grid.RowCount; i++)
                {
                    Model.ReceiptDetail plan = grid.GetRow(i) as Model.ReceiptDetail;
                    item.Add(new Model.ReceiptDetail
                    {
                        id = null,
                        currency = plan.currency,
                        partName = plan.partName,
                        partNumber = plan.partName,
                        receiptID = stockoutReceipt.data.receiptID,
                        position = plan.position,
                        price = plan.price,
                        quantity = plan.quantity,
                        unit = plan.unit,
                        createdAt = null,
                        updatedAt = null,
                    });

                }
                addReceiptDetail(item, table);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void addReceiptDetail(List<ReceiptDetail> items, string table)
        {
            var client = new RestClient(Properties.Resources.apiEndPoint);
            var request = new RestRequest(table, Method.POST);
            var json = JsonConvert.SerializeObject(items);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
        }
        //public static List<ReceiptDetail> getReceiptList(string table, string ID)
        //{
        //    var client = new RestClient(Properties.Resources.apiEndPoint + table + "/" + ID);
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = client.Execute(request);// Execute the Request
        //    request.RequestFormat = DataFormat.Json;
        //    return JsonConvert.DeserializeObject<getJson>(response.Content).datum;
        //}
    }
}
