using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class Department_obj
    {
        private static readonly HttpClient client = new HttpClient();
        public int id;
        public string name;
        public string time_job;
        public Dentist dentist;
        public List<product> services;


        public async Task<HttpResponseMessage> putDepartment(List<int> list, int IdDentist)
        {

            var model = new
            {
                name = this.name,
                time_job = this.time_job,
                dentist = IdDentist,
                services = list
            };
            var json = JsonConvert.SerializeObject(model);
            var location_content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PUT"), "http://127.0.0.1:8000/api/dentist/v1/department/" + this.id.ToString());
            request.Content = location_content;
            var response = await client.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> createDepartment(List<int> list, int IdDentist, string TimeJob)
        {
            var model = new
            {
                name = this.name,
                time_job = TimeJob,
                dentist = IdDentist,
                services = list
            };
            var json = JsonConvert.SerializeObject(model);
            var location_content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:8000/api/dentist/v1/department");
            request.Content = location_content;
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }
        public async Task<HttpResponseMessage> removeDepartment()
        {
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), "http://127.0.0.1:8000/api/dentist/v1/department/"+this.id);
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }
        public static List<Department_obj> departamentList()
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/department";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            var department_lists = JsonConvert.DeserializeObject<List<Department_obj>>(data);
            return department_lists;
        }
    }
}
