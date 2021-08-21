using System;
using System.Collections.Generic;

using CGeom2D.Geometry;

namespace CGeom2D.Points
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

        public int StartPoint { get; private set; }

        public List<int> EndPoints { get; private set; }

        public override string ToString()
        {
            int count = EndPoints.Count;
            string endPoints = "{";

            for(int i = 0; i < count; i++)
            {
                endPoints += EndPoints[i];

                if (i < count-1)
                    endPoints += ",";
            }

            endPoints += "}";

            return string.Format("[SweepEvent: Point={0}, StartPoint={1}, EndPoints={2}]", 
                Point, StartPoint, endPoints);
        }

        public Point2i GetEndPoint(int b)
        {
            return Collection.GetPoint(b);
        }

        public int CompareTo(SweepEvent other)
        {
            return Compare(Point, other.Point);
        }

        public static int Compare(Point2i a, Point2i b)
        {
            if (a.x != b.x)
            {
                //Left to right
                if (a.x < b.x)
                    return -1;
                else
                    return 1;
            }
            else if (a.y != b.y)
            {
                //top to bottom
                if (a.y > b.y)
                    return -1;
                else
                    return 1;
            }
            else
            {
                //equal
                return 0;
            }
        }

        public bool RemoveSegment(int a, int b)
        {
            if (StartPoint != a)
                return false;
            else
                return EndPoints.Remove(b);
        }

        public bool RemoveEndPoint(int b)
        {
            return EndPoints.Remove(b);
        }

        public Line2d Line(double len)
        {
            var point = Collection.ToPoint2d(Point);
            var x = point.x;

            var p1 = new Point2d(x, -len);
            var p2 = new Point2d(x, len);

            return new Line2d(p1, p2);
        }

    }
}
