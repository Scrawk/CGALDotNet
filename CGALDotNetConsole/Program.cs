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
using CGALDotNet.Extensions;

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var pmesh = PolyhedronFactory<EEK>.CreateCube();
            var smesh = SurfaceMeshFactory<EEK>.CreateCube();

            Console.WriteLine("Before");
            Print(smesh);

            smesh.RemoveVertex(0);
            smesh.RemoveFace(0);
            smesh.RemoveEdge(0);

            Console.WriteLine("");
            Console.WriteLine("After");
            Print(smesh);


        }

        static void Print(SurfaceMesh3<EEK> mesh)
        {
            mesh.Print();
            PrintIndices(mesh);
   ;
            Console.WriteLine("Points");

            var points = new Point3d[mesh.VertexCount];
            mesh.GetPoints(points, points.Length);

            //var points = mesh.ToArray();

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(i + " " + points[i]);
            }
        }

        static void PrintIndices(SurfaceMesh3<EEK> mesh)
        {
            Console.WriteLine("Actual Indices");
            mesh.PrintIndices(true, true, true, true, false);

            Console.WriteLine("Get Indices");
            var indices = new int[mesh.FaceCount * 3];
            mesh.GetTriangleIndices(indices, indices.Length);

            //indices = indices.RemoveNullTriangles();

            for (int i = 0; i < indices.Length / 3; i++)
            {
                int i0 = indices[i * 3 + 0];
                int i1 = indices[i * 3 + 1];
                int i2 = indices[i * 3 + 2];

                Console.WriteLine(i0 + " " + i1 + " " + i2);
            }
        }



    }
}
