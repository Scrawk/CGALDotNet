using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class BoxNode2 : Node<Point2d, double>
    {

        public BoxNode2(Point2d min, Point2d max)
        {
            Min = min;
            Max = max;
        }

        public Point2d Min, Max;

        public Point2d Center
        {
            get { return (Min + Max) * 0.5; }
        }

        public Point2d Size
        {
            get { return new Point2d(Width, Height); }
        }

        public double Width
        {
            get { return Max.x - Min.x; }
        }

        public double Height
        {
            get { return Max.y - Min.y; }
        }

        public override double Func(Point2d point)
        {
            Point2d p = point - Center;
            p.x = Math.Abs(p.x);
            p.y = Math.Abs(p.y);

            Point2d d = p - Size * 0.5;
            Point2d max = Point2d.Max(d, 0);

            return max.Magnitude + Math.Min(Math.Max(d.x, d.y), 0.0);
        }
    }
}
