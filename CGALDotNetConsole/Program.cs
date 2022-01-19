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
using CGALDotNet.Processing;

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            //ChineseDragon-10kv.off
            //bunny00.off
            //armadillo.off
            //elephant.off
            //elk.off
            //diplodocus.off
            //bunny00.off
            //refined_elephant.off

            //string filename = "C:/Users/Justin/Desktop/CGALData/meshes/elk.off";


            var cube = PolyhedronFactory<EEK>.CreateCube();
            var plane = PolyhedronFactory<EEK>.CreatePlane();
            var ncube = PolyhedronFactory<EEK>.CreateNormalizedCube();
            var uvsphere = PolyhedronFactory<EEK>.CreateUVSphere();
            var toruse = PolyhedronFactory<EEK>.CreateTorus();
            var cyliner = PolyhedronFactory<EEK>.CreateCylinder();
            var cone = PolyhedronFactory<EEK>.CreateCone();

            //cone.Print();
            //PolygonMeshProcessingRepair<EEK>.Instance.RepairPolygonSoup(cone);

            Console.WriteLine("Cube is closed " + cube.IsClosed);
            Console.WriteLine("Plane is closed " + plane.IsClosed);
            Console.WriteLine("NCube is closed " + ncube.IsClosed);
            Console.WriteLine("uvsphere is closed " + uvsphere.IsClosed);
            Console.WriteLine("toruse is closed " + toruse.IsClosed);
            Console.WriteLine("cyliner is closed " + cyliner.IsClosed);
            Console.WriteLine("cone is closed " + cone.IsClosed);

        }



    }
}
