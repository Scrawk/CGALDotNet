using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Single;
using POINT2 = CGALDotNetGeometry.Numerics.Point2f;

namespace CGALDotNetGeometry.Shapes
{

    /// <summary>
    ///  Represents a line from three coefficients
    ///  a, b and c, where ax + by + c = 0 holds.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Line2f : IEquatable<Line2f>
    {

        public REAL A, B, C;

        /// <summary>
        ///  Create a new line from three coefficients
        ///  a, b and c, where ax + by + c = 0 holds.
        /// </summary>
        /// <param name="a">The constant in ax.</param>
        /// <param name="b">The constant in by</param>
        /// <param name="c">The constant c</param>
        public Line2f(REAL a, REAL b, REAL c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        ///  Create a new line from the slope and the y 
        ///  intercept, where y = mx + b holds.
        /// </summary>
        /// <param name="m">The lines slope.</param>
        /// <param name="b">The y intercept.</param>
        public Line2f(REAL m, REAL b)
        {
            A = m;
            B = 1;
            C = b;
        }

        /// <summary>
        /// Create a new line that passes through the two points.
        /// </summary>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        public Line2f(POINT2 p1, POINT2 p2)
        {
            A = p1.y - p2.y;
            B = p2.x - p1.x;
            C = p1.x * p2.y - p2.x * p1.y;
        }

        /// <summary>
        /// Find the slope of the line.
        /// </summary>
        public REAL Slope
        {
            get
            {
                if (MathUtil.IsZero(B)) return 0;
                return -A / B;
            }
        }

        /// <summary>
        /// Determines whether the line is ascending
        /// (that is, makes an angle with the positive
        /// direction of the X axis that lies in (0, pi/2).
        /// </summary>
        public bool IsAscending
        {
            get
            {
                return (MathUtil.IsZero(B) || (-A / B) >= 0);
            }
        }

        /// <summary>
        /// Determines whether the line is vertical
        /// (that is, makes an angle with the positive
        /// direction of the X axis that is equal to pi/2.
        /// </summary>
        public bool IsVertical
        {
            get
            {
                return MathUtil.IsZero(B) && !MathUtil.IsZero(A);
            }
        }

        /// <summary>
        /// Determines whether the line is descending
        /// (that is, makes an angle with the positive
        /// direction of the X axis that lies in (pi/2, pi).
        /// </summary>
        public bool IsDescending
        {
            get
            {
                return (MathUtil.IsZero(B) || (-A / B) < 0);
            }
        }

        /// <summary>
        /// Determines whether the line is horizontal
        /// (that is, makes an angle with the positive
        /// direction of the X axis that is equal to pi.
        /// </summary>
        public bool IsHorizontal
        {
            get
            {
                return (MathUtil.IsZero(A) && !MathUtil.IsZero(B));
            }
        }

        /// <summary>
        /// Determines whether the line is undefined
        /// (e.g.two equal points were passed to the constructor).
        /// </summary>
        public bool IsUndefined
        {
            get
            {
                return (MathUtil.IsZero(A) && MathUtil.IsZero(B) && MathUtil.IsZero(C));
            }
        }

        /// <summary>
        /// Calculates the angle that the line makes
        /// with the positive direction of the X axis.
        /// </summary>
        /// <returns></returns>
        public REAL Angle
        {
            get
            {
                if (IsVertical) return MathUtil.PI_32 / 2.0f;

                REAL atan = MathUtil.Atan(-A / B);
                if (atan < 0) atan += MathUtil.PI_32;

                return atan;
            }
        }

        public static bool operator ==(Line2f i1, Line2f i2)
        {
            return i1.A == i2.A && i1.B == i2.B && i1.C == i2.C;
        }

        public static bool operator !=(Line2f i1, Line2f i2)
        {
            return i1.A != i2.A || i1.B != i2.B || i1.C != i2.C;
        }

        /// <summary>
        /// Is the line equal to the other object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>Is the line equal to the other object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Line2f)) return false;
            Line2f line = (Line2f)obj;
            return this == line;
        }

        /// <summary>
        /// Is the line equal to the other line.
        /// </summary>
        /// <param name="obj">The other line.</param>
        /// <returns>Is the line equal to the other line.</returns>
        public bool Equals(Line2f line)
        {
            return this == line;
        }

        /// <summary>
        /// The lines hash code.
        /// </summary>
        /// <returns>The lines hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ A.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ B.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ C.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Line2f: A={0}, B={1}, C={2}]", A, B, C);
        }

        /// <summary>
        /// Calculates the X coordinate of a point on the line by its Y coordinate.
        /// </summary>
        public REAL X(REAL y)
        {
            if (MathUtil.IsZero(A)) return 0;
            return (-C - B * y) / A;
        }

        /// <summary>
        /// Calculates the Y coordinate of a point on the line by its X coordinate.
        /// </summary>
        public REAL Y(REAL x)
        {
            if (MathUtil.IsZero(B)) return 0;
            return (-C - A * x) / B;
        }

        /// <summary>
        /// Determines whether the point lies on the line.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>if the point lies on the line</returns>
        public bool PointOnLine(POINT2 p)
        {
            return MathUtil.IsZero(A * p.x + B * p.y + C);
        }

        /// <summary>
        /// Calculates the perpendicular line that
        /// passes through the given point.
        /// </summary>
        public Line2f PerpendicularLine(POINT2 p)
        {
            return new Line2f(B, -A, -B * p.x + A * p.y);
        }

        /// <summary>
        /// Determines whether the point lies
        /// on the left side of the line.
        /// </summary>
        public bool IsLeftPoint(POINT2 p)
        {
            return p.x < X(p.y);
        }

        /// <summary>
        /// Determines whether the point lies
        /// on the right side of the line.
        /// </summary>
        public bool IsRightPoint(POINT2 p)
        {
            return p.x > X(p.y);
        }

        /// <summary>
        /// Determine if the two lines are the equivalent
        /// even though they may have a different equation.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool AreEquivalent(Line2f line)
        {
            if (IsVertical)
            {
                return line.IsVertical &&
                       MathUtil.AlmostEqual(X(0), line.X(0)) &&
                       MathUtil.AlmostEqual(Slope, line.Slope);
            }
            else
            {
                return !line.IsVertical &&
                       MathUtil.AlmostEqual(Y(0), line.Y(0)) &&
                       MathUtil.AlmostEqual(Slope, line.Slope);
            }
        }

        /// <summary>
        /// Calculates the intersection of two lines.
        /// </summary>
        /// <param name="line">the other line</param>
        /// <param name="p">intersection point</param>
        /// <returns>if lines intersect</returns>
        public bool Intersects(Line2f line, out POINT2 p)
        {

            if (!MathUtil.IsZero(B))
            {
                REAL f = line.A - line.B * A / B;
                if (MathUtil.IsZero(f))
                {
                    p = POINT2.Zero;
                    return false;
                }
                else
                {
                    REAL x = (-line.C + line.B * C / B) / f;
                    REAL y = (-C - A * x) / B;

                    p = new POINT2(x, y);
                    return true;
                }
            }
            else
            {
                if (MathUtil.IsZero(A))
                {
                    p = POINT2.Zero;
                    return false;
                }
                else
                {
                    REAL f = line.B - line.A * B / A;
                    if (MathUtil.IsZero(f))
                    {
                        p = POINT2.Zero;
                        return false;
                    }
                    else
                    {
                        REAL y = (-line.C + line.A * C / A) / f;
                        REAL x = (-C - B * y) / A;

                        p = new POINT2(x, y);
                        return true;
                    }
                }
            }
        }


    }

}
