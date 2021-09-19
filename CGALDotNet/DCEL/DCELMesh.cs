using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Arrangements;

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

        private List<DCELVertex> Vertices;

        private List<DCELHalfEdge> HalfEdges;

        private List<DCELFace> Faces;

        public override string ToString()
        {
            return string.Format("[DCELMesh: Vertices={0}, HalfEdges={1}, Faces={2}]",
                Vertices.Count, HalfEdges.Count, Faces.Count);
        }

        public void FromArrangement(Arrangement2 arrangement)
        {
            CreateVertices(arrangement);
            CreateHalfEdges(arrangement);
            CreateFaces(arrangement);
        }

        public int VertexCount => Vertices.Count;

        public int HalfEdgeCount => HalfEdges.Count;

        public int FaceCount => Faces.Count;

        public DCELVertex GetVertex(int index)
        {
            return Vertices[index];
        }

        public DCELHalfEdge GetHalfEdge(int index)
        {
            return HalfEdges[index];
        }

        public DCELFace GetFace(int index)
        {
            return Faces[index];
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

        private void CreateVertices(Arrangement2 arrangement)
        {
            Vertices.Clear();

            int count = arrangement.VertexCount;
            if (count <= 0) return;

            var vertices = new ArrVertex2[count];
            arrangement.GetVertices(vertices);

            var nullVert = new DCELVertex(null);
            for (int i = 0; i < count; i++)
                Vertices.Add(nullVert);

            for (int i = 0; i < count; i++)
            {
                var arrVert = vertices[i];
                var dcelVert = new DCELVertex(this);

                dcelVert.Point = arrVert.Point;
                dcelVert.Index = arrVert.Index;
                dcelVert.FaceIndex = arrVert.FaceIndex;
                dcelVert.HalfEdgeIndex = arrVert.HalfEdgeIndex;

                Vertices[dcelVert.Index] = dcelVert;
            }
        }

        private void CreateFaces(Arrangement2 arrangement)
        {
            Faces.Clear();

            int count = arrangement.FaceCount;
            if (count <= 0) return;

            var faces = new ArrFace2[count];
            arrangement.GetFaces(faces);

            var nullFace = new DCELFace(null);
            for (int i = 0; i < count; i++)
                Faces.Add(nullFace);

            for (int i = 0; i < count; i++)
            {
                var arrFace = faces[i];
                var dcelFace = new DCELFace(this);

                dcelFace.Index = arrFace.Index;
                dcelFace.HalfEdgeIndex = arrFace.HalfEdgeIndex;

                Faces[dcelFace.Index] = dcelFace;
            }
        }

        private void CreateHalfEdges(Arrangement2 arrangement)
        {
            HalfEdges.Clear();

            int count = arrangement.HalfEdgeCount;
            if (count <= 0) return;

            var edges = new ArrHalfEdge2[count];
            arrangement.GetHalfEdges(edges);

            var nullEdge = new DCELHalfEdge(null);
            for (int i = 0; i < count; i++)
                HalfEdges.Add(nullEdge);

            for (int i = 0; i < count; i++)
            {
                var arrEdge = edges[i];
                var dcelEdge = new DCELHalfEdge(this);

                dcelEdge.Index = arrEdge.Index;
                dcelEdge.NextIndex = arrEdge.NextIndex;
                dcelEdge.SourceIndex = arrEdge.SourceIndex;
                dcelEdge.TargetIndex = arrEdge.TargetIndex;
                dcelEdge.FaceIndex = arrEdge.FaceIndex;
                dcelEdge.NextIndex = arrEdge.NextIndex;
                dcelEdge.PreviousIndex = arrEdge.PreviousIndex;
                dcelEdge.TwinIndex = arrEdge.TwinIndex;

                HalfEdges[dcelEdge.Index] = dcelEdge;
            }
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
