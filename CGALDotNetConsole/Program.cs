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

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var mesh = SurfaceMeshFactory<EEK>.CreateCube();

            var copy = mesh.Copy();
            copy.Translate(new Point3d(10, 0, 0));

            mesh.Join(copy);

            var count = PolygonMeshProcessingConnections<EEK>.Instance.UnconnectedComponents(mesh);

            Console.WriteLine(count);
        }

     

    }
}
