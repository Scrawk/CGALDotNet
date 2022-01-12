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

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var box = new Box3d(-5, 5);
            var corners = box.GetCorners();

            var tri = new Triangulation3<EEK>(corners);
            tri.Refine(0.1, 1);

            var hull = tri.ComputeHull();

            hull.Print();

        }



    }
}
