using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2DWaypoint
{
    public partial class WayPointButton : RadioButton
    {

        ComboBox comboA, comboB;

        public WayPointButton(string name, Point Location, Panel panel, ComboBox combo1, ComboBox combo2)
        {
            BackColor = Color.Transparent;
            Parent = panel;
            Name = name;
            Text = name;
            this.Location = Location;
            comboA = combo1;
            comboB = combo2;
        }



        public RadioButton SetRadioButtonFunction()
        {
            return this;
        }

        public void RadioButtonClicked(object sender, MouseEventArgs e)
        {
            if(Editor.s_comboBox == 0)
            {
                comboA.Text = this.Name;
                Editor.s_comboBox++;
            }
            else if(Editor.s_comboBox == 1)
            {
                comboB.Text = this.Name;
                Editor.s_comboBox--;
            }
        }

        public void RadioButtonDelete(object sender, KeyEventArgs e)
        {
            if (e is KeyEventArgs)
            {
                if (this.Checked == true && e.KeyCode == Keys.Delete)
                {
                    this.Dispose();
                }
            }
        }

    }
}
