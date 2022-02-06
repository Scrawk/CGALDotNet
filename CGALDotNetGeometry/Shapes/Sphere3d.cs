using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Double;
using POINT3 = CGALDotNetGeometry.Numerics.Point3d;
using VECTOR4 = CGALDotNetGeometry.Numerics.Vector4d;
using MATRIX4 = CGALDotNetGeometry.Numerics.Matrix4x4d;
using BOX3 = CGALDotNetGeometry.Shapes.Box3d;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 3D sphere.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Sphere3d : IEquatable<Sphere3d>
    {

        /// <summary>
        /// The shperes center point.
        /// </summary>
        public POINT3 Center;

        /// <summary>
        /// The spheres radius.
        /// </summary>
        public REAL Radius;

        /// <summary>
        /// Construct a new sphere.
        /// </summary>
        /// <param name="center">The shperes center point.</param>
        /// <param name="radius">The spheres radius.</param>
        public Sphere3d(POINT3 center, REAL radius)
        {
            Center = center;
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
        /// The spheres diameter.
        /// </summary>
        public REAL Diameter
        {
            get { return Radius * 2.0f; }
        }

        /// <summary>
        /// The spheres area.
        /// </summary>
        public REAL Area
        {
            get { return 4.0f / 3.0f * MathUtil.PI_32 * Radius * Radius * Radius; }
        }

        /// <summary>
        /// The spheres surface area.
        /// </summary>
        public REAL SurfaceArea
        {
            get { return 4.0f * MathUtil.PI_32 * Radius2; }
        }

        /// <summary>
        /// Calculate the bounding box.
        /// </summary>
        public BOX3 Bounds
        {
            get
            {
                REAL xmin = Center.x - Radius;
                REAL xmax = Center.x + Radius;
                REAL ymin = Center.y - Radius;
                REAL ymax = Center.y + Radius;
                REAL zmin = Center.z - Radius;
                REAL zmax = Center.z + Radius;

                var min = new POINT3(xmin, ymin, zmin);
                var max = new POINT3(xmax, ymax, zmax);

                return new BOX3(min, max);
            }
        }

        public static bool operator ==(Sphere3d s1, Sphere3d s2)
        {
            return s1.Center == s2.Center && s1.Radius == s2.Radius;
        }

        public static bool operator !=(Sphere3d s1, Sphere3d s2)
        {
            return s1.Center != s2.Center || s1.Radius != s2.Radius;
        }

        /// <summary>
        /// Is this sphere equal to the other object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>Is this sphere equal to the other object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Sphere3d)) return false;
            Sphere3d sphere = (Sphere3d)obj;
            return this == sphere;
        }

        /// <summary>
        /// Is this sphere equal to the other sphere.
        /// </summary>
        /// <param name="obj">The other sphere.</param>
        /// <returns>Is this sphere equal to the other sphere.</returns>
        public bool Equals(Sphere3d sphere)
        {
            return this == sphere;
        }

        /// <summary>
        /// The spheres hashcode.
        /// </summary>
        /// <returns>The spheres hashcode.</returns>
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
            return string.Format("[Sphere3d: Center={0}, Radius={1}]", Center, Radius);
        }

        /// <summary>
        /// Enlarge the sphere so it contains the point p.
        /// </summary>
        public void Enlarge(POINT3 p)
        {
            POINT3 d = p - Center;
            REAL dist2 = d.SqrMagnitude;

            if (dist2 > Radius2)
            {
                REAL dist = MathUtil.Sqrt(dist2);
                REAL radius = (Radius + dist) * 0.5f;
                REAL k = (radius - Radius) / dist;

                Center += d * k;
                Radius = radius;
            }
        }

        /// <summary>
        /// Round the spheres components.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            Center.Round(digits);
            Radius = MathUtil.Round(Radius, digits);
        }

        /// <summary>
        /// Find the closest point to the sphere.
        /// If point inside sphere return point.
        /// </summary>
        public POINT3 Closest(POINT3 p)
        {
            POINT3 d = Center - p;
            if (d.SqrMagnitude <= Radius2) return p;
            return Center + Radius * d.Vector3d.Normalized;
        }

        /// <summary>
        /// Return the signed distance to the point. 
        /// If point is outside sphere field is positive.
        /// If point is inside spher field is negative.
        /// </summary>
        public REAL SignedDistance(POINT3 p)
        {
            p = p - Center;
            return p.Magnitude - Radius;
        }

        /// <summary>
        /// Does the sphere contain the point.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>true if sphere contains point</returns>
        public bool Contains(POINT3 p)
        {
            return POINT3.SqrDistance(Center, p) <= Radius2;
        }

        /// <summary>
        /// Does the sphere fully contain the box.
        /// </summary>
        public bool Contains(BOX3 box)
        {
            if (!Contains(new POINT3(box.Min.x, box.Min.y, box.Min.z))) return false;
            if (!Contains(new POINT3(box.Max.x, box.Min.y, box.Min.z))) return false;
            if (!Contains(new POINT3(box.Max.x, box.Min.y, box.Max.z))) return false;
            if (!Contains(new POINT3(box.Min.x, box.Min.y, box.Max.z))) return false;
            if (!Contains(new POINT3(box.Min.x, box.Max.y, box.Min.z))) return false;
            if (!Contains(new POINT3(box.Max.x, box.Max.y, box.Min.z))) return false;
            if (!Contains(new POINT3(box.Max.x, box.Max.y, box.Max.z))) return false;
            if (!Contains(new POINT3(box.Min.x, box.Max.y, box.Max.z))) return false;
            return true;
        }

        /// <summary>
        /// Does this sphere intersect with the other sphere.
        /// </summary>
        /// <param name="sphere">The other sphere</param>
        /// <returns>True if the spheres intersect</returns>
        public bool Intersects(Sphere3d sphere)
        {
            REAL r = Radius + sphere.Radius;
            return POINT3.SqrDistance(Center, sphere.Center) <= r * r;
        }

        /// <summary>
        /// Does the sphere intersect the box.
        /// </summary>
        public bool Intersects(BOX3 box)
        {
            var p = box.Closest(Center);
            return POINT3.SqrDistance(p, Center) <= Radius2;
        }

        /// <summary>
        /// Creates a sphere that has both points on its surface.
        /// </summary>
        public static Sphere3d CircumSphere(POINT3 p0, POINT3 p1)
        {
            var centre = (p0 + p1) * 0.5f;
            var radius = POINT3.Distance(p0, p1) * 0.5f;
            var bounds = new Sphere3d(centre, radius);
            return bounds;
        }

        /// <summary>
        /// Creates a sphere that has all 4 points on its surface.
        /// From MathWorld: http://mathworld.wolfram.com/Circumsphere.html.
        /// Fails if the points are colinear.
        /// </summary>
        public static Sphere3d CircumSphere(POINT3 p0, POINT3 p1, POINT3 p2, POINT3 p3)
        {
            var m = new MATRIX4();

            // x, y, z, 1
            m.SetRow(0, new VECTOR4(p0.Vector3d, 1));
            m.SetRow(1, new VECTOR4(p1.Vector3d, 1));
            m.SetRow(2, new VECTOR4(p2.Vector3d, 1));
            m.SetRow(3, new VECTOR4(p3.Vector3d, 1));
            REAL a = m.Determinant;

            // size, y, z, 1
            m.SetColumn(0, new VECTOR4(p0.SqrMagnitude, p1.SqrMagnitude, p2.SqrMagnitude, p3.SqrMagnitude));
            REAL dx = m.Determinant;

            // size, x, z, 1
            m.SetColumn(1, new VECTOR4(p0.x, p1.x, p2.x, p3.x));
            REAL dy = -m.Determinant;

            // size, x, y, 1
            m.SetColumn(2, new VECTOR4(p0.y, p1.y, p2.y, p3.y));
            REAL dz = m.Determinant;

            // size, x, y, z
            m.SetColumn(3, new VECTOR4(p0.z, p1.z, p2.z, p3.z));
            REAL c = m.Determinant;

            REAL s = -1.0f / (2.0f * a);

            var circumCenter = new POINT3(s * dx, s * dy, s * dz);
            REAL radius = Math.Abs(s) * MathUtil.Sqrt(dx * dx + dy * dy + dz * dz - 4.0f * a * c);

            return new Sphere3d(circumCenter, radius);
        }

        /// <summary>
        /// Creates a sphere that contains all three points.
        /// </summary>
        public static Sphere3d CalculateBounds(POINT3 p0, POINT3 p1, POINT3 p2)
        {
            var bounds = CircumSphere(p0, p1);
            bounds.Enlarge(p2);
            return bounds;
        }

        /// <summary>
        /// Calculate the minimum bounding sphere that contains 
        /// all the points in the list.
        /// </summary>
        public static Sphere3d CalculateBounds(IList<POINT3> points)
        {
            var idx = ExtremePoints(points);

            var bounds = CircumSphere(points[idx.x], points[idx.y]);

            int count = points.Count;
            for (int i = 2; i < count; i++)
                bounds.Enlarge(points[i]);

            return bounds;
        }

        /// <summary>
        /// Finds which axis contains the two most extreme points
        /// </summary>
        private static Point2i ExtremePoints(IList<POINT3> points)
        {
            Point3i min = new Point3i();
            Point3i max = new Point3i();

            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                var v = points[i];
                if (v.x < points[min.x].x) min.x = i;
                if (v.y < points[min.y].y) min.y = i;
                if (v.z < points[min.z].z) min.z = i;

                if (v.x > points[max.x].x) max.x = i;
                if (v.y > points[max.y].y) max.y = i;
                if (v.z > points[max.z].z) max.z = i;
            }

            var d2x = POINT3.SqrDistance(points[max.x], points[min.x]);
            var d2y = POINT3.SqrDistance(points[max.y], points[min.y]);
            var d2z = POINT3.SqrDistance(points[max.z], points[min.z]);

            if (d2x > d2y && d2x > d2z)
                return new Point2i(min.x, max.x);
            else if (d2y > d2z)
                return new Point2i(min.y, max.y);
            else
                return new Point2i(min.z, max.z);
        }

    }

}