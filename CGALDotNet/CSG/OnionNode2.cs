using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.CSG
{
    public class OnionNode2 : Node<Point2d, double>
    {
        public OnionNode2(Node<Point2d, double> node, double thickness)
        {
            AddChild(node);
            Thickness = thickness;
        }

        public double Thickness;

        public override double Func(Point2d point)
        {
            var sdf = GetChildOrDefault(0).Func(point);

            return Math.Abs(sdf) - Thickness;
        }
    }
}
