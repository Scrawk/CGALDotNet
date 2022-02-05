using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNetGeometry.Numerics
{
    /// <summary>
    /// Represents a angle in degrees.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Degree : IEquatable<Degree>
    {
        /// <summary>
        /// The angle in degrees.
        /// </summary>
        public double angle;

        /// <summary>
        /// The degrees angle in radians.
        /// </summary>
        public double radian => angle * MathUtil.DEG_TO_RAD_64;

        /// <summary>
        /// 0 degrees.
        /// </summary>
        public readonly static Degree A0 = new Degree(0);

        /// <summary>
        /// 90 degrees.
        /// </summary>
        public readonly static Degree A90 = new Degree(90);

        /// <summary>
        /// 180 degrees.
        /// </summary>
        public readonly static Degree A180 = new Degree(180);

        /// <summary>
        /// 270 degrees.
        /// </summary>
        public readonly static Degree A270 = new Degree(270);

        /// <summary>
        /// 360 degrees.
        /// </summary>
        public readonly static Degree A360 = new Degree(360);

        /// <summary>
        /// Create a new degree from a value.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Degree(double angle)
        {
            this.angle = angle;
        }

        /// <summary>
        /// Add two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator +(Degree v1, Degree v2)
        {
            return new Degree(v1.angle + v2.angle);
        }

        /// <summary>
        /// Add angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator +(Degree v1, double s)
        {
            return new Degree(v1.angle + s);
        }

        /// <summary>
        /// Negate the angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator -(Degree v)
        {
            return new Degree(-v.angle);
        }

        /// <summary>
        /// Add angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator +(double s, Degree v1)
        {
            return new Degree(s + v1.angle);
        }

        /// <summary>
        /// Subtract two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator -(Degree v1, Degree v2)
        {
            return new Degree(v1.angle - v2.angle);
        }

        /// <summary>
        /// Subtract angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator -(Degree v1, double s)
        {
            return new Degree(v1.angle - s);
        }

        /// <summary>
        /// Subtract angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator -(double s, Degree v1)
        {
            return new Degree(s - v1.angle);
        }

        /// <summary>
        /// Multiply two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator *(Degree v1, Degree v2)
        {
            return new Degree(v1.angle * v2.angle);
        }

        /// <summary>
        /// Multiply a angle and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator *(Degree v, double s)
        {
            return new Degree(v.angle * s);
        }

        /// <summary>
        /// Multiply a angle and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator *(double s, Degree v)
        {
            return new Degree(v.angle * s);
        }

        /// <summary>
        /// Divide two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator /(Degree v1, Degree v2)
        {
            return new Degree(v1.angle / v2.angle);
        }

        /// <summary>
        /// Divide a angle and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree operator /(Degree v, double s)
        {
            return new Degree(v.angle / s);
        }

        /// <summary>
        /// Cast from a radian to degrees.
        /// </summary>
        /// <param name="v">The angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Degree(Radian v)
        {
            return new Degree(v.angle * MathUtil.RAD_TO_DEG_64);
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Degree v1, Degree v2)
        {
            return v1.angle == v2.angle;
        }

        /// <summary>
        /// Are these angles not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Degree v1, Degree v2)
        {
            return v1.angle != v2.angle;
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Degree)) return false;
            Degree v = (Degree)obj;
            return this == v;
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Degree v)
        {
            return this == v;
        }

        /// <summary>
        /// Angles hash code. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return angle.GetHashCode();
        }

        /// <summary>
        /// Angles as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("{0} degrees", angle);
        }

        /// <summary>
        /// Angles as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0} degrees", angle.ToString(f));
        }

        /// <summary>
        /// A rounded angle.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        /// <returns>The rounded angle</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Rounded(int digits = 0)
        {
            return Math.Round(angle, digits);
        }
    }
}
