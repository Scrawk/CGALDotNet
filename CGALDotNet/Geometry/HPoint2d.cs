using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// A Homogenous 2D point struct.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct HPoint2d : IEquatable<HPoint2d>
    {
        public double x, y, w;

        /// <summary>
        /// The unit x point.
        /// </summary>
	    public readonly static HPoint2d UnitX = new HPoint2d(1, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static HPoint2d UnitY = new HPoint2d(0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static HPoint2d Zero = new HPoint2d(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
	    public readonly static HPoint2d One = new HPoint2d(1);


        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint2d(double v)
        {
            this.x = v;
            this.y = v;
            this.w = 1;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint2d(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.w = 1;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint2d(double x, double y, double w)
        {
            this.x = x;
            this.y = y;
            this.w = w;
        }

        /// <summary>
        /// Array accessor for variables. 
        /// </summary>
        /// <param name="i">The variables index.</param>
        /// <returns>The variable value</returns>
        unsafe public double this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("HPoint2d index out of range.");

                fixed (HPoint2d* array = &this) { return ((double*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("HPoint2d index out of range.");

                fixed (double* array = &x) { array[i] = value; }
            }
        }

        /// <summary>
        /// Convert from homogenous to cartesian space.
        /// </summary>
        public Point2d Cartesian
        {
            get
            {
                if (w != 0)
                    return new Point2d(x / w, y / w);
                else
                    return new Point2d(x, y);
            }
        }

        /// <summary>
        /// Add two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator +(HPoint2d v1, HPoint2d v2)
        {
            return new HPoint2d(v1.x + v2.x, v1.y + v2.y, v1.w + v2.w);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator +(HPoint2d v1, double s)
        {
            return new HPoint2d(v1.x + s, v1.y + s, v1.w + s);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator +(double s, HPoint2d v1)
        {
            return new HPoint2d(s + v1.x, s + v1.y, s + v1.w);
        }

        /// <summary>
        /// Multiply two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator *(HPoint2d v1, HPoint2d v2)
        {
            return new HPoint2d(v1.x * v2.x, v1.y * v2.y, v1.w * v2.w);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator *(HPoint2d v, double s)
        {
            return new HPoint2d(v.x * s, v.y * s, v.w * s);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint2d operator *(double s, HPoint2d v)
        {
            return new HPoint2d(v.x * s, v.y * s, v.w * s);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(HPoint2d v1, HPoint2d v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.w == v2.w);
        }

        /// <summary>
        /// Are these points not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(HPoint2d v1, HPoint2d v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.w != v2.w);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is HPoint2d)) return false;
            HPoint2d v = (HPoint2d)obj;
            return this == v;
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(HPoint2d v)
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
                hash = (hash * 16777619) ^ w.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", x, y, w);
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2}", x.ToString(f), y.ToString(f), w.ToString(f));
        }

    }
}
