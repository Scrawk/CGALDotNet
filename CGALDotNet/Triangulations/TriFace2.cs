using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Triangulations
{

    public unsafe struct TriFace2
    {
        public bool IsInfinite;

        public int Index;

        public fixed int VertexIndex[3];

        public override string ToString()
        {
            return string.Format("[TriFace2: Index={0}, IsInfinite={1}, Vertex0={2}, Vertex1={3}, Vertex2={4}]",
                Index, IsInfinite, VertexIndex[0], VertexIndex[1], VertexIndex[2]);
        }

        public int GetVertexIndex(int i)
        {
            i = CGALGlobal.Wrap(i, 3);
            return VertexIndex[i];
        }

    }
}
