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
            var box = PolygonFactory<EEK>.FromBox(-5, 5);

            var arr = new Arrangement2<EEK>();
            arr.InsertPolygon(box, true);
            //arr.Print(true);

            var mesh = new DCELMesh();
            mesh.FromArrangement(arr);
            //mesh.Print();

            var vert = mesh.GetVertex(0);
            var face = mesh.GetFace(0);
            var edge = mesh.GetHalfEdge(0);

            foreach (var e in edge.EnumerateVertices())
            {
                //Console.WriteLine(e);
            }

            foreach (var e in face.EnumerateEdges())
            {
                //Console.WriteLine(e);
            }

            foreach (var v in face.EnumerateVertices())
            {
                Console.WriteLine(v);
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
