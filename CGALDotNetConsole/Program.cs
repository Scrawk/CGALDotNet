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


        static void Main(string[] args)
        {
    
            var mesh = PolyhedronFactory<EEK>.CreateCube(1);

            Console.WriteLine("");
            foreach (var p in mesh)
                Console.WriteLine(p);

            mesh.Subdivide(1);

            Console.WriteLine("");
            foreach (var p in mesh)
                Console.WriteLine(p.Rounded(2));

            var points2 = new Point3d[mesh.VertexCount];
            mesh.GetPoints(points2, points2.Length);

            Console.WriteLine("");
            foreach (var p in points2)
                Console.WriteLine(p.Rounded(2));

        }


    }
}
