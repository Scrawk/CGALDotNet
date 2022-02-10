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
            pmesh.Print();

            var smesh = SurfaceMeshFactory<EEK>.CreateCube();
            smesh.Print();

            //MeshHalfedge3 edge;
            //pmesh.GetHalfedge(2, out edge);

            //foreach(var e in edge.EnumerateVertices(pmesh))
            //    Console.WriteLine(e);

            //MeshFace3 face;
            //mesh.GetFace(0, out face);

            //foreach (var f in face.EnumerateHalfedges(mesh))
            //    Console.WriteLine(f);

            //MeshVertex3 vert;
            //smesh.GetVertex(0, out vert);

            //foreach (var v in vert.EnumerateHalfedges(smesh))
            //    Console.WriteLine(v)

            
            var vertices = new MeshVertex3[smesh.VertexCount];
            smesh.GetVertices(vertices, vertices.Length);

            Console.WriteLine("Vertices");
            foreach(var v in vertices)
                Console.WriteLine(v);

            //var faces = new MeshFace3[mesh.FaceCount];
            //mesh.GetFaces(faces, faces.Length);

            //Console.WriteLine("Faces");
            //foreach (var f in faces)
            //    Console.WriteLine(f);

            //var edges = new MeshHalfedge3[mesh.HalfedgeCount];
            //mesh.GetHalfedges(edges, edges.Length);

            //Console.WriteLine("Edges");
            //foreach (var e in edges)
            //    Console.WriteLine(e);
            

        }

    }
}
