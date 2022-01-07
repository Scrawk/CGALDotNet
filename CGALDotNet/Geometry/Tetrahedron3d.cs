using System;
using System.Runtime.InteropServices;

using CGALDotNet.Circular;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Tetrahedron3d : IEquatable<Tetrahedron3d>
    {
        /// <summary>
        /// The tetrahedrons first point.
        /// </summary>
        public Point3d A;

        /// <summary>
        /// The tetrahedrons second point.
        /// </summary>
        public Point3d B;

        /// <summary>
        /// The tetrahedrons third point.
        /// </summary>
        public Point3d C;

        /// <summary>
        /// The tetrahedrons fourth point.
        /// </summary>
        public Point3d D;

        /// <summary>
        /// Create a new tetrahedron.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <param name="c">The third point.</param>
        /// <param name="d">The fourth point.</param>
        public Tetrahedron3d(Point3d a, Point3d b, Point3d c, Point3d d)
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
        unsafe public Point3d this[int i]
        {
            get
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Tetrahedron3d index out of range.");

                fixed (Tetrahedron3d* array = &this) { return ((Point3d*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Tetrahedron3d index out of range.");

                fixed (Point3d* array = &A) { array[i] = value; }
            }
        }

        public static Tetrahedron3d operator +(Tetrahedron3d tri, double s)
        {
            return new Tetrahedron3d(tri.A + s, tri.B + s, tri.C + s, tri.D + s);
        }

        public static Tetrahedron3d operator +(Tetrahedron3d tri, Point3d v)
        {
            return new Tetrahedron3d(tri.A + v, tri.B + v, tri.C + v, tri.D + v);
        }

        public static Tetrahedron3d operator -(Tetrahedron3d tri, double s)
        {
            return new Tetrahedron3d(tri.A - s, tri.B - s, tri.C - s, tri.D - s);
        }

        public static Tetrahedron3d operator -(Tetrahedron3d tri, Point3d v)
        {
            return new Tetrahedron3d(tri.A - v, tri.B - v, tri.C - v, tri.D - v);
        }

        public static Tetrahedron3d operator *(Tetrahedron3d tri, double s)
        {
            return new Tetrahedron3d(tri.A * s, tri.B * s, tri.C * s, tri.D * s);
        }

        public static Tetrahedron3d operator /(Tetrahedron3d tri, double s)
        {
            return new Tetrahedron3d(tri.A / s, tri.B / s, tri.C / s, tri.D / s);
        }

        public static bool operator ==(Tetrahedron3d t1, Tetrahedron3d t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C && t1.D == t2.D;
        }

        public static bool operator !=(Tetrahedron3d t1, Tetrahedron3d t2)
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
            if (!(obj is Tetrahedron3d)) return false;
            Tetrahedron3d tri = (Tetrahedron3d)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the tetrahedron equal to the other tetrahedron.
        /// </summary>
        /// <param name="tri">The other tetrahedron.</param>
        /// <returns>Is the tetrahedron equal to the other tetrahedron.</returns>
        public bool Equals(Tetrahedron3d tri)
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
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ A.GetHashCode();
                hash = (hash * 16777619) ^ B.GetHashCode();
                hash = (hash * 16777619) ^ C.GetHashCode();
                hash = (hash * 16777619) ^ D.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The tetrahedron as a string.
        /// </summary>
        /// <returns>The tetrahedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Tetrahedron3d: A={0}, B={1}, C={2}, C={D}]", A, B, C, D);
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