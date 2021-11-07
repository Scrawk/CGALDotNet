using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNet.DCEL
{
    public struct DCELVertex
    {
        public Point3d Point;

        public int Index;

        public int FaceIndex;

        public int HalfEdgeIndex;

        internal DCELMesh Mesh;

        internal DCELVertex(DCELMesh mesh)
        {
            Mesh = mesh;
            Point = new Point3d();
            Index = -1;
            FaceIndex = -1;
            HalfEdgeIndex = -1;
        }

        internal DCELVertex(DCELMesh mesh, ArrVertex2 verts)
        {
            Mesh = mesh;
            Point = verts.Point.xy0;
            Index = verts.Index;
            FaceIndex = verts.FaceIndex;
            HalfEdgeIndex = verts.HalfEdgeIndex;
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
