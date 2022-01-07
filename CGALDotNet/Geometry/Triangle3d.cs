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
    public struct Triangle3d : IEquatable<Triangle3d>
    {
        /// <summary>
        /// The triangles first point.
        /// </summary>
        public Point3d A;

        /// <summary>
        /// The triangles second point.
        /// </summary>
        public Point3d B;

        /// <summary>
        /// The triangles third point.
        /// </summary>
        public Point3d C;

        /// <summary>
        /// Create a new triangle.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <param name="c">The third point.</param>
        public Triangle3d(Point3d a, Point3d b, Point3d c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Create a new triangle.
        /// </summary>
        /// <param name="ax">The first points x value.</param>
        /// <param name="ay">The first points y value.</param>
        /// <param name="az">The first points z value.</param>
        /// <param name="bx">The second points x value.</param>
        /// <param name="by">The second points y value.</param>
        /// <param name="bz">The second points z value.</param>
        /// <param name="cx">The third points x value.</param>
        /// <param name="cy">The third points y value.</param>
        /// <param name="cz">The third points z value.</param>
        public Triangle3d(double ax, double ay, double az, double bx, double by, double bz, double cx, double cy, double cz)
        {
            A = new Point3d(ax, ay, az);
            B = new Point3d(bx, by, bz);
            C = new Point3d(cx, cy, cz);
        }

        /// <summary>
        /// Array acess to the triangles points.
        /// </summary>
        /// <param name="i">The index of the point to access (0-2)</param>
        /// <returns>The point at index i.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        unsafe public Point3d this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle3d index out of range.");

                fixed (Triangle3d* array = &this) { return ((Point3d*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle3d index out of range.");

                fixed (Point3d* array = &A) { array[i] = value; }
            }
        }

        public static Triangle3d operator +(Triangle3d tri, double s)
        {
            return new Triangle3d(tri.A + s, tri.B + s, tri.C + s);
        }

        public static Triangle3d operator +(Triangle3d tri, Point3d v)
        {
            return new Triangle3d(tri.A + v, tri.B + v, tri.C + v);
        }

        public static Triangle3d operator -(Triangle3d tri, double s)
        {
            return new Triangle3d(tri.A - s, tri.B - s, tri.C - s);
        }

        public static Triangle3d operator -(Triangle3d tri, Point3d v)
        {
            return new Triangle3d(tri.A - v, tri.B - v, tri.C - v);
        }

        public static Triangle3d operator *(Triangle3d tri, double s)
        {
            return new Triangle3d(tri.A * s, tri.B * s, tri.C * s);
        }

        public static Triangle3d operator /(Triangle3d tri, double s)
        {
            return new Triangle3d(tri.A / s, tri.B / s, tri.C / s);
        }

        public static bool operator ==(Triangle3d t1, Triangle3d t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(Triangle3d t1, Triangle3d t2)
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
            if (!(obj is Triangle3d)) return false;
            Triangle3d tri = (Triangle3d)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the triangle equal to the other triangle.
        /// </summary>
        /// <param name="tri">The other triangle.</param>
        /// <returns>Is the triangle equal to the other triangle.</returns>
        public bool Equals(Triangle3d tri)
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
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ A.GetHashCode();
                hash = (hash * 16777619) ^ B.GetHashCode();
                hash = (hash * 16777619) ^ C.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The triangle as a string.
        /// </summary>
        /// <returns>The triangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Triangle3d: A={0}, B={1}, C={2}]", A, B, C);
        }

        /// <summary>
        /// Round the triangles points.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            A = A.Rounded(digits);
            B = B.Rounded(digits);
            C = C.Rounded(digits);
        }

    }
}