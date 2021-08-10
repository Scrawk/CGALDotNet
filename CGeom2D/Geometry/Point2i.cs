using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using REAL = CGeom2D.Numerics.Int128;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2i : IEquatable<Point2i>
    {
        public REAL x, y;

        /// <summary>
        /// The unit x point.
        /// </summary>
	    public readonly static Point2i UnitX = new Point2i(1, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static Point2i UnitY = new Point2i(0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static Point2i Zero = new Point2i(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
	    public readonly static Point2i One = new Point2i(1);

        /// <summary>
        /// A point of positive infinity.
        /// </summary>
        public readonly static Point2i MaxValue = new Point2i(REAL.MaxValue);

        /// <summary>
        /// A point of negative infinity.
        /// </summary>
        public readonly static Point2i MinValue = new Point2i(REAL.MinValue);

        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2i(REAL v)
        {
            this.x = v;
            this.y = v;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2i(REAL x, REAL y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Array accessor for variables. 
        /// </summary>
        /// <param name="i">The variables index.</param>
        /// <returns>The variable value</returns>
        unsafe public REAL this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Point2i index out of range.");

                fixed (Point2i* array = &this) { return ((REAL*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Point2i index out of range.");

                fixed (REAL* array = &x) { array[i] = value; }
            }
        }

        /// <summary>
        /// The length of the point from the origin squared.
        /// </summary>
		public REAL SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return x * x + y * y;
            }
        }

        /// <summary>
        /// Add two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator +(Point2i v1, Point2i v2)
        {
            return new Point2i(v1.x + v2.x, v1.y + v2.y);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator +(Point2i v1, REAL s)
        {
            return new Point2i(v1.x + s, v1.y + s);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator +(REAL s, Point2i v1)
        {
            return new Point2i(s + v1.x, s + v1.y);
        }

        /// <summary>
        /// Negate point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator -(Point2i v)
        {
            return new Point2i(-v.x, -v.y);
        }

        /// <summary>
        /// Subtract two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator -(Point2i v1, Point2i v2)
        {
            return new Point2i(v1.x - v2.x, v1.y - v2.y);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator -(Point2i v1, REAL s)
        {
            return new Point2i(v1.x - s, v1.y - s);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator -(REAL s, Point2i v1)
        {
            return new Point2i(s - v1.x, s - v1.y);
        }

        /// <summary>
        /// Multiply two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator *(Point2i v1, Point2i v2)
        {
            return new Point2i(v1.x * v2.x, v1.y * v2.y);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator *(Point2i v, REAL s)
        {
            return new Point2i(v.x * s, v.y * s);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator *(REAL s, Point2i v)
        {
            return new Point2i(v.x * s, v.y * s);
        }

        /// <summary>
        /// Divide two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator /(Point2i v1, Point2i v2)
        {
            return new Point2i(v1.x / v2.x, v1.y / v2.y);
        }

        /// <summary>
        /// Divide a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2i operator /(Point2i v, REAL s)
        {
            return new Point2i(v.x / s, v.y / s);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point2i v1, Point2i v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        /// <summary>
        /// Are these points not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point2i v1, Point2i v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Point2i)) return false;
            Point2i v = (Point2i)obj;
            return this == v;
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Point2i v)
        {
            return this == v;
        }

        /// <summary>
        /// Vectors hash code. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ x.GetHashCode();
                hash = (hash * 16777619) ^ y.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0},{1}", x.ToString(f), y.ToString(f));
        }

        /// <summary>
        /// Square distance between two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static REAL SqrDistance(Point2i v0, Point2i v1)
        {
            REAL x = v0.x - v1.x;
            REAL y = v0.y - v1.y;
            return x * x + y * y;
        }

    }
}
