using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    public static class MathUtil
    {

        public const double RAD_TO_DEG = 180.0 / Math.PI;

        public const double DEG_TO_RAD = Math.PI / 180.0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double v, double min, double max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Wrap(int v, int count)
        {
            int r = v % count;
            return r < 0 ? r + count : r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double degrees)
        {
            return degrees * DEG_TO_RAD;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Sin(Radian radian)
        {
            return new Radian(Math.Sin(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Sin(Degree degree)
        {
            return new Degree(Math.Sin(degree.angle * DEG_TO_RAD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Cos(Radian radian)
        {
            return new Radian(Math.Cos(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Cos(Degree degree)
        {
            return new Degree(Math.Cos(degree.angle * DEG_TO_RAD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Radian Tan(Radian radian)
        {
            return new Radian(Math.Tan(radian.angle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Degree Tan(Degree degree)
        {
            return new Degree(Math.Tan(degree.angle * DEG_TO_RAD));
        }
    }
}
