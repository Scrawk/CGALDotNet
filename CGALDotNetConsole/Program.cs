using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

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
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var a = new Point2<EEK>(1, 0);
            var b = new Point2<EEK>(2, 0);
            var c = new Point2<EEK>(3, 0);

            var list = new NativeList<Point2<EEK>>();

            list.Add(a);
            list.Add(b);
            list.Add(c);

            list.Remove(a); 

            Console.WriteLine(list);

        }


    }
}
