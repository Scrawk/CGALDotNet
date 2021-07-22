using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public struct TriVertex2
    {
        public Point2d Point;

        public int Degree;

        public int Index;

        public int FaceIndex;
        public override string ToString()
        {
            return string.Format("[TriVertex2: Point={0}, Degree={1}]", Point, Degree);
        }
    }
}
