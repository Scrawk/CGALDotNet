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


            var outer = PolygonFactory<EEK>.FromBox(-2, 2);
            var inner = PolygonFactory<EEK>.FromBox(-1, 1);
            inner.Reverse();

            var poly = new PolygonWithHoles2<EEK>(outer);
            poly.AddHole(inner);

            Console.WriteLine(poly.GetPoint(POLYGON_ELEMENT.HOLE, 0, 0));
            Console.WriteLine(poly.GetPoint(POLYGON_ELEMENT.HOLE, 1, 0));
            Console.WriteLine(poly.GetPoint(POLYGON_ELEMENT.HOLE, 2, 0));
            Console.WriteLine(poly.GetPoint(POLYGON_ELEMENT.HOLE, 3, 0));

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
