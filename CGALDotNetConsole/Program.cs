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
using CGALDotNet.PolyHedra;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var pwh = PolygonFactory<EEK>.FromDounut(10, 5, 16);

            PolygonWithHoles2<EEK> poly;
            if( PolygonVisibility<EEK>.Instance.ComputeVisibilityRSV(new Point2d(6, 0), pwh, out poly))
            {
                poly.Print();
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
