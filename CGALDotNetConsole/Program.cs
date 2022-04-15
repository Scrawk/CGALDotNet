using System;
using System.Text;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNetGeometry.Extensions;

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
using CGALDotNet.Extensions;
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {


        static void Main(string[] args)
        {

            var indices = new PolygonalIndices();

            indices.quads = new int[]
            {
                3, 2, 1, 0
            };

            var points = new Point3d[]
            {
                new Point3d(0, 0, 0),
                new Point3d(1, 0, 0),
                new Point3d(1, 1, 0),
                new Point3d(0, 1, 0)
            };

            var mesh = new SurfaceMesh3<EEK>(points, indices);
            mesh.Triangulate();

            var distances = new List<double>();

           HeatMethod<EEK>.Instance.EstimateGeodesicDistances(mesh, 0, distances);

            foreach(var d in distances)
                Console.WriteLine(d);

        }


    }
}
