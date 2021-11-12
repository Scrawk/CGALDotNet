using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class UnionNode2 : Node2
    {

        public UnionNode2(Node2 node0, Node2 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point2d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Min(sdf0, sdf1);
        }
    }

    public class SubtractionNode2 : Node2
    {

        public SubtractionNode2(Node2 node0, Node2 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point2d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Max(sdf0, -sdf1);
        }
    }

    public class IntersectionNode2 : Node2
    {

        public IntersectionNode2(Node2 node0, Node2 node1)
        {
            AddChild(node0);
            AddChild(node1);
        }

        public override double Func(Point2d point)
        {
            var sdf0 = GetChildOrDefault(0).Func(point);
            var sdf1 = GetChildOrDefault(1).Func(point);

            return Math.Max(sdf0, sdf1);
        }
    }
}
