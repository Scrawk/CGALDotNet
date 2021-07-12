using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class Polygon2BooleanExamples
    {
        public static void IntersectExample()
        {
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
        }
    }
}
