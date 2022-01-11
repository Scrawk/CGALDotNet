using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            
            var points = new Point3d[]
            {
                new Point3d(1, 0, 0),
                new Point3d(0, 1, 0),
                new Point3d(0, 0, 1),
                new Point3d(0, 0, 0),
            };

            var tri = new Triangulation3<EEK>(points);
            tri.Refine(0.1, 1);
           

            /*
            var box1 = PolyhedronFactory<EEK>.CreateCube();
            box1.Translate(new Point3d(0.5));

            var box2 = PolyhedronFactory<EEK>.CreateCube();

            var nef1 = new NefPolyhedron3<EEK>(box1);
            var nef2 = new NefPolyhedron3<EEK>(box2);

            var nef3 = nef1.Join(nef2);

            var volumes = new List<Polyhedron3<EEK>>();
            nef3.GetVolumes(volumes);

            foreach (var poly in volumes)
            {
                if (!poly.IsPureTriangle)
                    poly.Triangulate();

                poly.Print();
            }
            */
        }



    }
}
