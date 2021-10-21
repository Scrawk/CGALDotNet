using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNet.DCEL
{

    public struct DCELFace
    {
        public int Index;

        public int HalfEdgeIndex;

        internal DCELMesh Mesh;

        internal DCELFace(DCELMesh mesh)
        {
            Mesh = mesh;
            Index = -1;
            HalfEdgeIndex = -1;
        }

        internal DCELFace(DCELMesh mesh, ArrFace2 face)
        {
            Mesh = mesh;
            Index = face.Index;
            HalfEdgeIndex = face.HalfEdgeIndex;
        }

        public override string ToString()
        {
            return string.Format("[DCELFace: Index={0}, HalfEdgeIndex={1}]",
                Index, HalfEdgeIndex);
        }

        public int VertexCount
        {
            get
            {
                int count = 0;
                foreach (var v in EnumerateVertices())
                    count++;

                return count;
            }
        }

        public IEnumerable<DCELHalfEdge> EnumerateEdges()
        {
            if (Mesh.InHalfEdgeBounds(HalfEdgeIndex))
            {
                var edge = Mesh.GetHalfEdge(HalfEdgeIndex);
                foreach (var e in edge.EnumerateEdges())
                    yield return e;
            }
            else
            {
                yield break;
            }
        }

        public IEnumerable<DCELVertex> EnumerateVertices()
        {
            if (Mesh.InHalfEdgeBounds(HalfEdgeIndex))
            {
                var edge = Mesh.GetHalfEdge(HalfEdgeIndex);
                foreach (var v in edge.EnumerateVertices())
                    yield return v;
            }
            else
            {
                yield break;
            }
        }

        public void GetPoints(List<Point2d> points)
        {
            foreach(var v in EnumerateVertices())
                points.Add(v.Point.xy);
        }

    }
}
