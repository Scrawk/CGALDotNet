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

            var mesh = new SurfaceMesh3<EEK>();

            int u = mesh.AddVertex(new Point3d(0, 1, 0));
            int v = mesh.AddVertex(new Point3d(0, 0, 0));
            int w = mesh.AddVertex(new Point3d(1, 1, 0));
            int x = mesh.AddVertex(new Point3d(1, 0, 0));

            int f0 = mesh.AddFace(u, v, w);
            //int f1 = mesh.AddFace(u, v, x);

            int f2 = mesh.AddFace(u, x, v);

            Console.WriteLine(mesh);
            Console.WriteLine(mesh.IsValid()); 

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
