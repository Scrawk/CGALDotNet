using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class UnionNode3 : Node3
    {

        public UnionNode3(Node3 node0, Node3 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point3d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Min(sdf0, sdf1);
        }
    }

    public class SubtractionNode3 : Node3
    {

        public SubtractionNode3(Node3 node0, Node3 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point3d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Max(sdf0, -sdf1);
        }
    }

    public class IntersectionNode3 : Node3
    {

        public IntersectionNode3(Node3 node0, Node3 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point3d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Max(sdf0, sdf1);
        }
    }
}
