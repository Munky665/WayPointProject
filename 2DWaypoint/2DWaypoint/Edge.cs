using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace _2DWaypoint
{
    [Serializable]
    class Edge : IGraphic
    {
        public PointF Start { get; }
        public PointF End { get; }
        public bool Selected { get; set; }
        Color m_color = Color.White;
        public PointF Length { get; }
        public string Name { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("Start.X", Start.X, typeof(float));
            info.AddValue("Start.Y", Start.Y, typeof(float));
            info.AddValue("End.X", End.X, typeof(float));
            info.AddValue("End.Y", End.Y, typeof(float));
        }

        public Edge(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            PointF tempX = new PointF((float)info.GetValue("Start.X", typeof(float)), 0f);
            PointF tempY = new PointF(0f, (float)info.GetValue("Start.Y", typeof(float)));
            Start = new PointF(tempX.X, tempY.Y);
            tempX = new PointF((float)info.GetValue("End.X", typeof(float)), 0f);
            tempY = new PointF(0f, (float)info.GetValue("End.Y", typeof(float)));
            End = new PointF(tempX.X, tempY.Y);
            Length = VectorMath.Minus(Start, End);
        }

        public Edge(string n, PointF s, PointF e)
        {
            Start = s;
            End = e;
            Name = n;
            Length = VectorMath.Minus(Start, End);
        }

        public override void Draw(Graphics g)
        {
            if(Selected == true)
            {
                m_color = Color.Green;
            }
            else
            {
                m_color = Color.White;
            }
            Pen pen = new Pen(m_color, 2);
            g.DrawLine(pen, Start, End);
        }

        public static Edge CreateEdge(List<WayPointButton> waypoints, ComboBox a, ComboBox b)
        {

            PointF start = new PointF();
            PointF end = new PointF();
            string edgeName = null;

            for (int i = 0; i < waypoints.Count; i++)
            {
                if (waypoints[i].Name == a.Text)
                {
                    start = waypoints[i].Location;
                    edgeName += waypoints[i].Name;
                }
                if (waypoints[i].Name == b.Text)
                {
                    end = waypoints[i].Location;
                    edgeName += ", " + waypoints[i].Name;
                }
            }

            Edge NewEdge = new Edge(edgeName, start, end);
            return NewEdge;
        }


    }
}
