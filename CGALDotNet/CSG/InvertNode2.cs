using CGALDotNet.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.CSG
{
    public class InvertNode2 : Node2
    {

        public InvertNode2(Node2 child)
        {
            AddChild(child);
        }

        public override double Func(Point2d point)
        {
            return -GetChildOrDefault(0).Func(point);
        }
    }
}
