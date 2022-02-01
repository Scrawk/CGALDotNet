using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

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

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var pmesh = PolyhedronFactory<EEK>.CreateCube();
            var smesh = SurfaceMeshFactory<EEK>.CreateIcosahedron();

            Console.WriteLine("before");
            foreach (var point in pmesh)
                Console.WriteLine(point);

            var points = new Point3d[pmesh.VertexCount];

            for (int i = 0; i < pmesh.VertexCount; i++)
            {
                points[i] = new Point3d(1, 2, 3);
                //pmesh.SetPoint(i, new Point3d(1, 2, 3));
            }

            pmesh.SetPoints(points, points.Length);

            Console.WriteLine("before");
            foreach (var point in pmesh)
                Console.WriteLine(point);

        }

    }
}
