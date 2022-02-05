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
            //var ico = PolyhedronFactory<EEK>.CreateIcosahedron();
            //ico.Subdivide(2);
            //var dual = ico.CreateDualMesh();
            //dual.Print();

            var param = CapsuleParams.Default;
            var capsule = PolyhedronFactory<EEK>.CreateCapsule(param);

            capsule.Print();

        }

    }
}
