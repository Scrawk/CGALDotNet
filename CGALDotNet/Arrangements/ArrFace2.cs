using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    [Serializable]
    public struct ArrFace2
    {
        public bool IsFictitious;

        public bool IsUnbounded;

        public bool HasOuterEdges;

        public int Index;

        public int HalfEdgeIndex;

        public override string ToString()
        {
            return string.Format("[ArrFace2: IsFictitious={0}, IsUnbounded={1}, HasOuterEdges={2}]",
                IsFictitious, IsUnbounded, HasOuterEdges);
        }
    }
}
