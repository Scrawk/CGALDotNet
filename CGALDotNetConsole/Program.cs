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
            var tri = new ConstrainedTriangulation2<EEK>();

            /*
            var va = new Point2d(5.0, 5.0);
            var vb = new Point2d(-5.0, 5.0);
            var vc = new Point2d(4.0, 3.0);
            var vd = new Point2d(5.0, -5.0);
            var ve = new Point2d(6.0, 6.0);
            var vf = new Point2d(-6.0, 6.0);
            var vg = new Point2d(-6.0, -6.0);
            var vh = new Point2d(6.0, -6.0);

            tri.InsertPoint(va);
            tri.InsertPoint(vb);
            tri.InsertPoint(vc);
            tri.InsertPoint(vd);
            tri.InsertPoint(ve);
            tri.InsertPoint(vf);
            tri.InsertPoint(vg);
            tri.InsertPoint(vh);

            tri.InsertConstraint(va, vb);
            tri.InsertConstraint(vb, vc);
            tri.InsertConstraint(vc, vd);
            tri.InsertConstraint(vd, va);
            tri.InsertConstraint(ve, vf);
            tri.InsertConstraint(vf, vg);
            tri.InsertConstraint(vg, vh);
            tri.InsertConstraint(vh, ve);
            */

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

            //Console.WriteLine("Make Delaunay");
            //tri.MakeDelaunay();
            //tri.Print();

            //Console.WriteLine("Make Gabriel");
            //tri.MakeGabriel();
            //tri.Print();

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
