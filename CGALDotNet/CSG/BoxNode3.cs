using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class BoxNode3 : Node3
    {

        public BoxNode3(Point3d min, Point3d max)
        {
            Min = min;
            Max = max;
        }

        public Point3d Min, Max;

        public Point3d Center
        {
            get { return (Min + Max) * 0.5; }
        }

        public Point3d Size
        {
            get { return new Point3d(Width, Height, Depth); }
        }

        public double Width
        {
            get { return Max.x - Min.x; }
        }

        public double Height
        {
            get { return Max.y - Min.y; }
        }

        public double Depth
        {
            get { return Max.z - Min.z; }
        }

        public override double Func(Point3d point)
        {
            Point3d p = point - Center;
            p.x = Math.Abs(p.x);
            p.y = Math.Abs(p.y);
            p.z = Math.Abs(p.z);

            Point3d d = p - Size * 0.5;
            Point3d max = Point3d.Max(d, 0);

            return max.Magnitude + Math.Min(Math.Max(Math.Max(d.x, d.y), d.z), 0.0);
        }
    }
}
