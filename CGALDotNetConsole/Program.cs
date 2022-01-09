using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var box = new Box3d(-1, 1);
            var corners = box.GetCorners();

            var tri = new Triangulation3<EEK>(corners);

            tri.Print();

            PrintPoints(tri);
            //PrintSegments(tri);
            //PrintTriangles(tri);
            PrintTetrahedron(tri);
         
        }

        private static void PrintPoints(Triangulation3<EEK> tri)
        {
            Console.WriteLine("Points");

            int count = tri.VertexCount;
            var points = new Point3d[count];

            tri.GetPoints(points, count);

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i]);
            }
        }

        /*
        private static void PrintSegments(Triangulation3<EEK> tri)
        {
            Console.WriteLine("Segments");

            int count = tri.SegmentIndiceCount;
            var indices = new int[count];

            tri.GetSegmentIndices(indices, count);

            for (int i = 0; i < indices.Length / 2; i++)
            {
                int i0 = indices[i * 2 + 0];
                int i1 = indices[i * 2 + 1];

                Console.WriteLine(i0 + " " + i1);
            }
        }

        private static void PrintTriangles(Triangulation3<EEK> tri)
        {
            Console.WriteLine("Triangles");

            int count = tri.TriangleIndiceCount;
            var indices = new int[count];

            tri.GetTriangleIndices(indices, count);

            for (int i = 0; i < indices.Length / 3; i++)
            {
                int i0 = indices[i * 3 + 0];
                int i1 = indices[i * 3 + 1];
                int i2 = indices[i * 3 + 2];

                Console.WriteLine(i0 + " " + i1 + " " + i2);
            }
        }
        */

        private static void PrintTetrahedron(Triangulation3<EEK> tri)
        {
            Console.WriteLine("Tetrahedron");

            int count = tri.TetrahdronIndiceCount;
            var indices = new int[count];

            tri.GetTetrahedronIndices(indices, count);

            for (int i = 0; i < indices.Length / 4; i++)
            {
                int i0 = indices[i * 4 + 0];
                int i1 = indices[i * 4 + 1];
                int i2 = indices[i * 4 + 2];
                int i3 = indices[i * 4 + 3];

                Console.WriteLine(i0 + " " + i1 + " " + i2 + " " + i3);
            }
        }


    }
}
