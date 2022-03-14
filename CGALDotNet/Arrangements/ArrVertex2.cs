using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{

    public struct ArrVertex2
    {
        public Point2d Point;

        public int Degree;

        public bool IsIsolated;

        public int Index;

        public int FaceIndex;

        public int HalfEdgeIndex;

        public override string ToString()
        {
            return string.Format("[ArrVertex2: Point={0}, Index={1}, FaceIndex={2}, Degree={3}, IsIsolated={4}]",
                Point, Index, FaceIndex, Degree, IsIsolated);
        }

        public IEnumerable<ArrHalfedge2> EnumerateHalfedges(Arrangement2 arr)
        {
            ArrHalfedge2 start;
            arr.GetHalfEdge(HalfEdgeIndex, out start);
            ArrHalfedge2 e = start;

            int count = arr.HalfEdgeCount;

            do
            {
                yield return e;

                ArrHalfedge2 twin, next;

                if (e.TwinIndex >= 0 && e.TwinIndex < count)
                    arr.GetHalfEdge(e.TwinIndex, out twin);
                else
                    yield break;

                if (e.NextIndex >= 0 && e.NextIndex < count)
                    arr.GetHalfEdge(twin.NextIndex, out next);
                else
                    yield break;

                e = next;
            }
            while (e.Index != start.Index);
        }

    }
}
