namespace StockManagement.Model
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Authenticators;
    using System;

    //    /// <summary>
    //    /// Defines the <see cref="RestSharpC" />.
    //    /// </summary>
    public class RestSharpC
    {
        //        /*private*/
        //        /// <summary>
        //        /// Defines the URL.
        //        /// </summary>
        internal static String URL = Properties.Resources.apiEndPoint;

    //        /*private*/ /*public*/
    //        /// <summary>
    //        /// The execCommand.
    //        /// </summary>
    //        /// <param name="source">The source<see cref="string"/>.</param>
    //        /// <param name="method">The method<see cref="Method"/>.</param>
    //        /// <returns>The <see cref="string"/>.</returns>
    //        internal static string execCommand(string source, Method method)
    //        {
    //            RestClient client = new RestClient(URL);
    //            RestRequest request = new RestRequest(source, method);
    //            IRestResponse response = client.Execute(request);
    //            request.RequestFormat = DataFormat.Json;// Execute the Request
    //            string content = response.Content;
    //            return content;
    //        }

    //        /*private*/
    //        /// <summary>
    //        /// The execCommand1.
    //        /// </summary>
    //        /// <param name="source">The source<see cref="string"/>.</param>
    //        /// <param name="method">The method<see cref="Method"/>.</param>
    //        /// <param name="id">The id<see cref="int"/>.</param>
    //        /// <returns>The <see cref="string"/>.</returns>
    //        internal static string execCommand1(string source, Method method, int id)
    //        {
    //            RestClient client = new RestClient(URL);
    //            RestRequest request = new RestRequest(source, method);
    //            request.AddUrlSegment("id", id);
    //            request.RequestFormat = DataFormat.Json;
    //            IRestResponse response = client.Execute(request);  // Execute the Request
    //            string content = response.Content;
    //            return content;
    //        }

    //        /* private */
    //        /// <summary>
    //        /// The execCommand2.
    //        /// </summary>
    //        /// <param name="source">The source<see cref="string"/>.</param>
    //        /// <param name="method">The method<see cref="Method"/>.</param>
    //        /// <param name="quotationID">The quotationID<see cref="int"/>.</param>
    //        /// <returns>The <see cref="string"/>.</returns>
    internal static string execCommand2(string source, Method method, int quotationID)
{
    RestClient client = new RestClient(URL);
    RestRequest request = new RestRequest(source, method);
    request.AddParameter("quotationID", quotationID);
    request.RequestFormat = DataFormat.Json;
    IRestResponse response = client.Execute(request);  // Execute the Request
    string content = response.Content;
    return content;
}

        //        /*private*/
        //        /// <summary>
        //        /// The execCommand3.
        //        /// </summary>
        //        /// <param name="source">The source<see cref="string"/>.</param>
        //        /// <param name="method">The method<see cref="Method"/>.</param>
        //        /// <param name="stockin">The stockin<see cref="StockIn"/>.</param>
        //        internal static void execCommand3(string source, Method method, StockIn stockin)
        //        {
        //            var client = new RestClient(URL);
        //            var request = new RestRequest(source, method);
        //            var json = JsonConvert.SerializeObject(stockin);
        //            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        //            IRestResponse response = client.Execute(request);  // Execute the Request
        //        }

        //        /*private*/
        //        /// <summary>
        //        /// The execCommand4.
        //        /// </summary>
        //        /// <param name="source">The source<see cref="string"/>.</param>
        //        /// <param name="method">The method<see cref="Method"/>.</param>
        //        /// <param name="stockin">The stockin<see cref="StockIn[]"/>.</param>
        //        internal static void execCommand4(string source, Method method, StockIn[] stockin)
        //        {
        //            var client = new RestClient(URL);
        //            var request = new RestRequest(source, method);
        //            var json = JsonConvert.SerializeObject(stockin);
        //            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        //            IRestResponse response = client.Execute(request);  // Execute the Request
        //        }

        //        /* private */
        //        /// <summary>
        //        /// The execCommand5.
        //        /// </summary>
        //        /// <param name="source">The source<see cref="string"/>.</param>
        //        /// <param name="method">The method<see cref="Method"/>.</param>
        //        /// <param name="poID">The poID<see cref="int"/>.</param>
        //        /// <returns>The <see cref="string"/>.</returns>
        internal static string execCommand5(string source, Method method, int poID)
        {
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(source, method);
            request.AddParameter("poID", poID);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);  // Execute the Request
            string content = response.Content;
            return content;
        }

        //        /// <summary>
        //        /// The execCommand7.
        //        /// </summary>
        //        /// <param name="source">The source<see cref="string"/>.</param>
        //        /// <param name="method">The method<see cref="Method"/>.</param>
        //        /// <param name="PoNumber">The PoNumber<see cref="string"/>.</param>
        //        /// <returns>The <see cref="string"/>.</returns>
        //        internal static string execCommand7(string source, Method method, string PoNumber)
        //        {
        //            RestClient client = new RestClient(URL);
        //            RestRequest request = new RestRequest(source, method);
        //            request.AddUrlSegment("PoNumber", PoNumber);
        //            request.RequestFormat = DataFormat.Json;
        //            IRestResponse response = client.Execute(request);  // Execute the Request
        //            string content = response.Content;
        //            return content;
        //        }

        //        /*private*/
        //        /// <summary>
        //        /// The execCommand6.
        //        /// </summary>
        //        /// <param name="source">The source<see cref="string"/>.</param>
        //        /// <param name="method">The method<see cref="Method"/>.</param>
        //        /// <param name="stockout">The stockout<see cref="StockOut[]"/>.</param>
        //        internal static void execCommand6(string source, Method method, StockOut[] stockout)
        //        {
        //            var client = new RestClient(URL);
        //            var request = new RestRequest(source, method);
        //            var json = JsonConvert.SerializeObject(stockout);
        //            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        //            IRestResponse response = client.Execute(request);  // Execute the Request
        //        }
    }
}
