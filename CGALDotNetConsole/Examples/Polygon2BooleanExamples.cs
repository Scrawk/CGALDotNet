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

            /*
            points2 = new Point2d[]
            {
                new Point2d(9, 1),
                new Point2d(11, -1),
                new Point2d(10, 1)
            };
            */

            var polygon1 = new Polygon2_EEK(points1);
            var polygon2 = new Polygon2_EEK(points2);

            PolygonWithHoles2 result;

            Console.WriteLine("Polygons join = " + PolygonBoolean2.Join(polygon1, polygon2, out result));

            Print(result);

            Console.WriteLine("");
        }

        private static void Print(PolygonWithHoles2 pwh)
        {
            Console.WriteLine(pwh);
            Console.WriteLine("Is Unbounded = " + pwh.IsUnbounded());
        }
    }
}
