using kursach.Forms.Department;
using kursach.Forms.Users.Info;
using kursach.Objects.Zakaz;
using Newtonsoft.Json;
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

namespace kursach
{
    public partial class zakaz_list_form : Form
    {

        public zakaz_list_form()
        {
            InitializeComponent();
        }

        private void zakaz_list_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
            }
            var zakaz_list = zakaz_lists.getZakazList(RegOrAuth.user.id);
            int i, raz, vhod, j;
            raz = Width;
            vhod = raz / (290 + 12);
            i = 0;
            zakaz[][] arrays = zakaz_list.zakaz_list.GroupBy(s => i++ / vhod).Select(s => s.ToArray()).ToArray();
            for (j = 0; j < arrays.Length; j++)
            {
                for (i = 0; i < arrays[j].Length; i++)
                {
                    DateTime enteredDate = DateTime.Parse(arrays[j][i].data);
                    var gr = MyGroupBox.createGroupBox("Заказ №"+ arrays[j][i].id, "gr/" + arrays[j][i].id.ToString(), 250, 383, 300 * i + 10, (400 * j) + 80);
                    var lb = MyLabel.createLabel("Оформлен: " + enteredDate.ToString("f"), "lb", 300 * i + 30, (400 * j) + 300);
                    var lb2 = MyLabel.createLabel("Общая сумма: " + arrays[j][i].summa.ToString() + " руб.", "lb2", 300 * i + 30, (400 * j) + 250);
                    var bt = MyButton.createButton("Открыть чек", "bt/" + arrays[j][i].id.ToString(), 110, 70, 300 * i + 80, (400 * j) + 380);
                    bt.Click += new EventHandler(Button_Click);
                    lb.Size = new System.Drawing.Size(200, 100);
                    lb2.Size = new System.Drawing.Size(200, 50);
                    gr.Controls.Add(bt);
                    gr.Controls.Add(lb);
                    gr.Controls.Add(lb2);
                    Controls.Add(bt);
                    Controls.Add(lb);
                    Controls.Add(lb2);
                    Controls.Add(gr);
                }
            }

        }
        public void Button_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            string[] name = b.Name.Split(new char[] { '/' });
            var zakaz_output = zakaz.getZakaz(int.Parse(name[1]), RegOrAuth.user.id);
            zakaz_output.OpenZakazInWord();
            
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

        private void менюУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {

            department_list_user_form f2 = new department_list_user_form();
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

        private void zakaz_list_form_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void оНасToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_nas f = new O_nas();
            Hide();
            f.Show();
        }
    }
}
