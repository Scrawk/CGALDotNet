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
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);

            var results = new List<Polygon2<EEK>>();
            PolygonOffset2<EEK>.Instance.CreateInteriorOffset(poly, 0.1, results);

            PolygonOffset2<EEK>.Instance.CreateExteriorOffset(poly, 0.1, results);

            foreach (var p in results)
            {
                p.Print();
            }
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
