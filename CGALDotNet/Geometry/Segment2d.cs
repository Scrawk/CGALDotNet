using System;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2d : IEquatable<Segment2d>, IGeometry2d
    {

        public Point2d A;

        public Point2d B;

        public Segment2d(Point2d a, Point2d b)
        {
            A = a;
            B = b;
        }

        public Segment2d(double ax, double ay, double bx, double by)
        {
            A = new Point2d(ax, ay);
            B = new Point2d(bx, by);
        }

        public double Length => Point2d.Distance(A, B);

        public double SqrLength => Point2d.SqrDistance(A, B);

        unsafe public Point2d this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (Segment2d* array = &this) { return ((Point2d*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (Point2d* array = &A) { array[i] = value; }
            }
        }


        public static Segment2d operator +(Segment2d seg, double s)
        {
            return new Segment2d(seg.A + s, seg.B + s);
        }

        public static Segment2d operator +(Segment2d seg, Point2d v)
        {
            return new Segment2d(seg.A + v, seg.B + v);
        }

        public static Segment2d operator -(Segment2d seg, double s)
        {
            return new Segment2d(seg.A - s, seg.B - s);
        }

        public static Segment2d operator -(Segment2d seg, Point2d v)
        {
            return new Segment2d(seg.A - v, seg.B - v);
        }

        public static Segment2d operator *(Segment2d seg, double s)
        {
            return new Segment2d(seg.A * s, seg.B * s);
        }

        public static Segment2d operator /(Segment2d seg, double s)
        {
            return new Segment2d(seg.A / s, seg.B / s);
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
        /// Check if the geometries intersects.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>True if there is a intersection.</returns>
        public bool DoIntersect(IGeometry2d geometry)
        {
            return CGALIntersections.DoIntersect(this, geometry);
        }

        /// <summary>
        /// Find the intersection with this geometry.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>The intersection result.</returns>
        public IntersectionResult2d Intersection(IGeometry2d geometry)
        {
            return CGALIntersections.Intersection(this, geometry);
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

