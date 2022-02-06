using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Single;
using POINT3 = CGALDotNetGeometry.Numerics.Point3f;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 3D segment.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment3f : IEquatable<Segment3f>
    {
        /// <summary>
        /// The segments first (aka source) point.
        /// </summary>
        public POINT3 A;

        /// <summary>
        /// The segments second (aka target) point.
        /// </summary>
        public POINT3 B;

        /// <summary>
        /// Create a new segment.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public Segment3f(POINT3 a, POINT3 b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Create a new segment.
        /// </summary>
        /// <param name="ax">The first points x value.</param>
        /// <param name="ay">The first points y value.</param>
        /// <param name="az">The first points z value.</param>
        /// <param name="bx">The second points x value.</param>
        /// <param name="by">The second points y value.</param>
        /// <param name="bz">The second points z value.</param>
        public Segment3f(REAL ax, REAL ay, REAL az, REAL bx, REAL by, REAL bz)
        {
            A = new POINT3(ax, ay, az);
            B = new POINT3(bx, by, bz);
        }

        /// <summary>
        /// The length of the segment.
        /// </summary>
        public REAL Length => POINT3.Distance(A, B);

        /// <summary>
        /// The square length of the segment.
        /// </summary>
        public REAL SqrLength => POINT3.SqrDistance(A, B);

        /// <summary>
        /// The segment flipped, a is now b, b is now a.
        /// </summary>
        public Segment3f Reversed => new Segment3f(B, A);

        /// <summary>
        /// Array acess to the segments points.
        /// </summary>
        /// <param name="i">The index of the point to access (0-2)</param>
        /// <returns>The point at index i.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        unsafe public POINT3 this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Segment3f index out of range.");

                fixed (Segment3f* array = &this) { return ((POINT3*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Segment3f index out of range.");

                fixed (POINT3* array = &A) { array[i] = value; }
            }
        }


        public static Segment3f operator +(Segment3f seg, REAL s)
        {
            return new Segment3f(seg.A + s, seg.B + s);
        }

        public static Segment3f operator +(Segment3f seg, POINT3 v)
        {
            return new Segment3f(seg.A + v, seg.B + v);
        }

        public static Segment3f operator -(Segment3f seg, REAL s)
        {
            return new Segment3f(seg.A - s, seg.B - s);
        }

        public static Segment3f operator -(Segment3f seg, POINT3 v)
        {
            return new Segment3f(seg.A - v, seg.B - v);
        }

        public static Segment3f operator *(Segment3f seg, REAL s)
        {
            return new Segment3f(seg.A * s, seg.B * s);
        }

        public static Segment3f operator /(Segment3f seg, REAL s)
        {
            return new Segment3f(seg.A / s, seg.B / s);
        }

        public static bool operator ==(Segment3f s1, Segment3f s2)
        {
            return s1.A == s2.A && s1.B == s2.B;
        }

        public static bool operator !=(Segment3f s1, Segment3f s2)
        {
            return s1.A != s2.A || s1.B != s2.B;
        }

        /// <summary>
        /// Is the segment equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the segment equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Segment3f)) return false;
            Segment3f seg = (Segment3f)obj;
            return this == seg;
        }

        /// <summary>
        /// Is the segment equal to the other segment.
        /// </summary>
        /// <param name="seg">The other segment.</param>
        /// <returns>Is the segment equal to the other segment.</returns>
        public bool Equals(Segment3f seg)
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
            return string.Format("[Segment3f: A={0}, B={1}]", A, B);
        }

        /// <summary>
        /// Round the segments points.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            A = A.Rounded(digits);
            B = B.Rounded(digits);
        }

    }
}

