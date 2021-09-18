using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

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
            var box = PolygonFactory<EEK>.FromBox(-1, 1);

            var arr = new Arrangement2<EEK>();
            arr.InsertPolygon(box, true);
            //arr.Print(true);

            var mesh = new DCELMesh();
            mesh.FromArrangement(arr);
            //mesh.Print();

            var edge = mesh.GetHalfEdge(0);

            //Console.WriteLine(edge.ToString());

            foreach (var e in edge.EnumerateEdges())
            {
                Console.WriteLine(e);
            }

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
