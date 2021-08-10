using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using CGeom2D.Numerics;
using CGeom2D.Geometry;

namespace CGeom2D.Sweep
{
    public class SweepEvent : IComparable<SweepEvent>, IComparer<SweepEvent>
    {

        public static readonly IComparer<SweepEvent> Comparer = new SweepEvent();

        private SweepEvent()
        {
      
        }

        public SweepEvent(Point2i point)
        {
            Point = point;
        }

        public Point2i Point;

        public override string ToString()
        {
            return string.Format("[SweepEvent: Point={0}]", Point);
        }

        public int CompareTo(SweepEvent other)
        {
            if (Point.x != other.Point.x)
                return Point.x.CompareTo(other.Point.x);
            else
                return Point.y.CompareTo(other.Point.y);
        }

        public int Compare(SweepEvent x, SweepEvent y)
        {
            return x.CompareTo(y);
        }
    }
}
