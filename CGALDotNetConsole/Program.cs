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

            string filename = "C:/Users/Justin/Desktop/CGALData/meshes/elk.off";

            var poly = PolyhedronFactory<EEK>.CreateCube();
            //poly.ReadOFF(filename);
            poly.Triangulate();
            poly.Print();

            var normals = new Vector3d[poly.FaceCount];
            poly.GetFaceNormals(normals, normals.Length);

            foreach (var n in normals)
                Console.WriteLine(n);

            Console.WriteLine("Done");

        }



    }
}
