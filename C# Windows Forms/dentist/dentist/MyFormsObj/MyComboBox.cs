using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Windows.Forms;

namespace kursach
{
    public class MyComboBox
    {
        public static ComboBox create_ComboBoxDentist(string name, int sizeX, int sizeY, int x, int y, List<Dentist> dent_list, Dentist active)
        {
            ComboBox cb = new ComboBox();
            cb.Size = new System.Drawing.Size(sizeX, sizeY);
            cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
            cb.Name = name;
            int i;
            for (i = 0; i < dent_list.Count; i++)
            {
                cb.Items.Add(dent_list[i].name + "("+ dent_list[i].id+")");
            }
            if (active != null)
            {
                cb.SelectedIndex = cb.FindStringExact(active.name + "(" + active.id + ")");
            }
            
            cb.Location = new System.Drawing.Point(x, y);
            return cb;
        }
        public static ComboBox create_ComboBoxServises(string name, int sizeX, int sizeY, int x, int y, List<product> dent_list)
        {
            ComboBox cb = new ComboBox();
            cb.Size = new System.Drawing.Size(sizeX, sizeY);
            cb.Name = name;
            int i;
            for (i = 0; i < dent_list.Count; i++)
            {
                cb.Items.Add(dent_list[i].name + "(" + dent_list[i].id + ")");
            }
            cb.Location = new System.Drawing.Point(x, y);
            return cb;
        }
    }
}
