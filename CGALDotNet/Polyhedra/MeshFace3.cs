using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshFace3 : IEquatable<MeshFace3>
    {
        /// <summary>
        /// The faces index
        /// </summary>
        public int Index;

        /// <summary>
        /// THe faces edge
        /// </summary>
        public int Halfedge;

        /// <summary>
        /// A face where all compents are null index.
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshFace3: Index={0}, Halfedge={1}]",
                Index, Halfedge);
        }

        /// <summary>
        /// Are these faces equal.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(MeshFace3 v1, MeshFace3 v2)
        {
            return v1.Index == v2.Index && v1.Halfedge == v2.Halfedge;
        }

        /// <summary>
        /// Are these faces not equal.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(MeshFace3 v1, MeshFace3 v2)
        {
            return v1.Index != v2.Index || v1.Halfedge != v2.Halfedge;
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is MeshFace3)) return false;
            MeshFace3 v = (MeshFace3)obj;
            return this == v;
        }

        /// <summary>
        /// Are these faces equal.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Equals(MeshFace3 v)
        {
            return this == v;
        }

        /// <summary>
        /// The faces hash code.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Enmerate all edges in this edge loop.
        /// </summary>
        /// <param name="mesh">The mesh the edges belong too.</param>
        /// <returns>The next edge</returns>
        public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
        {
            if (Halfedge != CGALGlobal.NULL_INDEX)
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

        /// <summary>
        /// Enmerate all vertices in this edge loop.
        /// </summary>
        /// <param name="mesh">The mesh the edges belong too.</param>
        /// <returns>The next vertex</returns>
        public IEnumerable<MeshVertex3> EnumerateVertices(IMesh mesh)
        {
            if (Halfedge != CGALGlobal.NULL_INDEX)
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
