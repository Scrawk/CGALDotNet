using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Arrangements
{
    public struct ArrFace2
    {
        public bool IsFictitious;

        public bool IsUnbounded;

        public bool HasOuterEdges;

        public int HoleCount;

        public int Index;

        public int HalfEdgeIndex;

        public override string ToString()
        {
            return string.Format("[ArrFace2: Index={0}, HalfEdgeIndex={1}, IsFictitious={2}, IsUnbounded={3}, HasOuterEdges={4}, HoleCount={5}]",
                Index, HalfEdgeIndex, IsFictitious, IsUnbounded, HasOuterEdges, HoleCount);
        }

        public IEnumerable<ArrHalfedge2> EnumerateEdges(Arrangement2 arr)
        {
            int count = arr.HalfEdgeCount;

            if (HalfEdgeIndex >= 0 && HalfEdgeIndex < count)
            {
                ArrHalfedge2 edge;
                arr.GetHalfEdge(HalfEdgeIndex, out edge);

                foreach (var e in edge.EnumerateEdges(arr))
                    yield return e;
            }
            else
            {
                yield break;
            }
        }

        public IEnumerable<ArrVertex2> EnumerateVertices(Arrangement2 arr)
        {
            int count = arr.HalfEdgeCount;

            if (HalfEdgeIndex >= 0 && HalfEdgeIndex < count)
            {
                ArrHalfedge2 edge;
                arr.GetHalfEdge(HalfEdgeIndex, out edge);

                foreach (var e in edge.EnumerateVertices(arr))
                    yield return e;
            }
            else
            {
                yield break;
            }
        }
    
    }
}
