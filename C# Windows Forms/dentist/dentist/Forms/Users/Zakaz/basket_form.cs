
using kursach.Forms.Department;
using kursach.Forms.Users.Info;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace kursach
{
    public partial class basket_form : Form
    {
        public static basket_list kor = new basket_list();
        private static readonly HttpClient client = new HttpClient();
        public basket_form()
        {
            InitializeComponent();
        }

        public static int init_summa()
        {

            int itog_summa = 0;
            foreach (var tovar in kor.baskets)
            {
                itog_summa += tovar.summa;
            }
            return itog_summa;


        }

        public void Init_korz()
        {
            string contents;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest
                                    .Create("http://127.0.0.1:8000/api/dentist/v1/users/" + RegOrAuth.user.id.ToString() + "/product");
            request.Method = "GET";
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                contents = reader.ReadToEnd();
            }
            kor = JsonConvert.DeserializeObject<basket_list>(contents);
            int j;
            int i, raz, vhod;
            raz = Width;
            vhod = raz / (290 + 12);
            i = 0;
            int k = 0;
            basket_obj[][] arrays = kor.baskets.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    var gr = MyGroupBox.createGroupBox(arrays[j][i].product.name, "gr/" + arrays[j][i].id.ToString(), 250, 383, 300 * i + 10, (400 * j) + 80);
                    var bt = MyButton.createButton("Изменить", "bt/" + arrays[j][i].id.ToString(), 110, 70, (i * 305) + 15, (400 * j) + 380);
                    var bt2 = MyButton.createButton("Удалить", "btd/" + arrays[j][i].id.ToString(), 110, 70, (i * 305) + 140, (400 * j) + 380);
                    var tx1 = MyTextBox.createTextBox(arrays[j][i].count.ToString(), "tx/" + arrays[j][i].id.ToString(), 160, 60, 300 * i + 60, 350 * j + 280);
                    var lb = MyLabel.createLabel("Сумма: " + arrays[j][i].summa.ToString(), "lb/" + arrays[j][i].id.ToString(), 300 * i + 90, (400 * j) + 350);
                    tx1.Enabled = false;
                    bt.Click += new EventHandler(Button_Click);
                    bt2.Click += new EventHandler(Button_Del_Click);
                    gr.Controls.Add(bt);
                    gr.Controls.Add(tx1);
                    gr.Controls.Add(lb);
                    gr.Controls.Add(bt2);
                    Controls.Add(bt);
                    Controls.Add(lb);
                    Controls.Add(tx1);
                    Controls.Add(bt2);
                    Controls.Add(gr);
                }
            }
            label1.Text = "Сумма: " + init_summa().ToString();

            
        }
        public async void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            if (b.Text == "Изменить")
            {

                var textBox = Controls[b.Name.Replace("bt", "tx")];
                textBox.Enabled = true;
                b.Text = "Подтвердить";
            }
            else
            {

                var textBox = Controls[b.Name.Replace("bt", "tx")];
                var values = new Dictionary<string, string>
                {
              { "count", textBox.Text },
          };
                if (textBox.Text == "")
                {

                    MessageBox.Show("Вы не ввели кол-во услуги", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(textBox.Text == "0")
                {
                    MessageBox.Show("Кол-во услуг может быть только больше 0", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var content = new FormUrlEncodedContent(values);
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), "http://127.0.0.1:8000/api/dentist/v1/product/" + name[1]);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var tov = JsonConvert.DeserializeObject<basket_obj>(responseString);
                    textBox.Enabled = false;
                    var label = Controls[b.Name.Replace("bt", "lb")];
                    label.Text = "Сумма: " + tov.summa.ToString();
                    for (int i = 0; i < kor.baskets.Count; i++)
                    {
                        if (kor.baskets[i].id == Convert.ToInt16(name[1]))
                        {

                            kor.baskets[i].summa = tov.summa;
                            kor.baskets[i].count = tov.count;
                        }
                    }
                    var label_gl = Controls["label1"];
                    label_gl.Text = "Сумма: " + basket_form.init_summa().ToString();
                    b.Text = "Изменить";
                }

                
            }


        }
        public async void Button_Del_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), "http://127.0.0.1:8000/api/dentist/v1/users/" + RegOrAuth.user.id.ToString() + "/product?pr=" + name[1]);

            var response = await client.SendAsync(request);

            for (int i = 0; i < kor.baskets.Count; i++)
            {
                if (kor.baskets[i].id == Convert.ToInt16(name[1]))
                {
                    kor.baskets.RemoveAt(i);
                    break;
                }
            }
            Form5_Reload();
        }
        public void Form5_Reload()
        {
            var l = label1;
            var b = button1;
            var m = menuStrip1;
            Controls.Clear();
            Controls.Add(l);
            Controls.Add(b);
            Controls.Add(m);
            Init_korz();
        }
        public void Form5_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
            }
            Init_korz();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }

        private void моиДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            User_form f2 = new User_form();
            f2.Show();
            Hide();
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            File.Delete(@"C:\Dentist\reg.txt");
            RegOrAuth f = new RegOrAuth();
            f.Show();
            Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (kor.baskets.Count == 0)
            {
                if (MessageBox.Show("Ваша корзина пуста. Не хотите оформить услугу?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    department_list_user_form f = new department_list_user_form();
                    f.Show();
                    Hide();
                }
                
            }
            else
            {
                List<int> result = kor.baskets.Select(ed => ed.id).ToList();
                string combinedString = string.Join(",", result);
                var values = new Dictionary<string, string>
                {
              { "uploader_id", combinedString }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://127.0.0.1:8000/api/dentist/v1/users/" + RegOrAuth.user.id.ToString() + "/product/upload", content);

                var responseString = await response.Content.ReadAsStringAsync();
                var kor_upload = JsonConvert.DeserializeObject<zakaz>(responseString);
                kor_upload.OpenZakazInWord();
                zakaz_list_form z = new zakaz_list_form();
                z.Show();
                Hide();
            }
            


        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            zakaz_list_form f = new zakaz_list_form();
            f.Show();
            Hide();
        }

        private void менюУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {

            department_list_user_form f2 = new department_list_user_form();
            f2.Show();
            Hide();
        }
        private void списокToolStripMenuItem_Click(object sender, EventArgs e)
        {

            department_list den = new department_list();
            den.Show();
            Hide();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            department_create den = new department_create();
            den.Show();
            Hide();
        }

        private void списокToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            dentist_list den = new dentist_list();
            den.Show();
            Hide();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dentist_form den = new dentist_form();
            den.Show();
            Hide();
        }

        private void списокToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            services_list ser = new services_list();
            ser.Show();
            Hide();
        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            services ser = new services();
            ser.Show();
            Hide();
        }

        private void оНасToolStripMenuItem_Click(object sender, EventArgs e)
        {

            O_nas f = new O_nas();
            Hide();
            f.Show();
        }
    }
}
