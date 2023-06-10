using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public class MyTextBox : TextBox
    {
        public static TextBox createTextBox(string text, string name, int sizeX, int sizeY, int x, int y, float FontSize=12)
        {
            TextBox tx = new TextBox();
            tx.Size = new System.Drawing.Size(sizeX, sizeY);
            tx.Font = new System.Drawing.Font("Microsoft Tai Le", FontSize);
            tx.Name = name;
            tx.Text = text;
            tx.Location = new System.Drawing.Point(x, y);
            return tx;
        }
    }
}
