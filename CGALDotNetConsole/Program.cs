using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.PolyHedra;
using CGALDotNet.Meshing;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var mesh = SurfaceMeshFactory<EEK>.CreateIcosahedron();

            mesh.Print();

            var count = mesh.VertexCount;
            var points = new Point3d[count];
            mesh.GetPoints(points, count);

            foreach(var p in points)
                Console.WriteLine(p);

        }


    }
}
