using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

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
    }
}
