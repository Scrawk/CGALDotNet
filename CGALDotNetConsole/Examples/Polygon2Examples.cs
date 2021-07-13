using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class Polygon2Examples
    {
        public static void CreateSimplePolygon()
        {
            Console.WriteLine("Create simple polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(0, 5)
            };

            var polygon = new Polygon2_EEK(points);
            polygon.Print();
        }

        public static void CreateRelativelySimplePolygon()
        {
            Console.WriteLine("Create relatively simple polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(4, 0),
                new Point2d(8, 0),
                new Point2d(8, 4),
                new Point2d(4, 0),
                new Point2d(0, 4),
            };

            var polygon = new Polygon2_EEK(points);
            polygon.Print();
        }

        public static void CreateConcavePolygon()
        {
            Console.WriteLine("Create concave polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var polygon = new Polygon2_EEK(points);
            polygon.Print();
        }

        public static void CreateNonSimplePolygon()
        {
            Console.WriteLine("Create non simple polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(8, 4),
                new Point2d(8, 0),
                new Point2d(0, 4),
            };

            var polygon = new Polygon2_EEK(points);
            polygon.Print();
        }

        public static void PolygonContainsPoint()
        {
            Console.WriteLine("Polygon contains point example\n");

            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var polygon = new Polygon2_EEK(points);

            Console.WriteLine("Point (0.0, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.0, 0.0)));
            Console.WriteLine("Point (0.5, 0.5) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));
            Console.WriteLine("Point (1.5, 2.5) is on the = " + polygon.OrientedSide(new Point2d(1.5, 2.5)));
            Console.WriteLine("Point (2.5, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));

            Console.WriteLine("Contains point (0.0, 0.0) = " + polygon.ContainsPoint(new Point2d(0.0, 0.0)));
            Console.WriteLine("Contains point (0.5, 0.5) = " + polygon.ContainsPoint(new Point2d(0.5, 0.5)));
            Console.WriteLine("Contains point (1.5, 2.5) = " + polygon.ContainsPoint(new Point2d(1.5, 2.5)));
            Console.WriteLine("Contains point (2.5, 0.0) = " + polygon.ContainsPoint(new Point2d(0.5, 0.5)));
        }

        public static void CreatePolygonWithHoles()
        {
            Console.WriteLine("Create polygon with holes example\n");

            var bounds = new Point2d[]
            {
                new Point2d(-10,-10),
                new Point2d(10,-10),
                new Point2d(10,10),
                new Point2d(-10,10)
            };

            var points = new Point2d[]
            {
                new Point2d(-5,-5),
                new Point2d(-5,5),
                new Point2d(5,5),
                new Point2d(5,-5)
            };

            var pwh = new PolygonWithHoles2_EEK(new Polygon2_EEK(bounds));
            pwh.AddHole(new Polygon2_EEK(points));

            pwh.Print();

            Console.WriteLine();
        }
    }
}
