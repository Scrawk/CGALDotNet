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
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var m1 = new EigenMatrix(3, 3);
            m1.SetRow(0, 1, 2, 3);
            m1.SetRow(1, 4, 5, 6);
            m1.SetRow(2, 7, 8, 9);
 
            var m3 = new EigenMatrix(2, 2);
            m3.SetRow(0, 2, -1);
            m3.SetRow(1, -1, 3);

            var m2 = new EigenMatrix(2, 2);
            m2.SetRow(0, 1, 2);
            m2.SetRow(1, 3, 1);

            var v = new EigenColumnVector(3, 3, 4);
 
            var x = m2.ColPivHouseholderQr(v);
            x.Round(2);
            x.Print();


            Console.WriteLine("Done");
        }


    }
}
