using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class Polygon2BooleanExamples
    {
        public static void DoIntersect()
        {
            Console.WriteLine("Do polygons intersect example\n");

            var points1 = new Point2d[]
            {
                new Point2d(-1, 1),
                new Point2d(0, -1),
                new Point2d(1, 1)
            };

            var points2 = new Point2d[]
            {
                new Point2d(-1, 1),
                new Point2d(1, -1),
                new Point2d(0, 1)
            };

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            Console.WriteLine("Polygons intersect = " + PolygonBoolean2.DoIntersect(polygon1, polygon2));

            Console.WriteLine();
        }

        public static void Join()
        {
            Console.WriteLine("Join polygons example\n");

            var points1 = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(3.5, 1.5),
                new Point2d(2.5, 0.5),
                new Point2d(1.5, 1.5)
            };

            var points2 = new Point2d[]
            {
                new Point2d(0, 2),
                new Point2d(1.5, 0.5),
                new Point2d(2.5, 1.5),
                new Point2d(3.5, 0.5),
                new Point2d(5, 2)
            };

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            var result = new List<PolygonWithHoles2_EEK>();

            Console.WriteLine("Polygons join = " + PolygonBoolean2.Join(polygon1, polygon2, result));
            Console.WriteLine("");

            foreach (var poly in result)
                poly.Print();

            Console.WriteLine("");
        }

        public static void Intersect()
        {
            Console.WriteLine("Intersect polygons example\n");

            var points1 = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(3.5, 1.5),
                new Point2d(2.5, 0.5),
                new Point2d(1.5, 1.5)
            };

            var points2 = new Point2d[]
            {
                new Point2d(0, 2),
                new Point2d(1.5, 0.5),
                new Point2d(2.5, 1.5),
                new Point2d(3.5, 0.5),
                new Point2d(5, 2)
            };

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            var result = new List<PolygonWithHoles2_EEK>();

            PolygonBoolean2.Intersect(polygon1, polygon2, result);

            foreach(var poly in result)
                poly.Print();

            Console.WriteLine("");
        }

        public static void Difference()
        {
            Console.WriteLine("Difference polygons example\n");

            var points1 = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(3.5, 1.5),
                new Point2d(2.5, 0.5),
                new Point2d(1.5, 1.5)
            };

            var points2 = new Point2d[]
            {
                new Point2d(0, 2),
                new Point2d(1.5, 0.5),
                new Point2d(2.5, 1.5),
                new Point2d(3.5, 0.5),
                new Point2d(5, 2)
            };

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            var result = new List<PolygonWithHoles2_EEK>();

            PolygonBoolean2.Difference(polygon1, polygon2, result);

            foreach (var poly in result)
                poly.Print();

            Console.WriteLine("");
        }

        public static void SymmetricDifference()
        {
            Console.WriteLine("Symmetric difference polygons example\n");

            var points1 = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(3.5, 1.5),
                new Point2d(2.5, 0.5),
                new Point2d(1.5, 1.5)
            };

            var points2 = new Point2d[]
            {
                new Point2d(0, 2),
                new Point2d(1.5, 0.5),
                new Point2d(2.5, 1.5),
                new Point2d(3.5, 0.5),
                new Point2d(5, 2)
            };

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            var result = new List<PolygonWithHoles2_EEK>();

            PolygonBoolean2.SymmetricDifference(polygon1, polygon2, result);

            foreach (var poly in result)
                poly.Print();

            Console.WriteLine("");
        }

        public static void Complement()
        {
            Console.WriteLine("Complement polygons example\n");

            var points = new Point2d[]
            {
                new Point2d(-5, -5),
                new Point2d(5, -5),
                new Point2d(5, 5),
                new Point2d(-5, 5)
            };

            var hole = new Point2d[]
            {
                new Point2d(-1, -1),
                new Point2d(-1, 1),
                new Point2d(1, 1),
                new Point2d(1, -1)
            };

            var polygon = new PolygonWithHoles2_EEK(points);
            polygon.AddHole(hole);

            var result = new List<PolygonWithHoles2_EEK>();

            PolygonBoolean2.Complement(polygon, result);

            foreach (var poly in result)
                poly.Print();

            Console.WriteLine("");
        }

    }
}
