using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

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
    }
}
