using kursach.Forms.Department;
using kursach.Forms.Users.Info;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kursach
{
    public partial class User_form : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public static int user_id;
        public User_form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
            }
            init_user(RegOrAuth.user);

        }
        private void init_user(user_obj user)
        {

            user_id = user.id;
            label6.Text = user.FIO;
            label7.Text = user.email;
            label8.Text = user.State;
            label9.Text = user.Age;
            textBox1.Text = user.FIO;
            textBox2.Text = user.email;
            textBox3.Text = user.State;
            textBox4.Text = user.Age;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }
        private void errors_init(string resp)
        {
            var errors = JsonConvert.DeserializeObject<Hashtable>(resp);
            label10.Text = "";
            label12.Text = "";
            label11.Text = "";
            label13.Text = "";
            foreach (DictionaryEntry error in errors)
            {
                string fieldName = error.Key.ToString();
                if (fieldName == "FIO")
                {
                    label10.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                }
                else if (fieldName == "State")
                {
                    label12.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "email")
                {
                    label11.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                    if (label11.Text.Length >= 38)
                    {
                        label11.Font = new Font("Microsoft Sans Serif", 12f);
                    }
                    else
                    {
                        label11.Font = new Font("Microsoft Sans Serif", 14f);
                    }

                }
                else if (fieldName == "Age")
                {
                    label13.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>
          {
              { "FIO", textBox1.Text },
              { "email", textBox2.Text },
              { "State", textBox3.Text },
              { "Age", textBox4.Text },
          };
            
            var content = new FormUrlEncodedContent(values);
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), "http://127.0.0.1:8000/api/dentist/v1/users/" + RegOrAuth.user.id.ToString());
                request.Content = content;
            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {

                var responseString = await response.Content.ReadAsStringAsync();
                errors_init(responseString);
            }else if (response.StatusCode == HttpStatusCode.NotFound)
            {

            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                RegOrAuth.user = JsonConvert.DeserializeObject<user_obj>(responseString);
                init_user(RegOrAuth.user);
                groupBox2.Visible = false;
            }
            
            

        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {


            File.Delete(@"C:\Dentist\reg.txt");
            RegOrAuth f = new RegOrAuth();
            f.Show();
            Hide();
        }

        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            basket_form f2 = new basket_form();
            f2.Show();
            Hide();
        }

        private void менюУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {

            department_list_user_form f2 = new department_list_user_form();
            f2.Show();
            Hide();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {


            zakaz_list_form f2 = new zakaz_list_form();
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
