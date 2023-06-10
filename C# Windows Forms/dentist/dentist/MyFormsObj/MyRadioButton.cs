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
    internal class MyRadioButton : RadioButton
    {
        public static RadioButton CreatesRadiobutton(int x, int y, product den)
        {
            RadioButton radioButton = new RadioButton();
            radioButton = new RadioButton();
            radioButton.AutoSize = false;
            radioButton.Location = new Point(x, y);
            radioButton.Size = new Size(250, 100);
            radioButton.Text = den.name.ToString();
            radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
            radioButton.Name = den.price.ToString()+"/"+den.id;
            return radioButton;
        }
    }
}
