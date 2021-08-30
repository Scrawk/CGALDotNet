using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGeom2D;
using CGeom2D.Geometry;
using CGeom2D.Points;
using CGeom2D.Numerics;
using CGeom2D.Arrangements;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            BenchmarkRunner.Run<BenchmarkDemo>();

        }

        [MemoryDiagnoser]
        public class BenchmarkDemo
        {

            private List<Segment2d> segments;


            [GlobalSetup]
            public void Setup()
            {
                segments = SegmentArrangement.RandomSegments(10, 0, 10);
            }

            [Benchmark]
            public void Func1()
            {
                var arr = new SegmentArrangement();

                var output = arr.Run(segments);
                
            }



        }

    }
}
