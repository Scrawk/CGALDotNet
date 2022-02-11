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


            PrintFace(smesh, 0);

            PrintEdge(smesh, 4);

            PrintFaceEdges(smesh, 0);
           

        }

        private static void PrintVertex(IMesh mesh, int index)
        {
            Console.WriteLine("Vertex " + index);
            MeshVertex3 vert;
            mesh.GetVertex(index, out vert);
            Console.WriteLine(vert);
        }

        private static void PrintFace(IMesh mesh, int index)
        {
            Console.WriteLine("Face " + index);
            MeshFace3 face;
            mesh.GetFace(index, out face);
            Console.WriteLine(face);
        }

        private static void PrintFaceVertices(IMesh mesh, int index)
        {
            Console.WriteLine("Face " + index);
            MeshFace3 face;
            mesh.GetFace(index, out face);

            foreach(var v in face.EnumerateVertices(mesh))
                Console.WriteLine(v);
        }

        private static void PrintFaceEdges(IMesh mesh, int index)
        {
            Console.WriteLine("Face " + index);
            MeshFace3 face;
            mesh.GetFace(index, out face);

            foreach (var e in face.EnumerateHalfedges(mesh))
                Console.WriteLine(e);
        }

        private static void PrintEdge(IMesh mesh, int index)
        {
            Console.WriteLine("Edge " + index);
            MeshHalfedge3 edge;
            mesh.GetHalfedge(index, out edge);
            Console.WriteLine(edge);
        }

        private static void PrintVertices(IMesh mesh)
        {
            var vertices = new MeshVertex3[mesh.VertexCount];
            mesh.GetVertices(vertices, vertices.Length);

            Console.WriteLine("Vertices");
            foreach (var v in vertices)
                Console.WriteLine(v);
        }

        private static void PrintFaces(IMesh mesh)
        {
            var faces = new MeshFace3[mesh.FaceCount];
            mesh.GetFaces(faces, faces.Length);

            Console.WriteLine("Faces");
            foreach (var f in faces)
                Console.WriteLine(f);
        }

        private static void PrintEdges(IMesh mesh)
        {
            var edges = new MeshHalfedge3[mesh.HalfedgeCount];
            mesh.GetHalfedges(edges, edges.Length);

            Console.WriteLine("Edges");
            foreach (var e in edges)
                Console.WriteLine(e);
        }

    }
}
