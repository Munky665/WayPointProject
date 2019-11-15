using System.Windows.Forms;
using System.Drawing;

namespace _2DWaypoint
{
    public partial class WayPointButton : IGraphic
    {
        public static float Radius = 5;
        ToolTip toolTip = new ToolTip();
        public string Name { get;}
        public PointF Location { get; }
        ComboBox comboA, comboB;
        PictureBox panel;
        public bool Selected { get; set; }
        Color color = Color.Blue;

        public WayPointButton(string name,PictureBox panel, PointF Location, ComboBox combo1, ComboBox combo2)
        {
            this.panel = panel;
            Name = name;
            this.Location = Location;
            comboA = combo1;
            comboB = combo2;
        }

        public void Draw(Graphics g)
        {
            if(Selected == true)
            {
                color = Color.White;
            }
            g.FillEllipse(new SolidBrush(color), Location.X - 10/2, Location.Y -10/2, 10, 10);
            color = Color.Blue;
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
