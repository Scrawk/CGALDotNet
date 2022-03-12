using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshFace3 : IEquatable<MeshFace3>
    {
        public int Index;

        public int Halfedge;

        public static MeshFace3 NullFace
        {
            get
            {
                var face = new MeshFace3();
                face.Index = CGALGlobal.NULL_INDEX;
                face.Halfedge = CGALGlobal.NULL_INDEX;
                return face;
            }
        }

        public override string ToString()
        {
            return string.Format("[MeshFace3: Index={0}, Halfedge={1}]",
                Index, Halfedge);
        }

        public static bool operator ==(MeshFace3 v1, MeshFace3 v2)
        {
            return v1.Index == v2.Index && v1.Halfedge == v2.Halfedge;
        }

        public static bool operator !=(MeshFace3 v1, MeshFace3 v2)
        {
            return v1.Index != v2.Index || v1.Halfedge != v2.Halfedge;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MeshFace3)) return false;
            MeshFace3 v = (MeshFace3)obj;
            return this == v;
        }

        public bool Equals(MeshFace3 v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Halfedge.GetHashCode();
                return hash;
            }
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
