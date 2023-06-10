using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{

    public class Dentist
    {
        private static readonly HttpClient client = new HttpClient();
        public int id;
        public string name;
        public string sertificate_id;
        public string seria_nomer;

        public Dentist(string name, string sertificate_id, string seria_nomer) { 
            this.name = name;
            this.sertificate_id = sertificate_id;
            this.seria_nomer = seria_nomer;
        }

        public async Task<HttpResponseMessage> createDentist()
        {
            var model = new
            {
                name = this.name,
                sertificate_id = this.sertificate_id,
                seria_nomer = this.seria_nomer,
            };
            var json = JsonConvert.SerializeObject(model);
            var location_content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:8000/api/dentist/v1/dentist");
            request.Content = location_content;
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }

        public static List<product> list_product_not_in_department(int id)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/department/" + id + "/not_services";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<product>>(data);
        }

        public static List<Dentist> listDentist()
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/dentist";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Dentist>>(data);
        }
        public static void deleteDentist(int DenId)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/dentist/"+DenId.ToString();
            var request = WebRequest.Create(url);
            request.Method = "DELETE";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
        }
    }
}
