using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MongoLabUtils
{
    public class MongoApi
    {
        public string ApiKey { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public string Database { get; set; }
        private readonly string baseUrl = "https://api.mongolab.com/api/1/databases/";

        public async Task<HttpResponseMessage> SelectAll(string table)
        {
            string url = baseUrl + Database + "/";

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("collections/" + table + "?apiKey=" + ApiKey);
            return response;
        }

        public async Task<HttpResponseMessage> Write(string table, object data)
        {
            string url = baseUrl + Database + "/";

            var dataString = new JavaScriptSerializer().Serialize(data);
            var content = new StringContent(dataString, Encoding.Unicode, "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            return await client.PostAsync("collections/" + table + "?apiKey=" + ApiKey, content);
        }
    }
}
