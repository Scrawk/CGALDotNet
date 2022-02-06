using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using CGALDotNetGeometry.Shapes;

using REAL = System.Double;

namespace CGALDotNetGeometry.Numerics
{

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct HPoint3d : IEquatable<HPoint3d>
    {
        public REAL x, y, z, w;

        /// <summary>
        /// The unit x point.
        /// </summary>
	    public readonly static HPoint3d UnitX = new HPoint3d(1, 0, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static HPoint3d UnitY = new HPoint3d(0, 1, 0);

        /// <summary>
        /// The unit z point.
        /// </summary>
        public readonly static HPoint3d UnitZ = new HPoint3d(0, 0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static HPoint3d Zero = new HPoint3d(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
	    public readonly static HPoint3d One = new HPoint3d(1);

        /// <summary>
        /// A point of 0.5.
        /// </summary>
        public readonly static HPoint3d Half = new HPoint3d(0.5);

        /// <summary>
        /// A point of positive infinity.
        /// </summary>
        public readonly static HPoint3d PositiveInfinity = new HPoint3d(REAL.PositiveInfinity);

        /// <summary>
        /// A point of negative infinity.
        /// </summary>
        public readonly static HPoint3d NegativeInfinity = new HPoint3d(REAL.NegativeInfinity);


        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint3d(REAL v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = 1;
        }

        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint3d(REAL v, REAL w)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = w;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint3d(REAL x, REAL y, REAL z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 1;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HPoint3d(REAL x, REAL y, REAL z, REAL w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
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
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("HPoint3d index out of range.");

                fixed (HPoint3d* array = &this) { return ((REAL*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("HPoint3d index out of range.");

                fixed (REAL* array = &x) { array[i] = value; }
            }
        }

        /// <summary>
        /// Are all the components of vector finite.
        /// </summary>
        public bool IsFinite
        {
            get
            {
                if (!MathUtil.IsFinite(x)) return false;
                if (!MathUtil.IsFinite(y)) return false;
                if (!MathUtil.IsFinite(w)) return false;
                return true;
            }
        }

        /// <summary>
        /// Make a point with no non finite conponents.
        /// </summary>
        public HPoint2d Finite
        {
            get
            {
                var p = new HPoint2d(x, y, w);
                if (!MathUtil.IsFinite(p.x)) p.x = 0;
                if (!MathUtil.IsFinite(p.y)) p.y = 0;
                if (!MathUtil.IsFinite(p.w)) p.w = 0;
                return p;
            }
        }

        /// <summary>
        /// Convert from homogenous to cartesian space.
        /// </summary>
        public Point3d Cartesian
        {
            get
            {
                if (w != 0)
                    return new Point3d(x / w, y / w, z / w);
                else
                    return new Point3d(x, y, z);
            }
        }

        /// <summary>
        /// Point as vector.
        /// </summary>
        public Vector3d Vector3d => new Vector3d(x, y, z);

        /// <summary>
        /// Point as vector.
        /// </summary>
        public Vector4d Vector4d => new Vector4d(x, y, z, w);

        /// <summary>
        /// Add two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator +(HPoint3d v1, HPoint3d v2)
        {
            return new HPoint3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator +(HPoint3d v1, REAL s)
        {
            return new HPoint3d(v1.x + s, v1.z + s, v1.z + s, v1.w + s);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator +(REAL s, HPoint3d v1)
        {
            return new HPoint3d(s + v1.x, s + v1.y, s + v1.z, s + v1.w);
        }

        /// <summary>
        /// Multiply two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator *(HPoint3d v1, HPoint3d v2)
        {
            return new HPoint3d(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator *(HPoint3d v, REAL s)
        {
            return new HPoint3d(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HPoint3d operator *(REAL s, HPoint3d v)
        {
            return new HPoint3d(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(HPoint3d v1, HPoint3d v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w);
        }

        /// <summary>
        /// Are these points not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(HPoint3d v1, HPoint3d v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.z != v2.z || v1.w != v2.w);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is HPoint3d)) return false;
            HPoint3d v = (HPoint3d)obj;
            return this == v;
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(HPoint3d v)
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
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ x.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ y.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ z.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ w.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", x, y, z, w);
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2},{3}", x.ToString(f), y.ToString(f), z.ToString(f), w.ToString(f));
        }

        /// <summary>
        /// Create a array of random points.
        /// </summary>
        /// <param name="seed">The seed</param>
        /// <param name="count">The number of points to create.</param>
        /// <param name="weight">The number of points weight.</param>
        /// <param name="range">The range of the points.</param>
        /// <returns>The point array.</returns>
        public static HPoint3d[] RandomPoints(int seed, int count, REAL weight, Box3d range)
        {
            var points = new HPoint3d[count];
            var rnd = new Random(seed);

            for (int i = 0; i < count; i++)
            {
                REAL x = range.Min.x + rnd.NextDouble() * range.Max.x;
                REAL y = range.Min.y + rnd.NextDouble() * range.Max.y;
                REAL z = range.Min.z + rnd.NextDouble() * range.Max.z;

                points[i] = new HPoint3d(x, y, z, weight);
            }

            return points;
        }

    }
}
