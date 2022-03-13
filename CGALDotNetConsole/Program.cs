using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNetGeometry.Extensions;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Polylines;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Processing;
using CGALDotNet.Extensions;
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var points = Point3d.RandomPoints(0, 10, new Box3f(-10, 10));
            points.Round(2);

            var tri = new DelaunayTriangulation3<EEK>(points);

            tri.Print();

            var vertices = new TriVertex3[tri.VertexCount];
            tri.GetVertices(vertices, vertices.Length);

            var cells = new TriCell3[tri.TetrahedronCount];
            tri.GetCells(cells, cells.Length);

            var segments = new int[tri.EdgeCount * 2];
            tri.GetSegmentIndices(segments, segments.Length);

            var triangles = new int[tri.TriangleCount * 3];
            tri.GetTriangleIndices(triangles, triangles.Length);

            Console.WriteLine("");
            Console.WriteLine("vertices");

            foreach (var v in vertices)
                Console.WriteLine(v);

            Console.WriteLine("");
            Console.WriteLine("cells");

            foreach (var c in cells)
                Console.WriteLine(c);

            Console.WriteLine("");
            Console.WriteLine("segments");
            for (int i = 0; i < segments.Length / 2; i++)
            {
                int i0 = segments[i * 2 + 0];
                int i1 = segments[i * 2 + 1];

                Console.WriteLine(i0 + " " + i1);
            }

            Console.WriteLine("");
            Console.WriteLine("Triangles");
            for (int i = 0; i < triangles.Length / 3; i++)
            {
                int i0 = triangles[i * 3 + 0];
                int i1 = triangles[i * 3 + 1];
                int i2 = triangles[i * 3 + 2];

                Console.WriteLine(i0 + " " + i1 + " " + i2);
            }


            Console.WriteLine("");

            tri.GetVertex(1, out TriVertex3 vert);

            Console.WriteLine(vert);

        }


    }
}
