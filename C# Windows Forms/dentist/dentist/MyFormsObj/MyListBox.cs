using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace kursach
{
    public class MyListBox
    {
        public static ListBox createListBox(string name, int sizeX, int sizeY, int x, int y, List<product> service_list)
        {
            ListBox lb = new ListBox();
            lb.Size = new System.Drawing.Size(sizeX, sizeY);
            lb.Name = name;
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
            int i;
            if (service_list != null)
            {
                for (i = 0; i < service_list.Count; i++)
                {
                    lb.Items.Add(service_list[i].name + "(" + service_list[i].id + ")");
                }
            }
            
            lb.Location = new System.Drawing.Point(x, y);
            return lb;
        }
    }
}
