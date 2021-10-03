using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNet.DCEL
{

    public struct DCELHalfEdge
    {
        public int Index;

        public int SourceIndex;

        public int TargetIndex;

        public int FaceIndex;

        public int NextIndex;

        public int PreviousIndex;

        public int TwinIndex;

        public DCELMesh Mesh;

        internal DCELHalfEdge(DCELMesh mesh)
        {
            Mesh = mesh;
            Index = -1;
            NextIndex = -1;
            SourceIndex = -1;
            TargetIndex = -1;
            FaceIndex = -1;
            NextIndex = -1;
            PreviousIndex = -1;
            TwinIndex = -1;
        }

        internal DCELHalfEdge(DCELMesh mesh, ArrHalfEdge2 edge)
        {
            Mesh = mesh;
            Index = edge.Index;
            NextIndex = edge.NextIndex;
            SourceIndex = edge.SourceIndex;
            TargetIndex = edge.TargetIndex;
            FaceIndex = edge.FaceIndex;
            NextIndex = edge.NextIndex;
            PreviousIndex = edge.PreviousIndex;
            TwinIndex = edge.TwinIndex;
        }

        public override string ToString()
        {
            return string.Format("[DCELHalfEdge: Index={0}, NextIndex={1}, SourceIndex={2}, Targetndex={3}, FaceIndex={4}, PreviousIndex={5}, TwinIndex={6}]",
                Index, NextIndex, SourceIndex, TargetIndex, FaceIndex, PreviousIndex, TwinIndex);
        }

        public Point3d SourcePoint => Mesh.GetVertex(SourceIndex).Point;

        public Point3d TargetPoint => Mesh.GetVertex(TargetIndex).Point;

        public IEnumerable<DCELHalfEdge> EnumerateEdges()
        {
            var start = this;
            var e = start;

            do
            {
                yield return e;

                if(!Mesh.InHalfEdgeBounds(e.NextIndex))
                    yield break;
                else
                    e = Mesh.GetHalfEdge(e.NextIndex);
            }
            while (e.Index != start.Index);
        }

        public IEnumerable<DCELVertex> EnumerateVertices()
        {
            var start = this;
            var e = start;

            do
            {
                if (Mesh.InVerticesBounds(e.SourceIndex))
                    yield return Mesh.GetVertex(e.SourceIndex);

                if (!Mesh.InHalfEdgeBounds(e.NextIndex))
                    yield break;
                else
                    e = Mesh.GetHalfEdge(e.NextIndex);
            }
            while (e.Index != start.Index);
        }
    }
}
