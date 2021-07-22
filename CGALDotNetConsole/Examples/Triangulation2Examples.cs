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

        public static void GetPointsAndIndices()
        {
            Console.WriteLine("Get points and indices example\n");

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

        public static void GetVerticesAndFaces()
        {
            Console.WriteLine("Get vertices and faces example\n");

            var points = new Point2d[]
            {
                new Point2d(0, 0),
                new Point2d(5, 0),
                new Point2d(5, 5),
                new Point2d(2, 2),
                new Point2d(0, 5)
            };

            var tri = new Triangulation2<EEK>(points);

            var vertices = new TriVertex2[tri.VertexCount];
            tri.GetVertices(vertices);

            Console.WriteLine("Vertices " + vertices.Length);
            Console.WriteLine();

            for (int i = 0; i < vertices.Length; i++)
                Console.WriteLine(vertices[i]);

            var faces = new TriFace2[tri.FaceCount];
            tri.GetFaces(faces);

            Console.WriteLine();
            Console.WriteLine("Faces " + faces.Length);
            Console.WriteLine();

            for (int i = 0; i < faces.Length; i++)
                Console.WriteLine(faces[i]);

            Console.WriteLine();
        }

    }

}
