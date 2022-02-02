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

            var cube1 = SurfaceMeshFactory<EEK>.CreateCube();
            cube1.Translate(new Point3d(-1, 0, 0));

            var cube2 = SurfaceMeshFactory<EEK>.CreateCube();
            cube2.Translate(new Point3d(1, 0, 0));

            cube1.Join(cube2);

            var pmesh = cube1.ToPolyhedronMesh();
            var smesh = cube1.Copy();

            pmesh.Print();
            smesh.Print();

            //ConnectedFaces(pmesh, smesh);
        }

        private static void UnconnectedComponents(Polyhedron3<EEK> pmesh, SurfaceMesh3<EEK> smesh)
        {
            var proc = PolygonMeshProcessingConnections<EEK>.Instance;
            //Console.WriteLine("Unconnected component PM = " + proc.UnconnectedComponents(pmesh));
            //Console.WriteLine("Unconnected component SM = " + proc.UnconnectedComponents(smesh));
        }

        private static void ConnectedFaces(Polyhedron3<EEK> pmesh, SurfaceMesh3<EEK> smesh)
        {
            var proc = PolygonMeshProcessingConnections<EEK>.Instance;

            var pfaces = new List<int>();
            proc.ConnectedFaces(pmesh, 0, pfaces);
            Console.WriteLine("Connected faces PM = " + pfaces.Count);

            var sfaces = new List<int>();
            proc.ConnectedFaces(smesh, 0, sfaces);
            Console.WriteLine("Connected faces SM = " + sfaces.Count);
        }

    }
}
