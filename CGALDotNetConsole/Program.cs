using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Polylines;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Processing;

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var poly = PolyhedronFactory<EEK>.CreateCube();
            var slicer = PolygonMeshProcessingSlicer<EEK>.Instance;

            var lines = new List<Polyline3<EEK>>();

            var plane = new Plane3d(new Point3d(0, 0, 0), new Vector3d(0, 1, 0));

            slicer.Slice(poly, plane, lines);

            foreach(var line in lines)
            {
                line.Print();

                foreach(var p in line)
                    Console.WriteLine(p.ToString());
            }
        }



    }
}
