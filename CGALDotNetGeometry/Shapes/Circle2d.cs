using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Double;
using POINT2 = CGALDotNetGeometry.Numerics.Point2d;
using POINT3 = CGALDotNetGeometry.Numerics.Point3d;
using VECTOR3 = CGALDotNetGeometry.Numerics.Vector3d;
using BOX2 = CGALDotNetGeometry.Shapes.Box2d;
using MATRIX3 = CGALDotNetGeometry.Numerics.Matrix3x3d;

namespace CGALDotNetGeometry.Shapes
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Circle2d : IEquatable<Circle2d>
    {
        public POINT2 Center;

        public REAL Radius;

        public Circle2d(POINT2 centre, REAL radius)
        {
            Center = centre;
            Radius = radius;
        }

        public Circle2d(REAL x, REAL y, REAL radius)
        {
            Center = new POINT2(x, y);
            Radius = radius;
        }

        /// <summary>
        /// The squared radius.
        /// </summary>
        public REAL Radius2
        {
            get { return Radius * Radius; }
        }

        /// <summary>
        /// The circles diameter.
        /// </summary>
        public REAL Diameter
        {
            get { return Radius * 2.0; }
        }

        /// <summary>
        /// The circles area.
        /// </summary>
        public REAL Area
        {
            get { return MathUtil.PI_64 * Radius * Radius; }
        }

        /// <summary>
        /// the circles circumference.
        /// </summary>
        public REAL Circumference
        {
            get { return MathUtil.PI_64 * Radius * 2.0; }
        }

        /// <summary>
        /// Calculate the bounding box.
        /// </summary>
        public BOX2 Bounds
        {
            get
            {
                REAL xmin = Center.x - Radius;
                REAL xmax = Center.x + Radius;
                REAL ymin = Center.y - Radius;
                REAL ymax = Center.y + Radius;

                return new BOX2(new POINT2(xmin, ymin), new POINT2(xmax, ymax));
            }
        }

        public static bool operator ==(Circle2d c1, Circle2d c2)
        {
            return c1.Radius == c2.Radius && c1.Center == c2.Center;
        }

        public static bool operator !=(Circle2d c1, Circle2d c2)
        {
            return c1.Radius != c2.Radius || c1.Center != c2.Center;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Circle2d)) return false;
            Circle2d cir = (Circle2d)obj;
            return this == cir;
        }

        public bool Equals(Circle2d cir)
        {
            return this == cir;
        }

        /// <summary>
        /// The circles hashcode.
        /// </summary>
        /// <returns>The circles hashcode.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Center.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Radius.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Circle2f: Center={0}, Radius={1}]", Center, Radius);
        }

        /// <summary>
        /// Find the closest point to the circle.
        /// If point inside circle return point.
        /// </summary>
        public POINT2 Closest(POINT2 p)
        {
            POINT2 d = Center - p;
            if (d.SqrMagnitude <= Radius2) return p;
            return Center + Radius * d.Vector2d.Normalized;
        }

        /// <summary>
        /// Return the signed distance to the point. 
        /// If point is outside circle field is positive.
        /// If point is inside circle field is negative.
        /// </summary>
        public REAL SignedDistance(POINT2 p)
        {
            p = p - Center;
            return p.Magnitude - Radius;
        }

        /// <summary>
        /// Does the circle contain the point.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>true if circle contains point</returns>
        public bool Contains(POINT2 p)
        {
            return POINT2.SqrDistance(Center, p) <= Radius2;
        }

        /// <summary>
        /// Does the circle fully contain the box.
        /// </summary>
        public bool Contains(BOX2 box)
        {
            if (!Contains(box.Corner00)) return false;
            if (!Contains(box.Corner01)) return false;
            if (!Contains(box.Corner10)) return false;
            if (!Contains(box.Corner11)) return false;
            return true;
        }

        /// <summary>
        /// Does this circle intersect with the other circle.
        /// </summary>
        /// <param name="circle">The other circle</param>
        /// <returns>True if the circles intersect</returns>
        public bool Intersects(Circle2d circle)
        {
            REAL r = Radius + circle.Radius;
            return POINT2.SqrDistance(Center, circle.Center) <= r * r;
        }

        /// <summary>
        /// Does the circle intersect the box.
        /// </summary>
        public bool Intersects(BOX2 box)
        {
            var p = box.Closest(Center);
            return POINT2.SqrDistance(p, Center) <= Radius2;
        }

        /// <summary>
        /// Enlarge the circle so it contains the point p.
        /// </summary>
        public static Circle2d Enlarge(Circle2d cir, POINT2 p)
        {
            POINT2 d = p - cir.Center;
            REAL dist2 = d.SqrMagnitude;

            if (dist2 > cir.Radius2)
            {
                REAL dist = MathUtil.Sqrt(dist2);
                REAL radius = (cir.Radius + dist) * 0.5;
                REAL k = (radius - cir.Radius) / dist;

                cir.Center += d * k;
                cir.Radius = radius;
            }

            return cir;
        }

        /// <summary>
        /// Returns true if the point d is inside the circle defined by the points a, b, c.
        /// </summary>
        public static bool InCircle(POINT2 a, POINT2 b, POINT2 c, POINT2 d)
        {
            return (a.x * a.x + a.y * a.y) * Triangle2d.CrossProductArea(b, c, d) -
                    (b.x * b.x + b.y * b.y) * Triangle2d.CrossProductArea(a, c, d) +
                    (c.x * c.x + c.y * c.y) * Triangle2d.CrossProductArea(a, b, d) -
                    (d.x * d.x + d.y * d.y) * Triangle2d.CrossProductArea(a, b, c) > 0;
        }

        /// <summary>
        /// Creates a circle that has both points on its circumference.
        /// </summary>
        public static Circle2d CircumCircle(POINT2 p0, POINT2 p1)
        {
            var centre = (p0 + p1) * 0.5;
            var radius = POINT2.Distance(p0, p1) * 0.5;
            var bounds = new Circle2d(centre, radius);
            return bounds;
        }

        /// <summary>
        /// Creates a circle that has all 3 points on its circumference.
        /// From MathWorld: http://mathworld.wolfram.com/Circumcircle.html.
        /// Fails if the points are colinear.
        /// </summary>
        public static Circle2d CircumCircle(POINT2 p0, POINT2 p1, POINT2 p2)
        {
            var m = new MATRIX3();

            // x, y, 1
            m.SetRow(0, new VECTOR3(p0.x, p0.y, 1));
            m.SetRow(1, new VECTOR3(p1.x, p1.y, 1));
            m.SetRow(2, new VECTOR3(p2.x, p2.y, 1));
            REAL a = m.Determinant;

            // size, y, 1
            m.SetColumn(0, new VECTOR3(p0.SqrMagnitude, p1.SqrMagnitude, p2.SqrMagnitude));
            REAL dx = -m.Determinant;

            // size, x, 1
            m.SetColumn(1, new VECTOR3(p0.x, p1.x, p2.x));
            REAL dy = m.Determinant;

            // size, x, y
            m.SetColumn(2, new VECTOR3(p0.y, p1.y, p2.y));
            REAL c = -m.Determinant;

            REAL s = -1.0 / (2.0 * a);

            var circumCenter = new POINT2(s * dx, s * dy);
            REAL radius = Math.Abs(s) * MathUtil.Sqrt(dx * dx + dy * dy - 4.0 * a * c);

            return new Circle2d(circumCenter, radius);
        }

        /// <summary>
        /// Creates a circle that contains all three point.
        /// </summary>
        public static Circle2d CalculateBounds(POINT2 p0, POINT2 p1, POINT2 p2)
        {
            var bounds = CircumCircle(p0, p1);
            return Enlarge(bounds, p2);
        }

        /// <summary>
        /// Calculate the bounding circle that contains 
        /// all the points in the list.
        /// </summary>
        public static Circle2d CalculateBounds(IList<POINT2> points)
        {
            var idx = ExtremePoints(points);

            var bounds = CircumCircle(points[idx.x], points[idx.y]);

            int count = points.Count;
            for (int i = 2; i < count; i++)
                bounds = Enlarge(bounds, points[i]);

            return bounds;
        }

        /// <summary>
        /// Finds which axis contains the two most extreme points
        /// </summary>
        private static Point2i ExtremePoints(IList<POINT2> points)
        {
            Point2i min = new Point2i();
            Point2i max = new Point2i();

            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                var v = points[i];
                if (v.x < points[min.x].x) min.x = i;
                if (v.y < points[min.y].y) min.y = i;

                if (v.x > points[max.x].x) max.x = i;
                if (v.y > points[max.y].y) max.y = i;
            }

            var d2x = POINT2.SqrDistance(points[max.x], points[min.x]);
            var d2y = POINT2.SqrDistance(points[max.y], points[min.y]);

            if (d2x > d2y)
                return new Point2i(min.x, max.x);
            else
                return new Point2i(min.y, max.y);
        }
    }
}