using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class SubtractionNode2 : Node<Point2d, double>
    {

        public SubtractionNode2(Node<Point2d, double> node0, Node<Point2d, double> node1)
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
}
