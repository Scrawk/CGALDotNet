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

            var pmesh = PolyhedronFactory<EEK>.CreateCube();
            var smesh = SurfaceMeshFactory<EEK>.CreateCube();

            smesh.Print();
            //smesh.RemoveFace(3);

            var fea = PolygonMeshProcessingFeatures<EEK>.Instance;
 
            var results = new List<int>();
            fea.SharpEdgesSegmentation(smesh, Degree.A90);

            //results.Sort();
            //foreach(var i in results)
            //    Console.WriteLine(i);
        }

     

    }
}
