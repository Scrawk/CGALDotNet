using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// From Index to HalfEdgeIndex must match layout
    /// of the unmanaged TriFace2 in the TriFace2 header file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TriFace2 : IEquatable<TriFace2>
    {
        /// <summary>
        /// Is this the infinite face.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The faces index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The faces 3 vertices.
        /// </summary>
        private fixed int VertexIndex[3];

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[TriFace2: Index={0}, IsInfinite={1}, Vertex0={2}, Vertex1={3}, Vertex2={4}]",
                Index, IsInfinite, VertexIndex[0], VertexIndex[1], VertexIndex[2]);
        }

        /// <summary>
        /// Are the two faces equal.
        /// </summary>
        /// <param name="f1">The first face.</param>
        /// <param name="f2">The second face.</param>
        /// <returns>True if the faces are equal.</returns>
        public static bool operator ==(TriFace2 f1, TriFace2 f2)
        {
            return f1.Index == f2.Index && f1.IsInfinite == f2.IsInfinite
                && f1.VertexIndex[0] == f2.VertexIndex[0] && f1.VertexIndex[1] == f2.VertexIndex[1]
                && f1.VertexIndex[2] == f2.VertexIndex[2];
        }

        /// <summary>
        /// Are the two faces not equal.
        /// </summary>
        /// <param name="f1">The first face.</param>
        /// <param name="f2">The second face.</param>
        /// <returns>True if the faces are not equal.</returns>
        public static bool operator !=(TriFace2 f1, TriFace2 f2)
        {
            return f1.Index != f2.Index || f1.IsInfinite != f2.IsInfinite
                 || f1.VertexIndex[0] != f2.VertexIndex[0] || f1.VertexIndex[1] != f2.VertexIndex[1]
                 || f1.VertexIndex[2] != f2.VertexIndex[2];
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriFace2)) return false;
            TriFace2 v = (TriFace2)obj;
            return this == v;
        }

        /// <summary>
        /// Are these faces equal.
        /// </summary>
        /// <param name="face">The other face.</param>
        /// <returns>True if the faces are equal.</returns>
        public bool Equals(TriFace2 face)
        {
            return this == face;
        }

        /// <summary>
        /// The faces hash code.
        /// </summary>
        /// <returns>The faces hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ IsInfinite.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ VertexIndex[0].GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ VertexIndex[1].GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ VertexIndex[2].GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Get a vertex index and wrap around array.
        /// </summary>
        /// <param name="i">The vertices index wrapped to 0-2.</param>
        /// <returns>The vertices index in the triangulation.</returns>
        public int GetVertexIndex(int i)
        {
            i = MathUtil.Wrap(i, 3);
            return VertexIndex[i];
        }

        /// <summary>
        /// Enumerate the vertices of the face.
        /// </summary>
        /// <param name="tri">The triangle the vertices below too.</param>
        /// <returns>The face vertices.</returns>
        public IEnumerable<TriVertex2> EnumerateVertices(BaseTriangulation2 tri)
        {
            for(int i = 0; i < 3; i++)
            {
                if(tri.GetVertex(i, out TriVertex2 v))
                {
                    yield return v;
                }
            }
        }

        /// <summary>
        /// Enumerate the vertices of the face.
        /// </summary>
        /// <param name="vertices">The vertices array.</param>
        /// <returns>The face vertices.</returns>
        public IEnumerable<TriVertex2> EnumerateVertices(TriVertex2[] vertices)
        {
            for (int i = 0; i < 3; i++)
            {
                int index = GetVertexIndex(i);

                if (index != CGALGlobal.NULL_INDEX)
                {
                    yield return vertices[index];
                }
            }
        }

    }
}
