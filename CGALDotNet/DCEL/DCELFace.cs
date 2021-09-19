using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.DCEL
{
    public struct DCELFace
    {
        public int Index;

        public int HalfEdgeIndex;

        private DCELMesh Mesh;

        internal DCELFace(DCELMesh mesh)
        {
            Mesh = mesh;
            Index = -1;
            HalfEdgeIndex = -1;
        }

        public override string ToString()
        {
            return string.Format("[DCELFace: Index={0}, HalfEdgeIndex={1}]",
                Index, HalfEdgeIndex);
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

        public void GetPoints( List<Point2d> points)
        {
            foreach(var v in EnumerateVertices())
                points.Add(v.Point);
        }
    }
}
