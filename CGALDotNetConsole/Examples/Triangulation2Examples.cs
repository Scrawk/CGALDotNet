using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;

namespace CGALDotNetConsole.Examples
{
    public static class Triangulation2Examples
    {

        public static void CreateTriangulation()
        {
            Console.WriteLine("Create triangulation example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(4, 0),
                new Point2d(0, 4)
            };

            var tri = new Triangulation2<EEK>(points);
            tri.Print();
        }

        public static void GetGeometryExample()
        {
            Console.WriteLine("Get geometry example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(0, 4),
                new Point2d(4, 0)
            };

            var tri = new Triangulation2<EEK>(points);

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Triangulation Points.");
            Console.WriteLine();

            foreach (var p in points)
                Console.WriteLine(p.ToString());
        }

    }

}
