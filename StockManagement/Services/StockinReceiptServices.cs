using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockinReceiptServices
    {
        //    public static List<StockinReceiptData> getStockinReceipts()
        //    {
        //        try
        //        {
        //            RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
        //            RestRequest request = new RestRequest(Properties.Settings.Default.stockinReceiptsPath, Method.GET);
        //            IRestResponse response = client.Execute(request);
        //            request.RequestFormat = DataFormat.Json;// Execute the Request
        //            StockinReceipts receipt = JsonConvert.DeserializeObject<StockinReceipts>(response.Content);
        //            if (receipt != null)
        //                return receipt.datum;
        //            return new List<StockinReceiptData>();
        //        }
        //        catch { return new List<StockinReceiptData>(); }
        //    }
        //    public static StockinReceipt addStockinReceipt(StockinReceiptData item)
        //    {
        //        try
        //        {
        //            var client = new RestClient(Properties.Settings.Default.apiEndPoint);
        //            var request = new RestRequest(Properties.Settings.Default.stockinReceiptsPath, Method.POST);
        //            var json = JsonConvert.SerializeObject(item);
        //            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        //            IRestResponse response = client.Execute(request);  // Execute the Request
        //            return JsonConvert.DeserializeObject<StockinReceipt>(response.Content);
        //        }
        //        catch { return new StockinReceipt(); }
        //    }
        //    public static bool deleteStockinReceipt(string receiptID)
        //    {
        //        try
        //        {
        //            var client = new RestClient(Properties.Settings.Default.apiEndPoint + Properties.Settings.Default.stockinReceiptsPath + "/" + receiptID);
        //            var request = new RestRequest(Method.DELETE);
        //            IRestResponse response = client.Execute(request);  // Execute the Request

        //            return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }
    }
}
