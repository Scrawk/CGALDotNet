using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class CircleNode2 : Node<Point2d, double>
    {

        public CircleNode2(Point2d center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point2d Center;

        public double Radius;

        public override double Func(Point2d point)
        {
            point = point - Center;
            return point.Magnitude - Radius;
        }
    }
}
