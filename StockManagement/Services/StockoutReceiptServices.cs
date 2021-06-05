using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class StockoutReceiptServices
    {
        //public static List<StockoutReceiptData> getStockoutReceipts()
        //{
        //    try
        //    {
        //        RestClient client = new RestClient(Properties.Settings.Default.apiEndPoint);
        //        RestRequest request = new RestRequest(Properties.Settings.Default.stockoutReceiptsPath, Method.GET);
        //        IRestResponse response = client.Execute(request);
        //        request.RequestFormat = DataFormat.Json;// Execute the Request
        //        StockoutReceipts receipt = JsonConvert.DeserializeObject<StockoutReceipts>(response.Content);
        //        if (receipt != null)
        //            return receipt.datum;
        //        return new List<StockoutReceiptData>();
        //    }
        //    catch { return new List<StockoutReceiptData>(); }
        //}
        //public static StockoutReceipt addStockoutReceipt(StockoutReceiptData item)
        //{
        //    try
        //    {
        //        var client = new RestClient(Properties.Settings.Default.apiEndPoint);
        //        var request = new RestRequest(Properties.Settings.Default.stockoutReceiptsPath, Method.POST);
        //        var json = JsonConvert.SerializeObject(item);
        //        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);  // Execute the Request
        //        return JsonConvert.DeserializeObject<StockoutReceipt>(response.Content);
        //    }
        //    catch { return new StockoutReceipt(); }
        //}
        //public static bool deleteStockoutReceipt(string receiptID)
        //{
        //    try
        //    {
        //        var client = new RestClient(Properties.Settings.Default.apiEndPoint + Properties.Settings.Default.stockoutReceiptsPath + "/" + receiptID);
        //        var request = new RestRequest(Method.DELETE);
        //        IRestResponse response = client.Execute(request);  // Execute the Request

        //        return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
