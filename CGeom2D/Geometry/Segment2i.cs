using System;
using System.Runtime.InteropServices;

using CGeom2D.Numerics;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2i : IEquatable<Segment2i>
    {

        public Point2i A;

        public Point2i B;

        public Point2i C => A;

        public Point2i D => B;

        public Segment2i(Point2i a, Point2i b)
        {
            A = a;
            B = b;
        }

        public Segment2i(Int128 ax, Int128 ay, Int128 bx, Int128 by)
        {
            A = new Point2i(ax, ay);
            B = new Point2i(bx, by);
        }

        public Int128 SqrLength => Point2i.SqrDistance(A, B);

        unsafe public Point2i this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2i index out of range.");

                fixed (Segment2i* array = &this) { return ((Point2i*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2i index out of range.");

                fixed (Point2i* array = &A) { array[i] = value; }
            }
        }


        public static Segment2i operator +(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A + s, seg.B + s);
        }

        public static Segment2i operator +(Segment2i seg, Point2i v)
        {
            return new Segment2i(seg.A + v, seg.B + v);
        }

        public static Segment2i operator -(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A - s, seg.B - s);
        }

        public static Segment2i operator -(Segment2i seg, Point2i v)
        {
            return new Segment2i(seg.A - v, seg.B - v);
        }

        public static Segment2i operator *(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A * s, seg.B * s);
        }

        public static Segment2i operator /(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A / s, seg.B / s);
        }

        public static bool operator ==(Segment2i s1, Segment2i s2)
        {
            return s1.A == s2.A && s1.B == s2.B;
        }

        public static bool operator !=(Segment2i s1, Segment2i s2)
        {
            return s1.A != s2.A || s1.B != s2.B;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Segment2i)) return false;
            Segment2i seg = (Segment2i)obj;
            return this == seg;
        }

        public bool Equals(Segment2i seg)
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
            return string.Format("[Segment2i: A={0}, B={1}]", A, B);
        }

    }
}

