using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;
using CGALDotNet.Polygons;

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
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var polygon = new Polygon2<EEK>(points);

            var tri = new Triangulation2<EEK>(polygon);

            tri.SetIndices();
            tri.Print();

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Triangulation Points.");
            Console.WriteLine();

            foreach (var p in points)
                Console.WriteLine(p.ToString());

            Console.WriteLine();

            var indices = new List<int>();
            tri.GetPolygonIndices(polygon, indices);

            Console.WriteLine("Count " + indices.Count);

            foreach (var i in indices)
                Console.WriteLine(i.ToString());

            Console.WriteLine();
        }

        public static void GetTrianglesExample()
        {
            Console.WriteLine("Get triangles example\n");

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
