using kursach.Forms.Department;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kursach.Forms.Users.Info;

namespace kursach
{
    public partial class services : Form
    {
        public services()
        {
            InitializeComponent();
        }
        private void init_errors(string responseString)
        {
            var errors = JsonConvert.DeserializeObject<Hashtable>(responseString);
            foreach (DictionaryEntry error in errors)
            {
                string fieldName = error.Key.ToString();
                if (fieldName == "name")
                {
                    label3.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }else if (fieldName == "price")
                {
                    label4.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                }
            }
        }
        private void services_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
                MessageBox.Show("Вы не админ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                department_list_user_form f = new department_list_user_form();
                f.Show();
                Hide();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            label4.Text = string.Empty;
            if (textBox2.Text == string.Empty)
            {
                label4.Text = "Введите число";
            }
            else
            {
                try
                {
                    int.Parse(textBox2.Text);
                }
                catch
                {
                    label4.Text = "Введенная строка не число";
                }
                var response = await product.createProduct(textBox1.Text, int.Parse(textBox2.Text));
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("Успешно", "", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    init_errors(responseString);
                }
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void services_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\Dentist\reg.txt");
            RegOrAuth f = new RegOrAuth();
            f.Show();
            Hide();
        }

        private void моиДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_form f2 = new User_form();
            f2.Show();
            Hide();
        }

        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            basket_form f2 = new basket_form();
            f2.Show();
            Hide();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            zakaz_list_form f2 = new zakaz_list_form();
            f2.Show();
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
