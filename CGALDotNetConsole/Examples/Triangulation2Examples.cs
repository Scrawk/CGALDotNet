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

            tri.SetIndices();
            tri.Print();
        }

        public static void TriangulatePolygon()
        {
            Console.WriteLine("Triangulate polygon example\n");

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

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Points " + points.Length);
            Console.WriteLine();

            for (int i = 0; i < points.Length; i++)
                Console.WriteLine("Point " + i + " = " + points[i]);

            var indices = new List<int>();
            tri.GetPolygonIndices(polygon, indices);

            int triangles = indices.Count / 3;

            Console.WriteLine();
            Console.WriteLine("Triangles " + triangles);
            Console.WriteLine();

            for (int i = 0; i < triangles; i++)
            {
                Console.WriteLine("Triangle = " + indices[i*3+0] + "," + indices[i * 3 + 1] + "," + indices[i * 3 + 2]);
            }
                
            Console.WriteLine();
        }

        public static void TriangulatePolygonWithHoles()
        {
            Console.WriteLine("Triangulate polygon with holes example\n");

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

            var tri = new Triangulation2<EEK>(pwh);

            tri.SetIndices();

            points = new Point2d[tri.VertexCount];
            tri.GetPoints(points);

            Console.WriteLine("Points " + points.Length);
            Console.WriteLine();

            for (int i = 0; i < points.Length; i++)
                Console.WriteLine("Point " + i + " = " + points[i]);

            var indices = new List<int>();
            tri.GetPolygonIndices(pwh, indices);

            int triangles = indices.Count / 3;

            Console.WriteLine();
            Console.WriteLine("Triangles " + triangles);
            Console.WriteLine();

            for (int i = 0; i < triangles; i++)
            {
                Console.WriteLine("Triangle = " + indices[i * 3 + 0] + "," + indices[i * 3 + 1] + "," + indices[i * 3 + 2]);
            }

            Console.WriteLine();
        }

    }

}
