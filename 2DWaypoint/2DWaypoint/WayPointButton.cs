using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2DWaypoint
{
    public partial class WayPointButton
    {
        ToolTip toolTip = new ToolTip();
        public string Name { get;}
        public PointF Location { get; }
        ComboBox comboA, comboB;
        PictureBox panel;
        public bool Selected { get; }

        public WayPointButton(string name,PictureBox panel, PointF Location, ComboBox combo1, ComboBox combo2)
        {
            this.panel = panel;
            Name = name;
            this.Location = Location;
            comboA = combo1;
            comboB = combo2;
            panel.Paint += DrawDot;
        }

         ~WayPointButton()
        {
            
        }

        private void DrawDot(object sender, PaintEventArgs e)
        {
            if (e is PaintEventArgs pe)
                pe.Graphics.FillEllipse(new SolidBrush(Color.Blue), Location.X, Location.Y, 10, 10);

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

    }
}
