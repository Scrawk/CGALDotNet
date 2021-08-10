using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGeom2D.Numerics;
using CGeom2D.Sweep;

namespace CGeom2D.Geometry
{
    public class PointCollection : IEnumerable<Point2i>
    {

        public PointCollection(Point2i origin, double scale)
        {
            Origin = origin;
            Scale = scale;
            InvScale = 1.0 / Scale;
            Points = new List<Point2i>();
        }

        public int PointCount => Points.Count;

        public Point2i Origin { get; private set; }

        public double Scale { get; private set; }

        public double InvScale { get; private set; }

        private List<Point2i> Points { get; set; }

        public void Clear()
        {
            Points.Clear();
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

        public IEnumerator<Point2i> GetEnumerator()
        {
            foreach (var point in Points)
                yield return point;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ToList(List<Point2d> points)
        {
            foreach (var point in Points)
                points.Add(ToPoint2d(point));
        }

        public void ToList(List<Point2i> points)
        {
            foreach (var point in Points)
                points.Add(point);
        }

        public SweepLine CreateSweepLine()
        {
            var line = new SweepLine();

            foreach(var point in Points)
                line.Add(new SweepEvent(point));

            return line;
        }
    }
}
