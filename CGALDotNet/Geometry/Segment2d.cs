using System;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2d : IEquatable<Segment2d>
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

    }
}

