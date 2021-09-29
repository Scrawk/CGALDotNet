using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.DCEL;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var tri = new ConformingTriangulation2<EEK>();

            var va = new Point2d(-2, 0);
            var vb = new Point2d(0, -2);
            var vc = new Point2d(2, 0);
            var vd = new Point2d(0, 1);
            var ve = new Point2d(2, 0.6);

            tri.Insert(ve);
            tri.InsertConstraint(va, vb);
            tri.InsertConstraint(vb, vc);
            tri.InsertConstraint(vc, vd);
            tri.InsertConstraint(vd, va);

            Console.WriteLine("Before");
            tri.Print();

            Console.WriteLine("Make Delaunay");
            tri.MakeDelaunay();
            tri.Print();

            Console.WriteLine("Make Gabriel");
            tri.MakeGabriel();
            tri.Print();

            tri.Refine(0.125, 0.5);

            tri.Print();

        }

        public class BenckMark
        {

            [GlobalSetup]
            public void GlobalSetup()
            {
               
            }

            [Benchmark]
            public void Func()
            {
                
            }

            [GlobalCleanup]
            public void GlobalCleanup()
            {
              
            }
        }


    }
}
