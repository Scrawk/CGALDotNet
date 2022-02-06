using System;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Linq;

namespace CGALDotNetGeometry.Numerics
{
    public static class MathUtil
    {
        public const int NULL_INDEX = -1;

        public const uint HASH_PRIME_1 = 2166136261;

        public const int HASH_PRIME_2 = 16777619;

        public const int PRECISION = 9;

        public const double EPS_64 = 1e-9;

        public const float EPS_32 = 1e-9f;

        public const double PI_64 = Math.PI;

        public const float PI_32 = (float)Math.PI;

        public const double SQRT2_64 = 1.414213562373095;

        public const float SQRT2_32 = 1.414213562373095f;

        public const double RAD_TO_DEG_64 = 180.0 / PI_64;

        public const float RAD_TO_DEG_32 = 180.0f / PI_32;

        public const double DEG_TO_RAD_64 = PI_64 / 180.0;

        public const float DEG_TO_RAD_32 = PI_32 / 180.0f;

        public const int MAX_FACTORIAL = 20;

        private static ulong[] m_factorialTable;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRadians(float a)
        {
            return a * DEG_TO_RAD_32;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double a)
        {
            return a * DEG_TO_RAD_64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToDegrees(float a)
        {
            return a * RAD_TO_DEG_32;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDegrees(double a)
        {
            return a * RAD_TO_DEG_64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float a)
        {
            return (float)Math.Abs(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Abs(double a)
        {
            return Math.Abs(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float a)
        {
            return (float)Math.Sin(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin(double a)
        {
            return Math.Sin(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float a)
        {
            return (float)Math.Asin(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asin(double a)
        {
            return Math.Asin(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeAsin(float r)
        {
            return Asin(Clamp(r, -1.0f, 1.0f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeAsin(double r)
        {
            return Asin(Clamp(r, -1.0, 1.0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float a)
        {
            return (float)Math.Cos(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cos(double a)
        {
            return Math.Cos(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float a)
        {
            return (float)Math.Acos(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Acos(double a)
        {
            return Math.Acos(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeAcos(float r)
        {
            return Acos(Clamp(r, -1.0f, 1.0f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeAcos(double r)
        {
            return Acos(Clamp(r, -1.0, 1.0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float a)
        {
            return (float)Math.Tan(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Tan(double a)
        {
            return Math.Tan(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float a)
        {
            return (float)Math.Atan(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan(double a)
        {
            return Math.Atan(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float x, float y)
        {
            return (float)Math.Atan2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan2(double x, double y)
        {
            return Math.Atan2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float d)
        {
            return (float)Math.Sqrt(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sqrt(double d)
        {
            return Math.Sqrt(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeSqrt(float v)
        {
            if (v <= 0.0f) return 0.0f;
            return (float)Math.Sqrt(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeSqrt(double v)
        {
            if (v <= 0.0) return 0.0;
            return Math.Sqrt(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float d)
        {
            return (float)Math.Exp(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Exp(double d)
        {
            return Math.Exp(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float d)
        {
            return (float)Math.Log(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Log(double d)
        {
            return Math.Log(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeLog(float v)
        {
            if (v <= 0.0f) return 0.0f;
            return (float)Math.Log(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeLog(double v)
        {
            if (v <= 0.0) return 0.0;
            return Math.Log(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeLog10(float v)
        {
            if (v <= 0.0f) return 0.0f;
            return (float)Math.Log10(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeLog10(double v)
        {
            if (v <= 0.0) return 0.0;
            return Math.Log10(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float d)
        {
            return (float)Math.Floor(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Floor(double d)
        {
            return Math.Floor(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceilling(float d)
        {
            return (float)Math.Ceiling(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Ceilling(double d)
        {
            return Math.Ceiling(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float d, int n)
        {
            return (float)Math.Round(d, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Round(double d, int n)
        {
            return Math.Round(d, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeInvSqrt(float n, float d, float eps = EPS_32)
        {
            if (d <= 0.0f) return 0.0f;
            d = Sqrt(d);
            if (d < eps) return 0.0f;
            return n / d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeInvSqrt(double n, double d, double eps = EPS_64)
        {
            if (d <= 0.0) return 0.0;
            d = Math.Sqrt(d);
            if (d < eps) return 0.0;
            return n / d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeInv(float v, float eps = EPS_32)
        {
            if (Math.Abs(v) < eps) return 0.0f;
            return 1.0f / v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeInv(double v, double eps = EPS_64)
        {
            if (Math.Abs(v) < eps) return 0.0;
            return 1.0 / v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeDiv(float n, float d, float eps = EPS_32)
        {
            if (Math.Abs(d) < eps) return 0.0f;
            return n / d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeDiv(double n, double d, double eps = EPS_64)
        {
            if (Math.Abs(d) < eps) return 0.0;
            return n / d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(float v, float eps = EPS_32)
        {
            return Math.Abs(v) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(double v, double eps = EPS_64)
        {
            return Math.Abs(v) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOne(float v, float eps = EPS_32)
        {
            return Math.Abs(1.0f - v) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOne(double v, double eps = EPS_64)
        {
            return Math.Abs(1.0 - v) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEqual(float v0, float v1, float eps = EPS_32)
        {
            return Math.Abs(v0 - v1) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEqual(double v0, double v1, double eps = EPS_64)
        {
            return Math.Abs(v0 - v1) < eps;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(float f)
        {
            return !(float.IsInfinity(f) || float.IsNaN(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(double f)
        {
            return !(double.IsInfinity(f) || double.IsNaN(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqr(float v)
        {
            return v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sqr(double v)
        {
            return v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow3(float v)
        {
            return v * v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pow3(double v)
        {
            return v * v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow4(float v)
        {
            return v * v * v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pow4(double v)
        {
            return v * v * v * v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int v, int min, int max)
        {
            if (v < min) v = min;
            if (v > max) v = max;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float v, float min, float max)
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
        public static float Clamp01(float v)
        {
            if (v < 0.0f) v = 0.0f;
            if (v > 1.0f) v = 1.0f;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp01(double v)
        {
            if (v < 0.0) v = 0.0;
            if (v > 1.0) v = 1.0;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FloorFrac(float x)
        {
            return (float)(x - Math.Floor(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FloorFrac(double x)
        {
            return x - Math.Floor(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TruncateFrac(float x)
        {
            return (float)(x - Math.Truncate(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TruncateFrac(double x)
        {
            return x - Math.Truncate(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float v0, float v1, float a)
        {
            return v0 + (v1 - v0) * a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double v0, double v1, double a)
        {
            return v0 + (v1 - v0) * a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Blerp(float v00, float v10, float v01, float v11, float tx, float ty)
        {
            return Lerp(Lerp(v00, v10, tx), Lerp(v01, v11, tx), ty);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Blerp(double v00, double v10, double v01, double v11, double tx, double ty)
        {
            return Lerp(Lerp(v00, v10, tx), Lerp(v01, v11, tx), ty);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SignOrZero(int v)
        {
            if (v == 0) return 0;
            return Math.Sign(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SignOrZero(float v)
        {
            if (v == 0) return 0;
            return Math.Sign(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignOrZero(double v)
        {
            if (v == 0) return 0;
            return Math.Sign(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int a, int b)
        {
            return Math.Min(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b)
        {
            return Math.Min(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double a, double b)
        {
            return Math.Min(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double a, double b, double c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int a, int b)
        {
            return Math.Max(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b)
        {
            return Math.Max(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double a, double b)
        {
            return Math.Max(a, b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double a, double b, double c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Normalize(float a, float min, float max)
        {
            float len = max - min;
            if (len <= 0) return 0;
            return (a - min) / len;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Normalize(double a, double min, double max)
        {
            double len = max - min;
            if (len <= 0) return 0;
            return (a - min) / len;
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

        /// <summary>
        /// Mirror a value between 0 and count-1 (inclusive).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Mirror(int v, int count)
        {
            int m1 = count - 1;
            int i = Math.Abs(v);

            v = i % (m1 * 2);
            if (v >= m1) v = m1 - i % m1;

            return v;
        }

        /// <summary>
        /// Is number a power of 2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2(int num)
        {
            int power = (int)(Math.Log(num) / Math.Log(2.0));
            double result = Math.Pow(2.0, power);
            return result == num;
        }

        /// <summary>
        /// Return the closest pow2 number to num.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NearestPow2(int num)
        {
            int n = num > 0 ? num - 1 : 0;

            n |= n >> 1;
            n |= n >> 2;
            n |= n >> 4;
            n |= n >> 8;
            n |= n >> 16;
            n++;

            return n;
        }

        /// <summary>
        /// Return the closest pow2 number thats less than num.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LowerPow2(int num)
        {
            int n = num > 0 ? num - 1 : 0;

            n |= n >> 1;
            n |= n >> 2;
            n |= n >> 4;
            n |= n >> 8;
            n |= n >> 16;
            n++;

            return n - (n >> 1);
        }

        /// <summary>
        /// Simple int pow function.
        /// System Math.Pow may produce precision errors.
        /// </summary>
        public static long IntPow(int a, int b)
        {
            if (b < 0) throw new ArgumentException("Exponent must be > 0");
            checked
            {
                if (b == 2) return a * a;
                if (b == 3) return a * a * a;

                long p = 1;
                for (int i = 0; i < b; i++)
                    p *= a;
                return p;
            }
        }

        public static ulong IntPow(uint a, uint b)
        {
            checked
            {
                if (b == 2) return a * a;
                if (b == 3) return a * a * a;

                ulong p = 1;
                for (uint i = 0; i < b; i++)
                    p *= a;
                return p;
            }
        }

        /// <summary>
        /// Return the Binomial coefficients.
        /// </summary>
        /// <param name="k">N</param>
        /// <param name="i">n</param>
        /// <returns></returns>
        public static double Binomial(int k, int i)
        {
            return Factorial(k) / (double)(Factorial(i) * Factorial(k - i));
        }

        /// <summary>
        /// Returns the factorial of number.
        /// Must be less than or equal MAX_FACTORIAL or overflow will occur.
        /// </summary>
        public static ulong Factorial(int num)
        {
            if (num <= 1) return 1;
            if (num > MAX_FACTORIAL)
                throw new ArgumentException("num > MAX_FACTORIAL");

            CreateFactorialTable();
            return m_factorialTable[num];

        }

        /// <summary>
        /// Returns the factorial of number using a BigInteger.
        /// </summary>
        public static BigInteger FactorialBI(int num)
        {
            if (num <= MAX_FACTORIAL)
                return Factorial(num);

            BigInteger f = Factorial(MAX_FACTORIAL);
            for (int i = MAX_FACTORIAL; i <= num; i++)
                f = f * i;

            return f;
        }

        /// <summary>
        /// Given N objects, how many unique sets exist.
        /// </summary>
        public static BigInteger Permutations(int N)
        {
            return FactorialBI(N);
        }

        /// <summary>
        /// Given N objects, how many unique sets exist of size n 
        /// where the order matters and objects may repeat.
        /// </summary>
        /// <param name="n">The size of the sets</param>
        /// <param name="N">The total number of objects</param>
        /// <returns>The number of sets possible</returns>
        public static BigInteger PermutationsOrderedWithRepeats(int n, int N)
        {
            return BigInteger.Pow(N, n);
        }

        /// <summary>
        /// Given N objects, how many unique sets exist of size n 
        /// where the order does not matters and objects may repeat.
        /// </summary>
        /// <param name="n">The size of the sets</param>
        /// <param name="N">The total number of objects</param>
        /// <returns>The number of sets possible</returns>
        public static BigInteger PermutationsUnorderedWithRepeats(int n, int N)
        {
            var a = FactorialBI(n + N - 1);
            var b = FactorialBI(n);
            var c = FactorialBI(N - 1);

            return a / (b * c);
        }

        /// <summary>
        /// Given N objects, how many unique sets exist of size n 
        /// where the order matters and objects may not repeat.
        /// </summary>
        /// <param name="n">The size of the sets</param>
        /// <param name="N">The total number of objects</param>
        /// <returns>The number of sets possible</returns>
        public static BigInteger PermutationsOrderedWithoutRepeats(int n, int N)
        {
            var a = FactorialBI(N);
            var b = FactorialBI(N - n);

            return a / b;
        }

        /// <summary>
        /// Given N objects, how many unique sets exist of size n 
        /// where the order does not matters and objects may not repeat.
        /// </summary>
        /// <param name="n">The size of the sets</param>
        /// <param name="N">The total number of objects</param>
        /// <returns>The number of sets possible</returns>
        public static BigInteger PermutationsUnorderedWithoutRepeats(int n, int N)
        {
            var a = FactorialBI(N);
            var b = FactorialBI(n);
            var c = FactorialBI(N - n);

            return a / (b * c);
        }

        /// <summary>
        /// Creates a look up table for factorials.
        /// </summary>
        private static void CreateFactorialTable()
        {
            if (m_factorialTable != null) return;

            m_factorialTable = new ulong[MAX_FACTORIAL + 1];
            m_factorialTable[0] = 1;

            ulong f = 1;
            for (ulong i = 1; i < (ulong)m_factorialTable.Length; i++)
            {
                f = f * i;
                m_factorialTable[i] = f;
            }
        }

    }
}
