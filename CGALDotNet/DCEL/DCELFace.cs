using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.DCEL
{
    public struct DCELFace
    {
        public int Index;

        public int HalfEdgeIndex;

        private DCELMesh Mesh;

        internal DCELFace(DCELMesh mesh)
        {
            Mesh = mesh;
            Index = -1;
            HalfEdgeIndex = -1;
        }

        public override string ToString()
        {
            return string.Format("[DCELFace: Index={0}, HalfEdgeIndex={1}]",
                Index, HalfEdgeIndex);
        }
    }
}
