using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public struct TriEdgeConstraint2
    {
        public int FaceIndex;
        public int NeighbourIndex;

        public override string ToString()
        {
            return string.Format("[TriEdgeConstraint2: FaceIndex={0}, NeighbourIndex={1}]", 
                FaceIndex, NeighbourIndex);
        }

    }
}
