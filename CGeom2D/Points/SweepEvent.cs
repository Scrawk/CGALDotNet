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
            Bounds = FindBounds();
        }

        public Point2i Point => Collection.GetPoint(StartPoint);

        public Box2i Bounds { get; private set; }

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
            return Collection.Comparer.Compare(Point, other.Point);
        }

        public int Compare(Point2i a, Point2i b)
        {
            return Collection.Comparer.Compare(a, b);
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

        public Line2d CreateLine()
        {
            Point2d p1, p2;

            if (Collection.Comparer.Axis == SWEEP.X)
            {
                p1 = Collection.ToPoint2d(Bounds.Corner00);
                p2 = Collection.ToPoint2d(Bounds.Corner01);
            }
            else
            {
                p1 = Collection.ToPoint2d(Bounds.Corner01);
                p2 = Collection.ToPoint2d(Bounds.Corner11);
            }

            return new Line2d(p1, p2);
        }

        private Box2i FindBounds()
        {
            var list = new List<Point2i>();
            list.Add(Point);

            for (int i = 0; i < EndPoints.Count; i++)
            {
                int b = EndPoints[i];
                var p = GetEndPoint(b);
                list.Add(p);
            }

            return Box2i.CalculateBounds(list);
        }

    }
}
