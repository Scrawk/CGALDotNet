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
using CGALDotNet.Processing;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var param = CylinderParams.Default;

            var poly = PolyhedronFactory<EEK>.CreateTetrahedron();
            //poly.Triangulate();

            poly.Print();

            var primatives = poly.GetPrimativeCount();

            Console.WriteLine(primatives);

            return;

            if (primatives.triangleCount > 0)
            {
                var triangles = new int[primatives.triangleCount];
                poly.GetTriangleIndices(triangles, triangles.Length);

                Console.WriteLine("Triangles");

                for (int i = 0; i < triangles.Length / 3; i++)
                {
                    int i0 = triangles[i * 3 + 0];
                    int i1 = triangles[i * 3 + 1];
                    int i2 = triangles[i * 3 + 2];

                    Console.WriteLine(i0 + " " + i1 + " " + i2);
                }
            }

            if (primatives.quadCount > 0)
            {
                var quads = new int[primatives.quadCount];
                poly.GetQuadIndices(quads, quads.Length);

                Console.WriteLine("Quads");

                for (int i = 0; i < quads.Length / 3; i++)
                {
                    int i0 = quads[i * 4 + 0];
                    int i1 = quads[i * 4 + 1];
                    int i2 = quads[i * 4 + 2];
                    int i3 = quads[i * 4 + 3];

                    Console.WriteLine(i0 + " " + i1 + " " + i2 + " " + i3);
                }
            }

        }



    }
}
