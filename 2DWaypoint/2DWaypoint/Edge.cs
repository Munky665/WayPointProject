using System.Drawing;


namespace _2DWaypoint
{
    class Edge : IGraphic
    {
        PointF Start { get; }
        PointF End { get; }
        public bool Selected { get; set; }
        Color m_color = Color.White;
        public PointF Length { get; }
        public string Name { get; }

        public Edge(string n, PointF s, PointF e)
        {
            Start = s;
            End = e;
            Name = n;
            Length = VectorMath.Minus(Start, End);
        }

        public void Draw(Graphics g)
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
    }
}
