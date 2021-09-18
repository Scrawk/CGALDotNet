using System;
using System.Collections.Generic;
using System.Text;

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

        private DCELMesh Mesh;

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

        public override string ToString()
        {
            return string.Format("[DCELHalfEdge: Index={0}, FaceIndex={1}]",
                Index, FaceIndex);
        }

        public IEnumerable<DCELHalfEdge> EnumerateEdges()
        {
            var start = this;
            var e = start;

            do
            {
                if (e.Index == -1) yield break;
                yield return e;

                if(e.NextIndex < 0 || e.NextIndex >= Mesh.HalfEdgeCount)
                    yield break;
                else
                    e = Mesh.GetHalfEdge(e.NextIndex);
            }
            while (e.Index != start.Index);
        }
    }
}
