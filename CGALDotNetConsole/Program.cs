﻿using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.DCEL;
using CGALDotNet.PolyHedra;
using CGALDotNet.Meshing;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var vertices = new List<Point3d>();
            var indices = new List<int>();
            var bounds = new Box2d(0, 5);
            var param = SurfaceMesherParams.Default;

            SurfaceMesher3<EIK>.Instance.Generate(vertices, indices, bounds, param);

            foreach (var v in vertices)
                Console.WriteLine(v);

            foreach (var i in indices)
                Console.WriteLine(i);

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
