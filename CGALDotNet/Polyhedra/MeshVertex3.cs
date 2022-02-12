using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshVertex3 : IEquatable<MeshVertex3>
    {
        public Point3d Point;

        public int Degree;

        public int Index;

        public int Halfedge;

        public static MeshVertex3 NullVertex
        {
            get
            {
                var vertex = new MeshVertex3();
                vertex.Index = -CGALGlobal.NULL_INDEX;
                vertex.Halfedge = -CGALGlobal.NULL_INDEX;
                return vertex;
            }
        }

        public static bool operator ==(MeshVertex3 v1, MeshVertex3 v2)
        {
            return v1.Index == v2.Index && v1.Halfedge == v2.Halfedge 
                && v1.Degree == v2.Degree && v1.Point == v2.Point;
        }

        public static bool operator !=(MeshVertex3 v1, MeshVertex3 v2)
        {
            return v1.Index != v2.Index || v1.Halfedge != v2.Halfedge
                || v1.Degree != v2.Degree || v1.Point != v2.Point;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MeshVertex3)) return false;
            MeshVertex3 v = (MeshVertex3)obj;
            return this == v;
        }

        public bool Equals(MeshVertex3 v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Point.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Degree.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Halfedge.GetHashCode();
                return hash;
            }
        }

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
