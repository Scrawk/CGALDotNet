using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNet.Geometry
{

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4d : IEquatable<Vector4d>
    {

        public double x, y, z, w;

        /// <summary>
        /// The unit x vector.
        /// </summary>
        public readonly static Vector4d UnitX = new Vector4d(1, 0, 0, 0);

        /// <summary>
        /// The unit y vector.
        /// </summary>
	    public readonly static Vector4d UnitY = new Vector4d(0, 1, 0, 0);

        /// <summary>
        /// The unit z vector.
        /// </summary>
	    public readonly static Vector4d UnitZ = new Vector4d(0, 0, 1, 0);

        /// <summary>
        /// The unit w vector.
        /// </summary>
	    public readonly static Vector4d UnitW = new Vector4d(0, 0, 0, 1);

        /// <summary>
        /// A vector of zeros.
        /// </summary>
	    public readonly static Vector4d Zero = new Vector4d(0);

        /// <summary>
        /// A vector of ones.
        /// </summary>
	    public readonly static Vector4d One = new Vector4d(1);

        /// <summary>
        /// A vector of 0.5.
        /// </summary>
        public readonly static Vector4d Half = new Vector4d(0.5);

        /// <summary>
        /// A vector of positive infinity.
        /// </summary>
        public readonly static Vector4d PositiveInfinity = new Vector4d(double.PositiveInfinity);

        /// <summary>
        /// A vector of negative infinity.
        /// </summary>
        public readonly static Vector4d NegativeInfinity = new Vector4d(double.NegativeInfinity);

        /// <summary>
        /// A vector all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4d(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }

        /// <summary>
        /// A vector from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4d(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// A vector from a 2d vector and the z and w varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4d(Vector2d v, double z, double w)
        {
            x = v.x;
            y = v.y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// A vector from a 3d vector and the w varible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4d(Vector3d v, double w)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            this.w = w;
        }

        unsafe public double this[int i]
        {
            get
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Vector4d index out of range.");

                fixed (Vector4d* array = &this) { return ((double*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("Vector4d index out of range.");

                fixed (double* array = &x) { array[i] = value; }
            }
        }

        /// <summary>
        /// The length of the vector.
        /// </summary>
        public double Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                double sqm = SqrMagnitude;
                if (sqm != 0)
                    return Math.Sqrt(SqrMagnitude);
                else
                    return 0;
            }
        }

        /// <summary>
        /// The length of the vector squared.
        /// </summary>
		public double SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (x * x + y * y + z * z + w * w);
            }
        }

        /// <summary>
        /// The vector normalized.
        /// </summary>
        public Vector4d Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                double sqm = SqrMagnitude;
                if (sqm != 0)
                {
                    double invLength = 1.0 / sqm;
                    return new Vector4d(x * invLength, y * invLength, z * invLength, w * invLength);
                }
                else
                    return Zero;
            }
        }

        /// <summary>
        /// Add two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator +(Vector4d v1, Vector4d v2)
        {
            return new Vector4d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator +(Vector4d v1, double s)
        {
            return new Vector4d(v1.x + s, v1.y + s, v1.z + s, v1.w + s);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator +(double s, Vector4d v1)
        {
            return new Vector4d(s + v1.x, s + v1.y, s + v1.z, s + v1.w);
        }

        /// <summary>
        /// Negate vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator -(Vector4d v)
        {
            return new Vector4d(-v.x, -v.y, -v.z, -v.w);
        }

        /// <summary>
        /// Subtract two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator -(Vector4d v1, Vector4d v2)
        {
            return new Vector4d(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator -(Vector4d v1, double s)
        {
            return new Vector4d(v1.x - s, v1.y - s, v1.z - s, v1.w - s);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator -(double s, Vector4d v1)
        {
            return new Vector4d(s - v1.x, s - v1.y, s - v1.z, s - v1.w);
        }

        /// <summary>
        /// Dot porduct of two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator *(Vector4d v1, Vector4d v2)
        {
            return Dot(v1, v2);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator *(Vector4d v, double s)
        {
            return new Vector4d(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator *(double s, Vector4d v)
        {
            return new Vector4d(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        /// <summary>
        /// Divide a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d operator /(Vector4d v, double s)
        {
            if (s != 0)
                return new Vector4d(v.x / s, v.y / s, v.z / s, v.w / s);
            else
                return Zero;
        }

        /// <summary>
        /// Are these vectors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4d v1, Vector4d v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w);
        }

        /// <summary>
        /// Are these vectors not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4d v1, Vector4d v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.z != v2.z || v1.w != v2.w);
        }

        /// <summary>
        /// Are these vectors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4d)) return false;
            Vector4d v = (Vector4d)obj;
            return this == v;
        }

        /// <summary>
        /// Are these vectors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector4d v)
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
                hash = (hash * 16777619) ^ z.GetHashCode();
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
        /// The dot product of two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dot(Vector4d v0, Vector4d v1)
        {
            return (v0.x * v1.x + v0.y * v1.y + v0.z * v1.z + v0.w * v1.w);
        }
        /// <summary>
        /// The abs dot product of two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AbsDot(Vector4d v0, Vector4d v1)
        {
            return Math.Abs(v0.x * v1.x + v0.y * v1.y + v0.z * v1.z + v0.w * v1.w);
        }

        /// <summary>
        /// Normalize the vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            double sqm = SqrMagnitude;
            if (sqm != 0)
            {
                double invLength = 1.0 / sqm;
                x *= invLength;
                y *= invLength;
                z *= invLength;
                w *= invLength;
            }
        }

        /// <summary>
        /// The minimum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Min(Vector4d v, double s)
        {
            v.x = Math.Min(v.x, s);
            v.y = Math.Min(v.y, s);
            v.z = Math.Min(v.z, s);
            v.w = Math.Min(v.w, s);
            return v;
        }

        /// <summary>
        /// The minimum value between each component in vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Min(Vector4d v0, Vector4d v1)
        {
            v0.x = Math.Min(v0.x, v1.x);
            v0.y = Math.Min(v0.y, v1.y);
            v0.z = Math.Min(v0.z, v1.z);
            v0.w = Math.Min(v0.w, v1.w);
            return v0;
        }

        /// <summary>
        /// The maximum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Max(Vector4d v, double s)
        {
            v.x = Math.Max(v.x, s);
            v.y = Math.Max(v.y, s);
            v.z = Math.Max(v.z, s);
            v.w = Math.Max(v.w, s);
            return v;
        }

        /// <summary>
        /// The maximum value between each component in vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Max(Vector4d v0, Vector4d v1)
        {
            v0.x = Math.Max(v0.x, v1.x);
            v0.y = Math.Max(v0.y, v1.y);
            v0.z = Math.Max(v0.z, v1.z);
            v0.w = Math.Max(v0.w, v1.w);
            return v0;
        }

        /// <summary>
        /// Clamp each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Clamp(Vector4d v, double min, double max)
        {
            v.x = Math.Max(Math.Min(v.x, max), min);
            v.y = Math.Max(Math.Min(v.y, max), min);
            v.z = Math.Max(Math.Min(v.z, max), min);
            v.w = Math.Max(Math.Min(v.w, max), min);
            return v;
        }

        /// <summary>
        /// Clamp each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4d Clamp(Vector4d v, Vector4d min, Vector4d max)
        {
            v.x = Math.Max(Math.Min(v.x, max.x), min.x);
            v.y = Math.Max(Math.Min(v.y, max.y), min.y);
            v.z = Math.Max(Math.Min(v.z, max.z), min.z);
            v.w = Math.Max(Math.Min(v.w, max.w), min.w);
            return v;
        }

        /// <summary>
        /// Lerp between two vectors.
        /// </summary>
        public static Vector4d Lerp(Vector4d from, Vector4d to, double t)
        {
            if (t < 0.0) t = 0.0;
            if (t > 1.0) t = 1.0;

            if (t == 0.0) return from;
            if (t == 1.0) return to;

            double t1 = 1.0 - t;
            Vector4d v = new Vector4d();
            v.x = from.x * t1 + to.x * t;
            v.y = from.y * t1 + to.y * t;
            v.z = from.z * t1 + to.z * t;
            v.w = from.w * t1 + to.w * t;
            return v;
        }

        /// <summary>
        /// Round vector.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4d Rounded(int digits)
        {
            double x = Math.Round(this.x, digits);
            double y = Math.Round(this.y, digits);
            double z = Math.Round(this.z, digits);
            double w = Math.Round(this.w, digits);
            return new Vector4d(x, y, z, w);
        }

    }

}


































