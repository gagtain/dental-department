using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using kursach.Forms.Department;
using kursach.Forms.Users.Info;

namespace kursach
{
    public partial class department_user_form : Form
    {
        public Department_obj dentist = new Department_obj();
        static public int summa;
        user_obj users = new user_obj();
        public department_user_form()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string buttons;
            try
            {
                buttons = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
            }
            catch
            {
                MessageBox.Show("Поле кол-ва пустое", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                int colvo = Convert.ToInt16(textBox1.Text);
                if (colvo <= 0)
                {
                       MessageBox.Show("В поле кол-во введено число меньше 1","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    //запрос на сервер о формировании заказа
                    RegOrAuth f = new RegOrAuth();

                    department_list_user_form f4 = new department_list_user_form();
                    string text = buttons;
                    string[] words = text.Split(new char[] { '/' });
                    summa += Convert.ToInt16(words[0]) * Convert.ToInt16(textBox1.Text);
                    label4.Text = summa.ToString();
                    HttpWebRequest request = (HttpWebRequest)WebRequest
                                           .Create("http://127.0.0.1:8000/api/dentist/v1/users/" + RegOrAuth.user.id.ToString() +"/product?pr=" + words[1] + "&count=" + textBox1.Text);
                    request.Method = "POST";
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream());
                }
            }
            catch
            {
                MessageBox.Show("В поле кол-во введено не число", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        public void f(List<Department_obj> list, string name)
        {
            dentist = list.FirstOrDefault(g => g.id == Convert.ToInt16(name.Replace("dent", string.Empty)));
            

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (RegOrAuth.user.IsAdmin())
            {
                админПанельToolStripMenuItem.Visible = true;
            }
            else
            {
                админПанельToolStripMenuItem.Visible = false;
            }
            int i;
            Labeles labeles = new Labeles();
            Label Labels = new Label();
            for (i = 0; i < dentist.services.Count; i++)
            {
                var radioButton = MyRadioButton.CreatesRadiobutton(120, 30+80*i, dentist.services[i]);
                Labels = labeles.CreatesGroup(Labels, 50, 70 + 80 * i, dentist.services[i]);
                Controls.Add(radioButton);
                Controls.Add(Labels);
                panel1.Controls.Add(radioButton);
                panel1.Controls.Add(Labels);
            }
            label4.Text = summa.ToString();
            label5.Text = $"Заведующий {dentist.dentist.name}";
            label6.Text = $"Время работы {dentist.time_job}";
            label1.Text = dentist.name;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void менюУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            department_list_user_form f2 = new department_list_user_form();
            f2.Show();
            Hide();
        }

        private void моиДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            User_form f2 = new User_form();
            f2.Show();
            Hide();
        }

        private void аккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            basket_form f2 = new basket_form();
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
