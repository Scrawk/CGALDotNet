using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// From Point to HalfEdgeIndex must match layout
    /// of the unmanaged TriVertex2 in the TriVertex2 header file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriVertex2 : IEquatable<TriVertex2>
    {
        /// <summary>
        /// The vertices point.
        /// </summary>
        public Point2d Point;

        /// <summary>
        /// Is this a infinite vertex.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The number of egdes connected to the vertex.
        /// </summary>
        public int Degree;

        /// <summary>
        /// The vertices index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The one of the faces the vertex is connected to.
        /// </summary>
        public int FaceIndex;

        public override string ToString()
        {
            return string.Format("[TriVertex2: Index={0}, Point={1}, IsInfinite={2}, Degree={3}, Face={4}]", 
                Index, Point, IsInfinite, Degree, FaceIndex);
        }

        /// <summary>
        /// Are the two faces equal.
        /// </summary>
        /// <param name="v1">The first face.</param>
        /// <param name="v2">The second face.</param>
        /// <returns>True if the faces are equal.</returns>
        public static bool operator ==(TriVertex2 v1, TriVertex2 v2)
        {
            return v1.Index == v2.Index && v1.IsInfinite == v2.IsInfinite
                && v1.Degree == v2.Degree && v1.FaceIndex == v2.FaceIndex
                && v1.Point == v2.Point;
        }

        /// <summary>
        /// Are the two faces not equal.
        /// </summary>
        /// <param name="v1">The first face.</param>
        /// <param name="v2">The second face.</param>
        /// <returns>True if the faces are not equal.</returns>
        public static bool operator !=(TriVertex2 v1, TriVertex2 v2)
        {
            return v1.Index != v2.Index || v1.IsInfinite != v2.IsInfinite
                    || v1.Degree != v2.Degree || v1.FaceIndex != v2.FaceIndex
                    || v1.Point != v2.Point;
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriVertex2)) return false;
            TriVertex2 v = (TriVertex2)obj;
            return this == v;
        }

        /// <summary>
        /// Are these faces equal.
        /// </summary>
        /// <param name="face">The other face.</param>
        /// <returns>True if the faces are equal.</returns>
        public bool Equals(TriVertex2 face)
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
                hash = (hash * MathUtil.HASH_PRIME_2) ^ FaceIndex.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Degree.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Point.GetHashCode();
                return hash;
            }
        }
    }
}
