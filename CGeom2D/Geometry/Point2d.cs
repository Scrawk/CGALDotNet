using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using REAL = System.Double;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2d : IEquatable<Point2d>
    {
        public double x, y;

        /// <summary>
        /// The unit x point.
        /// </summary>
	    public readonly static Point2d UnitX = new Point2d(1, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static Point2d UnitY = new Point2d(0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static Point2d Zero = new Point2d(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
	    public readonly static Point2d One = new Point2d(1);

        /// <summary>
        /// A point of 0.5.
        /// </summary>
        public readonly static Point2d Half = new Point2d(0.5);

        /// <summary>
        /// A point of positive infinity.
        /// </summary>
        public readonly static Point2d PositiveInfinity = new Point2d(double.PositiveInfinity);

        /// <summary>
        /// A point of negative infinity.
        /// </summary>
        public readonly static Point2d NegativeInfinity = new Point2d(double.NegativeInfinity);

        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2d(REAL v)
        {
            this.x = v;
            this.y = v;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2d(REAL x, REAL y)
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
                    throw new IndexOutOfRangeException("Point2d index out of range.");

                fixed (Point2d* array = &this) { return ((REAL*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Point2d index out of range.");

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
        public static Point2d operator +(Point2d v1, Point2d v2)
        {
            return new Point2d(v1.x + v2.x, v1.y + v2.y);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator +(Point2d v1, double s)
        {
            return new Point2d(v1.x + s, v1.y + s);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator +(double s, Point2d v1)
        {
            return new Point2d(s + v1.x, s + v1.y);
        }

        /// <summary>
        /// Negate point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator -(Point2d v)
        {
            return new Point2d(-v.x, -v.y);
        }

        /// <summary>
        /// Subtract two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator -(Point2d v1, Point2d v2)
        {
            return new Point2d(v1.x - v2.x, v1.y - v2.y);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator -(Point2d v1, double s)
        {
            return new Point2d(v1.x - s, v1.y - s);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator -(double s, Point2d v1)
        {
            return new Point2d(s - v1.x, s - v1.y);
        }

        /// <summary>
        /// Multiply two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator *(Point2d v1, Point2d v2)
        {
            return new Point2d(v1.x * v2.x, v1.y * v2.y);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator *(Point2d v, double s)
        {
            return new Point2d(v.x * s, v.y * s);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator *(double s, Point2d v)
        {
            return new Point2d(v.x * s, v.y * s);
        }

        /// <summary>
        /// Divide two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator /(Point2d v1, Point2d v2)
        {
            return new Point2d(v1.x / v2.x, v1.y / v2.y);
        }

        /// <summary>
        /// Divide a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2d operator /(Point2d v, double s)
        {
            return new Point2d(v.x / s, v.y / s);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point2d v1, Point2d v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        /// <summary>
        /// Are these points not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point2d v1, Point2d v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Point2d)) return false;
            Point2d v = (Point2d)obj;
            return this == v;
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Point2d v)
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
        public static double SqrDistance(Point2d v0, Point2d v1)
        {
            REAL x = v0.x - v1.x;
            REAL y = v0.y - v1.y;
            return x * x + y * y;
        }


    }
}
