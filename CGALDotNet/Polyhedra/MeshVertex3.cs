using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshVertex3
    {
        public Point3d Point;

        public int Degree;

        public int Index;

        public int Halfedge;

        public override string ToString()
        {
            return string.Format("[MeshVertex3: Index={0}, Halfedge={1}, Point={2}, Degree={3}]",
                Index, Halfedge, Point, Degree);
        }

        public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
        {
            MeshHalfedge3 start;
            mesh.GetHalfedge(Halfedge, out start);
            MeshHalfedge3 e = start;

            int count = mesh.HalfedgeCount;

            do
            {
                yield return e;

                MeshHalfedge3 opp, next;

                if (e.Opposite >= 0 && e.Opposite < count)
                    mesh.GetHalfedge(e.Opposite, out opp);
                else
                    yield break;

                if (e.Next >= 0 && e.Next < count)
                    mesh.GetHalfedge(opp.Next, out next);
                else
                    yield break;

                e = next;
            }
            while (e.Index != start.Index);
        }
    }
}
