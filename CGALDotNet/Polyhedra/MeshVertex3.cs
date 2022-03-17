using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshVertex3 : IEquatable<MeshVertex3>
    {
        /// <summary>
        /// The vertices point.
        /// </summary>
        public Point3d Point;

        /// <summary>
        /// The vertices degree is how mang edges connect to it.
        /// </summary>
        public int Degree;

        /// <summary>
        /// The vertices index.
        /// </summary>
        public int Index;

        /// <summary>
        /// The vertices edge
        /// </summary>
        public int Halfedge;

        /// <summary>
        /// A vertex where all components are null.
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshVertex3: Index={0}, Halfedge={1}, Point={2}, Degree={3}]",
                Index, Halfedge, Point, Degree);
        }

        /// <summary>
        /// Are these vertices equal.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(MeshVertex3 v1, MeshVertex3 v2)
        {
            return v1.Index == v2.Index && v1.Halfedge == v2.Halfedge
                && v1.Degree == v2.Degree && v1.Point == v2.Point;
        }

        /// <summary>
        /// Are these vertices not equal.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(MeshVertex3 v1, MeshVertex3 v2)
        {
            return v1.Index != v2.Index || v1.Halfedge != v2.Halfedge
                || v1.Degree != v2.Degree || v1.Point != v2.Point;
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is MeshVertex3)) return false;
            MeshVertex3 v = (MeshVertex3)obj;
            return this == v;
        }

        /// <summary>
        /// Are these vertices equal.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Equals(MeshVertex3 v)
        {
            return this == v;
        }

        /// <summary>
        /// The vertices hash code
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Enmerate all edges surrounding the vertex.
        /// </summary>
        /// <param name="mesh">The mesh the edges belong too.</param>
        /// <returns>The next edge</returns>
        public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
        {
            MeshHalfedge3 start;
            mesh.GetHalfedge(Halfedge, out start);
            MeshHalfedge3 e = start;

            do
            {
                yield return e;

                MeshHalfedge3 opp, next;

                if (e.Next != CGALGlobal.NULL_INDEX)
                    mesh.GetHalfedge(e.Next, out next);
                else
                    yield break;

                if (next.Opposite != CGALGlobal.NULL_INDEX)
                    mesh.GetHalfedge(next.Opposite, out opp);
                else
                    yield break;

                e = opp;
            }
            while (e.Index != start.Index);
        }
    }
}
