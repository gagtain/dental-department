using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public class MyGroupBox : GroupBox
    {
        public static GroupBox createGroupBox(string text, string name, int sizeX,int sizeY,int x, int y)
        {
            GroupBox gr = new GroupBox();
            gr.Size = new System.Drawing.Size(sizeX,sizeY);
            gr.BackColor = System.Drawing.Color.Transparent;
            gr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
            gr.Name = name;
            gr.Text = text;
            gr.Location = new System.Drawing.Point(x,y);
            return gr;
        }
    }
}
