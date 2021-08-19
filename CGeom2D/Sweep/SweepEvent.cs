using System;
using System.Collections.Generic;

using CGeom2D.Geometry;

namespace CGeom2D.Sweep
{

    public class SweepEvent : IComparable<SweepEvent>
    {

        public SweepEvent(PointCollection collection, int startPoint, List<int> endPoints)
        {
            Collection = collection;
            StartPoint = startPoint;
            EndPoints = endPoints;
        }

        public Point2i Point => Collection.GetPoint(StartPoint);

        private PointCollection Collection { get; set; }

        private int StartPoint { get; set; }

        private List<int> EndPoints { get; set; }

        public override string ToString()
        {
            return string.Format("[SweepEvent: Point={0}]", Point);
        }

        public int CompareTo(SweepEvent other)
        {
            return Compare(Point, other.Point);
        }

        public static int Compare(Point2i a, Point2i b)
        {
            if (a.x != b.x)
                return a.x.CompareTo(b.x);
            else
                return a.y.CompareTo(b.y);
        }

    }
}
