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
    public struct Line2d : IEquatable<Line2d>, IGeometry2d
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

        /// <summary>
        /// Find the slope of the line.
        /// </summary>
        public double Slope
        {
            get
            {
                if (B == 0) return 0;
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
                return (B == 0 || (-A / B) >= 0);
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
                return B == 0 && A != 0;
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
                return (B == 0 || (-A / B) < 0);
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
                return (A == 0 && B != 0);
            }
        }

        /// <summary>
        /// Determines whether the line is degenerate
        /// (e.g.two equal points were passed to the constructor).
        /// </summary>
        public bool IsDegenerate
        {
            get
            {
                return (A == 0 && B == 0 && C == 0);
            }
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

        /// <summary>
        /// Check if the geometries intersects.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>True if there is a intersection.</returns>
        public bool DoIntersect(IGeometry2d geometry)
        {
            return CGALIntersections.DoIntersect(this, geometry);
        }

        /// <summary>
        /// Find the intersection with this geometry.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>The intersection result.</returns>
        public IntersectionResult2d Intersection(IGeometry2d geometry)
        {
            return CGALIntersections.Intersection(this, geometry);
        }

        /// <summary>
        /// Transform the line by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix2x2d m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transform the line by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix3x3d m)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transform the line by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix4x4d m)
        {
            throw new NotImplementedException();
        }

    }

}
