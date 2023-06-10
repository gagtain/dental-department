using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public class MyLabel
    {
        public static Label createLabel(string text, string name, int x, int y)
        {
            Label lb = new Label();
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
            lb.BackColor = System.Drawing.Color.Transparent;
            lb.Text = text;
            lb.Name = name;
            lb.Location = new System.Drawing.Point(x, y);
            return lb;
        }
    }
}
