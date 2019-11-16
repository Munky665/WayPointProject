using System.Windows.Forms;
using System.Drawing;
using System;
using System.Runtime.Serialization;

namespace _2DWaypoint
{
    [Serializable]
     class WayPointButton : IGraphic
    {
        public static float Radius = 5;
        public string Name { get;}
        public PointF Location { get; }
        ComboBox comboA, comboB;
        public bool Selected { get; set; }
        Color color = Color.Blue;


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("location.X", Location.X, typeof(float));
            info.AddValue("location.Y", Location.Y, typeof(float));  
        }

        public WayPointButton(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            PointF tempX = new PointF((float)info.GetValue("location.X", typeof(float)), 0f);
            PointF tempY = new PointF(0f, (float)info.GetValue("location.Y", typeof(float)));
            Location = new PointF(tempX.X, tempY.Y);
            
        }

        public WayPointButton(string name, PointF Location, ComboBox combo1, ComboBox combo2)
        {
            Name = name;
            this.Location = Location;
            comboA = combo1;
            comboB = combo2;
        }

        public WayPointButton()
        {
        }

        public override void Draw(Graphics g)
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
            if(Data.comboBox == 0)
            {
                comboA.Text = this.Name;
                Data.comboBox++;
            }
            else if(Data.comboBox == 1)
            {
                comboB.Text = this.Name;
                Data.comboBox--;
            }
        }


    }
}
