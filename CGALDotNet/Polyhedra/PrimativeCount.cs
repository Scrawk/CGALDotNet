using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public struct PrimativeCount
    {
        public int triangleCount;

        public int quadCount;

        public int polygonCount;

        public override string ToString()
        {
            return string.Format("[PrimativeCount: TriangleCount={0}, QuadCount={1}, PolygonCount={2}]",
                triangleCount, quadCount, polygonCount);
        }

    }
}
