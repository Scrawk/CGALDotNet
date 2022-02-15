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
   

            var m = EigenMatrix.Random(4, 4, 0, 10, 0);
            m.Round(2);
            m.Print();

            var v = EigenColumnVector.Random(4, 0, 10, 0);
            v.Round(2);
            v.Print();

            var x = v.Transpose;
            x.Print();  

        }


    }
}
