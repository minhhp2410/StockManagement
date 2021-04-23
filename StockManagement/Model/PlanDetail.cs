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
    class PlanDetail
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("planID")]
        public string planID { get; set; }
        [JsonProperty("partNumber")]
        public string partNumber { get; set; }
        [JsonProperty("partName")]
        public string partName { get; set; }
        [JsonProperty("price")]
        public float price { get; set; }
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

        public static void insertStockinPlanDetail(GridView grid, string table, string note, string quotationNumber, string store)
        {
            try
            {
                Model.StockinPlan stockinPlan = Model.StockinPlan.addStockinPlan(new Model.StockinPlanData { note = note, quotationNumber = quotationNumber
                    , store = store });
                List<Model.PlanDetail> item = new List<Model.PlanDetail>();
                for (int i = 0; i < grid.RowCount; i++)
                {
                    Model.PlanDetail plan = grid.GetRow(i) as Model.PlanDetail;
                    item.Add(new Model.PlanDetail
                    {
                        id = null,
                        currency = plan.currency,
                        partName = plan.partName,
                        partNumber = plan.partName,
                        planID = stockinPlan.data.planID,
                        position = plan.position,
                        price = plan.price,
                        quantity = plan.quantity,
                        unit = plan.unit,
                        createdAt = null,
                        updatedAt = null,
                    });

                }
                addPlanDetail(item, table);
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
                Model.StockoutPlan stockoutPlan = Model.StockoutPlan.addStockoutPlan(new Model.StockoutPlanData
                {
                    note = note,
                    poNumber = poNumber,
                    store = store
                });
                List<Model.PlanDetail> item = new List<Model.PlanDetail>();
                for (int i = 0; i < grid.RowCount; i++)
                {
                    Model.PlanDetail plan = grid.GetRow(i) as Model.PlanDetail;
                    item.Add(new Model.PlanDetail
                    {
                        id = null,
                        currency = plan.currency,
                        partName = plan.partName,
                        partNumber = plan.partName,
                        planID = stockoutPlan.data.planID,
                        position = plan.position,
                        price = plan.price,
                        quantity = plan.quantity,
                        unit = plan.unit,
                        createdAt = null,
                        updatedAt = null,
                    });

                }
                addPlanDetail(item, table);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void addPlanDetail(List<PlanDetail> items, string table)
        {
            var client = new RestClient(Properties.Resources.apiEndPoint);
            var request = new RestRequest(table, Method.POST);
            var json = JsonConvert.SerializeObject(items);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
        }
        public static List<PlanDetail> getPlanList(string table, string ID)
        {
            var client = new RestClient(Properties.Resources.apiEndPoint + table+"/"+ID);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);// Execute the Request
            request.RequestFormat = DataFormat.Json;
            return JsonConvert.DeserializeObject<getJson>(response.Content).datum;
        }
    }
    class getJson
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public List<PlanDetail> datum { get; set; }
    }
}
