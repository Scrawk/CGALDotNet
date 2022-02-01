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

            var pmesh = PolyhedronFactory<EEK>.CreateIcosahedron();
            var smesh = SurfaceMeshFactory<EEK>.CreateIcosahedron();

            var pdual = pmesh.CreateDualMesh();
            var sdual = smesh.CreateDualMesh();

            pmesh.Print();
            smesh.Print();

            pdual.Print();
            sdual.Print();
  
        }

    }
}
