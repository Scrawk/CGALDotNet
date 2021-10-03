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

            var arr = new Arrangement2<EEK>();
            var poly = PolygonFactory<EEK>.FromBox(-1, 1);
            arr.InsertPolygon(poly, true);
            arr.Print();

            var mesh = new DCELMesh(arr);

            mesh.Print();

        }

        private static void KernelSpeedTest()
        {
            var offsetEEK = PolygonOffset2<EEK>.Instance;
            var polyEEK = PolygonFactory<EEK>.KochStar(10, 3);
            var resultsEEK = new List<Polygon2<EEK>>();

            var offsetEIK = PolygonOffset2<EIK>.Instance;
            var polyEIK = PolygonFactory<EIK>.KochStar(10, 3);
            var resultsEIK = new List<Polygon2<EIK>>();

            var boxEEK = PolygonFactory<EEK>.FromBox(0, 10);
            var boxEIK = PolygonFactory<EIK>.FromBox(0, 10);

            var timer = new Timer();
            timer.Start();
            offsetEEK.CreateInteriorOffset(polyEEK, 1, resultsEEK);
            timer.StopAndPrintInMilliSeconds();

            timer = new Timer();
            timer.Start();
            offsetEIK.CreateInteriorOffset(polyEIK, 1, resultsEIK);
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
