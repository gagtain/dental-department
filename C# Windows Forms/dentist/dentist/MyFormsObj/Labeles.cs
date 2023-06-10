using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace kursach
{
    internal class Labeles : Label
    {
        public Label CreatesGroup(Label Lab, int x, int y, product den)
        {
            Lab = new Label();

            Lab.Location = new Point(x, y);
            Lab.Size = new Size(93, 34);
            Lab.Font = new Font("Microsoft Sans Serif", 14);
            Lab.Text = den.price.ToString() + "руб";
            return Lab;
        }
    }
}
