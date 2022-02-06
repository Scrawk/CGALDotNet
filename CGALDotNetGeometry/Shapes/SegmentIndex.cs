using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A segment represented by indices instead of points.
    /// The indices represent a index into a array of points.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SegmentIndex : IEquatable<SegmentIndex>
    {
        /// <summary>
        /// The segments first point index.
        /// </summary>
        public int A;

        /// <summary>
        /// The segments seconds point index.
        /// </summary
        public int B;

        /// <summary>
        /// Consturct a new segment.
        /// </summary>
        /// <param name="a">The segments first point index.</param>
        /// <param name="b">The segments second point index.</param>
        public SegmentIndex(int a, int b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Does the segment have a null index.
        /// </summary>
        public bool HasNullIndex => A == MathUtil.NULL_INDEX || B == MathUtil.NULL_INDEX;

        /// <summary>
        /// The segment reverse where a is now b and b is now a.
        /// </summary>
        public SegmentIndex Reversed => new SegmentIndex(B, A);

        public static bool operator ==(SegmentIndex t1, SegmentIndex t2)
        {
            return t1.A == t2.A && t1.B == t2.B;
        }

        public static bool operator !=(SegmentIndex t1, SegmentIndex t2)
        {
            return t1.A != t2.A || t1.B != t2.B;
        }

        /// <summary>
        /// Is the segment equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the segment equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is SegmentIndex)) return false;
            SegmentIndex tri = (SegmentIndex)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the segment equal to the other segment.
        /// </summary>
        /// <param name="seg">The other segment.</param>
        /// <returns>Is the segment equal to the other segment.</returns>
        public bool Equals(SegmentIndex seg)
        {
            return this == seg;
        }

        /// <summary>
        /// The segments hash code.
        /// </summary>
        /// <returns>The segments hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ A.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ B.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The segment as a string.
        /// </summary>
        /// <returns>The segment as a string.</returns>
        public override string ToString()
        {
            return string.Format("[SegmentIndex: A={0}, B={1}]", A, B);
        }
    }
}
