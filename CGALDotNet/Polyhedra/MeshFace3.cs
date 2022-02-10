using System;
using System.Collections.Generic;

namespace CGALDotNet.Polyhedra
{
    public struct MeshFace3
    {
        public int Index;

        public int Halfedge;

        public override string ToString()
        {
            return string.Format("[MeshFace3: Index={0}, Halfedge={1}]",
                Index, Halfedge);
        }

        public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
        {
            int count = mesh.HalfedgeCount;

            if (Halfedge >= 0 && Halfedge < count)
            {
                MeshHalfedge3 edge;
                mesh.GetHalfedge(Halfedge, out edge);

                foreach (var e in edge.EnumerateHalfedges(mesh))
                    yield return e;
            }
            else
            {
                yield break;
            }
        }

        public IEnumerable<MeshVertex3> EnumerateVertices(IMesh mesh)
        {
            int count = mesh.HalfedgeCount;

            if (Halfedge >= 0 && Halfedge < count)
            {
                MeshHalfedge3 edge;
                mesh.GetHalfedge(Halfedge, out edge);

                foreach (var e in edge.EnumerateVertices(mesh))
                    yield return e;
            }
            else
            {
                yield break;
            }
        }

    }
}
