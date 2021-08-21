using System;
using System.Runtime.InteropServices;

using CGeom2D.Numerics;
using CGeom2D.Points;

using REAL = CGeom2D.Numerics.Int128;
using POINT2 = CGeom2D.Points.Point2i;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2i : IEquatable<Segment2i>
    {

        public POINT2 A;

        public POINT2 B;

        public POINT2 C => A;

        public POINT2 D => B;

        public Segment2i(POINT2 a, POINT2 b)
        {
            A = a;
            B = b;
        }

        public Segment2i(Int128 ax, Int128 ay, Int128 bx, Int128 by)
        {
            A = new POINT2(ax, ay);
            B = new POINT2(bx, by);
        }

        public Int128 SqrLength => POINT2.SqrDistance(A, B);

        unsafe public POINT2 this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2i index out of range.");

                fixed (Segment2i* array = &this) { return ((POINT2*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2i index out of range.");

                fixed (POINT2* array = &A) { array[i] = value; }
            }
        }


        public static Segment2i operator +(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A + s, seg.B + s);
        }

        public static Segment2i operator +(Segment2i seg, POINT2 v)
        {
            return new Segment2i(seg.A + v, seg.B + v);
        }

        public static Segment2i operator -(Segment2i seg, Int128 s)
        {
            return new Segment2i(seg.A - s, seg.B - s);
        }

        public static Segment2i operator -(Segment2i seg, POINT2 v)
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

