using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class Polygon2Examples
    {
        public static void CreatePolygon()
        {
            Console.WriteLine("Create polygon example\n");

            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var polygon = new Polygon2_EIK(points);

            Print(polygon);

            Console.WriteLine("Point (0.0, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.0, 0.0)));
            Console.WriteLine("Point (0.5, 0.5) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));
            Console.WriteLine("Point (1.5, 2.5) is on the = " + polygon.OrientedSide(new Point2d(1.5, 2.5)));
            Console.WriteLine("Point (2.5, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));

            Console.WriteLine();
        }

        public static void CreatePolygonWithHoles()
        {
            Console.WriteLine("Create polygon holes example\n");

            var bounds = new Point2d[]
            {
                new Point2d(-10,-10),
                new Point2d(10,-10),
                new Point2d(10,10),
                new Point2d(-10,10)
            };

            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var pwh = new PolygonWithHoles2(bounds);

            pwh.AddHole(points);
            Print(pwh);

            Console.WriteLine();
        }

        private static void Print(PolygonWithHoles2 pwh)
        {
            Console.WriteLine(pwh);
            Console.WriteLine("Is Unbounded = " + pwh.IsUnbounded());
            Console.WriteLine("Is simple = " + pwh.BoundaryIsSimple());
            Console.WriteLine("Is convex = " + pwh.BoundaryIsConvex());
            Console.WriteLine("Is orientation = " + pwh.BoundaryOrientation());
            Console.WriteLine("Is signed area = " + pwh.BoundarySignedArea());

            for (int i = 0; i < pwh.HoleCount; i++)
            {
                Console.WriteLine("Hole " + i);
                Console.WriteLine("Is simple = " + pwh.HoleIsSimple(i));
                Console.WriteLine("Is convex = " + pwh.HoleIsConvex(i));
                Console.WriteLine("Is orientation = " + pwh.HoleOrientation(i));
                Console.WriteLine("Is signed area = " + pwh.HoleSignedArea(i));

                Console.WriteLine();
            }

        }

        private static void Print(Polygon2 polygon)
        {
            Console.WriteLine(polygon);
            Console.WriteLine("Is simple = " + polygon.IsSimple());
            Console.WriteLine("Is convex = " + polygon.IsConvex());
            Console.WriteLine("Orientation = " + polygon.Orientation());
            Console.WriteLine("Signed Area = " + polygon.SignedArea());
            Console.WriteLine("Area = " + polygon.Area());
        }
    }
}
