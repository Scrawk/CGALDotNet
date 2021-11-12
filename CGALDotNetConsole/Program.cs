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
using CGALDotNet.Meshing;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var poly = PolygonFactory<EEK>.KochStar(10, 2);

            Console.WriteLine(poly);

            int count = poly.Count;

            var timer = new Timer();
            timer.Start();

            for(int i = 0; i < count; i++)
            {
                poly.GetPoint(i);
            }


            timer.StopAndPrintInMilliSeconds();

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
