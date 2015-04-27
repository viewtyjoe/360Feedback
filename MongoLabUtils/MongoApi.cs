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

        public async Task<HttpResponseMessage> Select(string table, string column, string value)
        {
            string url = baseUrl + Database + "/";
            string query = "{\"" + column + "\":\"" + value + "\"}";

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("collections/" + table + "?apiKey=" + ApiKey + "&q=" + query);
            return response;
        }


        public async Task<HttpResponseMessage> Select(string table, object data, List<string> idColumn, List<string> key)
        {
            string url = baseUrl + Database + "/";

            string query = "{";
            for (int i = 0; i < idColumn.Count(); i++)
            {
                query += "\"" + idColumn[i] + "\":\"" + key[i] + "\"";
            }
            query += "}";

            var dataString = new JavaScriptSerializer().Serialize(data);
            var content = new StringContent(dataString, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return await client.GetAsync("collections/" + table + "?apiKey=" + ApiKey + "&q=" + query);
        }

        public async Task<HttpResponseMessage> Write(string table, object data)
        {
            string url = baseUrl + Database + "/";

            var dataString = new JavaScriptSerializer().Serialize(data);
            var content = new StringContent(dataString, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return await client.PostAsync("collections/" + table + "?apiKey=" + ApiKey, content);
        }


        public async Task<HttpResponseMessage> Update(string table, object data, string idColumn, string key)
        {
            string url = baseUrl + Database + "/";
            string query = "{\"" + idColumn + "\":\"" + key + "\"}";

            var dataString = new JavaScriptSerializer().Serialize(data);
            var content = new StringContent(dataString, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return await client.PutAsync("collections/" + table + "?apiKey=" + ApiKey + "&q=" + query, content);
        }


        public async Task<HttpResponseMessage> Update(string table, object data, List<string> idColumn, List<string> key)
        {
            string url = baseUrl + Database + "/";

            string query = "{";
            for (int i = 0; i < idColumn.Count(); i++)
            {
                query += "\"" + idColumn[i] + "\":\"" + key[i] + "\"";
            }
            query += "}";

            var dataString = new JavaScriptSerializer().Serialize(data);
            var content = new StringContent(dataString, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return await client.PutAsync("collections/" + table + "?apiKey=" + ApiKey + "&q=" + query, content);
        }


        public async Task<HttpResponseMessage> Delete(string table, string idColumn, string key)
        {
            string url = baseUrl + Database + "/";
            string query = "{\"" + idColumn + "\":\"" + key + "\"}";

            var content = new StringContent("", Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return await client.PutAsync("collections/" + table + "?apiKey=" + ApiKey + "&q=" + query, content);
        }
    }
}
