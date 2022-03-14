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

            Tri3Test();
        }

        private static void Tri3Test()
        {
            var box = new Box3d(-20, 20);
            var randomPoints = Point3d.RandomPoints(1, 10, box);

            var m_triangulation = new DelaunayTriangulation3<EEK>(randomPoints);

            m_triangulation.Print();

            var points = new Point3d[m_triangulation.VertexCount];
            m_triangulation.GetPoints(points, points.Length);
            points.Round(2);

            var verts = new TriVertex3[m_triangulation.VertexCount];
            m_triangulation.GetVertices(verts, verts.Length);
            verts.Round(2);

            var segments = new int[m_triangulation.EdgeCount * 2];
            m_triangulation.GetSegmentIndices(segments, segments.Length);

            Console.WriteLine("Segments = " + segments.Length);

            foreach (var p in points)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("");

            foreach (var v in verts)
            {
                Console.WriteLine(v);
            }

            int edges = 0;

            for (int i = 0; i < segments.Length / 2; i++)
            {
                int A = segments[i * 2 + 0];
                int B = segments[i * 2 + 1];

                Console.WriteLine("Create edge " + A + " " + B);

                if (A < 0 || A >= points.Length)
                {
                    //Console.WriteLine("A is out of bounds");
                    continue;
                }

                if (B < 0 || B >= points.Length)
                {
                    //Console.WriteLine("B is out of bounds");
                    continue;
                }

                var a = points[A];
                var b = points[B];

                if (!a.IsFinite)
                {
                    //Console.WriteLine("a is not finite");
                    //Console.WriteLine(a);
                    continue;
                }

                if (!b.IsFinite)
                {
                    //Console.WriteLine("b is not finite");
                    //Console.WriteLine(b);
                    continue;
                }

                edges++;

                Console.WriteLine("Create edge " + a + " " + b);
            }

            Console.WriteLine("Created " + edges + " edges)");
        }


    }
}
