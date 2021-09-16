using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public struct TriEdge2
    {
        public int FaceIndex;
        public int NeighbourIndex;

        public TriEdge2(int faceIndex, int neighbourIndex)
        {
            FaceIndex = faceIndex;
            NeighbourIndex = neighbourIndex;
        }

        public override string ToString()
        {
            return string.Format("[TriEdge2:  FaceIndex={0}, NeighbourIndex={1}]", 
                FaceIndex, NeighbourIndex);
        }

    }
}
