using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGeom2D.Numerics;
using CGeom2D.Geometry;

namespace CGeom2D.Points
{
    public class PointCollection : IEnumerable<Point2i>
    {

        private enum BETWEEN_ORDER
        {
            NONE, ABC, ACB
        }

        public PointCollection(double scale) :
            this(new SweepComparer(SWEEP.X), Point2i.Zero, scale)
        {

        }

        public PointCollection(SweepComparer comparer, double scale) :
            this(comparer, Point2i.Zero, scale)
        {

        }

        public PointCollection(SweepComparer comparer, Point2i origin, double scale)
        {
            Comparer = comparer;
            Origin = origin;
            Scale = scale;
            InvScale = 1.0 / Scale;
            Points = new List<Point2i>();
        }

        public int PointCount => Points.Count;

        public Point2i Origin { get; private set; }

        public double Scale { get; private set; }

        public double InvScale { get; private set; }

        public SweepComparer Comparer { get; private set; }

        private List<Point2i> Points { get; set; }

        private List<int>[] Segments { get; set; }

        public void Clear()
        {
            Points.Clear();
            Segments = null;
        }

        public IEnumerator<Point2i> GetEnumerator()
        {
            foreach (var point in Points)
                yield return point;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point2i GetPoint2i(int i)
        {
            return Points[i];
        }

        public Point2d GetPoint2d(int i)
        {
            return ToPoint2d(Points[i]);
        }

        public void AddPoint(double x, double y)
        {
            Points.Add(ToPoint2i(new Point2d(x, y)));
        }

        public void AddPoint(Point2d point)
        {
            Points.Add(ToPoint2i(point));
        }

        public Point2i ToPoint2i(Point2d point)
        {
            Int128 x = new Int128(point.x * Scale) - Origin.x;
            Int128 y = new Int128(point.y * Scale) - Origin.y;

            return new Point2i(x, y);
        }

        public Point2d ToPoint2d(Point2i point)
        {
            double x = (double)Origin.x + (double)point.x * InvScale;
            double y = (double)Origin.y + (double)point.y * InvScale;

            return new Point2d(x, y);
        }

        public void RandomFill(int count, int seed, double range)
        {
            var rnd = new Random(seed);

            for(int i = 0; i < count; i++)
            {
                double x = rnd.NextDouble(-range, range);
                double y = rnd.NextDouble(-range, range);

                var point = new Point2d(x, y);
                Points.Add(ToPoint2i(point));
            }

        }

        public bool ContainsSegment(int a, int b)
        {
            if (Segments == null)
                return false;

            var list = Segments[a];
            if (list == null || list.Count == 0)
                return false;

            return list.Contains(b);
        }

        public bool RemoveSegment(int a, int b)
        {
            if (Segments == null)
                return false;

            var list = Segments[a];
            if (list == null || list.Count == 0) 
                return false;

            return list.Remove(b);
        }

        public void AddSegment(int a, int b)
        {
            if (Segments == null)
                Segments = new List<int>[PointCount];

            var comparision = Comparer.Comparison(GetPoint2i(a), GetPoint2i(b));

            if (comparision == COMPARISON.EQUAL) 
                return;
            else if(comparision == COMPARISON.LARGER)
                MathUtil.Swap(ref a, ref b);

            var list = new List<int>();
            FindBetweenOrder(a, b, list);

            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count / 2; i++)
                {
                    int A = list[i * 2 + 0];
                    int B = list[i * 2 + a];
                    TryAddSegment(A, B);
                }
            }
            else
            {
                TryAddSegment(a, b);
            }

            /*
            var order = FindBetweenOrder(a, b, out int c);

            if (order == BETWEEN_ORDER.NONE)
            {
                TryAddSegment(a, b);
            }
            else
            {
                if (order == BETWEEN_ORDER.ABC)
                {
                    TryAddSegment(a, b);
                    TryAddSegment(b, c);
                }
                else
                {
                    TryAddSegment(a, c);
                    TryAddSegment(c, b);
                }
            }
         */
        }

        private void TryAddSegment(int a, int b)
        {
            if (Segments[a] == null)
                Segments[a] = new List<int>();

            if (!Segments[a].Contains(b))
                Segments[a].Add(b);
        }

        public void GetPoints(List<Point2d> points)
        {
            foreach (var point in Points)
                points.Add(ToPoint2d(point));
        }

        public void GetPoints(List<Point2i> points)
        {
            foreach (var point in Points)
                points.Add(point);
        }

        public void GetSegments(List<int> indices)
        {
            for (int a = 0; a < Segments.Length; a++)
            {
                var list = Segments[a];
                if (list == null || list.Count == 0) continue;

                for (int j = 0; j < list.Count; j++)
                    indices.Add(a, list[j]);
            }
        }

        public void GetSegments(Dictionary<int, List<Segment2d>> table)
        {
            for (int a = 0; a < Segments.Length; a++)
            {
                var list = Segments[a];
                if (list == null || list.Count == 0) continue;

                var segments = new List<Segment2d>(list.Count);
                var A = ToPoint2d(GetPoint2i(a));

                for (int j = 0; j < list.Count; j++)
                {
                    int b = list[j];
                    var B = ToPoint2d(GetPoint2i(b));
                    segments.Add(new Segment2d(A, B));
                }

                table.Add(a, segments);
            }
        }

        public SweepLine CreateSweepLine()
        {
            var line = new SweepLine();

            for(int a = 0; a < Segments.Length; a++)
            {
                var list = Segments[a];
                if (list == null || list.Count == 0) continue;

                var e = new SweepEvent(this, a, new List<int>(list));
                line.AddEvent(e);
            }
                
            return line;
        }

        private BETWEEN_ORDER FindBetweenOrder(int a, int b, out int c)
        {
            c = -1;
            var list = Segments[a];
            if (list == null || list.Count == 0) 
                return BETWEEN_ORDER.NONE;

            var A = GetPoint2i(a);
            var B = GetPoint2i(b);

            for (int i = 0; i < list.Count; i++)
            {
                c = list[i];
                var C = GetPoint2i(c);

                if (Predicates.Between(A, B, C))
                    return BETWEEN_ORDER.ABC;

                if (Predicates.Between(A, C, B))
                    return BETWEEN_ORDER.ACB;
            }

            return BETWEEN_ORDER.NONE;
        }

        private void FindBetweenOrder(int a, int b, List<int> results)
        {
            var list = Segments[a];
            if (list == null || list.Count == 0)
                return;

            var A = GetPoint2i(a);
            var B = GetPoint2i(b);

            for (int i = 0; i < list.Count; i++)
            {
                var c = list[i];
                var C = GetPoint2i(c);

                if (Predicates.Between(A, B, C))
                {
                    results.Add(a, b);
                    results.Add(b, c);
                }
                else if (Predicates.Between(A, C, B))
                {
                    results.Add(a, c);
                    results.Add(c, b);
                }
            }

        }

    }
}
