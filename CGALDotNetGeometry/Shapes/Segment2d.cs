using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Double;
using POINT2 = CGALDotNetGeometry.Numerics.Point2d;
using VECTOR2 = CGALDotNetGeometry.Numerics.Vector2d;
using BOX2 = CGALDotNetGeometry.Shapes.Box2d;
using MATRIX2 = CGALDotNetGeometry.Numerics.Matrix2x2d;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 2D segment.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Segment2d : IEquatable<Segment2d>
    {
        /// <summary>
        /// The segments first point.
        /// </summary>
        public POINT2 A;

        /// <summary>
        /// The segments second point.
        /// </summary>
        public POINT2 B;

        /// <summary>
        /// Construct a new segment.
        /// </summary>
        /// <param name="a">The segments first point.</param>
        /// <param name="b">The segments second point.</param>
        public Segment2d(POINT2 a, POINT2 b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Construct a new segment.
        /// </summary>
        /// <param name="ax">The segments first points x value.</param>
        /// <param name="ay">The segments first points y value.</param>
        /// <param name="bx">The segments second points x value.</param>
        /// <param name="by">The segments second points y value.param>
        public Segment2d(REAL ax, REAL ay, REAL bx, REAL by)
        {
            A = new POINT2(ax, ay);
            B = new POINT2(bx, by);
        }

        /// <summary>
        /// The segments center.
        /// </summary>
        public POINT2 Center => (A + B) * 0.5;

        /// <summary>
        /// The segments length.
        /// </summary>
        public REAL Length => POINT2.Distance(A, B);

        /// <summary>
        /// The segments square length.
        /// </summary>
        public REAL SqrLength => POINT2.SqrDistance(A, B);

        /// <summary>
        /// The segments tangent vector.
        /// </summary>
        public VECTOR2 Tangent => POINT2.Direction(A, B);

        /// <summary>
        /// The segments normal vector.
        /// </summary>
        public VECTOR2 Normal => Tangent.PerpendicularCW;

        /// <summary>
        /// The left most point of the segment.
        /// </summary>
        public REAL LeftMost => Math.Min(A.x, B.x);

        /// <summary>
        /// The right most point of the segment.
        /// </summary>
        public REAL RightMost => Math.Max(A.x, B.x);

        /// <summary>
        /// The bottom most point of the segment.
        /// </summary>
        public REAL BottomMost => Math.Min(A.y, B.y);

        /// <summary>
        /// The top most point of the segment.
        /// </summary>
        public REAL TopMost => Math.Max(A.y, B.y);

        /// <summary>
        /// THe segment flipped, a is now b, b is now a.
        /// </summary>
        public Segment2d Reversed => new Segment2d(B, A);

        /// <summary>
        /// The segments bounding box.
        /// </summary>
        public BOX2 Bounds
        {
            get
            {
                REAL xmin = Math.Min(A.x, B.x);
                REAL xmax = Math.Max(A.x, B.x);
                REAL ymin = Math.Min(A.y, B.y);
                REAL ymax = Math.Max(A.y, B.y);

                return new BOX2(new POINT2(xmin, ymin), new POINT2(xmax, ymax));
            }
        }

        unsafe public POINT2 this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (Segment2d* array = &this) { return ((POINT2*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("Segment2d index out of range.");

                fixed (POINT2* array = &A) { array[i] = value; }
            }
        }


        public static Segment2d operator +(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A + s, seg.B + s);
        }

        public static Segment2d operator +(Segment2d seg, POINT2 v)
        {
            return new Segment2d(seg.A + v, seg.B + v);
        }

        public static Segment2d operator -(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A - s, seg.B - s);
        }

        public static Segment2d operator -(Segment2d seg, POINT2 v)
        {
            return new Segment2d(seg.A - v, seg.B - v);
        }

        public static Segment2d operator *(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A * s, seg.B * s);
        }

        public static Segment2d operator /(Segment2d seg, REAL s)
        {
            return new Segment2d(seg.A / s, seg.B / s);
        }

        public static Segment2d operator *(Segment2d seg, MATRIX2 m)
        {
            return new Segment2d(m * seg.A, m * seg.B);
        }

        public static bool operator ==(Segment2d s1, Segment2d s2)
        {
            return s1.A == s2.A && s1.B == s2.B;
        }

        public static bool operator !=(Segment2d s1, Segment2d s2)
        {
            return s1.A != s2.A || s1.B != s2.B;
        }

        /// <summary>
        /// Is the segment equal to the other object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>Is the segment equal to the other object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Segment2d)) return false;
            Segment2d seg = (Segment2d)obj;
            return this == seg;
        }

        /// <summary>
        /// Is the segment equal to the other segment.
        /// </summary>
        /// <param name="obj">The other segment.</param>
        /// <returns>Is the segment equal to the other segment.</returns>
        public bool Equals(Segment2d seg)
        {
            return this == seg;
        }

        /// <summary>
        /// The segments hashcode.
        /// </summary>
        /// <returns>The segments hashcode.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ A.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ B.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Segment2d: A={0}, B={1}]", A, B);
        }

        /// <summary>
        /// The points distance from the segment.
        /// </summary>
        public REAL Distance(POINT2 point)
        {
            return MathUtil.Sqrt(SqrDistance(point));
        }

        /// <summary>
        /// The points sqr distance from the segment.
        /// </summary>
        public REAL SqrDistance(POINT2 point)
        {
            return POINT2.SqrDistance(Closest(point), point);
        }

        /// <summary>
        /// Round the segments points.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            A.Round(digits);
            B.Round(digits);
        }

        /// <summary>
        /// Does the point line on the segemnts.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Contains(POINT2 p)
        {
            var c = Closest(p);
            return POINT2.AlmostEqual(c, p);
        }

        /// <summary>
        /// Does the point line on the segemnts.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public bool Contains(POINT2 p, REAL eps)
        {
            var c = Closest(p);
            return POINT2.AlmostEqual(c, p, eps);
        }

        /// <summary>
        /// Return the signed distance to the point. 
        /// Always positive.
        /// </summary>
        public REAL SignedDistance(POINT2 p)
        {
            return POINT2.Distance(Closest(p), p);
        }

        /// <summary>
        /// Does the two segments intersect.
        /// </summary>
        /// <param name="seg">other segment</param>
        public bool Intersects(Segment2d seg)
        {
            return Intersects(seg, out REAL t);
        }

        /// <summary>
        /// Do the two segments intersect.
        /// </summary>
        /// <param name="seg">other segment</param>
        /// <param name="t">Intersection point = A + t * (B - A)</param>
        /// <returns>If they intersect</returns>
        public bool Intersects(Segment2d seg, out REAL t)
        {
            REAL area1 = Triangle2d.CrossProductArea(A, B, seg.B);
            REAL area2 = Triangle2d.CrossProductArea(A, B, seg.A);
            t = 0.0f;

            if (area1 * area2 < 0.0f)
            {
                REAL area3 = Triangle2d.CrossProductArea(seg.A, seg.B, A);
                REAL area4 = area3 + area2 - area1;

                if (area3 * area4 < 0.0f)
                {
                    t = area3 / (area3 - area4);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Do the two segments intersect.
        /// </summary>
        /// <param name="seg">other segment</param>
        /// <param name="s">Intersection point = A + s * (B - A)</param>
        /// <param name="t">Intersection point = seg.A + t * (seg.B - seg.A)</param>
        /// <returns>If they intersect</returns>
        public bool Intersects(Segment2d seg, out REAL s, out REAL t)
        {

            REAL area1 = Triangle2d.CrossProductArea(A, B, seg.B);
            REAL area2 = Triangle2d.CrossProductArea(A, B, seg.A);
            s = 0.0f;
            t = 0.0f;

            if (area1 * area2 < 0.0f)
            {
                REAL area3 = Triangle2d.CrossProductArea(seg.A, seg.B, A);
                REAL area4 = area3 + area2 - area1;

                if (area3 * area4 < 0.0f)
                {
                    s = area3 / (area3 - area4);

                    REAL a2 = area2;
                    REAL a3 = area3;

                    area1 = Triangle2d.CrossProductArea(seg.A, seg.B, B);
                    area2 = a3;
                    area3 = a2;
                    area4 = area3 + area2 - area1;
                    t = area3 / (area3 - area4);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Does the segment intersect this box.
        /// </summary>
        public bool Intersects(BOX2 box)
        {
            POINT2 c = box.Center;
            POINT2 e = box.Max - c; //Box half length extents
            POINT2 m = Center;
            POINT2 d = B - m; //Segment halflength vector.
            m = m - c; //translate box and segment to origin.

            //try world coordinate axes as seperating axes.
            REAL adx = Math.Abs(d.x);
            if (Math.Abs(m.x) > e.x + adx) return false;
            REAL ady = Math.Abs(d.y);
            if (Math.Abs(m.y) > e.y + ady) return false;

            //add in an epsilon term to counteract arithmetic errors 
            //when segment is near parallel to a coordinate axis.
            adx += MathUtil.EPS_32;
            ady += MathUtil.EPS_32;

            if (Math.Abs(m.x * d.y - m.y * d.x) > e.x * ady + e.y * adx) return false;

            return true;
        }

        /// <summary>
        /// The closest point on segment to point.
        /// </summary>
        /// <param name="p">point</param>
        public POINT2 Closest(POINT2 p)
        {
            REAL t;
            Closest(p, out t);
            return A + (B - A) * t;
        }

        /// <summary>
        /// The closest point on segment to point.
        /// </summary>
        /// <param name="p">point</param>
        /// <param name="t">closest point = A + t * (B - A)</param>
        public void Closest(POINT2 p, out REAL t)
        {
            t = 0.0f;
            POINT2 ab = B - A;
            POINT2 ap = p - A;

            REAL len = ab.x * ab.x + ab.y * ab.y;
            if (MathUtil.IsZero(len)) return;

            t = (ab.x * ap.x + ab.y * ap.y) / len;
            t = MathUtil.Clamp01(t);
        }

        /// <summary>
        /// The closest segment spanning two other segments.
        /// </summary>
        /// <param name="seg">the other segment</param>
        public Segment2d Closest(Segment2d seg)
        {
            REAL s, t;
            Closest(seg, out s, out t);
            return new Segment2d(A + (B - A) * s, seg.A + (seg.B - seg.A) * t);
        }

        /// <summary>
        /// The closest segment spanning two other segments.
        /// </summary>
        /// <param name="seg">the other segment</param>
        /// <param name="s">closest point = A + s * (B - A)</param>
        /// <param name="t">other closest point = seg.A + t * (seg.B - seg.A)</param>
        public void Closest(Segment2d seg, out REAL s, out REAL t)
        {

            VECTOR2 ab0 = (B - A).Vector2d;
            VECTOR2 ab1 = (seg.B - seg.A).Vector2d;
            VECTOR2 a01 = (A - seg.A).Vector2d;

            REAL d00 = VECTOR2.Dot(ab0, ab0);
            REAL d11 = VECTOR2.Dot(ab1, ab1);
            REAL d1 = VECTOR2.Dot(ab1, a01);

            s = 0;
            t = 0;

            //Check if either or both segments degenerate into points.
            if (MathUtil.IsZero(d00) && MathUtil.IsZero(d11))
                return;

            if (MathUtil.IsZero(d00))
            {
                //First segment degenerates into a point.
                s = 0;
                t = MathUtil.Clamp01(d1 / d11);
            }
            else
            {
                REAL c = VECTOR2.Dot(ab0, a01);

                if (MathUtil.IsZero(d11))
                {
                    //Second segment degenerates into a point.
                    s = MathUtil.Clamp01(-c / d00);
                    t = 0;
                }
                else
                {
                    //The generate non degenerate case starts here.
                    REAL d2 = VECTOR2.Dot(ab0, ab1);
                    REAL denom = d00 * d11 - d2 * d2;

                    //if segments not parallel compute closest point and clamp to segment.
                    if (!MathUtil.IsZero(denom))
                        s = MathUtil.Clamp01((d2 * d1 - c * d11) / denom);
                    else
                        s = 0;

                    t = (d2 * s + d1) / d11;

                    if (t < 0.0f)
                    {
                        t = 0.0f;
                        s = MathUtil.Clamp01(-c / d00);
                    }
                    else if (t > 1.0f)
                    {
                        t = 1.0f;
                        s = MathUtil.Clamp01((d2 - c) / d00);
                    }
                }
            }
        }

    }
}

