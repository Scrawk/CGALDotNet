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

            //var indices = new int[mesh.FaceCount * 3];
            //mesh.GetTriangleIndices(indices, indices.Length);

            var indices = new int[mesh.FaceCount * 4];
            mesh.GetQuadIndices(indices, indices.Length);

            for(int i = 0; i < indices.Length / 4; i++)
            {
                int i0 = indices[i * 4 + 0];
                int i1 = indices[i * 4 + 1];
                int i2 = indices[i * 4 + 2];
                int i3 = indices[i * 4 + 3];

                Console.WriteLine(i0 + " " + i1 + " " + i2 + " " + i3);
            }
        }

    }
}
