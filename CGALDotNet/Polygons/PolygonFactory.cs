using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Circular;
using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// Factory for creating polygons.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public static class PolygonFactory<K> where K : CGALKernel, new()
    {

        /// <summary>
        /// Create a empty polygon.
        /// </summary>
        /// <returns></returns>
        public static Polygon2<K> Create()
        {
            var poly = new Polygon2<K>();
            return poly;
        }

        /// <summary>
        /// Create a polygon from a triangle.
        /// </summary>
        /// <param name="tri">The triangle.</param>
        /// <returns>The created polygon.</returns>
        public static Polygon2<K> FromTriangle(Point2d a, Point2d b, Point2d c)
        {
            var points = new Point2d[] { a, b, c };
            var poly = new Polygon2<K>(points);

            return poly;
        }

        /// <summary>
        /// Create a polygon from a triangle.
        /// </summary>
        /// <param name="tri">The triangle.</param>
        /// <returns>The created polygon.</returns>
        public static Polygon2<K> FromTriangle(Triangle2d tri)
        {
            var points = new Point2d[] { tri.A, tri.B, tri.C };
            var poly = new Polygon2<K>(points);

            return poly;
        }

        /// <summary>
        /// Create a polygon from a box.
        /// </summary>
        /// <param name="min">The boxs min point.</param>
        /// <param name="max">The boxs max point.</param>
        /// <returns>The created polygon.</returns>
        public static Polygon2<K> FromBox(Point2d min, Point2d max)
        {
            var box = new Box2d(min, max);
            return FromBox(box);
        }

        /// <summary>
        /// Create a polygon from a box.
        /// </summary>
        /// <param name="min">The boxs min point.</param>
        /// <param name="max">The boxs max point.</param>
        /// <returns>The created polygon.</returns>
        public static Polygon2<K> FromBox(double min, double max)
        {
            var box = new Box2d(min, max);
            return FromBox(box);
        }

        /// <summary>
        /// Create a polygon from a box.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <returns>The created polygon.</returns>
        public static Polygon2<K> FromBox(Box2d box)
        {
            var points = box.GetCorners();
            var poly = new Polygon2<K>(points);

            return poly;
        }

        /// <summary>
        /// Create a polygon from a dounut.
        /// Outer radius must be greater than inner.
        /// </summary>
        /// <param name="outer">The outer radius.</param>
        /// <param name="inner">The inner radius</param>
        /// <param name="segments">The number of segments.</param>
        /// <returns>The created polygon with holes</returns>
        public static PolygonWithHoles2<K> FromDounut(double outer, double inner, int segments)
        {
            var poly = FromDounut(Point2d.Zero, outer, inner, segments);

            return poly;
        }


        /// <summary>
        /// Create a polygon from a dounut.
        /// Outer radius must be greater than inner.
        /// </summary>
        /// <param name="center">The center position of the polygon.</param>
        /// <param name="outer">The outer radius.</param>
        /// <param name="inner">The inner radius</param>
        /// <param name="segments">The number of segments.</param>
        /// <returns>The created polygon with holes</returns>
        public static PolygonWithHoles2<K> FromDounut(Point2d center, double outer, double inner, int segments)
        {
            var boundary = FromCircle(new Circle2d(center, outer), segments);
            var pwh = new PolygonWithHoles2<K>(boundary);

            if (inner < outer)
            {
                var hole = FromCircle(new Circle2d(center, inner), segments);

                hole.Reverse();
                pwh.AddHole(hole);
            }

            return pwh;
        }

        /// <summary>
        /// Create a polygon from a circle.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="segments">The number of segments.</param>
        /// <returns>The polygon.</returns>
        public static Polygon2<K> FromCircle(double radius, int segments)
        {
            return FromCircle(new Circle2d(Point2d.Zero, radius), segments);
        }

        /// <summary>
        /// Create a polygon from a circle.
        /// </summary>
        /// <param name="center">The center of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="segments">The number of segments.</param>
        /// <returns></returns>
        public static Polygon2<K> FromCircle(Point2d center, double radius, int segments)
        {
            return FromCircle(new Circle2d(center, radius), segments);
        }

        /// <summary>
        /// Create a polygon from a circle.
        /// </summary>
        /// <param name="circle">The cirlce.</param>
        /// <param name="segments">The number of segments.</param>
        /// <returns></returns>
        public static Polygon2<K> FromCircle(Circle2d circle, int segments)
        {
            segments = Math.Max(3, segments);

            double pi = Math.PI;
            var points = new Point2d[segments];

            double rotate = Rotation(segments);

            for (int i = 0; i < segments; i++)
            {
                double theta = 2.0 * pi * i / segments + rotate;

                double x = -circle.Radius * Math.Cos(theta);
                double y = -circle.Radius * Math.Sin(theta);

                points[i] = circle.Center + new Point2d(x, y);
            }

            var poly = new Polygon2<K>(points);

            return poly;
        }

        private static double Rotation(int segments)
        {
            return (((segments - 2) * 180) / segments) * CGALGlobal.DEG_TO_RAD * 0.5;
        }

        /// <summary>
        /// https://rosettacode.org/wiki/Koch_curve#C.2B.2B
        /// </summary>
        /// <param name="size"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static Polygon2<K> KochStar(double size, int iterations)
        {
            var poly = KochStar(Point2d.Zero, size, iterations);

            return poly;
        }

        /// <summary>
        /// https://rosettacode.org/wiki/Koch_curve#C.2B.2B
        /// </summary>
        /// <param name="size"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static Polygon2<K> KochStar(Point2d center, double size, int iterations)
        {
            double sqrt3_2 = Math.Sqrt(3) / 2.0;
            double length = size * sqrt3_2 * 0.95;

            double x = (size - length) / 2.0;
            double y = size / 2.0 - length * sqrt3_2 / 3.0;

            var points = new List<Point2d>(4);

            points.Add(new Point2d(x, y));
            points.Add(new Point2d(x + length / 2, y + length * sqrt3_2));
            points.Add(new Point2d(x + length, y));
            points.Add(new Point2d(x, y));

            for (int i = 0; i < iterations; ++i)
                points = KochNext(points);

            int last = points.Count - 1;
            points.RemoveAt(last);
            points.Reverse();

            var offset = center + new Point2d(size / 2);
            for (int i = 0; i < points.Count; ++i)
                points[i] -= offset;
            
            return new Polygon2<K>(points.ToArray());
        }

        /// <summary>
        /// https://rosettacode.org/wiki/Koch_curve#C.2B.2B
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static List<Point2d> KochNext(List<Point2d> points)
        {
            double sqrt3_2 = Math.Sqrt(3) / 2.0;
            int size = points.Count;
            var output = new List<Point2d>(4 * (size - 1) + 1);

            double x0 = 0, y0 = 0, x1 = 0, y1 = 0;

            for (int i = 0; i + 1 < size; ++i)
            {
                x0 = points[i].x;
                y0 = points[i].y;
                x1 = points[i + 1].x;
                y1 = points[i + 1].y;
                double dy = y1 - y0;
                double dx = x1 - x0;

                output.Add(new Point2d(x0, y0));
                output.Add(new Point2d(x0 + dx / 3.0, y0 + dy / 3.0));
                output.Add(new Point2d(x0 + dx / 2.0 - dy * sqrt3_2 / 3, y0 + dy / 2.0 + dx * sqrt3_2 / 3.0));
                output.Add(new Point2d(x0 + 2.0 * dx / 3.0, y0 + 2.0 * dy / 3.0));
            }

            output.Add(new Point2d(x1, y1));

            return output;
        }

    }
}
