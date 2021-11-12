using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class RoundNode3 : Node3
    {
        public RoundNode3(Node3 node, double radius)
        {
            AddChild(node);
            Radius = radius;
        }

        public double Radius;

        public override double Func(Point3d point)
        {
            var sdf = GetChildOrDefault(0).Func(point);

            return sdf - Radius;
        }
    }
}
