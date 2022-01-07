using System;
using System.Runtime.InteropServices;

using CGALDotNet.Circular;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle2d : IEquatable<Triangle2d>, IGeometry2d
    {
        /// <summary>
        /// The triangles first point.
        /// </summary>
        public Point2d A;

        /// <summary>
        /// The triangles second point.
        /// </summary>
        public Point2d B;

        /// <summary>
        /// The triangles third point.
        /// </summary>
        public Point2d C;

        /// <summary>
        /// Create a new triangle.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <param name="c">The third point.</param>
        public Triangle2d(Point2d a, Point2d b, Point2d c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Create a new triangle.
        /// </summary>
        /// <param name="ax">The first points x value.</param>
        /// <param name="ay">The first points y value.</param>
        /// <param name="bx">The second points x value.</param>
        /// <param name="by">The second points y value.</param>
        /// <param name="cx">The third points x value.</param>
        /// <param name="cy">The third points y value.</param>
        public Triangle2d(double ax, double ay, double bx, double by, double cx, double cy)
        {
            A = new Point2d(ax, ay);
            B = new Point2d(bx, by);
            C = new Point2d(cx, cy);
        }

        /// <summary>
        /// The triangles area.
        /// </summary>
        public double Area => Math.Abs(SignedArea);

        /// <summary>
        /// The triangles signed area.
        /// </summary>
        public double SignedArea => ((A.x - C.x) * (B.y - C.y) - (A.y - C.y) * (B.x - C.x)) * 0.5;

        /// <summary>
        /// Array acess to the triangles points.
        /// </summary>
        /// <param name="i">The index of the point to access (0-2)</param>
        /// <returns>The point at index i.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        unsafe public Point2d this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle2d index out of range.");

                fixed (Triangle2d* array = &this) { return ((Point2d*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle2d index out of range.");

                fixed (Point2d* array = &A) { array[i] = value; }
            }
        }

        public static Triangle2d operator +(Triangle2d tri, double s)
        {
            return new Triangle2d(tri.A + s, tri.B + s, tri.C + s);
        }

        public static Triangle2d operator +(Triangle2d tri, Point2d v)
        {
            return new Triangle2d(tri.A + v, tri.B + v, tri.C + v);
        }

        public static Triangle2d operator -(Triangle2d tri, double s)
        {
            return new Triangle2d(tri.A - s, tri.B - s, tri.C - s);
        }

        public static Triangle2d operator -(Triangle2d tri, Point2d v)
        {
            return new Triangle2d(tri.A - v, tri.B - v, tri.C - v);
        }

        public static Triangle2d operator *(Triangle2d tri, double s)
        {
            return new Triangle2d(tri.A * s, tri.B * s, tri.C * s);
        }

        public static Triangle2d operator /(Triangle2d tri, double s)
        {
            return new Triangle2d(tri.A / s, tri.B / s, tri.C / s);
        }

        public static bool operator ==(Triangle2d t1, Triangle2d t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(Triangle2d t1, Triangle2d t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C;
        }

        /// <summary>
        /// Is the triangle equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the triangle equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Triangle2d)) return false;
            Triangle2d tri = (Triangle2d)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the triangle equal to the other triangle.
        /// </summary>
        /// <param name="tri">The other triangle.</param>
        /// <returns>Is the triangle equal to the other triangle.</returns>
        public bool Equals(Triangle2d tri)
        {
            return this == tri;
        }

        /// <summary>
        /// The triangles hash code.
        /// </summary>
        /// <returns>The triangles hash code.</returns>
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

        /// <summary>
        /// The triangle as a string.
        /// </summary>
        /// <returns>The triangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Triangle2d: A={0}, B={1}, C={2}]", A, B, C);
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
        /// Round the triangles points.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            A = A.Rounded(digits);
            B = B.Rounded(digits);
            C = C.Rounded(digits);
        }

        /// <summary>
        /// Creates a circle that has all 3 points on its circumference.
        /// From MathWorld: http://mathworld.wolfram.com/Circumcircle.html.
        /// Fails if the points are colinear.
        /// </summary>
        public Circle2d CircumCircle()
        {
            var m = new Matrix3x3d();

            // x, y, 1
            m.SetRow(0, new Vector3d(A.x, A.y, 1));
            m.SetRow(1, new Vector3d(B.x, B.y, 1));
            m.SetRow(2, new Vector3d(C.x, C.y, 1));
            double a = m.Determinant;

            // size, y, 1
            m.SetColumn(0, new Vector3d(A.SqrMagnitude, B.SqrMagnitude, C.SqrMagnitude));
            double dx = -m.Determinant;

            // size, x, 1
            m.SetColumn(1, new Vector3d(A.x, B.x, C.x));
            double dy = m.Determinant;

            // size, x, y
            m.SetColumn(2, new Vector3d(A.y, B.y, C.y));
            double c = -m.Determinant;

            double s = -1.0 / (2.0 * a);

            var circumCenter = new Point2d(s * dx, s * dy);
            double radius = Math.Abs(s) * Math.Sqrt(dx * dx + dy * dy - 4.0 * a * c);

            return new Circle2d(circumCenter, radius);
        }

    }
}