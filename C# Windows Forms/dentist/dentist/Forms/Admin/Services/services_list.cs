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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace kursach
{
    public partial class services_list : Form
    {
        List<product> servis_list = new List<product>();
        private static readonly HttpClient client = new HttpClient();
        product[][] arrays;
        public services_list()
        {
            InitializeComponent();
        }


        public async void Izmen_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            var textBox = Controls[b.Name.Replace("bt", "tx")];
            var textBox1 = Controls[b.Name.Replace("bt", "tx1")];
            if (b.Text == "Изменить")
            {
                textBox.Enabled = true;
                textBox1.Enabled = true;
                b.Text = "Подтвердить";
            }
            else
            {
                var values = new Dictionary<string, string>
                {
              { "name", textBox1.Text },
              { "price", textBox.Text }
          };
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Вы не ввели имя услуги", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (textBox.Text == "")
                {
                    MessageBox.Show("Вы не ввели стоимость услуги", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    var content = new FormUrlEncodedContent(values);
                    var request = new HttpRequestMessage(new HttpMethod("PUT"), "http://127.0.0.1:8000/api/dentist/v1/services/" + name[1]);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    var gr = Controls[b.Name.Replace("bt", "gr")];
                    gr.Text = textBox1.Text;

                    textBox.Enabled = false;
                    textBox1.Enabled = false;
                    b.Text = "Изменить";
                }
                
            }
            
        }
        private async void interlayer_remove_service(object sender, EventArgs e)
        {
            int i = 0;
            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            product prod = new product();
            prod.id = int.Parse(name[1]);
            await prod.removeProduct();
            servis_list.RemoveAll(obj => (obj.id == int.Parse(name[1])));
            var raz = this.Width;
            var vhod = raz / (290 + 12);
            arrays = servis_list.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            Form_Reload();
        }

        private void Form_services_load(product[][] arrays)
        {
            int i, j;
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    var gr = MyGroupBox.createGroupBox(arrays[j][i].name, "gr/" + arrays[j][i].id.ToString(), 250, 360, 300 * i + 10, 370 * j + 80);
                    var tx1 = MyTextBox.createTextBox(arrays[j][i].name, "tx1/" + arrays[j][i].id.ToString(), 160, 60, 300 * i + 50, 350 * j + 180);
                    var tx = MyTextBox.createTextBox(arrays[j][i].price.ToString(), "tx/" + arrays[j][i].id.ToString(), 100, 50, 300 * i + 80, 350 * j + 290);
                    var bt = MyButton.createButton("Изменить", "bt/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 15, 350 * j + 350);
                    var bt2 = MyButton.createButton("Удалить", "bt2/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 135, 350 * j + 350);
                    tx.Enabled = false;
                    tx1.Enabled = false;
                    tx1.Multiline = true;
                    bt.Click += new EventHandler(Izmen_Click);
                    bt2.Click += new EventHandler(interlayer_remove_service);
                    gr.Controls.Add(tx1);
                    gr.Controls.Add(tx);
                    gr.Controls.Add(bt);
                    gr.Controls.Add(bt2);
                    Controls.Add(tx1);
                    Controls.Add(tx);
                    Controls.Add(bt);
                    Controls.Add(bt2);
                    Controls.Add(gr);
                }

            }
        }

        private void Form_Reload()
        {

            var menu = menuStrip1;
            Controls.Clear();
            Controls.Add(menu);
            Form_services_load(arrays);
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

            servis_list = product.list_product();
            var h = servis_list;
            int i, raz, vhod;
            raz = this.Width;
            vhod = raz / (290 + 12);
            i = 0;
            arrays = h.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            Form_services_load(arrays);
        }

        private void services_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            services s = new services();
            Hide();
            s.Show();
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
