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
   
            var points = new HPoint3d[]
            {
                new HPoint3d(1, -1, -1, 1.25),
                new HPoint3d(1, 1, 1, 1.25),
                new HPoint3d(-1, 1, -1, 1.25),
                new HPoint3d(-1, -1, 1, 1.25)
            };

            var skin = SkinSurfaceMeshing<EEK>.Instance;

            var poly = skin.CreateSkinPolyhedra(0.5, true, points, points.Length);

            poly.Print();
        }



    }
}
