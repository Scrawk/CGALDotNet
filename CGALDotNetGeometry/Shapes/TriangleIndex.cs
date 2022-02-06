using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A triangle represented by indices instead of points.
    /// The indices represent a index into a array of points.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleIndex : IEquatable<TriangleIndex>
    {
        /// <summary>
        /// The triangles first point index.
        /// </summary>
        public int A;

        /// <summary>
        /// The triangles second point index.
        /// </summary>
        public int B;

        /// <summary>
        /// The triangles third point index.
        /// </summary>
        public int C;

        /// <summary>
        /// Consturct a new triangle.
        /// </summary>
        /// <param name="a">The triangles first point index.</param>
        /// <param name="b">The triangles second point index.</param>
        /// <param name="c">The triangles third point index.</param>
        public TriangleIndex(int a, int b, int c)
        {
            A = a; 
            B = b; 
            C = c; 
        }

        /// <summary>
        /// Does the triangle have a null index.
        /// </summary>
        public bool HasNullIndex => A == MathUtil.NULL_INDEX || B == MathUtil.NULL_INDEX || C == MathUtil.NULL_INDEX;

        /// <summary>
        /// The triangle reversed.
        /// </summary>
        public TriangleIndex Reversed => new TriangleIndex(C, B, A);

        public static bool operator ==(TriangleIndex t1, TriangleIndex t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(TriangleIndex t1, TriangleIndex t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C;
        }

        /// <summary>
        /// Is the triangle equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the triangle equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriangleIndex)) return false;
            TriangleIndex tri = (TriangleIndex)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the triangle equal to the other triangle.
        /// </summary>
        /// <param name="tri">The other triangle.</param>
        /// <returns>Is the triangle equal to the other triangle.</returns>
        public bool Equals(TriangleIndex tri)
        {
            return this == tri;
        }

        /// <summary>
        /// The triangles hash code.
        /// </summary>
        /// <returns>The triangles hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ A.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ B.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ C.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The triangle as a string.
        /// </summary>
        /// <returns>The triangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[TriangleIndex: A={0}, B={1}, C={2}]", A, B, C);
        }
    }
}
