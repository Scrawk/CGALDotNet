using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Colors
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorHSV : IEquatable<ColorHSV>
    {

        public readonly static ColorHSV Red = new ColorHSV(0, 1, 1);
        public readonly static ColorHSV Green = new ColorHSV(120.0f / 360.0f, 1, 1);
        public readonly static ColorHSV Blue = new ColorHSV(240.0f / 360.0f, 1, 1);
        public readonly static ColorHSV Black = new ColorHSV(0, 0, 0);
        public readonly static ColorHSV White = new ColorHSV(0, 0, 1);

        public float h, s, v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorHSV(float h, float s, float v)
        {
            this.h = h;
            this.s = s;
            this.v = v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorHSV(double h, double s, double v)
        {
            this.h = (float)h;
            this.s = (float)s;
            this.v = (float)v;
        }

        public ColorRGB rgb
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return ToRGB(h, s, v); }
        }

        public ColorRGBA rgb1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return ToRGB(h, s, v).rgb1; }
        }

        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return MathUtil.SafeSqrt(SqrMagnitude); }
        }

        public float SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (h * h + s * s + v * v); }
        }

        unsafe public float this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("ColorHSV index out of range.");

                fixed (ColorHSV* array = &this) { return ((float*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("ColorHSV index out of range.");

                fixed (float* array = &h) { array[i] = value; }
            }
        }

        /// <summary>
        /// Add two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator +(ColorHSV hsv1, ColorHSV hsv2)
        {
            return new ColorHSV(hsv1.h + hsv2.h, hsv1.s + hsv2.s, hsv1.v + hsv2.v);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator +(ColorHSV hsv1, float s)
        {
            return new ColorHSV(hsv1.h + s, hsv1.s + s, hsv1.v + s);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator +(float s, ColorHSV hsv1)
        {
            return new ColorHSV(hsv1.h + s, hsv1.s + s, hsv1.v + s);
        }

        /// <summary>
        /// Subtract two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator -(ColorHSV hsv1, ColorHSV hsv2)
        {
            return new ColorHSV(hsv1.h - hsv2.h, hsv1.s - hsv2.s, hsv1.v - hsv2.v);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator -(ColorHSV hsv1, float s)
        {
            return new ColorHSV(hsv1.h - s, hsv1.s - s, hsv1.v - s);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator -(float s, ColorHSV hsv1)
        {
            return new ColorHSV(s - hsv1.h, s - hsv1.s, s - hsv1.v);
        }

        /// <summary>
        /// Multiply two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator *(ColorHSV hsv1, ColorHSV hsv2)
        {
            return new ColorHSV(hsv1.h * hsv2.h, hsv1.s * hsv2.s, hsv1.v * hsv2.v);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator *(ColorHSV hsv, float s)
        {
            return new ColorHSV(hsv.h * s, hsv.s * s, hsv.v * s);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator *(float s, ColorHSV v)
        {
            return new ColorHSV(v.h * s, v.s * s, v.v * s);
        }

        /// <summary>
        /// Divide two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator /(ColorHSV hsv1, ColorHSV hsv2)
        {
            return new ColorHSV(hsv1.h / hsv2.h, hsv1.s / hsv2.s, hsv1.v / hsv2.v);
        }

        /// <summary>
        /// Divide a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorHSV operator /(ColorHSV hsv, float s)
        {
            return new ColorHSV(hsv.h / s, hsv.s / s, hsv.v / s);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ColorHSV hsv1, ColorHSV hsv2)
        {
            return (hsv1.h == hsv2.h && hsv1.s == hsv2.s && hsv1.v == hsv2.v);
        }

        /// <summary>
        /// Are these colors not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ColorHSV hsv1, ColorHSV hsv2)
        {
            return (hsv1.h != hsv2.h || hsv1.s != hsv2.s || hsv1.v != hsv2.v);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is ColorHSV)) return false;

            ColorHSV hsv = (ColorHSV)obj;

            return this == hsv;
        }

        /// <summary>
        /// Are these colors equal given the error.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEqual(ColorHSV c0, ColorHSV c1, float eps = MathUtil.EPS_32)
        {
            if (Math.Abs(c0.h - c1.h) > eps) return false;
            if (Math.Abs(c0.s - c1.s) > eps) return false;
            if (Math.Abs(c0.v - c1.v) > eps) return false;
            return true;
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ColorHSV hsv)
        {
            return this == hsv;
        }

        /// <summary>
        /// colors hash code. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ h.GetHashCode();
                hash = (hash * 16777619) ^ s.GetHashCode();
                hash = (hash * 16777619) ^ v.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// color as a string.
        /// </summary>
		public override string ToString()
        {
            return string.Format("{0},{1},{2}", h, s, v);
        }

        /// <summary>
        /// color as a string.
        /// </summary>
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2}", h.ToString(f), s.ToString(f), v.ToString(f));
        }

        /// <summary>
        /// color from bytes.
        /// </summary>
        public static ColorHSV FromBytes(int h, int s, int v)
        {
            return new ColorHSV(h, s, v) / 255.0f;
        }

        /// <summary>
        /// The distance between two colors.
        /// </summary>
        public static float Distance(ColorHSV c0, ColorHSV c1)
        {
            return MathUtil.SafeSqrt(SqrDistance(c0, c1));
        }

        /// <summary>
        /// The square distance between two colors.
        /// </summary>
        public static float SqrDistance(ColorHSV c0, ColorHSV c1)
        {
            return (c0 - c1).SqrMagnitude;
        }

        /// <summary>
        /// Convert to RGB color space.
        /// </summary>
        public static ColorRGB ToRGB(float h, float s, float v)
        {
            //Wrap h to 0-1 range.
            h = h - (float)Math.Floor(h);

            float r = 0, g = 0, b = 0;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                int idx;
                float f, p, q, t;

                float H = MathUtil.Clamp(h, 0.0f, 1.0f) * 360.0f;
                float S = MathUtil.Clamp(s, 0.0f, 1.0f);
                float V = MathUtil.Clamp(v, 0.0f, 1.0f);

                if (H == 360)
                    H = 0;
                else
                    H = H / 60;

                idx = (int)Math.Truncate(H);
                f = H - idx;

                p = V * (1.0f - S);
                q = V * (1.0f - (S * f));
                t = V * (1.0f - (S * (1.0f - f)));

                switch (idx)
                {
                    case 0:
                        r = V;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = V;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = V;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = V;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = V;
                        break;

                    default:
                        r = V;
                        g = p;
                        b = q;
                        break;
                }
            }

            return new ColorRGB(r, g, b);
        }

        /// <summary>
        /// Generates a list of colors with hues ranging from 0 360
        /// and a saturation and value of 1. 
        /// </summary>
        public static List<ColorHSV> GenerateSpectrum(int bands)
        {

            List<ColorHSV> colorsList = new List<ColorHSV>(bands);

            int increment = 360 / bands;
            for (int i = 0; i < bands - 1; i++)
            {
                colorsList.Add(new ColorHSV(i * increment, 1, 1));
            }

            colorsList.Add(new ColorHSV(0, 1, 1));

            return colorsList;
        }
    }
}
