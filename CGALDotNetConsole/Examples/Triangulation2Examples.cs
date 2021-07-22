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

            var tri = new Triangulation2<EEK>(points);
            tri.Print();
        }

        public static void GetTriangulation()
        {
            Console.WriteLine("Get triangulation example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var tri = new Triangulation2<EEK>(points);

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Points " + points.Length);
            Console.WriteLine();

            for (int i = 0; i < points.Length; i++)
                Console.WriteLine("Point " + i + " = " + points[i]);

            var indices = new int[tri.IndiceCount];
            tri.GetIndices(indices);

            int triangles = indices.Length / 3;

            Console.WriteLine();
            Console.WriteLine("Triangles " + triangles);
            Console.WriteLine();

            for (int i = 0; i < triangles; i++)
            {
                Console.WriteLine("Triangle = " + indices[i*3+0] + "," + indices[i * 3 + 1] + "," + indices[i * 3 + 2]);
            }
                
            Console.WriteLine();
        }

    }

}
