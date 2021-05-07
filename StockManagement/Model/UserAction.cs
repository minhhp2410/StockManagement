namespace StockManagement.Model
{
    using DevExpress.XtraGrid.Views.Grid;
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Authenticators;
    using System.IdentityModel.Tokens.Jwt;
    using StockManagement.Properties;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;

    public class UserAction
    {
        internal static String URL = Properties.Settings.Default.apiEndPoint;

        #region user
       public static bool login(string ID, string password)
        {
            RestClient client = new RestClient(Settings.Default.apiEndPoint + Settings.Default.authorizePath);
            RestRequest request = new RestRequest(Method.POST);
            Model.User Account = new Model.User
            {
                email = ID,
                password = password
            };
            var userAccount = JsonConvert.SerializeObject(Account);
            request.AddParameter("application/json;charset=utf-8", userAccount, ParameterType.RequestBody);
            IRestResponse res = client.Execute(request);
            string token = "";
            string roles = "";
            try
            {
                token = JsonConvert.DeserializeObject<Model.GetToken>(res.Content).message;
                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token);
                roles = decodedToken.Claims.ElementAt(2).Value;
                Settings.Default.token = token;
                Settings.Default.roles = roles;
                Settings.Default.Save();
            }
            catch
            {
                token = "";
            }
            if (token != "")
                return true;
            return false;
        }
        #endregion

        #region PO & Quotation Items
        internal static string getQuotationItems(string source, Method method, int quotationID)
        {
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(source, method);
            request.AddParameter("quotationID", quotationID);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);  // Execute the Request
            string content = response.Content;
            return content;
        }

 
        internal static string getPoItems(string source, Method method, int poID)
        {
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(source, method);
            request.AddParameter("poID", poID);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);  // Execute the Request
            string content = response.Content;
            return content;
        }
        #endregion

        #region inventory
        public static List<DataInventory> getInventories()
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.inventorysPath, Method.GET);
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
        #endregion

        #region stockin plan
        public static List<StockinPlanData> getStockinPlans()
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockinPlansPath, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinPlans plan = JsonConvert.DeserializeObject<StockinPlans>(response.Content);
                if (plan != null)
                    return plan.datum;
                return new List<StockinPlanData>();
            }
            catch { return new List<StockinPlanData>(); }
        }
        public static StockinPlan addStockinPlan(StockinPlanData item)
        {
            try
            {
                var client = new RestClient(Properties.Settings.Default.apiEndPoint);
                var request = new RestRequest(Properties.Settings.Default.stockinPlansPath, Method.POST);
                var json = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);  // Execute the Request
                return JsonConvert.DeserializeObject<StockinPlan>(response.Content);
            }
            catch { return new StockinPlan(); }
        }
        public static StockinPlanData getStockinPlan(string planID)
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockinPlansPath + "/" + planID, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinPlan plan = JsonConvert.DeserializeObject<StockinPlan>(response.Content);
                if (plan != null)
                    return plan.data;
                return new StockinPlanData();
            }
            catch { return new StockinPlanData(); }
        }
        #endregion

        #region stockout plan
        public static StockoutPlan addStockoutPlan(StockoutPlanData item)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndPoint);
            var request = new RestRequest(Properties.Settings.Default.stockoutPlansPath, Method.POST);
            var json = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
            return JsonConvert.DeserializeObject<StockoutPlan>(response.Content);
        }
        public static StockoutPlanData getPlan(string planID)
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockoutPlansPath + "/" + planID, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockoutPlan plan = JsonConvert.DeserializeObject<StockoutPlan>(response.Content);
                if (plan != null)
                    return plan.data;
                return new StockoutPlanData();
            }
            catch { return new StockoutPlanData(); }
        }

        public static List<StockoutPlanData> getPlans()
        {
            RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
            RestRequest request = new RestRequest(Properties.Settings.Default.stockoutPlansPath, Method.GET);
            IRestResponse response = client.Execute(request);
            request.RequestFormat = DataFormat.Json;// Execute the Request
            StockoutPlans plan = JsonConvert.DeserializeObject<StockoutPlans>(response.Content);
            if (plan != null)
                return plan.datum;
            return new List<StockoutPlanData>();
        }
        #endregion

        #region plan detail
        public static void addPlanDetail(List<PlanDetail> items, string table)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndPoint);
            var request = new RestRequest(table, Method.POST);
            var json = JsonConvert.SerializeObject(items);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
        }
        public static List<PlanDetail> getPlanList(string table, string ID)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndPoint + table + "/" + ID);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);// Execute the Request
            request.RequestFormat = DataFormat.Json;
            return JsonConvert.DeserializeObject<getJson>(response.Content).datum;
        }
        public static void insertStockinPlanDetail(GridView grid, string table, string note, string quotationNumber, string store)
        {
            try
            {
                Model.StockinPlan stockinPlan = Model.UserAction.addStockinPlan(new Model.StockinPlanData
                {
                    note = note,
                    quotationNumber = quotationNumber
                    ,
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
                Model.StockoutPlan stockoutPlan = Model.UserAction.addStockoutPlan(new Model.StockoutPlanData
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
        #endregion

        #region receipt
        #region stockin
        public static List<StockinReceiptData> getStockinReceipts()
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockinReceiptsPath, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockinReceipts receipt = JsonConvert.DeserializeObject<StockinReceipts>(response.Content);
                if (receipt != null)
                    return receipt.datum;
                return new List<StockinReceiptData>();
            }
            catch { return new List<StockinReceiptData>(); }
        }
        public static StockinReceipt addStockinReceipt(StockinReceiptData item)
        {
            try
            {
                var client = new RestClient(Properties.Settings.Default.apiEndPoint);
                var request = new RestRequest(Properties.Settings.Default.stockinReceiptsPath, Method.POST);
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
                var client = new RestClient(Properties.Settings.Default.apiEndPoint + Properties.Settings.Default.stockinReceiptsPath + "/" + receiptID);
                var request = new RestRequest(Method.DELETE);
                IRestResponse response = client.Execute(request);  // Execute the Request

                return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region stockout
        public static List<StockoutReceiptData> getStockoutReceipts()
        {
            try
            {
                RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
                RestRequest request = new RestRequest(Properties.Settings.Default.stockoutReceiptsPath, Method.GET);
                IRestResponse response = client.Execute(request);
                request.RequestFormat = DataFormat.Json;// Execute the Request
                StockoutReceipts receipt = JsonConvert.DeserializeObject<StockoutReceipts>(response.Content);
                if (receipt != null)
                    return receipt.datum;
                return new List<StockoutReceiptData>();
            }
            catch { return new List<StockoutReceiptData>(); }
        }
        public static StockoutReceipt addStockoutReceipt(StockoutReceiptData item)
        {
            try
            {
                var client = new RestClient(Properties.Settings.Default.apiEndPoint);
                var request = new RestRequest(Properties.Settings.Default.stockoutReceiptsPath, Method.POST);
                var json = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);  // Execute the Request
                return JsonConvert.DeserializeObject<StockoutReceipt>(response.Content);
            }
            catch { return new StockoutReceipt(); }
        }
        public static bool deleteStockoutReceipt(string receiptID)
        {
            try
            {
                var client = new RestClient(Properties.Settings.Default.apiEndPoint + Properties.Settings.Default.stockoutReceiptsPath + "/" + receiptID);
                var request = new RestRequest(Method.DELETE);
                IRestResponse response = client.Execute(request);  // Execute the Request

                return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        public static void addReceiptDetail(List<ReceiptDetail> items, string table)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndPoint);
            var request = new RestRequest(table, Method.POST);
            var json = JsonConvert.SerializeObject(items);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);  // Execute the Request
        }
        public static List<ReceiptDetail> getReceiptList(string table, string ID)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndPoint + table + "/" + ID);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);// Execute the Request
            request.RequestFormat = DataFormat.Json;
            return JsonConvert.DeserializeObject<getJson1>(response.Content).datum;
        }

        #endregion

        #region Stockin/out
        public static void doStockin(GridView grid, string table, string note, string quotationNumber, string store)
        {
            try
            {
                if (quotationNumber.Contains("KHN"))
                {
                    StockinPlanData data = getStockinPlan(quotationNumber);
                    quotationNumber = data.quotationNumber;
                }
                Model.StockinReceipt stockinPlan = addStockinReceipt(new Model.StockinReceiptData
                {
                    note = note,
                    quotationNumber = quotationNumber
                    ,
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
        public static void doStockout(GridView grid, string table, string note, string poNumber, string store)
        {
            try
            {
                if (poNumber.Contains("KHX"))
                {
                    StockoutPlanData data = getPlan(poNumber);
                    poNumber = data.poNumber;
                }
                Model.StockoutReceipt stockoutReceipt = addStockoutReceipt(new Model.StockoutReceiptData
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

        #endregion
    }
}
