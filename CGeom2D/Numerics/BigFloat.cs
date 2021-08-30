using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CGeom2D.Numerics
{

    [Serializable]
    public class BigFloat : IComparable, IComparable<BigFloat>, IEquatable<BigFloat>
    {
        private BigInteger numerator;
        private BigInteger denominator;

        public static readonly BigFloat One = new BigFloat(1);
        public static readonly BigFloat Zero = new BigFloat(0);
        public static readonly BigFloat MinusOne = new BigFloat(-1);
        public static readonly BigFloat OneHalf = new BigFloat(1, 2);

        public int Sign
        {
            get
            {
                switch (numerator.Sign + denominator.Sign)
                {
                    case 2:
                    case -2:
                        return 1;
                    case 0:
                        return -1;
                    default:
                        return 0;
                }
            }
        }


        //constructors
        public BigFloat()
        {
            numerator = BigInteger.Zero;
            denominator = BigInteger.One;
        }
        public BigFloat(string value)
        {
            BigFloat bf = Parse(value);
            this.numerator = bf.numerator;
            this.denominator = bf.denominator;
        }
        public BigFloat(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            if (denominator == 0)
                throw new ArgumentException("denominator equals 0");
            this.denominator = BigInteger.Abs(denominator);
        }
        public BigFloat(BigInteger value)
        {
            this.numerator = value;
            this.denominator = BigInteger.One;
        }
        public BigFloat(BigFloat value)
        {
            if (BigFloat.Equals(value, null))
            {
                this.numerator = BigInteger.Zero;
                this.denominator = BigInteger.One;
            }
            else
            {

                this.numerator = value.numerator;
                this.denominator = value.denominator;
            }
        }
        public BigFloat(ulong value)
        {
            numerator = new BigInteger(value);
            denominator = BigInteger.One;
        }
        public BigFloat(long value)
        {
            numerator = new BigInteger(value);
            denominator = BigInteger.One;
        }
        public BigFloat(uint value)
        {
            numerator = new BigInteger(value);
            denominator = BigInteger.One;
        }
        public BigFloat(int value)
        {
            numerator = new BigInteger(value);
            denominator = BigInteger.One;
        }
        public BigFloat(float value) : this(value.ToString("N99"))
        {
        }
        public BigFloat(double value) : this(value.ToString("N99"))
        {
        }
        public BigFloat(decimal value) : this(value.ToString("N99"))
        {
        }

        //non-static methods
        public BigFloat Add(BigFloat other)
        {
            if (BigFloat.Equals(other, null))
                throw new ArgumentNullException("other");

            this.numerator = this.numerator * other.denominator + other.numerator * this.denominator;
            this.denominator *= other.denominator;
            return this;
        }
        public BigFloat Subtract(BigFloat other)
        {
            if (BigFloat.Equals(other, null))
                throw new ArgumentNullException("other");

            this.numerator = this.numerator * other.denominator - other.numerator * this.denominator;
            this.denominator *= other.denominator;
            return this;
        }
        public BigFloat Multiply(BigFloat other)
        {
            if (BigFloat.Equals(other, null))
                throw new ArgumentNullException("other");

            this.numerator *= other.numerator;
            this.denominator *= other.denominator;
            return this;
        }
        public BigFloat Divide(BigFloat other)
        {
            if (BigInteger.Equals(other, null))
                throw new ArgumentNullException("other");
            if (other.numerator == 0)
                throw new System.DivideByZeroException("other");

            this.numerator *= other.denominator;
            this.denominator *= other.numerator;
            return this;
        }
        public BigFloat Remainder(BigFloat other)
        {
            if (BigInteger.Equals(other, null))
                throw new ArgumentNullException("other");

            //b = a mod n
            //remainder = a - floor(a/n) * n

            BigFloat result = this - Floor(this / other) * other;

            this.numerator = result.numerator;
            this.denominator = result.denominator;


            return this;
        }
        public BigFloat DivideRemainder(BigFloat other, out BigFloat remainder)
        {
            this.Divide(other);

            remainder = BigFloat.Remainder(this, other);

            return this;
        }
        public BigFloat Pow(int exponent)
        {
            if (numerator.IsZero)
            {
                // Nothing to do
            }
            else if (exponent < 0)
            {
                BigInteger savedNumerator = numerator;
                numerator = BigInteger.Pow(denominator, -exponent);
                denominator = BigInteger.Pow(savedNumerator, -exponent);
            }
            else
            {
                numerator = BigInteger.Pow(numerator, exponent);
                denominator = BigInteger.Pow(denominator, exponent);
            }

            return this;
        }
        public BigFloat Abs()
        {
            numerator = BigInteger.Abs(numerator);
            return this;
        }
        public BigFloat Negate()
        {
            numerator = BigInteger.Negate(numerator);
            return this;
        }
        public BigFloat Inverse()
        {
            BigInteger temp = numerator;
            numerator = denominator;
            denominator = temp;
            return this;
        }
        public BigFloat Increment()
        {
            numerator += denominator;
            return this;
        }
        public BigFloat Decrement()
        {
            numerator -= denominator;
            return this;
        }
        public BigFloat Ceil()
        {
            if (numerator < 0)
                numerator -= BigInteger.Remainder(numerator, denominator);
            else
                numerator += denominator - BigInteger.Remainder(numerator, denominator);

            Factor();
            return this;
        }
        public BigFloat Floor()
        {
            if (numerator < 0)
                numerator += denominator - BigInteger.Remainder(numerator, denominator);
            else
                numerator -= BigInteger.Remainder(numerator, denominator);

            Factor();
            return this;
        }
        public BigFloat Round()
        {
            //get remainder. Over divisor see if it is > new BigFloat(0.5)
            BigFloat value = BigFloat.Decimals(this);

            if (value.CompareTo(OneHalf) >= 0)
                this.Ceil();
            else
                this.Floor();

            return this;
        }
        public BigFloat Truncate()
        {
            numerator -= BigInteger.Remainder(numerator, denominator);
            Factor();
            return this;
        }
        public BigFloat Decimals()
        {
            BigInteger result = BigInteger.Remainder(numerator, denominator);

            return new BigFloat(result, denominator);
        }
        public BigFloat ShiftDecimalLeft(int shift)
        {
            if (shift < 0)
                return ShiftDecimalRight(-shift);

            numerator *= BigInteger.Pow(10, shift);
            return this;
        }
        public BigFloat ShiftDecimalRight(int shift)
        {
            if (shift < 0)
                return ShiftDecimalLeft(-shift);
            denominator *= BigInteger.Pow(10, shift);
            return this;
        }
        public double Sqrt()
        {
            return Math.Pow(10, BigInteger.Log10(numerator) / 2) / Math.Pow(10, BigInteger.Log10(denominator) / 2);
        }
        public double Log10()
        {
            return BigInteger.Log10(numerator) - BigInteger.Log10(denominator);
        }
        public double Log(double baseValue)
        {
            return BigInteger.Log(numerator, baseValue) - BigInteger.Log(numerator, baseValue);
        }
        public override string ToString()
        {
            //default precision = 100
            return ToString(100);
        }
        public string ToString(int precision, bool trailingZeros = false)
        {
            Factor();

            BigInteger remainder;
            BigInteger result = BigInteger.DivRem(numerator, denominator, out remainder);

            if (remainder == 0 && trailingZeros)
                return result + ".0";
            else if (remainder == 0)
                return result.ToString();


            BigInteger decimals = (numerator * BigInteger.Pow(10, precision)) / denominator;

            if (decimals == 0 && trailingZeros)
                return result + ".0";
            else if (decimals == 0)
                return result.ToString();

            StringBuilder sb = new StringBuilder();

            while (precision-- > 0 && decimals > 0)
            {
                sb.Append(decimals % 10);
                decimals /= 10;
            }

            if (trailingZeros)
                return result + "." + new string(sb.ToString().Reverse().ToArray());
            else
                return result + "." + new string(sb.ToString().Reverse().ToArray()).TrimEnd(new char[] { '0' });


        }
        public string ToMixString()
        {
            Factor();

            BigInteger remainder;
            BigInteger result = BigInteger.DivRem(numerator, denominator, out remainder);

            if (remainder == 0)
                return result.ToString();
            else
                return result + ", " + remainder + "/" + denominator;
        }

        public string ToRationalString()
        {
            Factor();

            return numerator + " / " + denominator;
        }
        public int CompareTo(BigFloat other)
        {
            if (BigFloat.Equals(other, null))
                throw new ArgumentNullException("other");

            //Make copies
            BigInteger one = this.numerator;
            BigInteger two = other.numerator;

            //cross multiply
            one *= other.denominator;
            two *= this.denominator;

            //test
            return BigInteger.Compare(one, two);
        }
        public int CompareTo(object other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            if (!(other is BigFloat))
                throw new System.ArgumentException("other is not a BigFloat");

            return CompareTo((BigFloat)other);
        }
        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }

            return this.numerator == ((BigFloat)other).numerator && this.denominator == ((BigFloat)other).denominator;
        }
        public bool Equals(BigFloat other)
        {
            return (other.numerator == this.numerator && other.denominator == this.denominator);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //static methods
        public static bool Equals(object left, object right)
        {
            if (left == null && right == null) return true;
            else if (left == null || right == null) return false;
            else if (left.GetType() != right.GetType()) return false;
            else
                return (((BigInteger)left).Equals((BigInteger)right));
        }

        public static string ToString(BigFloat value)
        {
            return value.ToString();
        }

        public static BigFloat Inverse(BigFloat value)
        {
            return (new BigFloat(value)).Inverse();
        }
        public static BigFloat Decrement(BigFloat value)
        {
            return (new BigFloat(value)).Decrement();
        }
        public static BigFloat Negate(BigFloat value)
        {
            return (new BigFloat(value)).Negate();
        }
        public static BigFloat Increment(BigFloat value)
        {
            return (new BigFloat(value)).Increment();
        }
        public static BigFloat Abs(BigFloat value)
        {
            return (new BigFloat(value)).Abs();
        }
        public static BigFloat Add(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Add(right);
        }
        public static BigFloat Subtract(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Subtract(right);
        }
        public static BigFloat Multiply(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Multiply(right);
        }
        public static BigFloat Divide(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Divide(right);
        }
        public static BigFloat Pow(BigFloat value, int exponent)
        {
            return (new BigFloat(value)).Pow(exponent);
        }
        public static BigFloat Remainder(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Remainder(right);
        }
        public static BigFloat DivideRemainder(BigFloat left, BigFloat right, out BigFloat remainder)
        {
            return (new BigFloat(left)).DivideRemainder(right, out remainder);
        }
        public static BigFloat Decimals(BigFloat value)
        {
            return value.Decimals();
        }
        public static BigFloat Truncate(BigFloat value)
        {
            return (new BigFloat(value)).Truncate();
        }
        public static BigFloat Ceil(BigFloat value)
        {
            return (new BigFloat(value)).Ceil();
        }
        public static BigFloat Floor(BigFloat value)
        {
            return (new BigFloat(value)).Floor();
        }
        public static BigFloat Round(BigFloat value)
        {
            return (new BigFloat(value)).Round();
        }
        public static BigFloat Parse(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            value.Trim();
            value = value.Replace(",", "");
            int pos = value.IndexOf('.');
            value = value.Replace(".", "");

            if (pos < 0)
            {
                //no decimal point
                BigInteger numerator = BigInteger.Parse(value);
                return (new BigFloat(numerator)).Factor();
            }
            else
            {
                //decimal point (length - pos - 1)
                BigInteger numerator = BigInteger.Parse(value);
                BigInteger denominator = BigInteger.Pow(10, value.Length - pos);

                return (new BigFloat(numerator, denominator)).Factor();
            }
        }
        public static BigFloat ShiftDecimalLeft(BigFloat value, int shift)
        {
            return (new BigFloat(value)).ShiftDecimalLeft(shift);
        }
        public static BigFloat ShiftDecimalRight(BigFloat value, int shift)
        {
            return (new BigFloat(value)).ShiftDecimalRight(shift);
        }
        public static bool TryParse(string value, out BigFloat result)
        {
            try
            {
                result = BigFloat.Parse(value);
                return true;
            }
            catch (ArgumentNullException)
            {
                result = null;
                return false;
            }
            catch (FormatException)
            {
                result = null;
                return false;
            }
        }
        public static int Compare(BigFloat left, BigFloat right)
        {
            if (BigFloat.Equals(left, null))
                throw new ArgumentNullException("left");
            if (BigFloat.Equals(right, null))
                throw new ArgumentNullException("right");

            return (new BigFloat(left)).CompareTo(right);
        }
        public static double Log10(BigFloat value)
        {
            return (new BigFloat(value)).Log10();
        }
        public static double Log(BigFloat value, double baseValue)
        {
            return (new BigFloat(value)).Log(baseValue);
        }
        public static double Sqrt(BigFloat value)
        {
            return (new BigFloat(value)).Sqrt();
        }

        public static BigFloat operator -(BigFloat value)
        {
            return (new BigFloat(value)).Negate();
        }
        public static BigFloat operator -(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Subtract(right);
        }
        public static BigFloat operator --(BigFloat value)
        {
            return value.Decrement();
        }
        public static BigFloat operator +(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Add(right);
        }
        public static BigFloat operator +(BigFloat value)
        {
            return (new BigFloat(value)).Abs();
        }
        public static BigFloat operator ++(BigFloat value)
        {
            return value.Increment();
        }
        public static BigFloat operator %(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Remainder(right);
        }
        public static BigFloat operator *(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Multiply(right);
        }
        public static BigFloat operator /(BigFloat left, BigFloat right)
        {
            return (new BigFloat(left)).Divide(right);
        }
        public static BigFloat operator >>(BigFloat value, int shift)
        {
            return (new BigFloat(value)).ShiftDecimalRight(shift);
        }
        public static BigFloat operator <<(BigFloat value, int shift)
        {
            return (new BigFloat(value)).ShiftDecimalLeft(shift);
        }
        public static BigFloat operator ^(BigFloat left, int right)
        {
            return (new BigFloat(left)).Pow(right);
        }
        public static BigFloat operator ~(BigFloat value)
        {
            return (new BigFloat(value)).Inverse();
        }

        public static bool operator !=(BigFloat left, BigFloat right)
        {
            return Compare(left, right) != 0;
        }
        public static bool operator ==(BigFloat left, BigFloat right)
        {
            return Compare(left, right) == 0;
        }
        public static bool operator <(BigFloat left, BigFloat right)
        {
            return Compare(left, right) < 0;
        }
        public static bool operator <=(BigFloat left, BigFloat right)
        {
            return Compare(left, right) <= 0;
        }
        public static bool operator >(BigFloat left, BigFloat right)
        {
            return Compare(left, right) > 0;
        }
        public static bool operator >=(BigFloat left, BigFloat right)
        {
            return Compare(left, right) >= 0;
        }

        public static bool operator true(BigFloat value)
        {
            return value != 0;
        }
        public static bool operator false(BigFloat value)
        {
            return value == 0;
        }

        public static explicit operator decimal(BigFloat value)
        {
            if (decimal.MinValue > value) throw new System.OverflowException("value is less than System.decimal.MinValue.");
            if (decimal.MaxValue < value) throw new System.OverflowException("value is greater than System.decimal.MaxValue.");

            return (decimal)value.numerator / (decimal)value.denominator;
        }
        public static explicit operator double(BigFloat value)
        {
            if (double.MinValue > value) throw new System.OverflowException("value is less than System.double.MinValue.");
            if (double.MaxValue < value) throw new System.OverflowException("value is greater than System.double.MaxValue.");

            return (double)value.numerator / (double)value.denominator;
        }
        public static explicit operator float(BigFloat value)
        {
            if (float.MinValue > value) throw new System.OverflowException("value is less than System.float.MinValue.");
            if (float.MaxValue < value) throw new System.OverflowException("value is greater than System.float.MaxValue.");

            return (float)value.numerator / (float)value.denominator;
        }

        //byte, sbyte, 
        public static implicit operator BigFloat(byte value)
        {
            return new BigFloat((uint)value);
        }
        public static implicit operator BigFloat(sbyte value)
        {
            return new BigFloat((int)value);
        }
        public static implicit operator BigFloat(short value)
        {
            return new BigFloat((int)value);
        }
        public static implicit operator BigFloat(ushort value)
        {
            return new BigFloat((uint)value);
        }
        public static implicit operator BigFloat(int value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(long value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(uint value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(ulong value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(decimal value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(double value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(float value)
        {
            return new BigFloat(value);
        }
        public static implicit operator BigFloat(BigInteger value)
        {
            return new BigFloat(value);
        }
        public static explicit operator BigFloat(string value)
        {
            return new BigFloat(value);
        }

        private BigFloat Factor()
        {
            //factoring can be very slow. So use only when neccessary (ToString, and comparisons)

            if (denominator == 1)
                return this;

            //factor numerator and denominator
            BigInteger factor = BigInteger.GreatestCommonDivisor(numerator, denominator);

            numerator /= factor;
            denominator /= factor;

            return this;
        }

    }

}