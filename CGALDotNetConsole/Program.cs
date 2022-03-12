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

            var rpoints = Point2d.RandomPoints(0, 10, new Box2f(-10, 10));

            var tri = new Triangulation2<EIK>(rpoints);

           tri.Print();

            var vertices = new TriVertex2[tri.VertexCount];
            tri.GetVertices(vertices, vertices.Length);

            var faces = new TriFace2[tri.TriangleCount];
            tri.GetFaces(faces, faces.Length);

            foreach (var v in faces[0].EnumerateVertices(vertices))
            {
                Console.WriteLine(v);
            }

            var points = new Point2d[tri.VertexCount];
            tri.GetPoints(points, points.Length);

            var indices = new int[tri.TriangleCount];
            tri.GetIndices(indices, indices.Length);

            var triangles = new Triangle2d[tri.TriangleCount];
            tri.GetTriangles(triangles, triangles.Length);

            var face = faces[0];
            Console.WriteLine("Face index = " +face.Index);
            Console.WriteLine("Face first vertex index = " + face.GetVertexIndex(0));
            Console.WriteLine("Face second vertex index = " + face.GetVertexIndex(1));
            Console.WriteLine("Face third vertex index =" + face.GetVertexIndex(2));

            var vertex = vertices[0];
            Console.WriteLine("Vertex index = " + vertex.Index);
            Console.WriteLine("Vertex point = " + vertex.Point);
            Console.WriteLine("Vertex face index = " + vertex.FaceIndex);


        }


    }
}
