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
            var segments = new Segment2d[]
            {
                new Segment2d(new Point2d(1,5), new Point2d(8,5)),
                new Segment2d(new Point2d(1,1), new Point2d(8,8)),
                new Segment2d(new Point2d(3,1), new Point2d(3,8)),
                new Segment2d(new Point2d(8,5), new Point2d(8,8))
            };

            
            var SubCurves = SweepLine<EEK>.Instance.ComputeSubcurves(segments);

            Console.WriteLine("Sub curves = " + SubCurves.Length);

            foreach(var curve in SubCurves)
                Console.WriteLine(curve);

            var Points = SweepLine<EEK>.Instance.ComputeIntersectionPoints(segments);

            Console.WriteLine("Points = " + Points.Length);

            foreach (var points in Points)
                Console.WriteLine(points);
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
