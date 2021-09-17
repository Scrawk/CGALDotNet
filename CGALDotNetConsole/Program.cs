using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var box = PolygonFactory<EEK>.FromBox(-1, 1);

            var tri = new ConstrainedTriangulation2<EEK>();
            tri.InsertPolygonConstraint(box);

            //BenchmarkRunner.Run<BenckMark>();
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
