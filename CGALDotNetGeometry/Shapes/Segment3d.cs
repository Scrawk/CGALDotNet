using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment3d : IEquatable<Segment3d>
    {
        /// <summary>
        /// The segments first (aka source) point.
        /// </summary>
        public Point3d A;

        /// <summary>
        /// The segments second (aka target) point.
        /// </summary>
        public Point3d B;

        /// <summary>
        /// Create a new segment.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public Segment3d(Point3d a, Point3d b)
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
        public Segment3d(double ax, double ay, double az, double bx, double by, double bz)
        {
            A = new Point3d(ax, ay, az);
            B = new Point3d(bx, by, bz);
        }

        /// <summary>
        /// The length of the segment.
        /// </summary>
        public double Length => Point3d.Distance(A, B);

        /// <summary>
        /// The square length of the segment.
        /// </summary>
        public double SqrLength => Point3d.SqrDistance(A, B);

        /// <summary>
        /// Array acess to the segments points.
        /// </summary>
        /// <param name="i">The index of the point to access (0-2)</param>
        /// <returns>The point at index i.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        unsafe public Point3d this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Segment3d index out of range.");

                fixed (Segment3d* array = &this) { return ((Point3d*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Segment3d index out of range.");

                fixed (Point3d* array = &A) { array[i] = value; }
            }
        }


        public static Segment3d operator +(Segment3d seg, double s)
        {
            return new Segment3d(seg.A + s, seg.B + s);
        }

        public static Segment3d operator +(Segment3d seg, Point3d v)
        {
            return new Segment3d(seg.A + v, seg.B + v);
        }

        public static Segment3d operator -(Segment3d seg, double s)
        {
            return new Segment3d(seg.A - s, seg.B - s);
        }

        public static Segment3d operator -(Segment3d seg, Point3d v)
        {
            return new Segment3d(seg.A - v, seg.B - v);
        }

        public static Segment3d operator *(Segment3d seg, double s)
        {
            return new Segment3d(seg.A * s, seg.B * s);
        }

        public static Segment3d operator /(Segment3d seg, double s)
        {
            return new Segment3d(seg.A / s, seg.B / s);
        }

        public static bool operator ==(Segment3d s1, Segment3d s2)
        {
            return s1.A == s2.A && s1.B == s2.B;
        }

        public static bool operator !=(Segment3d s1, Segment3d s2)
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
            if (!(obj is Segment3d)) return false;
            Segment3d seg = (Segment3d)obj;
            return this == seg;
        }

        /// <summary>
        /// Is the segment equal to the other segment.
        /// </summary>
        /// <param name="seg">The other segment.</param>
        /// <returns>Is the segment equal to the other segment.</returns>
        public bool Equals(Segment3d seg)
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
            return string.Format("[Segment3d: A={0}, B={1}]", A, B);
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

