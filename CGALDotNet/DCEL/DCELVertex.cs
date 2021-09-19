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

        public IEnumerable<DCELHalfEdge> EnumerateIncidentEdges()
        {
            var start = Mesh.GetHalfEdge(HalfEdgeIndex);
            var e = start;

            do
            {
                yield return e;

                DCELHalfEdge twin, next;

                if(Mesh.InHalfEdgeBounds(e.TwinIndex))
                    twin = Mesh.GetHalfEdge(e.TwinIndex);
                else
                    yield break;

                if (Mesh.InHalfEdgeBounds(twin.NextIndex))
                    next = Mesh.GetHalfEdge(twin.NextIndex);
                else
                    yield break;

                e = next;
            }
            while (e.Index != start.Index);
        }
    }
}
