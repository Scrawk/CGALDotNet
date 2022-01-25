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

            var param = PlaneParams.Default;

            var mesh = PolyhedronFactory<EEK>.CreateCube(1, true);

            var centroids = new Point3d[mesh.FaceCount];
            mesh.GetCentroids(centroids, centroids.Length);

            foreach(var centroid in centroids)
                Console.WriteLine(centroid);

        }

    }
}
