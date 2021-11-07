using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Arrangements;
using CGALDotNet.Geometry;

namespace CGALDotNet.DCEL
{
    public class DCELMesh
    {

        public DCELMesh()
        {
            Vertices = new List<DCELVertex>();
            HalfEdges = new List<DCELHalfEdge>();
            Faces = new List<DCELFace>();
        }

        public DCELMesh(Arrangement2 arr)
        {
            Vertices = new List<DCELVertex>(arr.VertexCount);
            HalfEdges = new List<DCELHalfEdge>(arr.HalfEdgeCount);
            Faces = new List<DCELFace>(arr.FaceCount);

            BuildFromArrangement(arr);
        }

        private List<DCELVertex> Vertices;

        private List<DCELHalfEdge> HalfEdges;

        private List<DCELFace> Faces;

        public override string ToString()
        {
            return string.Format("[DCELMesh: Vertices={0}, HalfEdges={1}, Faces={2}]",
                Vertices.Count, HalfEdges.Count, Faces.Count);
        }

        public void BuildFromArrangement(Arrangement2 arr)
        {
            CreateVertices(arr);
            CreateHalfEdges(arr);
            CreateFaces(arr);
        }

        public int VertexCount => Vertices.Count;

        public int HalfEdgeCount => HalfEdges.Count;

        public int FaceCount => Faces.Count;

        public DCELVertex GetVertex(int index)
        {
            return Vertices[index];
        }

        public void AddVertex(DCELVertex vertex)
        {
            vertex.Mesh = this;
            Vertices.Add(vertex);
        }

        public DCELHalfEdge GetHalfEdge(int index)
        {
            return HalfEdges[index];
        }

        public void AddHalfEdge(DCELHalfEdge edge)
        {
            edge.Mesh = this;
            HalfEdges.Add(edge);
        }

        public DCELFace GetFace(int index)
        {
            return Faces[index];
        }

        public void AddFace(DCELFace face)
        {
            face.Mesh = this;
            Faces.Add(face);
        }

        public bool InVerticesBounds(int i)
        {
            return !(i < 0 || i >= VertexCount);
        }

        public bool InHalfEdgeBounds(int i)
        {
            return !(i < 0 || i >= HalfEdgeCount);
        }

        public bool InFaceBounds(int i)
        {
            return !(i < 0 || i >= FaceCount);
        }

        public IEnumerable<DCELVertex> EnumerateVertices()
        {
            foreach (var vert in Vertices)
                yield return vert;
        }

        public IEnumerable<DCELHalfEdge> EnumerateEdges()
        {
            foreach (var edge in HalfEdges)
                yield return edge;
        }

        public IEnumerable<DCELFace> EnumerateFaces()
        {
            foreach (var face in Faces)
                yield return face;
        }

        private void CreateVertices(Arrangement2 arr)
        {
            Vertices.Clear();

            int count = arr.VertexCount;
            if (count <= 0) return;

            var arrVerts = new ArrVertex2[count];
            arr.GetVertices(arrVerts);

            for (int i = 0; i < count; i++)
                AddVertex(new DCELVertex(this, arrVerts[i]));
        }

        private void CreateFaces(Arrangement2 arr)
        {
            Faces.Clear();

            int count = arr.FaceCount;
            if (count <= 0) return;

            var arrFaces = new ArrFace2[count];
            arr.GetFaces(arrFaces);

            for (int i = 0; i < count; i++)
                AddFace(new DCELFace(this, arrFaces[i]));
        }

        private void CreateHalfEdges(Arrangement2 arr)
        {
            HalfEdges.Clear();

            int count = arr.HalfEdgeCount;
            if (count <= 0) return;

            var arrEdges = new ArrHalfEdge2[count];
            arr.GetHalfEdges(arrEdges);

            for (int i = 0; i < count; i++)
                AddHalfEdge(new DCELHalfEdge(this, arrEdges[i]));
        }

        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());

            builder.AppendLine();

            foreach (var vert in Vertices)
                builder.AppendLine(vert.ToString());

            builder.AppendLine();

            foreach (var halfEdge in HalfEdges)
                builder.AppendLine(halfEdge.ToString());

            builder.AppendLine();

            foreach (var face in Faces)
                builder.AppendLine(face.ToString());
        }
    }
}
