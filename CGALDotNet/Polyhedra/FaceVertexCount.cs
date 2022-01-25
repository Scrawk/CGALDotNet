using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public struct FaceVertexCount
    {
        public int degenerate;
        public int triangles;
        public int quads;
        public int pentagons;
        public int hexagons;
        public int greater;

        public override string ToString()
        {
            return string.Format("[FaceVertexCount: Degenerate={0}, Triangles={1}, Quads={2}, Pentagons={3}, Hexagons={4}, Greater={5}]",
                degenerate, triangles, quads, pentagons, hexagons, greater);
        }

    }
}
