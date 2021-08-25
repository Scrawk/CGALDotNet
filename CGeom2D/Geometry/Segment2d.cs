using System;
using System.Runtime.InteropServices;

using CGeom2D.Numerics;
using CGeom2D.Points;

using REAL = System.Double;
using POINT2 = CGeom2D.Points.Point2d;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2d : IEquatable<Segment2d>
    {

        public POINT2 A;

        public POINT2 B;

        public Segment2d(POINT2 a, POINT2 b)
        {
            A = a;
            B = b;
        }

        public Segment2d(Point2i a, Point2i b)
        {
            A = (POINT2)a;
            B = (POINT2)b;
        }

        public Segment2d(REAL ax, REAL ay, REAL bx, REAL by)
        {
            A = new POINT2(ax, ay);
            B = new POINT2(bx, by);
        }

        public REAL Length => POINT2.Distance(A, B);

        public REAL SqrLength => POINT2.SqrDistance(A, B);

        unsafe public POINT2 this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (Segment2d* array = &this) { return ((POINT2*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (POINT2* array = &A) { array[i] = value; }
            }
        }


        public static Segment2d operator +(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A + s, seg.B + s);
        }

        public static Segment2d operator +(Segment2d seg, POINT2 v)
        {
            return new Segment2d(seg.A + v, seg.B + v);
        }

        public static Segment2d operator -(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A - s, seg.B - s);
        }

        public static Segment2d operator -(Segment2d seg, POINT2 v)
        {
            return new Segment2d(seg.A - v, seg.B - v);
        }

        public static Segment2d operator *(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A * s, seg.B * s);
        }

        public static Segment2d operator /(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A / s, seg.B / s);
        }

        public static explicit operator Segment2d(Segment2i seg)
        {
            return new Segment2d(seg.A, seg.B);
        }

        public static bool operator ==(Segment2d s1, Segment2d s2)
        {
            return s1.A == s2.A && s1.B == s2.B;
        }

        public static bool operator !=(Segment2d s1, Segment2d s2)
        {
            return s1.A != s2.A || s1.B != s2.B;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Segment2d)) return false;
            Segment2d seg = (Segment2d)obj;
            return this == seg;
        }

        public bool Equals(Segment2d seg)
        {
            return this == seg;
        }

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

        public override string ToString()
        {
            return string.Format("[Segment2d: A={0}, B={1}]", A, B);
        }

        /// <summary>
        /// Transform the segment by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix2x2d m)
        {
            A = m * A;
            B = m * B;
        }

        /// <summary>
        /// Transform the segment by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix3x3d m)
        {
            A = m * A;
            B = m * B;
        }

        /// <summary>
        /// Transform the segment by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix4x4d m)
        {
            A = m * A;
            B = m * B;
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

