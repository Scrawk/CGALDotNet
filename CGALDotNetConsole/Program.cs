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
            var points = new Point3d[]
            {
                new Point3d(1, -1, -1),
                new Point3d(1, 1, 1),
                new Point3d(-1, 1, -1),
                new Point3d(-1, -1, 1),
            };

            var poly = SkinSurfaceMeshing<EEK>.Instance.CreateSkinPolyhedra(0.5, false, points, points.Length);

            poly.Print();

        }



    }
}
