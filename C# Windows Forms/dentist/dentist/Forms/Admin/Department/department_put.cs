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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class department_put : Form
    {
        public static Department_obj department_obj = new Department_obj();
        private static readonly HttpClient client = new HttpClient();
        public department_put()
        {
            InitializeComponent();
        }
        public async void SelectedRe(object sender, EventArgs e)
        {

            ListBox lb1 = (ListBox)Controls["lb1"];
            TextBox tx = (TextBox)Controls["tx"];
            TextBox tx2 = (TextBox)Controls["tx2"];
            ComboBox cb = (ComboBox)Controls["cb"];
            if (cb.SelectedIndex == -1)
            {
                label1.Text = "Вы не выбрали стоматолога";
            }
            List<int> list = new List<int>();
            foreach (var item in lb1.Items)
            {
                list.Add(int.Parse(item.ToString().Split('(').Last().Replace(")", string.Empty)));
            }
            department_obj.name = tx.Text;
            department_obj.time_job = tx2.Text;
            var response = await department_obj.putDepartment(list, int.Parse(cb.SelectedItem.ToString().Split('(').Last().Replace(")", string.Empty)));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                init_errors(responseString);
            }
            else
            {
                MessageBox.Show("Success", "Успешно выполнено", MessageBoxButtons.OK);
            }
        }
        private void init_errors(string responseString)
        {
            label1.Text = "";
            label3.Text = "";
            label2.Text = "";
            label4.Text = "";
            var errors = JsonConvert.DeserializeObject<Hashtable>(responseString);
            foreach (DictionaryEntry error in errors)
            {
                string fieldName = error.Key.ToString();
                if (fieldName == "dentist")
                {
                    label1.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                }
                if (fieldName == "services")
                {
                    label3.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                if (fieldName == "name")
                {
                    label2.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                }
                if (fieldName == "time_job")
                {
                    label4.Text = error.Value.ToString().Replace("\"", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
                    if (label4.Text.Length > 38)
                    {
                        label4.Font = new Font("Microsoft Sans Serif", 12f);
                    }
                    else
                    {
                        label4.Font = new Font("Microsoft Sans Serif", 14f);
                    }

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
            var gr = MyGroupBox.createGroupBox(department_obj.name, "gr", 800, 461, 25, 52);
            var tx = MyTextBox.createTextBox(department_obj.name, "tx", 300, 120, 150, 130, 16);
            var cb = MyComboBox.create_ComboBoxDentist("cb", 300, 120, 150, 200, Dentist.listDentist(), department_obj.dentist);
            var lb1 = MyListBox.createListBox("lb1", 300, 120, 100, 280, department_obj.services);
            var tx2 = MyTextBox.createTextBox(department_obj.time_job, "tx2", 100, 120, 500, 130, 16);
            var lb2 = MyListBox.createListBox("lb2", 300, 120, 450, 280, Dentist.list_product_not_in_department(department_obj.id));
            var bt = MyButton.createButton("Подтвердить", "bt", 150, 60, 300, 430);
            bt.Click += new EventHandler(SelectedRe);
            gr.Controls.Add(bt);
            gr.Controls.Add(tx);
            gr.Controls.Add(tx2);
            gr.Controls.Add(cb);
            gr.Controls.Add(lb1);
            gr.Controls.Add(lb2);
            Controls.Add(lb1);
            Controls.Add(lb2);
            Controls.Add(bt);
            Controls.Add(cb);
            Controls.Add(tx);
            Controls.Add(tx2);
            Controls.Add(gr);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ListBox lb1 = (ListBox)Controls["lb1"];
            ListBox lb2 = (ListBox)Controls["lb2"];
            if (lb2.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали услугу", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectItem = lb2.SelectedItems[0].ToString();
                lb1.Items.Add(selectItem);
                lb2.Items.Remove(selectItem);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListBox lb1 = (ListBox)Controls["lb1"];
            ListBox lb2 = (ListBox)Controls["lb2"];
            if (lb1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали услугу", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectItem = lb1.SelectedItems[0].ToString();
                lb2.Items.Add(selectItem);
                lb1.Items.Remove(selectItem);
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

        private void department_put_FormClosed(object sender, FormClosedEventArgs e)
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
