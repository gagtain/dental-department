using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace kursach
{
    public class MyButton
    {
        public static Button createButton(string text, string name, int sizeX, int sizeY, int x, int y)
        {
            Button bt = new Button();
            bt.Size = new System.Drawing.Size(sizeX, sizeY);
            bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
            bt.BackColor = System.Drawing.Color.Gainsboro;
            bt.Name = name;
            bt.Text = text;
            bt.Location = new System.Drawing.Point(x, y);
            return bt;
        }
    }
}
