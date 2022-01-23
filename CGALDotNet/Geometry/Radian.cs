using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Represents a angle in degrees.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Radian : IEquatable<Radian>
    {
        /// <summary>
        /// The angle in radians.
        /// </summary>
        public double angle;

        /// <summary>
        /// Pi.
        /// </summary>
        public readonly static Radian PI = new Radian(Math.PI);

        /// <summary>
        /// 0 degrees.
        /// </summary>
        public readonly static Radian A0 = new Radian(0);

        /// <summary>
        /// 90 degrees.
        /// </summary>
        public readonly static Radian A45 = new Radian(45 * CGALGlobal.DEG_TO_RAD);

        /// <summary>
        /// 90 degrees.
        /// </summary>
        public readonly static Radian A90 = new Radian(90 * CGALGlobal.DEG_TO_RAD);

        /// <summary>
        /// 180 degrees.
        /// </summary>
        public readonly static Radian A180 = new Radian(180 * CGALGlobal.DEG_TO_RAD);

        /// <summary>
        /// 270 degrees.
        /// </summary>
        public readonly static Radian A270 = new Radian(270 * CGALGlobal.DEG_TO_RAD);

        /// <summary>
        /// 360 degrees.
        /// </summary>
        public readonly static Radian A360 = new Radian(360 * CGALGlobal.DEG_TO_RAD);

        /// <summary>
        /// Create a new radian from a value.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Radian(double angle)
        {
            this.angle = angle;
        }

        /// <summary>
        /// Add two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator +(Radian v1, Radian v2)
        {
            return new Radian(v1.angle + v2.angle);
        }

        /// <summary>
        /// Add angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator +(Radian v1, double s)
        {
            return new Radian(v1.angle + s);
        }

        /// <summary>
        /// Negate the angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator -(Radian v)
        {
            return new Radian(-v.angle);
        }

        /// <summary>
        /// Add angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator +(double s, Radian v1)
        {
            return new Radian(s + v1.angle);
        }

        /// <summary>
        /// Subtract two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator -(Radian v1, Radian v2)
        {
            return new Radian(v1.angle - v2.angle);
        }

        /// <summary>
        /// Subtract angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator -(Radian v1, double s)
        {
            return new Radian(v1.angle - s);
        }

        /// <summary>
        /// Subtract angle and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator -(double s, Radian v1)
        {
            return new Radian(s - v1.angle);
        }

        /// <summary>
        /// Multiply two angles.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator *(Radian v1, Radian v2)
        {
            return new Radian(v1.angle * v2.angle);
        }

        /// <summary>
        /// Multiply a angle and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator *(Radian v, double s)
        {
            return new Radian(v.angle * s);
        }

        /// <summary>
        /// Multiply a angle and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian operator *(double s, Radian v)
        {
            return new Radian(v.angle * s);
        }

        /// <summary>
        /// Cast from a degrees to radians.
        /// </summary>
        /// <param name="v">The angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Radian(Degree v)
        {
            return new Radian(v.angle * CGALGlobal.DEG_TO_RAD);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Radian v1, Radian v2)
        {
            return v1.angle >= v2.angle;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Radian v1, Radian v2)
        {
            return v1.angle > v2.angle;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Radian v1, Radian v2)
        {
            return v1.angle < v2.angle;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Radian v1, Radian v2)
        {
            return v1.angle <= v2.angle;
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Radian v1, Radian v2)
        {
            return v1.angle == v2.angle;
        }

        /// <summary>
        /// Are these angles not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Radian v1, Radian v2)
        {
            return v1.angle != v2.angle;
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Radian)) return false;
            Radian v = (Radian)obj;
            return this == v;
        }

        /// <summary>
        /// Are these angles equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Radian v)
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
            return string.Format("{0} radians", angle);
        }

        /// <summary>
        /// Angles as a string.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string f)
        {
            return string.Format("{0} radians", angle.ToString(f));
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
