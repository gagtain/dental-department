using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class RegOrAuth : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public static string token;
        public static user_obj user;
        public RegOrAuth()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            department_list_user_form f = new department_list_user_form();
            f.Show();
            this.Hide();
        }

        private void errors_init(string resp)
        {
            var errors = JsonConvert.DeserializeObject<Hashtable>(resp);
            label14.Text = "";
            label11.Text = "";
            label10.Text = "";
            label8.Text = "";
            label7.Text = "";
            foreach (DictionaryEntry error in errors)
            {
                string fieldName = error.Key.ToString();
                if (fieldName == "FIO")
                {
                    label7.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                }
                else if (fieldName == "State")
                {
                    label8.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "email")
                {
                    label14.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "Age")
                {
                    label10.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "password")
                {
                    label11.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
          var values = new Dictionary<string, string>
          {
              { "FIO", textBox1.Text },
              { "State", textBox2.Text },
              { "email", textBox6.Text },
              { "Age", textBox3.Text },
              { "password", textBox4.Text }
          };

            HttpResponseMessage response = await user_obj.Register(values);

            var responseString = await response.Content.ReadAsStringAsync();
            var status = response.StatusCode; 
            if (status == HttpStatusCode.BadRequest)
            {

                errors_init(responseString);

            }
            else
            {
                create_reg_txt(responseString);
                user = user_obj.GetUserInToken(responseString);
                department_list_user_form f = new department_list_user_form();
                f.Show();
                Hide();
            }
    }


        private void create_reg_txt(string responseString)
        {
            string subPath = @"C:\Dentist";

            bool exists = Directory.Exists(subPath);

            if (!exists)
                Directory.CreateDirectory(subPath);
            string fileName = @"C:\Dentist\reg.txt";
            using (FileStream fs = File.Create(fileName))
            {
                // Add some text to file   
                Byte[] title = new UTF8Encoding(true).GetBytes(responseString);
                fs.Write(title, 0, title.Length);
            }
            token = responseString;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            department_list_user_form f = new department_list_user_form();
            f.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private string file_reg()
        {
            string fileName = @"C:\Dentist\reg.txt";

            
                if (File.Exists(fileName))
                {
                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string s = sr.ReadLine();

                    return s;


                    }
            }
            else
            {
                return string.Empty;
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (file_reg() != string.Empty)
            {
                user = user_obj.GetUserInToken(file_reg());
                if (user.id != -1)
                {
                    department_list_user_form f = new department_list_user_form();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    label12.Text = "Неверные авторизационные данные";
                }
            } 
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label12.Text = string.Empty;
            var reg = user_obj.UserAuth(textBox8.Text, textBox5.Text);
            if (reg != 404.ToString() & reg != 400.ToString())
            {
                user = user_obj.GetUserInToken(reg);
                if (user.id != -1)
                {
                    create_reg_txt(reg);

                    user = user_obj.GetUserInToken(reg);
                    department_list_user_form f = new department_list_user_form();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    label12.Text = "Неверные авторизационные данные";
                }
                
            }
            else
            {
                label12.Text = "Неверные авторизационные данные";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
