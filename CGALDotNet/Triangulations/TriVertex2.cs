using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public struct TriVertex2
    {
        public Point2d Point;

        public bool IsInfinite;

        public int Degree;

        public int Index;

        public int FaceIndex;
        public override string ToString()
        {
            return string.Format("[TriVertex2: Index={0}, Point={1}, IsInfinite={2}, Degree={3}, Face={4}]", 
                Index, Point, IsInfinite, Degree, FaceIndex);
        }
    }
}
