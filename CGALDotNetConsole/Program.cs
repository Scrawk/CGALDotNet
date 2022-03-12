using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

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
        
        public static void Main(string[] args)
        {

            var points = Point2d.RandomPoints(0, 10, new Box2f(-10, 10));

            var tri = new Triangulation2<EIK>(points);

            Console.WriteLine(tri);

            var vertices = new TriVertex2[tri.VertexCount];
            tri.GetVertices(vertices, vertices.Length);

            var faces = new TriFace2[tri.TriangleCount];
            tri.GetFaces(faces, faces.Length);

            foreach (var v in faces[0].EnumerateVertices(vertices))
            {
                Console.WriteLine(v);
            }

        }


    }
}
