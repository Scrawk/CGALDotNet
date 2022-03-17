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

            var mesh = new Polyhedron3<EEK>(points, indices);
            mesh.Translate(new Point3d(-0.5, -0.5, 0));

            var v = mesh.GetVertex(1);
            var e0 = mesh.GetHalfedge(v.Halfedge);
            var e1 = mesh.GetHalfedge(e0.Next);

            var a = e0.TargetPoint(mesh);
            var b = v.Point;
            var c = e1.SourcePoint(mesh);

            Console.WriteLine("a " + a);
            Console.WriteLine("b " + b);
            Console.WriteLine("c " + c);

            var edge_index = mesh.SplitEdge(e0.Index);

            var split_edge = mesh.GetHalfedge(edge_index);

            var v0 = mesh.GetVertex(split_edge.Source);
            var v1 = mesh.GetVertex(split_edge.Target);

            Console.WriteLine(mesh);

            var builder = new StringBuilder();

            mesh.PrintFaces(builder);
            mesh.PrintVertices(builder);
            mesh.PrintHalfedges(builder);

            Console.WriteLine(builder.ToString());

        }


    }
}
