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


            var poly = PolygonFactory<EEK>.CreateCircle(10, 64);
            poly.Print();

            var param = PolygonSimplificationParams.Default;
            param.threshold = 0.1;

            poly.Simplify(param);
            poly.Print();

        }



    }
}
