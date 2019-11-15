using System;
using System.Drawing;


namespace _2DWaypoint
{
    class VectorMath
    {
        public static PointF Add(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF Multiply(PointF a, float b)
        {
            return new PointF(a.X * b, a.Y * b);
        }

        public static PointF Minus(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

        public static float Magnitued(PointF a)
        {
            return (float)Math.Sqrt((a.X * a.X) + (a.Y * a.Y));
        }

    }
}
