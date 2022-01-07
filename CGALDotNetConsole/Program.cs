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
using CGALDotNet.Hulls;

namespace CGALDotNetConsole
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var box = new Box3d(-5, 5);
            var hull = ConvexHull3<EEK>.Instance;

            var points = Point3d.RandomPoints(0, 10, box);

            var poly = hull.CreateHullAsPolyhedron(points, points.Length);
            poly.Print();

            var mesh = hull.CreateHullAsSurfaceMesh(points, points.Length);
            mesh.Print();

            Console.WriteLine("Is poly stronghly convex " + hull.IsStronglyConvex(poly));
            Console.WriteLine("Is mesh stronghly convex " + hull.IsStronglyConvex(mesh));

        }


    }
}
