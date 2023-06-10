using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class product
    {
        private static readonly HttpClient client = new HttpClient();
        public int id;
        public string name;
        public int price;
        public static async Task<HttpResponseMessage> createProduct(string name, int price)
        {
            var model = new
            {
                name = name,
                price = price
            };
            var json = JsonConvert.SerializeObject(model);
            var location_content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:8000/api/dentist/v1/services");
            request.Content = location_content;
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }
        public static List<product> list_product()
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/services";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<product>>(data);
        }
        public async Task<HttpResponseMessage> removeProduct()
        {
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), "http://127.0.0.1:8000/api/dentist/v1/services/" + this.id);
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }
    }
}
