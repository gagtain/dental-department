using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class user_obj
    {
        private static readonly HttpClient client = new HttpClient();
        public int id;
        public string FIO;
        public string email;
        public string State;
        public string Age;
        public string role;

        public bool IsAdmin()
        {
            if (this.role == "ADMIN")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async static Task<HttpResponseMessage> Register(Dictionary<string, string> values)
        {

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://127.0.0.1:8000/api/dentist/v1/registration", content);

            return response;
        }
        public static string UserAuth(string email, string password)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/authorization?email=" + email + "&" + "password=" + password;
            var request = WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                WebResponse webResponse = request.GetResponse();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var reader = new StreamReader(webStream);
                string data = reader.ReadToEnd();
                
                return data;

            }
            catch (WebException we)
            {
                int statusCode = (int)((HttpWebResponse)we.Response).StatusCode;
                return statusCode.ToString();
            }

        }
        public static user_obj GetUserInToken(string token)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/registration?token=" + token;
            var request = WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                WebResponse webResponse = request.GetResponse();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var reader = new StreamReader(webStream);
                string data = reader.ReadToEnd();
                user_obj user = JsonConvert.DeserializeObject<user_obj>(data);
                return user;
            }
            catch
            {
                user_obj user = new user_obj();
                user.id = -1;
                return user;
            }

        }
    }
}
