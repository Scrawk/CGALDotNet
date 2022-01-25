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

            var points = new Point3d[mesh.VertexCount];
            mesh.GetPoints(points, points.Length);

            var count = mesh.GetFaceVertexCount();
            var indices = count.Indices();
            mesh.GetPolygonalIndices(ref indices);

            Console.WriteLine("Count " + count);
            Console.WriteLine("Indices " + indices);

            for(int i = 0; i < indices.quadCount / 4; i++)
            {
                int i0 = indices.quads[i * 4 + 0];
                int i1 = indices.quads[i * 4 + 1];
                int i2 = indices.quads[i * 4 + 2];
                int i3 = indices.quads[i * 4 + 3];

                Console.WriteLine(i0 + " " + i1 + " " + i2 + " " + i3);
            }
                
            mesh.CreatePolygonalMesh(points, points.Length, indices);

            mesh.Print();
        }

    }
}
