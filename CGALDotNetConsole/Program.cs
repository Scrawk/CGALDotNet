using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int width = 20;
            int height = 20;
            int radius = 2;
            int samples = 1000;

            var points = CreateBoundaryPoints(width, height, radius);
            FillPoints(points, width, height, radius, samples);
            ExpandPoints(points, width, height, radius);
            TranslatePoints(points, width, height);

            var triangulation = new DelaunayTriangulation2<EEK>();
            triangulation.InsertPoints(points.ToArray());

            var rays = triangulation.GetVoronoiRays();
            var segments = triangulation.GetVoronoiSegments();

            Console.WriteLine("Rays = " + rays.Length);
            foreach (var ray in rays)
                Console.WriteLine(ray);

            Console.WriteLine("Segments = " + segments.Length);
            foreach (var segment in segments)
                Console.WriteLine(segment);

            
        }

        private static List<Point2d> CreateBoundaryPoints(int width, int height, int radius)
        {
            var points = new List<Point2d>();

            points.Add(new Point2d(0, 0));
            points.Add(new Point2d(width, 0));
            points.Add(new Point2d(0, height));
            points.Add(new Point2d(width, height));

            for (int i = radius; i <= width - radius; i += radius)
            {
                points.Add(new Point2d(i, 0));
                points.Add(new Point2d(i, width));

                points.Add(new Point2d(0, i));
                points.Add(new Point2d(width, i));
            }

            return points;
        }

        private static void FillPoints(List<Point2d> points, int width, int height, double radius, int samples)
        {
            var rnd = new System.Random(0);

            for (int i = 0; i < samples; i++)
            {
                var point = new Point2d();
                point.x = rnd.NextDouble() * width;
                point.y = rnd.NextDouble() * height;

                if (!WithInRadius(point, points, radius))
                {
                    points.Add(point);
                }
            }
        }

        private static List<Point2d> ExpandPoints(List<Point2d> points, int width, int height, int radius)
        {
            points.Add(new Point2d(-radius, -radius));
            points.Add(new Point2d(width + radius, -radius));
            points.Add(new Point2d(-radius, height + radius));
            points.Add(new Point2d(width + radius, height + radius));

            for (int i = 0; i <= width; i += radius)
            {
                points.Add(new Point2d(i, -radius));
                points.Add(new Point2d(i, width + radius));

                points.Add(new Point2d(-radius, i));
                points.Add(new Point2d(width + radius, i));
            }

            return points;
        }

        private static bool WithInRadius(Point2d point, List<Point2d> points, double radius)
        {
            double radius2 = radius * radius;
            foreach (var p in points)
            {
                if (Point2d.SqrDistance(point, p) < radius2)
                    return true;
            }

            return false;
        }

        private static void TranslatePoints(List<Point2d> points, int width, int height)
        {
            var translate = new Point2d(width * 0.5, height * 0.5);
            for (int i = 0; i < points.Count; i++)
                points[i] = points[i] - translate;
        }


    }
}
