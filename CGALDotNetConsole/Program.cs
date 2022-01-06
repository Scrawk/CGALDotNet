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

            var tri = new Triangulation2<EEK>();

            var del = new DelaunayTriangulation2<EEK>();

            var con = new ConstrainedTriangulation2<EEK>();

            tri.Print();
            del.Print();
            con.Print();

        }


    }
}
