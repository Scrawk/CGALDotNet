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

            var points = Point2d.RandomPoints(0, 10, new Box2d(-10, 10));

            var line = new Polyline2<EEK>(points);
            line.ShrinkToCapacityToFitCount();

            line.Remove(3, 6);
            line.Insert(2, 5, points);

            line.Print();
 
        }



    }
}
