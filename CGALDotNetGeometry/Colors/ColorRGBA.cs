using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Colors
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorRGBA : IEquatable<ColorRGBA>
    {

        public readonly static ColorRGBA Red = new ColorRGBA(1, 0, 0, 1);
        public readonly static ColorRGBA Orange = new ColorRGBA(1, 0.5, 0, 1);
        public readonly static ColorRGBA Olive = new ColorRGBA(0.5, 0.5, 0, 1);
        public readonly static ColorRGBA VividGreen = new ColorRGBA(0.5, 1, 0, 1);
        public readonly static ColorRGBA Yellow = new ColorRGBA(1, 1, 0, 1);
        public readonly static ColorRGBA Green = new ColorRGBA(0, 1, 0, 1);
        public readonly static ColorRGBA SpringGreen = new ColorRGBA(0, 1, 0.5, 1);
        public readonly static ColorRGBA Cyan = new ColorRGBA(0, 1, 1, 1);
        public readonly static ColorRGBA Azure = new ColorRGBA(0, 0.5, 1, 1);
        public readonly static ColorRGBA Teal = new ColorRGBA(0, 0.5, 0.5, 1);
        public readonly static ColorRGBA Blue = new ColorRGBA(0, 0, 1, 1);
        public readonly static ColorRGBA Violet = new ColorRGBA(0.5, 0, 1, 1);
        public readonly static ColorRGBA Purple = new ColorRGBA(0.5, 0, 0.5, 1);
        public readonly static ColorRGBA Magenta = new ColorRGBA(1, 0, 1, 1);

        public readonly static ColorRGBA Black = new ColorRGBA(0, 1);
        public readonly static ColorRGBA DarkGrey = new ColorRGBA(0.25f, 1);
        public readonly static ColorRGBA Grey = new ColorRGBA(0.5f, 1);
        public readonly static ColorRGBA LightGrey = new ColorRGBA(0.75f, 1);
        public readonly static ColorRGBA White = new ColorRGBA(1, 1);
        public readonly static ColorRGBA Clear = new ColorRGBA(0, 0);

        public float r, g, b, a;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(float r, float g, float b) 
            : this(r,g,b,1)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(float v) 
            : this(v,v,v,v)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(float v, float a) 
            : this(v,v,v, 1)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(double r, double g, double b, double a) 
            : this((float)r, (float)g, (float)b, (float)a)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(double r, double g, double b) 
            : this(r, g, b, 1)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(double v) 
            : this(v, v, v, v)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(double v, double a) 
            : this(v, v, v, a)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGBA(ColorRGB col, float a) 
            : this(col.r, col.g, col.b, a)
        {

        }

        unsafe public float this[int i]
        {
            get
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("ColorRGBA index out of range.");

                fixed (ColorRGBA* array = &this) { return ((float*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 4)
                    throw new IndexOutOfRangeException("ColorRGBA index out of range.");

                fixed (float* array = &r) { array[i] = value; }
            }
        }

        public ColorRGBA rrra
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGBA(r, r, r, a); }
        }

        public ColorRGBA bgra
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGBA(b, g, r, a); }
        }

        public ColorRGB rgb
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGB(r, g, b); }
        }

        public ColorHSV hsv
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return ColorRGB.ToHSV(r, g, b); }
        }

        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (float)Math.Sqrt(SqrMagnitude); }
        }

        public float SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (r * r + g * g + b * b + a * a); }
        }

        public float Intensity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (r + g + b) / 3.0f; }
        }

        public float Luminance
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return 0.2126f * r + 0.7152f * g + 0.0722f * b; }
        }

        public int Integer
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                int R = (int)MathUtil.Clamp(r * 255.0f, 0.0f, 255.0f);
                int G = (int)MathUtil.Clamp(g * 255.0f, 0.0f, 255.0f);
                int B = (int)MathUtil.Clamp(b * 255.0f, 0.0f, 255.0f);
                int A = (int)MathUtil.Clamp(a * 255.0f, 0.0f, 255.0f);

                return R | (G << 8) | (B << 16) | (A << 24);
            }
        }

        /// <summary>
        /// Add two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator +(ColorRGBA v1, ColorRGBA v2)
        {
            return new ColorRGBA(v1.r + v2.r, v1.g + v2.g, v1.b + v2.b, v1.a + v2.a);
        }

        /// <summary>
        /// Add color and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator +(ColorRGBA v1, float s)
        {
            return new ColorRGBA(v1.r + s, v1.g + s, v1.b + s, v1.a + s);
        }

        /// <summary>
        /// Add color and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator +(float s, ColorRGBA v1)
        {
            return new ColorRGBA(v1.r + s, v1.g + s, v1.b + s, v1.a + s);
        }

        /// <summary>
        /// Subtract two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator -(ColorRGBA v1, ColorRGBA v2)
        {
            return new ColorRGBA(v1.r - v2.r, v1.g - v2.g, v1.b - v2.b, v1.a - v2.a);
        }

        /// <summary>
        /// Subtract color and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator -(ColorRGBA v1, float s)
        {
            return new ColorRGBA(v1.r - s, v1.g - s, v1.b - s, v1.a - s);
        }

        /// <summary>
        /// Subtract color and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator -(float s, ColorRGBA v1)
        {
            return new ColorRGBA(s - v1.r,s -  v1.g, s - v1.b, s - v1.a);
        }

        /// <summary>
        /// Multiply two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator *(ColorRGBA v1, ColorRGBA v2)
        {
            return new ColorRGBA(v1.r * v2.r, v1.g * v2.g, v1.b * v2.b, v1.a * v2.a);
        }

        /// <summary>
        /// Multiply a color and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator *(ColorRGBA v, float s)
        {
            return new ColorRGBA(v.r * s, v.g * s, v.b * s, v.a * s);
        }

        /// <summary>
        /// Multiply a color and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator *(float s, ColorRGBA v)
        {
            return new ColorRGBA(v.r * s, v.g * s, v.b * s, v.a * s);
        }

        /// <summary>
        /// Divide two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator /(ColorRGBA v1, ColorRGBA v2)
        {
            return new ColorRGBA(v1.r / v2.r, v1.g / v2.g, v1.b / v2.b, v1.a / v2.a);
        }

        /// <summary>
        /// Divide a color and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA operator /(ColorRGBA v, float s)
        {
            return new ColorRGBA(v.r / s, v.g / s, v.b / s, v.a / s);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ColorRGBA v1, ColorRGBA v2)
        {
            return (v1.r == v2.r && v1.g == v2.g && v1.b == v2.b && v1.a == v2.a);
        }

        /// <summary>
        /// Are these colors not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ColorRGBA v1, ColorRGBA v2)
        {
            return (v1.r != v2.r || v1.g != v2.g || v1.b != v2.b || v1.a != v2.a);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is ColorRGBA)) return false;

            ColorRGBA v = (ColorRGBA)obj;

            return this == v;
        }

        /// <summary>
        /// Are these colors equal given the error.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEqual(ColorRGBA c0, ColorRGBA c1, float eps = MathUtil.EPS_32)
        {
            if (Math.Abs(c0.r - c1.r) > eps) return false;
            if (Math.Abs(c0.g - c1.g) > eps) return false;
            if (Math.Abs(c0.b - c1.b) > eps) return false;
            if (Math.Abs(c0.a - c1.a) > eps) return false;
            return true;
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ColorRGBA v)
        {
            return this == v;
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
                hash = (hash * 16777619) ^ r.GetHashCode();
                hash = (hash * 16777619) ^ g.GetHashCode();
                hash = (hash * 16777619) ^ b.GetHashCode();
                hash = (hash * 16777619) ^ a.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// color as a string.
        /// </summary>
		public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", r,g,b,a);
        }

        /// <summary>
        /// color as a string.
        /// </summary>
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2},{3}", r.ToString(f), g.ToString(f), b.ToString(f), a.ToString(f));
        }

        /// <summary>
        /// color from bytes.
        /// </summary>
        public static ColorRGBA FromBytes(int r, int g, int b)
        {
            return new ColorRGBA(r, g, b, 255) / 255.0f;
        }

        /// <summary>
        /// The distance between two colors.
        /// </summary>
        public static float Distance(ColorRGBA c0, ColorRGBA c1)
        {
            return MathUtil.SafeSqrt(SqrDistance(c0, c1));
        }

        /// <summary>
        /// The square distance between two colors.
        /// </summary>
        public static float SqrDistance(ColorRGBA c0, ColorRGBA c1)
        {
            return (c0 - c1).SqrMagnitude;
        }

        /// <summary>
        /// color from ints.
        /// </summary>
        public static ColorRGBA FromBytes(int r, int g, int b, int a)
        {
            return new ColorRGBA(r, g, b, a) / 255.0f;
        }

        /// <summary>
        /// The minimum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA Min(ColorRGBA col, float s)
        {
            col.r = Math.Min(col.r, s);
            col.g = Math.Min(col.g, s);
            col.b = Math.Min(col.b, s);
            col.a = Math.Min(col.a, s);
            return col;
        }

        /// <summary>
        /// The maximum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA Max(ColorRGBA col, float s)
        {
            col.r = Math.Max(col.r, s);
            col.g = Math.Max(col.g, s);
            col.b = Math.Max(col.b, s);
            col.a = Math.Max(col.a, s);
            return col;
        }

        /// <summary>
        /// Clamp the each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA Clamp(ColorRGBA col, float min, float max)
        {
            col.r = Math.Max(Math.Min(col.r, max), min);
            col.g = Math.Max(Math.Min(col.g, max), min);
            col.b = Math.Max(Math.Min(col.b, max), min);
            col.a = Math.Max(Math.Min(col.a, max), min);
            return col;
        }

        /// <summary>
        /// Lerp between two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGBA Lerp(ColorRGBA v1, ColorRGBA v2, float a)
        {
            float a1 = 1.0f - a;
            ColorRGBA v = new ColorRGBA();
            v.r = v1.r * a1 + v2.r * a;
            v.g = v1.g * a1 + v2.g * a;
            v.b = v1.b * a1 + v2.b * a;
            v.a = v1.a * a1 + v2.a * a;
            return v;
        }

        /// <summary>
        /// Convert to HSV color space.
        /// </summary>
        public ColorHSV ToHSV()
        {
            float delta, min;
            float h = 0, s, v;

            float R = MathUtil.Clamp(r * 255.0f, 0.0f, 255.0f);
            float G = MathUtil.Clamp(g * 255.0f, 0.0f, 255.0f);
            float B = MathUtil.Clamp(b * 255.0f, 0.0f, 255.0f);

            min = Math.Min(Math.Min(R, G), B);
            v = Math.Max(Math.Max(R, G), B);
            delta = v - min;

            if (v == 0.0)
                s = 0;
            else
                s = delta / v;

            if (s == 0)
                h = 0.0f;
            else
            {
                if (R == v)
                    h = (G - B) / delta;
                else if (G == v)
                    h = 2 + (B - R) / delta;
                else if (B == v)
                    h = 4 + (R - G) / delta;

                h *= 60;
                if (h < 0.0)
                    h = h + 360;
            }

            return new ColorHSV(h / 360.0f, s, v / 255.0f);
        }

    }

}
