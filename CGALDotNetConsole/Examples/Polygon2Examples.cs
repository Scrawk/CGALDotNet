using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class Polygon2Examples
    {
        public static void CreateExample()
        {
            var points = new Point2d[]
            {
                new Point2d(0,0),
                new Point2d(5.1,0),
                new Point2d(1,1),
                new Point2d(0.5,6)
            };

            var polygon = new Polygon2_EIK(points);

            Console.WriteLine("Polygon = " + polygon);
            Console.WriteLine("Is simple = " + polygon.IsSimple());
            Console.WriteLine("Is convex = " + polygon.IsConvex());
            Console.WriteLine("Orientation = " + polygon.Orientation());
            Console.WriteLine("Signed Area = " + polygon.SignedArea());
            Console.WriteLine("Area = " + polygon.Area());

            Console.WriteLine("Point (0.0, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.0, 0.0)));
            Console.WriteLine("Point (0.5, 0.5) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));
            Console.WriteLine("Point (1.5, 2.5) is on the = " + polygon.OrientedSide(new Point2d(1.5, 2.5)));
            Console.WriteLine("Point (2.5, 0.0) is on the = " + polygon.OrientedSide(new Point2d(0.5, 0.5)));
        }
    }
}
