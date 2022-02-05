using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle3f : IEquatable<Triangle3f>
    {

        public Point3f A;

        public Point3f B;

        public Point3f C;

        public Triangle3f(Point3f a, Point3f b, Point3f c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Triangle3f(float ax, float ay, float az, float bx, float by, float bz, float cx, float cy, float cz)
        {
            A = new Point3f(ax, ay, az);
            B = new Point3f(bx, by, bz);
            C = new Point3f(cx, cy, cz);
        }

        public Point3f Center
        {
            get { return (A + B + C) / 3.0f; }
        }


        /// <summary>
        /// Calculate the bounding box.
        /// </summary>
        public Box3f Bounds
        {
            get
            {
                var xmin = MathUtil.Min(A.x, B.x, C.x);
                var xmax = MathUtil.Max(A.x, B.x, C.x);
                var ymin = MathUtil.Min(A.y, B.y, C.y);
                var ymax = MathUtil.Max(A.y, B.y, C.y);
                var zmin = MathUtil.Min(A.z, B.y, C.y);
                var zmax = MathUtil.Max(A.z, B.z, C.z);

                return new Box3f(xmin, xmax, ymin, ymax, zmin, zmax);
            }
        }

        unsafe public Point3f this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle3f index out of range.");

                fixed (Triangle3f* array = &this) { return ((Point3f*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle3f index out of range.");

                fixed (Point3f* array = &A) { array[i] = value; }
            }
        }

        public static Triangle3f operator +(Triangle3f tri, float s)
        {
            return new Triangle3f(tri.A + s, tri.B + s, tri.C + s);
        }

        public static Triangle3f operator +(Triangle3f tri, Point3f v)
        {
            return new Triangle3f(tri.A + v, tri.B + v, tri.C + v);
        }

        public static Triangle3f operator -(Triangle3f tri, float s)
        {
            return new Triangle3f(tri.A - s, tri.B - s, tri.C - s);
        }

        public static Triangle3f operator *(Triangle3f tri, float s)
        {
            return new Triangle3f(tri.A * s, tri.B * s, tri.C * s);
        }

        public static Triangle3f operator /(Triangle3f tri, float s)
        {
            return new Triangle3f(tri.A / s, tri.B / s, tri.C / s);
        }

        public static Triangle3f operator /(Triangle3f tri, Point3f v)
        {
            return new Triangle3f(tri.A / v, tri.B / v, tri.C / v);
        }

        public static Triangle3f operator *(Triangle3f tri, Matrix3x3f m)
        {
            return new Triangle3f(m * tri.A, m * tri.B, m * tri.C);
        }

        public static bool operator ==(Triangle3f t1, Triangle3f t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(Triangle3f t1, Triangle3f t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Triangle3f)) return false;
            Triangle3f tri = (Triangle3f)obj;
            return this == tri;
        }

        public bool Equals(Triangle3f tri)
        {
            return this == tri;
        }

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

        public override string ToString()
        {
            return string.Format("[Triangle3f: A={0}, B={1}, C={2}]", A, B, C);
        }

    }
}
