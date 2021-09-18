using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.DCEL
{
    public struct DCELVertex
    {
        public Point2d Point;

        public int Index;

        public int FaceIndex;

        public int HalfEdgeIndex;

        private DCELMesh Mesh;

        internal DCELVertex(DCELMesh mesh)
        {
            Mesh = mesh;
            Point = new Point2d();
            Index = -1;
            FaceIndex = -1;
            HalfEdgeIndex = -1;
        }

        public override string ToString()
        {
            return string.Format("[DCELVertex: Point={0}, Index={1}, FaceIndex={2}]",
                Point, Index, FaceIndex);
        }
    }
}
