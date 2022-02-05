using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SegmentIndex : IEquatable<SegmentIndex>
    {
        public int A, B;

        public bool HasNullIndex => A == -1 || B == -1;

        public SegmentIndex Reversed => new SegmentIndex(B, A);

        public SegmentIndex(int a, int b)
        {
            A = a;
            B = b;
        }

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
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ A.GetHashCode();
                hash = (hash * 16777619) ^ B.GetHashCode();
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
