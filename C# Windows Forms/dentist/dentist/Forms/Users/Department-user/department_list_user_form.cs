using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using kursach.Forms.Department;
using kursach.Forms.Users.Info;

namespace kursach
{
    public partial class department_list_user_form : Form
    {
        public List<Department_obj> dent_list = new List<Department_obj>();
        public department_list_user_form()
        { 
            
            InitializeComponent();
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            department_user_form f = new department_user_form();
            f.Show();
            this.Hide();
        }
        public void Form2_Closes()
        {
            
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        public void Button_Click(object sender, EventArgs e)
        {
            department_user_form f3 = new department_user_form();
            f3.f(dent_list, ((Control)sender).Name);
            f3.Show();
            this.Hide();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
            }
            dent_list = Department_obj.departamentList();
            var h = dent_list;
            int i, j, raz, vhod;
            raz = this.Width;
            vhod = raz / (290 + 12);
            i = 0;
            Department_obj[][] arrays = h.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    var gr = MyGroupBox.createGroupBox(arrays[j][i].name, "gr/" + arrays[j][i].id.ToString(), 250, 383, (i * 290) + 12, (400 * j) + 120);
                    var bt = MyButton.createButton("Выбрать", "dent" + arrays[j][i].id.ToString(), 100, 60, (i * 290) + 85, (400 * j) + 350);
                    bt.Click += new EventHandler(Button_Click);
                    gr.Controls.Add(bt);
                    Controls.Add(bt);
                    Controls.Add(gr);
                }
            }
            
            //
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

        private void сервисыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            services_list ser = new services_list();
            ser.Show();
            Hide();
        }

        private void стоматологиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dentist_list den = new dentist_list();
            den.Show();
            Hide();
        }

        private void отделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {

            department_list den = new department_list();
            den.Show();
            Hide();
        }

        private void отделенияToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void стоматологиToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сервисыToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void оНасToolStripMenuItem_Click(object sender, EventArgs e)
        {

            O_nas f = new O_nas();
            Hide();
            f.Show();
        }
    }
}
