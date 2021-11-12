using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class SphereNode3 : Node3
    {

        public SphereNode3(Point3d center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point3d Center;

        public double Radius;

        public override double Func(Point3d point)
        {
            point = point - Center;
            return point.Magnitude - Radius;
        }
    }
}
