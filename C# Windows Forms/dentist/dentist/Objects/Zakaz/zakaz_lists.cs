using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Objects.Zakaz
{
    public class zakaz_lists
    {
        public List<zakaz> zakaz_list;


        public static zakaz_lists getZakazList(int UserId)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/users/"+UserId.ToString()+"/zakaz";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            zakaz_lists zakaz_list = JsonConvert.DeserializeObject<zakaz_lists>(data);

            return zakaz_list;
        }
    }
}
