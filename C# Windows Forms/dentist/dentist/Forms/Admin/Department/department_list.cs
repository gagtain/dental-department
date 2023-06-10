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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class department_list : Form
    {
        public List<Department_obj> department_lists = new List<Department_obj>();
        private Department_obj[][] arrays;
        public List<Dentist> dentist_list = new List<Dentist>();

        public department_list()
        {
            InitializeComponent();
        }
        public void Izmen_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });

            var url = "http://127.0.0.1:8000/api/dentist/v1/department/" + name[1];
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            department_put.department_obj = JsonConvert.DeserializeObject<Department_obj>(data);


            department_put den = new department_put();
            den.Show();
            Hide();


        }

        private async void interlayer_remove_department(object sender, EventArgs e)
        {
            int i=0;
            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            Department_obj dep = new Department_obj();
            dep.id = int.Parse(name[1]);
            await dep.removeDepartment();
            department_lists.RemoveAll(obj => (obj.id == int.Parse(name[1])));
            var raz = this.Width;
            var vhod = raz / (290 + 12);
            arrays = department_lists.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            Form_Reload();
        }
        private void Form_Reload()
        {
            var menu = menuStrip1;
            Controls.Clear();
            Controls.Add(menu);
            Form_Department_Load(arrays);
        }

        private void Form_Department_Load(Department_obj[][] arrays)
        {
            int j, i;
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    var gr = MyGroupBox.createGroupBox(arrays[j][i].name, "gr/" + arrays[j][i].id.ToString(), 250, 360, 300 * i + 10, 370 * j + 80);
                    var bt = MyButton.createButton("Изменить", "bt/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 15, 350 * j + 350);
                    var bt2 = MyButton.createButton("Удалить", "bt2/" + arrays[j][i].id.ToString(), 120, 70, 300 * i + 135, 350 * j + 350);
                    bt.Click += new EventHandler(Izmen_Click);
                    bt2.Click += new EventHandler(interlayer_remove_department);
                    gr.Controls.Add(bt);
                    gr.Controls.Add(bt2);
                    Controls.Add(bt);
                    Controls.Add(bt2);
                    Controls.Add(gr);
                }

            }
        }

        private void department_Load(object sender, EventArgs e)
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
            department_lists = Department_obj.departamentList();
            var h = department_lists;
            int i, raz, vhod;
            raz = this.Width;
            vhod = raz / (290 + 12);
            i = 0;
            arrays = h.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            Form_Department_Load(arrays);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            department_create d = new department_create();
            Hide();
            d.Show();
            
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

        private void department_list_FormClosed(object sender, FormClosedEventArgs e)
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
