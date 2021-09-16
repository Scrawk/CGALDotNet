using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var t = new Triangulation2<EEK>();
            t.InsertPoint(new Point2d(-5, -5));
            t.InsertPoint(new Point2d(5, -5));
            t.InsertPoint(new Point2d(0, 5));
            t.InsertPoint(new Point2d(0, 0));

            /*
            t.ForceSetIndices();

            var faces = new TriFace2[t.TriangleCount];
            t.GetFaces(faces);

            var verts = new TriVertex2[t.VertexCount];
            t.GetVertices(verts);

            foreach (var face in faces)
                Console.WriteLine(face);

            foreach (var vert in verts)
                Console.WriteLine(vert);
            */

            if (t.LocateEdge(new Point2d(-2, 0), out TriEdge2 edge, out Segment2d seg))
            {
                Console.WriteLine(edge);
            }
        }


    }
}
