using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using CGeom2D.Numerics;
using CGeom2D.Geometry;
using CGeom2D.Points;

namespace CGeom2D
{
    /// <summary>
    /// Global utility functions.
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        public const double RAD_TO_DEG = 180.0 / Math.PI;

        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        public const double DEG_TO_RAD = Math.PI / 180.0;

        /// <summary>
        /// Clamp v to min and max.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        /// <summary>
        /// Clamp v to min and max.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double v, double min, double max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        /// <summary>
        /// Clamp v to 0 and 1.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <returns>The clamped value</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp01(double v)
        {
            if (v < 0.0) v = 0.0;
            if (v > 1.0) v = 1.0;
            return v;
        }

        /// <summary>
        /// Wrap a value between 0 and count-1 (inclusive).
        /// </summary>
        /// <param name="v">The value v</param>
        /// <param name="count">The value to wrap at.</param>
        /// <returns>The value between 0 and count-1 (inclusive).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Wrap(int v, int count)
        {
            int r = v % count;
            return r < 0 ? r + count : r;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double degrees)
        {
            return degrees * DEG_TO_RAD;
        }

        /// <summary>
        /// Sin func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Sin(Radian radian)
        {
            return new Radian(Math.Sin(radian.angle));
        }

        /// <summary>
        /// Cos func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Cos(Radian radian)
        {
            return new Radian(Math.Cos(radian.angle));
        }

        /// <summary>
        /// Tan func using radians.
        /// </summary>
        /// <param name="radian">The input in radians.</param>
        /// <returns>The output in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Tan(Radian radian)
        {
            return new Radian(Math.Tan(radian.angle));
        }

        /// <summary>
        /// Swap the value of a and b.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T a,  ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

    }
}
