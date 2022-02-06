using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Single;
using POINT3 = CGALDotNetGeometry.Numerics.Point3f;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 3D tetrahedron.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Tetrahedron3f : IEquatable<Tetrahedron3f>
    {
        /// <summary>
        /// The tetrahedrons first point.
        /// </summary>
        public POINT3 A;

        /// <summary>
        /// The tetrahedrons second point.
        /// </summary>
        public POINT3 B;

        /// <summary>
        /// The tetrahedrons third point.
        /// </summary>
        public POINT3 C;

        /// <summary>
        /// The tetrahedrons fourth point.
        /// </summary>
        public POINT3 D;

        /// <summary>
        /// Create a new tetrahedron.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <param name="c">The third point.</param>
        /// <param name="d">The fourth point.</param>
        public Tetrahedron3f(POINT3 a, POINT3 b, POINT3 c, POINT3 d)
        {
            A = a;
            B = b;
            C = c;
            D = c;
        }

        /// <summary>
        /// Array acess to the tetrahedrons points.
        /// </summary>
        /// <param name="i">The index of the point to access (0-3)</param>
        /// <returns>The point at index i.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        unsafe public POINT3 this[int i]
        {
            get
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Tetrahedron3f index out of range.");

                fixed (Tetrahedron3f* array = &this) { return ((POINT3*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Tetrahedron3f index out of range.");

                fixed (POINT3* array = &A) { array[i] = value; }
            }
        }

        public static Tetrahedron3f operator +(Tetrahedron3f tri, REAL s)
        {
            return new Tetrahedron3f(tri.A + s, tri.B + s, tri.C + s, tri.D + s);
        }

        public static Tetrahedron3f operator +(Tetrahedron3f tri, POINT3 v)
        {
            return new Tetrahedron3f(tri.A + v, tri.B + v, tri.C + v, tri.D + v);
        }

        public static Tetrahedron3f operator -(Tetrahedron3f tri, REAL s)
        {
            return new Tetrahedron3f(tri.A - s, tri.B - s, tri.C - s, tri.D - s);
        }

        public static Tetrahedron3f operator -(Tetrahedron3f tri, POINT3 v)
        {
            return new Tetrahedron3f(tri.A - v, tri.B - v, tri.C - v, tri.D - v);
        }

        public static Tetrahedron3f operator *(Tetrahedron3f tri, REAL s)
        {
            return new Tetrahedron3f(tri.A * s, tri.B * s, tri.C * s, tri.D * s);
        }

        public static Tetrahedron3f operator /(Tetrahedron3f tri, REAL s)
        {
            return new Tetrahedron3f(tri.A / s, tri.B / s, tri.C / s, tri.D / s);
        }

        public static bool operator ==(Tetrahedron3f t1, Tetrahedron3f t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C && t1.D == t2.D;
        }

        public static bool operator !=(Tetrahedron3f t1, Tetrahedron3f t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C || t1.D != t2.D;
        }

        /// <summary>
        /// Is the tetrahedron equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the tetrahedron equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Tetrahedron3f)) return false;
            Tetrahedron3f tri = (Tetrahedron3f)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the tetrahedron equal to the other tetrahedron.
        /// </summary>
        /// <param name="tri">The other tetrahedron.</param>
        /// <returns>Is the tetrahedron equal to the other tetrahedron.</returns>
        public bool Equals(Tetrahedron3f tri)
        {
            return this == tri;
        }

        /// <summary>
        /// The tetrahedrons hash code.
        /// </summary>
        /// <returns>The tetrahedrons hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ A.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ B.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ C.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ D.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The tetrahedron as a string.
        /// </summary>
        /// <returns>The tetrahedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Tetrahedron3f: A={0}, B={1}, C={2}, C={D}]", A, B, C, D);
        }

        /// <summary>
        /// Round the tetrahedrons points.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            A = A.Rounded(digits);
            B = B.Rounded(digits);
            C = C.Rounded(digits);
            D = D.Rounded(digits);
        }

    }
}