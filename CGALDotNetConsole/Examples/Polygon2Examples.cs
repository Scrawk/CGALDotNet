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

            var polygon = new Polygon2<EEK>(points);
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

            var polygon = new Polygon2<EEK>(points);
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

            var polygon = new Polygon2<EEK>(points);
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

            var polygon = new Polygon2<EEK>(points);
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

            var polygon = new Polygon2<EEK>(points);

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

            var pwh = new PolygonWithHoles2<EEK>(bounds);
            pwh.AddHole(new Polygon2<EEK>(points));
            pwh.Print();

            Console.WriteLine();
        }

        public static void PolygonWithHolesContainsPoint()
        {
            Console.WriteLine("Polygon with holes contains point example\n");

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

            var pwh = new PolygonWithHoles2<EEK>(bounds);
            var hole = new Polygon2<EEK>(points);
            pwh.AddHole(hole);

            pwh.Print();

            Console.WriteLine("Contains point (0.0, 0.0) = " + pwh.ContainsPoint(new Point2d(0.0, 0.0)));
            Console.WriteLine("Contains point (9, 9) = " + pwh.ContainsPoint(new Point2d(9, 9)));
            Console.WriteLine("Contains point (11, 11) = " + pwh.ContainsPoint(new Point2d(11, 11)));
            Console.WriteLine("Contains point (-5, -5) = " + pwh.ContainsPoint(new Point2d(-5, -5)));
            Console.WriteLine("Contains point (-10, -10) = " + pwh.ContainsPoint(new Point2d(-10, -10)));

            Console.WriteLine();
        }

        public static void TransformPolygon()
        {
            Console.WriteLine("Transform polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(-1, -1),
                new Point2d(1, -1),
                new Point2d(1, 1),
                new Point2d(-1, 1)
            };

            var polygon = new PolygonWithHoles2<EEK>(points);

            var op = POLYGON_ELEMENT.BOUNDARY;

            Console.WriteLine("Before transform");
            foreach (var p in polygon.Copy(op))
                Console.WriteLine(p);

            polygon.Transform(op, new Point2d(1,1), Degree.A180, 2);

            Console.WriteLine("After transform");
            foreach (var p in polygon.Copy(op))
                Console.WriteLine(p);
            
        }

        public static void SimplifyPolygon()
        {
            Console.WriteLine("Compute visibility example\n");

            var polygon = PolygonFactory<EEK>.FromBox(-5, 5);
            //polygon.Print();

            var visibility = PolygonVisibility2<EEK>.Instance.ComputeVisibility(polygon, new Point2d(0, 0));

            if (visibility != null)
            {
                
                visibility.Print();

                var points = new Point2d[4];
                polygon.GetPoints(points);

                foreach (var p in points)
                    Console.WriteLine(p);

            }
        }
    }
}
