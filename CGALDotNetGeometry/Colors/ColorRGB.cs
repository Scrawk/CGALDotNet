using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Colors
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorRGB : IEquatable<ColorRGB>
    {

        public readonly static ColorRGB Red = new ColorRGB(1, 0, 0);
        public readonly static ColorRGB Orange = new ColorRGB(1, 0.5, 0);
        public readonly static ColorRGB Olive = new ColorRGB(0.5, 0.5, 0);
        public readonly static ColorRGB VividGreen = new ColorRGB(0.5, 1, 0);
        public readonly static ColorRGB Yellow = new ColorRGB(1, 1, 0);
        public readonly static ColorRGB Green = new ColorRGB(0, 1, 0);
        public readonly static ColorRGB SpringGreen = new ColorRGB(0, 1, 0.5);
        public readonly static ColorRGB Cyan = new ColorRGB(0, 1, 1);
        public readonly static ColorRGB Azure = new ColorRGB(0, 0.5, 1);
        public readonly static ColorRGB Teal = new ColorRGB(0, 0.5, 0.5);
        public readonly static ColorRGB Blue = new ColorRGB(0, 0, 1);
        public readonly static ColorRGB Indigo = new ColorRGB(0.25, 0, 1);
        public readonly static ColorRGB Violet = new ColorRGB(0.5, 0, 1);
        public readonly static ColorRGB Purple = new ColorRGB(0.5, 0, 0.5);
        public readonly static ColorRGB Magenta = new ColorRGB(1, 0, 1);

        public readonly static ColorRGB Black = new ColorRGB(0);
        public readonly static ColorRGB DarkGrey = new ColorRGB(0.25f);
        public readonly static ColorRGB Grey = new ColorRGB(0.5f);
        public readonly static ColorRGB LightGrey = new ColorRGB(0.75f);
        public readonly static ColorRGB White = new ColorRGB(1);
        
        public float r, g, b;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGB(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGB(float v) 
            : this(v,v,v)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGB(double r, double g, double b) 
            : this((float)r, (float)g, (float)b)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorRGB(double v) 
            : this(v, v, v)
        {

        }

        public ColorRGB rrr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGB(r, r, r); }
        }

        public ColorRGB bgr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGB(b, g, r); }
        }

        public ColorHSV hsv
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return ToHSV(r, g, b); }
        }

        public ColorRGBA rgb1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new ColorRGBA(r, g, b, 1); }
        }

        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return MathUtil.SafeSqrt(SqrMagnitude); }
        }

        public float SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (r * r + g * g + b * b); }
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
                int A = 255;

                return R | (G << 8) | (B << 16) | (A << 24);
            }
        }

        unsafe public float this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("ColorRGB index out of range.");

                fixed (ColorRGB* array = &this) { return ((float*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("ColorRGB index out of range.");

                fixed (float* array = &r) { array[i] = value; }
            }
        }

        /// <summary>
        /// Add two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator +(ColorRGB v1, ColorRGB v2)
        {
            return new ColorRGB(v1.r + v2.r, v1.g + v2.g, v1.b + v2.b);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator +(ColorRGB v1, float s)
        {
            return new ColorRGB(v1.r + s, v1.g + s, v1.b + s);
        }

        /// <summary>
        /// Add vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator +(float s, ColorRGB v1)
        {
            return new ColorRGB(v1.r + s, v1.g + s, v1.b + s);
        }

        /// <summary>
        /// Subtract two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator -(ColorRGB v1, ColorRGB v2)
        {
            return new ColorRGB(v1.r - v2.r, v1.g - v2.g, v1.b - v2.b);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator -(ColorRGB v1, float s)
        {
            return new ColorRGB(v1.r - s, v1.g - s, v1.b - s);
        }

        /// <summary>
        /// Subtract vector and scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator -(float s, ColorRGB v1)
        {
            return new ColorRGB(s - v1.r, s - v1.g, s - v1.b);
        }

        /// <summary>
        /// Multiply two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator *(ColorRGB v1, ColorRGB v2)
        {
            return new ColorRGB(v1.r * v2.r, v1.g * v2.g, v1.b * v2.b);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator *(ColorRGB v, float s)
        {
            return new ColorRGB(v.r * s, v.g * s, v.b * s);
        }

        /// <summary>
        /// Multiply a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator *(float s, ColorRGB v)
        {
            return new ColorRGB(v.r * s, v.g * s, v.b * s);
        }

        /// <summary>
        /// Divide two colors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator /(ColorRGB v1, ColorRGB v2)
        {
            return new ColorRGB(v1.r / v2.r, v1.g / v2.g, v1.b / v2.b);
        }

        /// <summary>
        /// Divide a vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB operator /(ColorRGB v, float s)
        {
            return new ColorRGB(v.r / s, v.g / s, v.b / s);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ColorRGB v1, ColorRGB v2)
        {
            return (v1.r == v2.r && v1.g == v2.g && v1.b == v2.b);
        }

        /// <summary>
        /// Are these colors not equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ColorRGB v1, ColorRGB v2)
        {
            return (v1.r != v2.r || v1.g != v2.g || v1.b != v2.b);
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is ColorRGB)) return false;

            ColorRGB v = (ColorRGB)obj;

            return this == v;
        }

        /// <summary>
        /// Are these colors equal given the error.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEqual(ColorRGB c0, ColorRGB c1, float eps = MathUtil.EPS_32)
        {
            if (Math.Abs(c0.r - c1.r) > eps) return false;
            if (Math.Abs(c0.g - c1.g) > eps) return false;
            if (Math.Abs(c0.b - c1.b) > eps) return false;
            return true;
        }

        /// <summary>
        /// Are these colors equal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ColorRGB v)
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
                return hash;
            }
        }

        /// <summary>
        /// color as a string.
        /// </summary>
		public override string ToString()
        {
            return string.Format("{0},{1},{2}", r, g, b);
        }

        /// <summary>
        /// color as a string.
        /// </summary>
        public string ToString(string f)
        {
            return string.Format("{0},{1},{2}", r.ToString(f), g.ToString(f), b.ToString(f));
        }

        /// <summary>
        /// color from bytes.
        /// </summary>
        public static ColorRGB FromBytes(int r, int g, int b)
        {
            return new ColorRGB(r, g, b) / 255.0f;
        }

        /// <summary>
        /// The distance between two colors.
        /// </summary>
        public static float Distance(ColorRGB c0, ColorRGB c1)
        {
            return MathUtil.SafeSqrt(SqrDistance(c0, c1));
        }

        /// <summary>
        /// The square distance between two colors.
        /// </summary>
        public static float SqrDistance(ColorRGB c0, ColorRGB c1)
        {
            return (c0 - c1).SqrMagnitude;
        }

        /// <summary>
        /// The minimum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB Min(ColorRGB col, float s)
        {
            col.r = Math.Min(col.r, s);
            col.g = Math.Min(col.g, s);
            col.b = Math.Min(col.b, s);
            return col;
        }

        /// <summary>
        /// The maximum value between s and each component in vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB Max(ColorRGB col, float s)
        {
            col.r = Math.Max(col.r, s);
            col.g = Math.Max(col.g, s);
            col.b = Math.Max(col.b, s);
            return col;
        }

        /// <summary>
        /// Clamp the each component to specified min and max.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB Clamp(ColorRGB col, float min, float max)
        {
            col.r = Math.Max(Math.Min(col.r, max), min);
            col.g = Math.Max(Math.Min(col.g, max), min);
            col.b = Math.Max(Math.Min(col.b, max), min);
            return col;
        }

        /// <summary>
        /// Lerp between two vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorRGB Lerp(ColorRGB v1, ColorRGB v2, float a)
        {
            float a1 = 1.0f - a;
            ColorRGB v = new ColorRGB();
            v.r = v1.r * a1 + v2.r * a;
            v.g = v1.g * a1 + v2.g * a;
            v.b = v1.b * a1 + v2.b * a;
            return v;
        }

        /// <summary>
        /// Convert to HSV color space.
        /// </summary>
        public static ColorHSV ToHSV(float r, float g, float b)
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

        /// <summary>
        /// Create a palette of 6 colors from the rainbow.
        /// </summary>
        /// <returns></returns>
        public static ColorRGB[] RainbowPalatte()
        {
            return new ColorRGB[]
            {
                Red, Orange, Yellow, Green, Blue, Violet
            };
        }

        /// <summary>
        /// Create a palette of colors..
        /// </summary>
        /// <returns></returns>
        public static ColorRGB[] Palette()
        {
            var palette = new ColorRGB[]
            {
                Red,
                Orange,
                Olive,
                VividGreen,
                Yellow,
                Green,
                SpringGreen,
                Cyan,
                Azure,
                Teal,
                Blue,
                Indigo,
                Violet,
                Purple,
                Magenta,
            };

            return palette;
        }

        /// <summary>
        /// Create a custom palette of hues with the same saturation and value.
        /// </summary>
        /// <param name="hues">The number of hues in the palette.</param>
        /// <param name="saturation">The saturation of the colors.</param>
        /// <param name="value">The values of the colors.</param>
        /// <returns></returns>
        public static ColorRGB[] CustomPalette(int hues, float saturation, float value)
        {
            var palette = new ColorRGB[hues];
            for(int i = 0; i < hues; i++)
            {
                float hue = (i + 1.0f) / hues;
                palette[i] = ColorHSV.ToRGB(hue, saturation, value);
            }

            return palette;
        }

    }

}
