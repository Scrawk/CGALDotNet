using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    public struct ArrHalfEdge2
    {
        public bool IsFictitious;

        public int Index;

        public int SourceIndex;

        public int TargetIndex;

        public int FaceIndex;

        public int NextIndex;

        public int PreviousIndex;

        public int TwinIndex;

        public override string ToString()
        {
            return string.Format("[ArrHalfEdge2: IsFictitious={0}]",
                IsFictitious);
        }
    }
}
