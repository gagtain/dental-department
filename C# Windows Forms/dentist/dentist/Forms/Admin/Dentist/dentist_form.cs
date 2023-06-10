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
using System.Management.Automation.Host;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class dentist_form : Form
    {
        public dentist_form()
        {
            InitializeComponent();
        }
        private void init_errors(string responseString)
        {
            var errors = JsonConvert.DeserializeObject<Hashtable>(responseString);
            label2.Text = "";
            label5.Text = "";
            label6.Text = "";
            foreach (DictionaryEntry error in errors)
            {
                string fieldName = error.Key.ToString();
                if (fieldName == "name")
                {
                    label2.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "sertificate_id")
                {
                    label5.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                else if (fieldName == "seria_nomer")
                {
                    label6.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            Dentist den = new Dentist(textBox1.Text, textBox2.Text, textBox3.Text);
            var response = await den.createDentist();
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                MessageBox.Show("Успешно", "", MessageBoxButtons.OK);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                init_errors(responseString);
            }
            
        }

        private void dentist_form_Load(object sender, EventArgs e)
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

        private void dentist_form_FormClosed(object sender, FormClosedEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
