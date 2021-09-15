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
                //new Point2d(5, 5),
                //new Point2d(2, 2),
                //new Point2d(0, 5)
            };

            var tri = new Triangulation2<EEK>(points);
            tri.Print();

            //if (tri.FlipEdge(0, 1))
            //    Console.WriteLine("Flipped face edge");

            var vertices = new TriVertex2[tri.VertexCount];
            tri.GetVertices(vertices);

            Console.WriteLine("Vertices " + vertices.Length);
            Console.WriteLine();

            for (int i = 0; i < vertices.Length; i++)
                Console.WriteLine(vertices[i]);

            Console.WriteLine();

            //TriVertex2 vert;
            //if (tri.GetVertex(3, out vert))
            //    Console.WriteLine("Get Vert 3 = " + vert);

            var faces = new TriFace2[tri.TriangleCount];
            tri.GetFaces(faces);

            Console.WriteLine();
            Console.WriteLine("Faces " + faces.Length);
            Console.WriteLine();

            for (int i = 0; i < faces.Length; i++)
                Console.WriteLine(faces[i]);

            Console.WriteLine();

            /*
            TriFace2 face;
            if (tri.GetFace(2, out face))
                Console.WriteLine("Get Face 2 = " + face);

            if (tri.LocateFace(new Point2d(1, 1), out face))
                Console.WriteLine("Locate face = " + face);

            if(tri.MoveVertex(0, new Point2d(-1,-1), true, out vert))
                Console.WriteLine("Move vert 0 = " + vert);

            if(tri.RemoveVertex(0))
                Console.WriteLine("Remove vertex = " + tri);
            */

            Console.WriteLine();
        }

    }

}
