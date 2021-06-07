using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.IdentityModel.Tokens.Jwt;
using StockManagement.Properties;

namespace StockManagement.Services
{
    class Http
    {
        string apiEP = Properties.Settings.Default.apiEndPoint;
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTgsIm5hbWUiOiJBZG1pbmlzdHJhdG9ycyIsImVtYWlsIjoiYWRtaW5AZGF0YS52biIsInJvbGVzIjoiYWRtaW47IEtEIiwicGVybWlzc2lvbnMiOlt7Im9iamVjdCI6InBvIiwicGF0aCI6Ii9QT3MiLCJhY3Rpb24iOiJ1cGRhdGVTdGVwIn0seyJvYmplY3QiOiJxdW90YXRpb24iLCJwYXRoIjoiL1F1b3RhdGlvbnMiLCJhY3Rpb24iOiJ1cGRhdGVTdGVwIn0seyJvYmplY3QiOiJjdXN0b21lciIsInBhdGgiOiIvQ3VzdG9tZXJzIiwiYWN0aW9uIjoidmlldyJ9LHsib2JqZWN0Ijoic3VwcGxpZXIiLCJwYXRoIjoiL1N1cHBsaWVycyIsImFjdGlvbiI6InZpZXcifSx7Im9iamVjdCI6InBvUGVuZGluZ1N0ZXBzIiwicGF0aCI6Ii9wZW5kaW5nU3RlcHMiLCJhY3Rpb24iOiJ1cGRhdGVTdGVwIn0seyJvYmplY3QiOiJkYXNoYm9hcmQiLCJwYXRoIjoiL2Rhc2hib2FyZCIsImFjdGlvbiI6InZpZXcifV0sImlhdCI6MTYyMDM3NzUzMX0.qGFN8ugJBcSvPRvmnaWI88mBM1DH_Pwoqn-tj36u-G8";
        protected Settings env = Settings.Default;
        public object Get(string source, List<Parameter> parameters, Type type)
        {
            RestClient client = new RestClient(apiEP);
            RestRequest req = new RestRequest(source, Method.GET);
            req.AddHeader("x-auth-token", token);
            if(parameters!=null)
            parameters.ForEach((p)=> {
                req.AddParameter(p);
            });
            req.RequestFormat = DataFormat.Json;
            var res = client.Execute(req);
            var json = JsonConvert.DeserializeObject(res.Content, type);
            return json.ToString();
        }
        public object Get(string source, Parameter parameters, Type type)
        {
            RestClient client = new RestClient(apiEP);
            RestRequest req = new RestRequest(source, Method.GET);
            req.AddHeader("x-auth-token", token);
            if (!String.IsNullOrEmpty(parameters.Name) && parameters.Value !=null)
            req.AddParameter(parameters);
            req.RequestFormat = DataFormat.Json;
            var res = client.Execute(req);
            var json = JsonConvert.DeserializeObject(res.Content, type);
            return json.ToString();
        }
        public object Get(string source, Type type)
        {
            RestClient client = new RestClient(apiEP);
            RestRequest req = new RestRequest(source, Method.GET);
            req.AddHeader("x-auth-token", token);
            req.RequestFormat = DataFormat.Json;
            var res = client.Execute(req);
            var json = JsonConvert.DeserializeObject(res.Content, type);
            return json;
        }

        public object Post(string source, object body, Type type)
        {
            RestClient client = new RestClient(apiEP);
            RestRequest req = new RestRequest(source, Method.POST);
            req.AddHeader("x-auth-token", token);
            var json = JsonConvert.SerializeObject(body);
            req.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var res = client.Execute(req);
            var _return = JsonConvert.DeserializeObject(res.Content, type);
            return _return;
        }
        public bool Delete(string source, string id)
        {
            var client = new RestClient(apiEP);
            var req = new RestRequest(source + "/" + id,Method.DELETE);
            req.AddHeader("x-auth-token", token);
            var res = client.Execute(req);

            return res.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }

        public object Put(string source,Parameter parameter, object body, Type type)
        {
            RestClient client = new RestClient(apiEP);
            RestRequest req = new RestRequest(source, Method.PUT);
            req.AddHeader("x-auth-token", token);
            req.AddParameter(parameter);
            var json = JsonConvert.SerializeObject(body);
            req.AddParameter("application/json; charset:utf-8", json, ParameterType.RequestBody);
            var res = client.Execute(req);
            return JsonConvert.DeserializeObject(res.Content, type);
        }
    }
}
