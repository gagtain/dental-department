using kursach.Forms.Department;
using kursach.Forms.Users.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class dentist_list : Form
    {
        List<Dentist> Dentist_list = new List<Dentist>();
        private static readonly HttpClient client = new HttpClient();
        public dentist_list()
        {
            InitializeComponent();
        }
        public async void Izmen_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            var textBox1 = Controls[b.Name.Replace("bt", "tx1")];
            if (b.Text == "Изменить")
            {
                textBox1.Enabled = true;
                b.Text = "Подтвердить";
            }
            else
            {
                var values = new Dictionary<string, string>
                {
              { "name", textBox1.Text },
          };
                if (textBox1.Text == "")
                {

                    MessageBox.Show("Вы не ввели стоимость услуги", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var content = new FormUrlEncodedContent(values);
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), "http://127.0.0.1:8000/api/dentist/v1/dentist/" + name[1]);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    var gr = Controls[b.Name.Replace("bt", "gr")];
                    gr.Text = textBox1.Text;

                    textBox1.Enabled = false;
                    b.Text = "Изменить";
                }

                
            }

        }
        private void dentist_init_in_form(Dentist[][] arrays)
        {
            int i, j;
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    var gr = MyGroupBox.createGroupBox(arrays[j][i].name, "gr/" + arrays[j][i].id.ToString(), 250, 360, 300 * i + 10, 370 * j + 80);
                    var tx1 = MyTextBox.createTextBox(arrays[j][i].name, "tx1/" + arrays[j][i].id.ToString(), 160, 60, 300 * i + 50, 350 * j + 180);
                    var bt = MyButton.createButton("Изменить", "bt/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 15, 350 * j + 340);
                    var bt2 = MyButton.createButton("Удалить", "bt/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 135, 350 * j + 340);
                    tx1.Enabled = false;
                    tx1.Multiline = true;
                    bt.Click += new EventHandler(Izmen_Click);
                    bt2.Click += new EventHandler(Delete_Click);
                    gr.Controls.Add(tx1);
                    gr.Controls.Add(bt);
                    gr.Controls.Add(bt2);
                    Controls.Add(tx1);
                    Controls.Add(bt);
                    Controls.Add(bt2);
                    Controls.Add(gr);
                }

            }
        }

        private void dentist_Load(object sender, EventArgs e)
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

            Dentist_list = Dentist.listDentist();
            var h = Dentist_list;
            int i, raz, vhod;
            raz = this.Width;
            vhod = raz / (290 + 12);
            i = 0;
            Dentist[][] arrays = h.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            dentist_init_in_form(arrays);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            int i;
            i = 0;
            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            Dentist.deleteDentist(int.Parse(name[1]));
            Dentist_list.RemoveAll(obj => (obj.id == int.Parse(name[1])));
            var raz = this.Width;
            var vhod = raz / (290 + 12);
            Dentist[][] arrays = Dentist_list.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            dentist_form_Reload(arrays);
        }
        public void dentist_form_Reload(Dentist[][] arrays)
        {

            var menu = menuStrip1;
            Controls.Clear();
            Controls.Add(menu);
            dentist_init_in_form(arrays);
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

        private void dentist_list_FormClosed(object sender, FormClosedEventArgs e)
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
