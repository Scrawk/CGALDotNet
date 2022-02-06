using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Single;
using POINT2 = CGALDotNetGeometry.Numerics.Point2f;
using VECTOR2 = CGALDotNetGeometry.Numerics.Vector2f;
using POINT3 = CGALDotNetGeometry.Numerics.Point3f;
using BOX2 = CGALDotNetGeometry.Shapes.Box2f;
using CIRCLE2 = CGALDotNetGeometry.Shapes.Circle2f;
using MATRIX2 = CGALDotNetGeometry.Numerics.Matrix2x2f;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 2D triangle.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle2f : IEquatable<Triangle2f>
    {

        /// <summary>
        /// The triangles first point.
        /// </summary>
        public POINT2 A;

        /// <summary>
        /// The triangles second point.
        /// </summary>
        public POINT2 B;

        /// <summary>
        /// The triangles third point.
        /// </summary>
        public POINT2 C;

        /// <summary>
        /// Construct a new triangle.
        /// </summary>
        /// <param name="a">The triangles first point.</param>
        /// <param name="b">The triangles second point.</param>
        /// <param name="c">The triangles third point.</param>
        public Triangle2f(POINT2 a, POINT2 b, POINT2 c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Construct a new triangle.
        /// </summary>
        /// <param name="ax">The triangles first points x value.</param>
        /// <param name="ay">The triangles first points y value.</param>
        /// <param name="bx">The triangles second points x value.</param>
        /// <param name="by">The triangles second points y value.</param>
        /// <param name="cx">The triangles third points x value.</param>
        /// <param name="cy">The triangles third points y value.</param>
        public Triangle2f(REAL ax, REAL ay, REAL bx, REAL by, REAL cx, REAL cy)
        {
            A = new POINT2(ax, ay);
            B = new POINT2(bx, by);
            C = new POINT2(cx, cy);
        }

        /// <summary>
        /// The average of the triangles positions.
        /// </summary>
        public POINT2 Center => (A + B + C) / 3.0f;

        /// <summary>
        /// Is the triangle orientated ccw.
        /// </summary>
        public bool IsCCW => SignedArea > 0;

        /// <summary>
        /// The triangles area.
        /// </summary>
        public REAL Area => Math.Abs(SignedArea);

        /// <summary>
        /// The triangles signed area.
        /// </summary>
        public REAL SignedArea => ((A.x - C.x) * (B.y - C.y) - (A.y - C.y) * (B.x - C.x)) * 0.5f;

        /// <summary>
        /// The side lengths are given as
        /// a = sqrt((cx - bx)^2 + (cy - by)^2) -- side BC opposite of A
        /// b = sqrt((cx - ax)^2 + (cy - ay)^2) -- side CA opposite of B
        /// c = sqrt((ax - bx)^2 + (ay - by)^2) -- side AB opposite of C
        /// </summary>
        public POINT3 SideLengths
        {
            get
            {
                var a = MathUtil.Sqrt(MathUtil.Sqr(C.x - B.x) + MathUtil.Sqr(C.y - B.y));
                var b = MathUtil.Sqrt(MathUtil.Sqr(C.x - A.x) + MathUtil.Sqr(C.y - A.y));
                var c = MathUtil.Sqrt(MathUtil.Sqr(A.x - B.x) + MathUtil.Sqr(A.y - B.y));
                return new POINT3(a, b, c);
            }
        }

        /// <summary>
        /// The side lengths are given as
        /// ang_a = acos((b^2 + c^2 - a^2)  / (2 * b * c)) -- angle at A
        /// ang_b = acos((c^2 + a^2 - b^2)  / (2 * c * a)) -- angle at B
        /// ang_c = acos((a^2 + b^2 - c^2)  / (2 * a * b)) -- angle at C
        /// </summary>
        public POINT3 Angles
        {
            get
            {
                var len = SideLengths;
                var a2 = len.x * len.x;
                var b2 = len.y * len.y;
                var c2 = len.z * len.z;
                var a = MathUtil.Acos((b2 + c2 - a2) * (2 * len.y * len.z));
                var b = MathUtil.Acos((c2 + a2 - b2) * (2 * len.z * len.x));
                var c = MathUtil.Acos((a2 + b2 - c2) * (2 * len.x * len.y));
                return new POINT3(a, b, c);
            }
        }

        /// <summary>
        /// The semiperimeter is given as
        /// s = (a + b + c) / 2
        /// </summary>
        public REAL SemiPerimeter => SideLengths.Sum / 2.0f;

        /// <summary>
        /// The inradius is given as
        /// r = D / s
        /// This is the radius of the largest circle that can
        /// fit within the triangle. Not the same as the 
        /// circum circles radius.
        /// </summary>
        public REAL InRadius => MathUtil.SafeDiv(Area, SemiPerimeter);

        /// <summary>
        /// The circumradius is given as
        ///   R = a * b * c / (4 * D)
        /// </summary>
        public REAL CircumRadius => SideLengths.Product / (4.0f * Area);

        /// <summary>
        /// The circum circle formed by the 
        /// triangles points.
        /// </summary>
        public CIRCLE2 CircumCircle => CIRCLE2.CircumCircle(A, B, C);

        /// <summary>
        /// The altitudes are given as
        ///   alt_a = 2 * D / a -- altitude above side a
        ///   alt_b = 2 * D / b -- altitude above side b
        ///   alt_c = 2 * D / c -- altitude above side c
        /// </summary>
        public POINT3 Altitudes
        {
            get
            {
                var a = 2 * Area / SideLengths.x;
                var b = 2 * Area / SideLengths.y;
                var c = 2 * Area / SideLengths.z;
                return new POINT3(a, b, c);
            }
        }

        /// <summary>
        /// The aspect ratio may be given as the ratio of the longest to the
        /// shortest edge or, more commonly as the ratio of the circumradius 
        /// to twice the inradius
        ///   ar = R / (2 * r)
        ///      = a * b * c / (8 * (s - a) * (s - b) * (s - c))
        ///      = a * b * c / ((b + c - a) * (c + a - b) * (a + b - c))
        /// </summary>
        public REAL AspectRatio => CircumRadius / (2 * InRadius);

        public BOX2 Bounds
        {
            get
            {
                var xmin = MathUtil.Min(A.x, B.x, C.x);
                var xmax = MathUtil.Max(A.x, B.x, C.x);
                var ymin = MathUtil.Min(A.y, B.y, C.y);
                var ymax = MathUtil.Max(A.y, B.y, C.y);

                return new BOX2(new POINT2(xmin, ymin), new POINT2(xmax, ymax));
            }
        }

        unsafe public POINT2 this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle2f index out of range.");

                fixed (Triangle2f* array = &this) { return ((POINT2*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("Triangle2f index out of range.");

                fixed (POINT2* array = &A) { array[i] = value; }
            }
        }

        public static Triangle2f operator +(Triangle2f tri, REAL s)
        {
            return new Triangle2f(tri.A + s, tri.B + s, tri.C + s);
        }

        public static Triangle2f operator +(Triangle2f tri, POINT2 v)
        {
            return new Triangle2f(tri.A + v, tri.B + v, tri.C + v);
        }

        public static Triangle2f operator -(Triangle2f tri, REAL s)
        {
            return new Triangle2f(tri.A - s, tri.B - s, tri.C - s);
        }

        public static Triangle2f operator -(Triangle2f tri, POINT2 v)
        {
            return new Triangle2f(tri.A - v, tri.B - v, tri.C - v);
        }

        public static Triangle2f operator *(Triangle2f tri, REAL s)
        {
            return new Triangle2f(tri.A * s, tri.B * s, tri.C * s);
        }

        public static Triangle2f operator /(Triangle2f tri, REAL s)
        {
            return new Triangle2f(tri.A / s, tri.B / s, tri.C / s);
        }

        public static Triangle2f operator *(Triangle2f tri, MATRIX2 m)
        {
            return new Triangle2f(m * tri.A, m * tri.B, m * tri.C);
        }

        public static bool operator ==(Triangle2f t1, Triangle2f t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(Triangle2f t1, Triangle2f t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C;
        }

        /// <summary>
        /// Is the triangle equal to the other object.
        /// </summary>
        /// <param name="obj">The  other object.</param>
        /// <returns>Is the triangle equal to the other object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Triangle2f)) return false;
            Triangle2f tri = (Triangle2f)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the triangle equal to the other riangle.
        /// </summary>
        /// <param name="tri">The  other riangle.</param>
        /// <returns>Is the triangle equal to the other riangle.</returns>
        public bool Equals(Triangle2f tri)
        {
            return this == tri;
        }

        /// <summary>
        /// The triangles hashcode.
        /// </summary>
        /// <returns>The triangles hashcode.</returns>
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
            return string.Format("[Triangle2f: A={0}, B={1}, C={2}]", A, B, C);
        }

        /// <summary>
        /// Round the triangles components.
        /// </summary>
        /// <param name="digits">The digits to round to.</param>
        public void Round(int digits)
        {
            A.Round(digits);
            B.Round(digits);
            C.Round(digits);
        }

        /// <summary>
        /// The cross product area which is the 
        /// same as double the signed area.
        /// </summary>
        public static REAL CrossProductArea(POINT2 a, POINT2 b, POINT2 c)
        {
            return (a.x - c.x) * (b.y - c.y) - (a.y - c.y) * (b.x - c.x);
        }

        /// <summary>
        /// Return th barycentric coordinates
        /// with respect to p.
        /// </summary>
        public POINT3 Barycentric(POINT2 p)
        {
            VECTOR2 v0 = (B - A).Vector2f;
            VECTOR2 v1 = (C - A).Vector2f;
            VECTOR2 v2 = (p - A).Vector2f;

            REAL d00 = VECTOR2.Dot(v0, v0);
            REAL d01 = VECTOR2.Dot(v0, v1);
            REAL d11 = VECTOR2.Dot(v1, v1);
            REAL d20 = VECTOR2.Dot(v2, v0);
            REAL d21 = VECTOR2.Dot(v2, v1);
            REAL denom = d00 * d11 - d01 * d01;
            REAL v = (d11 * d20 - d01 * d21) / denom;
            REAL w = (d00 * d21 - d01 * d20) / denom;
            REAL u = 1.0f - v - w;
            return new POINT3(u, v, w);
        }

        /// <summary>
        /// Find the closest point to the triangle.
        /// If point inside triangle return point.
        /// </summary>
        public POINT2 Closest(POINT2 p)
        {
            VECTOR2 ab = (B - A).Vector2f;
            VECTOR2 ac = (C - A).Vector2f;
            VECTOR2 ap = (p - A).Vector2f;

            // Check if P in vertex region outside A
            REAL d1 = VECTOR2.Dot(ab, ap);
            REAL d2 = VECTOR2.Dot(ac, ap);
            if (d1 <= 0.0 && d2 <= 0.0)
            {
                // barycentric coordinates (1,0,0)
                return A;
            }

            REAL v, w;

            // Check if P in vertex region outside B
            VECTOR2 bp = (p - B).Vector2f;
            REAL d3 = VECTOR2.Dot(ab, bp);
            REAL d4 = VECTOR2.Dot(ac, bp);
            if (d3 >= 0.0 && d4 <= d3)
            {
                // barycentric coordinates (0,1,0)
                return B;
            }

            // Check if P in edge region of AB, if so return projection of P onto AB
            REAL vc = d1 * d4 - d3 * d2;
            if (vc <= 0.0f && d1 >= 0.0f && d3 <= 0.0f)
            {
                v = d1 / (d1 - d3);
                // barycentric coordinates (1-v,v,0)
                return A + v * ab;
            }

            // Check if P in vertex region outside C
            VECTOR2 cp = (p - C).Vector2f;
            REAL d5 = VECTOR2.Dot(ab, cp);
            REAL d6 = VECTOR2.Dot(ac, cp);
            if (d6 >= 0.0f && d5 <= d6)
            {
                // barycentric coordinates (0,0,1)
                return C;
            }

            // Check if P in edge region of AC, if so return projection of P onto AC
            REAL vb = d5 * d2 - d1 * d6;
            if (vb <= 0.0f && d2 >= 0.0f && d6 <= 0.0f)
            {
                w = d2 / (d2 - d6);
                // barycentric coordinates (1-w,0,w)
                return A + w * ac;
            }

            // Check if P in edge region of BC, if so return projection of P onto BC
            REAL va = d3 * d6 - d5 * d4;
            if (va <= 0.0f && (d4 - d3) >= 0.0f && (d5 - d6) >= 0.0f)
            {
                w = (d4 - d3) / ((d4 - d3) + (d5 - d6));
                // barycentric coordinates (0,1-w,w)
                return B + w * (C - B);
            }

            // P inside face region. Compute Q through its barycentric coordinates (u,v,w)
            REAL denom = 1.0f / (va + vb + vc);
            v = vb * denom;
            w = vc * denom;

            // = u*a + v*b + w*c, u = va * denom = 1.0f - v - w
            return A + ab * v + ac * w;
        }

        /// <summary>
        /// Returns the signed distance to surface of triangle.
        /// </summary>
        /// <returns>positive if outside triangle, negative if inside and 0 on boundary</returns>
        public REAL SignedDistance(POINT2 p)
        {
            POINT2 center = Center;
            VECTOR2 P = (p - center).Vector2f;

            VECTOR2 a = (A - center).Vector2f;
            VECTOR2 b = (B - center).Vector2f;
            VECTOR2 c = (C - center).Vector2f;

            VECTOR2 e0 = b - a, e1 = c - b, e2 = a - c;
            VECTOR2 v0 = P - a, v1 = P - b, v2 = P - c;

            VECTOR2 pq0 = v0 - e0 * MathUtil.Clamp01(VECTOR2.Dot(v0, e0) / VECTOR2.Dot(e0, e0));
            VECTOR2 pq1 = v1 - e1 * MathUtil.Clamp01(VECTOR2.Dot(v1, e1) / VECTOR2.Dot(e1, e1));
            VECTOR2 pq2 = v2 - e2 * MathUtil.Clamp01(VECTOR2.Dot(v2, e2) / VECTOR2.Dot(e2, e2));

            REAL s = Math.Sign(e0.x * e2.y - e0.y * e2.x);

            VECTOR2 d0 = new VECTOR2(VECTOR2.Dot(pq0, pq0), s * (v0.x * e0.y - v0.y * e0.x));
            VECTOR2 d1 = new VECTOR2(VECTOR2.Dot(pq1, pq1), s * (v1.x * e1.y - v1.y * e1.x));
            VECTOR2 d2 = new VECTOR2(VECTOR2.Dot(pq2, pq2), s * (v2.x * e2.y - v2.y * e2.x));

            POINT2 d = new POINT2();
            d.x = MathUtil.Min(d0.x, d1.x, d2.x);
            d.y = MathUtil.Min(d0.y, d1.y, d2.y);

            return -MathUtil.Sqrt(d.x) * Math.Sign(d.y);
        }

        /// <summary>
        /// Does triangle contain point.
        /// </summary>
        /// <param name="p">point</param>
        /// <returns>true if triangle contains point</returns>
        public bool Contains(POINT2 p)
        {

            REAL pab = VECTOR2.Cross((p - A).Vector2f, (B - A).Vector2f);
            REAL pbc = VECTOR2.Cross((p - B).Vector2f, (C - B).Vector2f);

            if (Math.Sign(pab) != Math.Sign(pbc)) return false;

            REAL pca = VECTOR2.Cross((p - C).Vector2f, (A - C).Vector2f);

            if (Math.Sign(pab) != Math.Sign(pca)) return false;

            return true;
        }

        /// <summary>
        /// Does triangle contain point.
        /// Asumes triangle is CCW;
        /// </summary>
        /// <param name="p">point</param>
        /// <returns>true if triangle contains point</returns>
        public bool ContainsCCW(POINT2 p)
        {
            if (VECTOR2.Cross((p - A).Vector2f, (B - A).Vector2f) > 0.0) return false;
            if (VECTOR2.Cross((p - B).Vector2f, (C - B).Vector2f) > 0.0) return false;
            if (VECTOR2.Cross((p - C).Vector2f, (A - C).Vector2f) > 0.0) return false;

            return true;
        }

        /// <summary>
        /// Does the triangle intersect this box.
        /// </summary>
        public bool Intersects(Box2f box)
        {
            throw new NotImplementedException();
        }

    }
}