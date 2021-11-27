using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.PolyHedra;
using CGALDotNet.Meshing;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            List<Point3d> points = new List<Point3d>();
            List<int> indices = new List<int>();
            MeshFactory.CreateCube(points, indices);

            var poly = new Polyhedra3<EEK>();
            poly.CreateTriangleMesh(points.ToArray(), indices.ToArray());

            var _points = new Point3d[poly.VertexCount];
            var _indices = new int[poly.FaceCount * 3];

            poly.GetPoints(_points);
            poly.GetTriangleIndices(_indices);

            foreach (var p in _points)
                Console.WriteLine(p);

            foreach (var i in _indices)
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
