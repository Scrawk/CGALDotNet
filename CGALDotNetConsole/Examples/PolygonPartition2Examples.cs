using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNetConsole.Examples
{
    public static class PolygonPartition2Examples
    {

        public static void CreatePolygonPartition()
        {
            Console.WriteLine("Create polygon partition example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var polygon = new Polygon2<EEK>(points);

            var part = PolygonPartition2<EEK>.Instance;

            Console.WriteLine("Is Y monotonic " + part.Is_Y_Monotone(polygon));

            var results = new List<Polygon2<EEK>>();

            part.Partition(POLYGON_PARTITION.OPTIMAL_CONVEX, polygon, results);

            foreach(var poly in results)
            {
                poly.Print();
                Console.WriteLine("Is Y monotonic " + part.Is_Y_Monotone(poly) + "\n");
            }

        }
    }
}
