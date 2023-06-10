using kursach.Objects.Zakaz;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class zakaz
    {
        public int id;
        public List<basket_obj> baskets;
        public string data;
        public float summa;

        public static zakaz getZakaz(int idZakaz, int UserId)
        {
            var url = "http://127.0.0.1:8000/api/dentist/v1/users/" + UserId.ToString() + "/zakaz/" + idZakaz.ToString();
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            zakaz zakaz_out = JsonConvert.DeserializeObject<zakaz>(data);
            return zakaz_out;
        }
        public void OpenZakazInWord()
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Add();
            object missing = System.Reflection.Missing.Value; doc.Content.Text += "Чек по заказу №" + this.id;
            for (int i = 0; i < this.baskets.Count; i++)
            {
                doc.Content.Text += $"{i + 1} услуга: {this.baskets[i].product.name}"; doc.Content.Text += $"\t кол-во {this.baskets[i].count}";
                doc.Content.Text += $"\t цена 1 услуги {this.baskets[i].product.price}"; doc.Content.Text += $"\t Общая сумма {i + 1} услуги {this.baskets[i].summa}";
            }
            doc.Content.Text += $"Общая сумма составляет {this.summa}";
            app.Visible = true;
        }
    }
}
