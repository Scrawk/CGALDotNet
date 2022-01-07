using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNet.Geometry
{

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3d : IEquatable<Point3d>
    {
        public double x, y, z;

        /// <summary>
        /// The unit x point.
        /// </summary>
	    public readonly static Point3d UnitX = new Point3d(1, 0, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static Point3d UnitY = new Point3d(0, 1, 0);

        /// <summary>
        /// The unit z point.
        /// </summary>
        public readonly static Point3d UnitZ = new Point3d(0, 0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static Point3d Zero = new Point3d(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
	    public readonly static Point3d One = new Point3d(1);

        /// <summary>
        /// A point of 0.5.
        /// </summary>
        public readonly static Point3d Half = new Point3d(0.5);

        /// <summary>
        /// A point of positive infinity.
        /// </summary>
        public readonly static Point3d PositiveInfinity = new Point3d(double.PositiveInfinity);

        /// <summary>
        /// A point of negative infinity.
        /// </summary>
        public readonly static Point3d NegativeInfinity = new Point3d(double.NegativeInfinity);

        /// <summary>
        /// 3D point to 3D swizzle point.
        /// </summary>
        public Point3d xzy => new Point3d(x, z, y);

        /// <summary>
        /// 3D point to 2D point.
        /// </summary>
        public Point2d xy => new Point2d(x, y);

        /// <summary>
        /// 3D point to 4D point with w as 0.
        /// </summary>
        public Point4d xyz0 => new Point4d(x, y, z, 0);

        /// <summary>
        /// 3D point to 4D point with w as 1.
        /// </summary>
        public Point4d xyz1 => new Point4d(x, y, z, 1);

        /// <summary>
        /// A point all with the value v.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point3d(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// A point from the varibles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
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
                    throw new IndexOutOfRangeException("Point3d index out of range.");

                fixed (Point3d* array = &this) { return ((double*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Point3d index out of range.");

                fixed (double* array = &x) { array[i] = value; }
            }
        }

        /// <summary>
        /// Convert from cartesian to homogenous space.
        /// </summary>
        public HPoint3d Homogenous
        {
            get
            {
                return new HPoint3d(x, y, z, 1);
            }
        }

        /// <summary>
        /// Convert from cartesian to homogenous space.
        /// </summary>
        public HPoint3d ToHomogenous(double w)
        {
            return new HPoint3d(x * w, y * w, z * w, w);
        }

        /// <summary>
        /// Point as vector.
        /// </summary>
        public Vector3d Vector3d => new Vector3d(x, y, z);

        /// <summary>
        /// Point as vector.
        /// </summary>
        public Vector4d Vector4d => new Vector4d(x, y, z, 1);

        /// <summary>
        /// The length of the point from the origin.
        /// </summary>
        public double Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                double sqm = SqrMagnitude;
                if (sqm != 0)
                    return Math.Sqrt(sqm);
                else
                    return 0;
            }
        }

        /// <summary>
        /// The length of the point from the origin squared.
        /// </summary>
		public double SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (x * x + y * y + z * z);
            }
        }

        /// <summary>
        /// Add two point and vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator +(Point3d v1, Vector3d v2)
        {
            return new Point3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Add two point and vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator +(Vector3d v1, Point3d v2)
        {
            return new Point3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Add two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator +(Point3d v1, Point3d v2)
        {
            return new Point3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator +(Point3d v1, double s)
        {
            return new Point3d(v1.x + s, v1.y + s, v1.z + s);
        }

        /// <summary>
        /// Add point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator +(double s, Point3d v1)
        {
            return new Point3d(s + v1.x, s + v1.y, s + v1.z);
        }

        /// <summary>
        /// Negate point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator -(Point3d v)
        {
            return new Point3d(-v.x, -v.y, -v.z);
        }

        /// <summary>
        /// Subtract two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator -(Point3d v1, Point3d v2)
        {
            return new Point3d(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator -(Point3d v1, double s)
        {
            return new Point3d(v1.x - s, v1.y - s, v1.z - s);
        }

        /// <summary>
        /// Subtract point and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator -(double s, Point3d v1)
        {
            return new Point3d(s - v1.x, s - v1.y, s - v1.z);
        }

        /// <summary>
        /// Multiply two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator *(Point3d v1, Point3d v2)
        {
            return new Point3d(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator *(Point3d v, double s)
        {
            return new Point3d(v.x * s, v.y * s, v.z * s);
        }

        /// <summary>
        /// Multiply a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator *(double s, Point3d v)
        {
            return new Point3d(v.x * s, v.y * s, v.z * s);
        }

        /// <summary>
        /// Divide two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator /(Point3d v1, Point3d v2)
        {
            return new Point3d(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        /// <summary>
        /// Divide a point and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d operator /(Point3d v, double s)
        {
            return new Point3d(v.x / s, v.y / s, v.z / s);
        }

        /// <summary>
        /// Implict cast from vector.
        /// </summary>
        /// <param name="v">The vector to cast from</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Point3d(Vector3d v)
        {
            return new Point3d(v.x, v.y, v.z);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point3d v1, Point3d v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        /// <summary>
        /// Are these points not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point3d v1, Point3d v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.z != v2.z);
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Point3d)) return false;
            Point3d v = (Point3d)obj;
            return this == v;
        }

        /// <summary>
        /// Are these points equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Point3d v)
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
                return hash;
            }
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", x, y, z);
        }

        /// <summary>
        /// Vector as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2}", x.ToString(f), y.ToString(f), z.ToString(f));
        }

        /// <summary>
        /// Distance between two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance(Point3d v0, Point3d v1)
        {
            return Math.Sqrt(SqrDistance(v0, v1));
        }

        /// <summary>
        /// Square distance between two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SqrDistance(Point3d v0, Point3d v1)
        {
            double x = v0.x - v1.x;
            double y = v0.y - v1.y;
            double z = v0.z - v1.z;
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Direction between two points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d Direction(Point3d v0, Point3d v1)
        {
            return (v1 - v0).Vector3d.Normalized;
        }

        /// <summary>
        /// The minimum value between s and each component in point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Min(Point3d v, double s)
        {
            v.x = Math.Min(v.x, s);
            v.y = Math.Min(v.y, s);
            v.z = Math.Min(v.z, s);
            return v;
        }

        /// <summary>
        /// The minimum value between each component in points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Min(Point3d v0, Point3d v1)
        {
            v0.x = Math.Min(v0.x, v1.x);
            v0.y = Math.Min(v0.y, v1.y);
            v0.z = Math.Min(v0.z, v1.z);
            return v0;
        }

        /// <summary>
        /// The maximum value between s and each component in point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Max(Point3d v, double s)
        {
            v.x = Math.Max(v.x, s);
            v.y = Math.Max(v.y, s);
            v.z = Math.Max(v.z, s);
            return v;
        }

        /// <summary>
        /// The maximum value between each component in points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Max(Point3d v0, Point3d v1)
        {
            v0.x = Math.Max(v0.x, v1.x);
            v0.y = Math.Max(v0.y, v1.y);
            v0.z = Math.Max(v0.z, v1.z);
            return v0;
        }

        /// <summary>
        /// Clamp each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Clamp(Point3d v, double min, double max)
        {
            v.x = Math.Max(Math.Min(v.x, max), min);
            v.y = Math.Max(Math.Min(v.y, max), min);
            v.z = Math.Max(Math.Min(v.z, max), min);
            return v;
        }

        /// <summary>
        /// Clamp each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3d Clamp(Point3d v, Point3d min, Point3d max)
        {
            v.x = Math.Max(Math.Min(v.x, max.x), min.x);
            v.y = Math.Max(Math.Min(v.y, max.y), min.y);
            v.z = Math.Max(Math.Min(v.z, max.z), min.z);
            return v;
        }

        /// <summary>
        /// Lerp between two points.
        /// </summary>
        public static Point3d Lerp(Point3d from, Point3d to, double t)
        {
            if (t < 0.0) t = 0.0;
            if (t > 1.0) t = 1.0;

            if (t == 0.0) return from;
            if (t == 1.0) return to;

            double t1 = 1.0f - t;
            var v = new Point3d();
            v.x = from.x * t1 + to.x * t;
            v.y = from.y * t1 + to.y * t;
            v.z = from.z * t1 + to.z * t;
            return v;
        }

        /// <summary>
        /// A rounded point.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        /// <returns>The rounded point</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point3d Rounded(int digits = 0)
        {
            double x = Math.Round(this.x, digits);
            double y = Math.Round(this.y, digits);
            double z = Math.Round(this.z, digits);
            return new Point3d(x, y, z);
        }

        /// <summary>
        /// Round the point.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Round(int digits = 0)
        {
            x = Math.Round(x, digits);
            y = Math.Round(y, digits);
            z = Math.Round(z, digits);
        }

        /// <summary>
        /// Create a array of random points.
        /// </summary>
        /// <param name="seed">The seed</param>
        /// <param name="count">The number of points to create.</param>
        /// <param name="range">The range of the points.</param>
        /// <returns>The point array.</returns>
        public static Point3d[] RandomPoints(int seed, int count, Box3d range)
        {
            var points = new Point3d[count];
            var rnd = new Random(seed);

            for (int i = 0; i < count; i++)
            {
                double x = range.Min.x + rnd.NextDouble() * range.Max.x;
                double y = range.Min.y + rnd.NextDouble() * range.Max.y;
                double z = range.Min.z + rnd.NextDouble() * range.Max.z;

                points[i] = new Point3d(x, y, z);
            }

            return points;
        }

    }
}
