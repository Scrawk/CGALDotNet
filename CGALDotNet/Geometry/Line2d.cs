using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace CGALDotNet.Geometry
{

    /// <summary>
    ///  Represents a line from three coefficients
    ///  a, b and c, where ax + by + c = 0 holds.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Line2d : IEquatable<Line2d>
    {

        public double A, B, C;

        /// <summary>
        ///  Create a new line from three coefficients
        ///  a, b and c, where ax + by + c = 0 holds.
        /// </summary>
        /// <param name="a">The constant in ax.</param>
        /// <param name="b">The constant in by</param>
        /// <param name="c">The constant c</param>
        public Line2d(double a, double b, double c)
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
        public Line2d(double m, double b)
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
        public Line2d(Point2d p1, Point2d p2)
        {
            A = p1.y - p2.y;
            B = p2.x - p1.x;
            C = p1.x * p2.y - p2.x * p1.y;
        }

        public static bool operator ==(Line2d i1, Line2d i2)
        {
            return i1.A == i2.A && i1.B == i2.B && i1.C == i2.C;
        }

        public static bool operator !=(Line2d i1, Line2d i2)
        {
            return i1.A != i2.A || i1.B != i2.B || i1.C != i2.C;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Line2d)) return false;
            Line2d line = (Line2d)obj;
            return this == line;
        }

        public bool Equals(Line2d line)
        {
            return this == line;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ A.GetHashCode();
                hash = (hash * 16777619) ^ B.GetHashCode();
                hash = (hash * 16777619) ^ C.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("[Line2d: A={0}, B={1}, C={2}]", A, B, C);
        }

        /// <summary>
        /// Calculates the X coordinate of a point on the line by its Y coordinate.
        /// </summary>
        public double X(double y)
        {
            if (A == 0) return 0;
            return (-C - B * y) / A;
        }

        /// <summary>
        /// Calculates the Y coordinate of a point on the line by its X coordinate.
        /// </summary>
        public double Y(double x)
        {
            if (B == 0) return 0;
            return (-C - A * x) / B;
        }

    }

}
