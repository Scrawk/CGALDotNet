using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    [Serializable]
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
            return string.Format("[ArrVertex2: Point={0}, Degree={1}, IsIsolated={2}]",
                Point, Degree, IsIsolated);
        }
    }
}
