using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Sphere3f : IEquatable<Sphere3f>
    {

        public Point3f Center;

        public float Radius;

        public Sphere3f(float x, float y, float z, float radius)
        {
            Center = new Point3f(x,y,z);
            Radius = radius;
        }

        public Sphere3f(Point3f center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// The squared radius.
        /// </summary>
        public float Radius2
        {
            get { return Radius * Radius; }
        }

        /// <summary>
        /// The spheres diameter.
        /// </summary>
        public float Diameter
        {
            get { return Radius * 2.0f; }
        }

        /// <summary>
        /// The spheres area.
        /// </summary>
        public float Area
        {
            get { return 4.0f / 3.0f * MathUtil.PI_32 * Radius * Radius * Radius; }
        }

        /// <summary>
        /// The spheres surface area.
        /// </summary>
        public float SurfaceArea
        {
            get { return 4.0f * MathUtil.PI_32 * Radius2; }
        }

        /// <summary>
        /// Calculate the bounding box.
        /// </summary>
        public Box3f Bounds
        {
            get
            {
                float xmin = Center.x - Radius;
                float xmax = Center.x + Radius;
                float ymin = Center.y - Radius;
                float ymax = Center.y + Radius;
                float zmin = Center.z - Radius;
                float zmax = Center.z + Radius;

                return new Box3f(xmin, xmax, ymin, ymax, zmin, zmax);
            }
        }

        public static bool operator ==(Sphere3f s1, Sphere3f s2)
        {
            return s1.Center == s2.Center && s1.Radius == s2.Radius;
        }

        public static bool operator !=(Sphere3f s1, Sphere3f s2)
        {
            return s1.Center != s2.Center || s1.Radius != s2.Radius;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Sphere3f)) return false;
            Sphere3f sphere = (Sphere3f)obj;
            return this == sphere;
        }

        public bool Equals(Sphere3f sphere)
        {
            return this == sphere;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Center.GetHashCode();
                hash = (hash * 16777619) ^ Radius.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("[Sphere3f: Center={0}, Radius={1}]", Center, Radius);
        }

        /// <summary>
        /// Enlarge the sphere so it contains the point p.
        /// </summary>
        public void Enlarge(Point3f p)
        {
            Point3f d = p - Center;
            float dist2 = d.SqrMagnitude;

            if (dist2 > Radius2)
            {
                float dist = MathUtil.Sqrt(dist2);
                float radius = (Radius + dist) * 0.5f;
                float k = (radius - Radius) / dist;

                Center += d * k;
                Radius = radius;
            }
        }

        /// <summary>
        /// Find the closest point to the sphere.
        /// If point inside sphere return point.
        /// </summary>
        public Point3f Closest(Point3f p)
        {
            Point3f d = Center - p;
            if (d.SqrMagnitude <= Radius2) return p;
            return Center + Radius * d.Vector3f.Normalized;
        }

        /// <summary>
        /// Return the signed distance to the point. 
        /// If point is outside sphere field is positive.
        /// If point is inside spher field is negative.
        /// </summary>
        public float SignedDistance(Point3f p)
        {
            p = p - Center;
            return p.Magnitude - Radius;
        }

        /// <summary>
        /// Does the sphere contain the point.
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>true if sphere contains point</returns>
        public bool Contains(Point3f p)
        {
            return Point3f.SqrDistance(Center, p) <= Radius2;
        }

        /// <summary>
        /// Does the sphere fully contain the box.
        /// </summary>
        public bool Contains(Box3f box)
        {
            if (!Contains(new Point3f(box.Min.x, box.Min.y, box.Min.z))) return false;
            if (!Contains(new Point3f(box.Max.x, box.Min.y, box.Min.z))) return false;
            if (!Contains(new Point3f(box.Max.x, box.Min.y, box.Max.z))) return false;
            if (!Contains(new Point3f(box.Min.x, box.Min.y, box.Max.z))) return false;
            if (!Contains(new Point3f(box.Min.x, box.Max.y, box.Min.z))) return false;
            if (!Contains(new Point3f(box.Max.x, box.Max.y, box.Min.z))) return false;
            if (!Contains(new Point3f(box.Max.x, box.Max.y, box.Max.z))) return false;
            if (!Contains(new Point3f(box.Min.x, box.Max.y, box.Max.z))) return false;
            return true;
        }

        /// <summary>
        /// Does this sphere intersect with the other sphere.
        /// </summary>
        /// <param name="sphere">The other sphere</param>
        /// <returns>True if the spheres intersect</returns>
        public bool Intersects(Sphere3f sphere)
        {
            float r = Radius + sphere.Radius;
            return Point3f.SqrDistance(Center, sphere.Center) <= r * r;
        }

        /// <summary>
        /// Does the sphere intersect the box.
        /// </summary>
        public bool Intersects(Box3f box)
        {
            var p = box.Closest(Center);
            return Point3f.SqrDistance(p, Center) <= Radius2;
        }

        /// <summary>
        /// Creates a sphere that has both points on its surface.
        /// </summary>
        public static Sphere3f CircumSphere(Point3f p0, Point3f p1)
        {
            var centre = (p0 + p1) * 0.5f;
            var radius = Point3f.Distance(p0, p1) * 0.5f;
            var bounds = new Sphere3f(centre, radius);
            return bounds;
        }

        /// <summary>
        /// Creates a sphere that has all 4 points on its surface.
        /// From MathWorld: http://mathworld.wolfram.com/Circumsphere.html.
        /// Fails if the points are colinear.
        /// </summary>
        public static Sphere3f CircumSphere(Point3f p0, Point3f p1, Point3f p2, Point3f p3)
        {
            var m = new Matrix4x4f();

            // x, y, z, 1
            m.SetRow(0, new Vector4f(p0.Vector3f, 1));
            m.SetRow(1, new Vector4f(p1.Vector3f, 1));
            m.SetRow(2, new Vector4f(p2.Vector3f, 1));
            m.SetRow(3, new Vector4f(p3.Vector3f, 1));
            float a = m.Determinant;

            // size, y, z, 1
            m.SetColumn(0, new Vector4f(p0.SqrMagnitude, p1.SqrMagnitude, p2.SqrMagnitude, p3.SqrMagnitude));
            float dx = m.Determinant;

            // size, x, z, 1
            m.SetColumn(1, new Vector4f(p0.x, p1.x, p2.x, p3.x));
            float dy = -m.Determinant;

            // size, x, y, 1
            m.SetColumn(2, new Vector4f(p0.y, p1.y, p2.y, p3.y));
            float dz = m.Determinant;

            // size, x, y, z
            m.SetColumn(3, new Vector4f(p0.z, p1.z, p2.z, p3.z));
            float c = m.Determinant;

            float s = -1.0f / (2.0f * a);

            var circumCenter = new Point3f(s * dx, s * dy, s * dz);
            float radius = Math.Abs(s) * MathUtil.Sqrt(dx * dx + dy * dy + dz * dz - 4.0f * a * c);

            return new Sphere3f(circumCenter, radius);
        }

        /// <summary>
        /// Creates a sphere that contains all three points.
        /// </summary>
        public static Sphere3f CalculateBounds(Point3f p0, Point3f p1, Point3f p2)
        {
            var bounds = CircumSphere(p0, p1);
            bounds.Enlarge(p2);
            return bounds;
        }

        /// <summary>
        /// Calculate the minimum bounding sphere that contains 
        /// all the points in the list.
        /// </summary>
        public static Sphere3f CalculateBounds(IList<Point3f> points)
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
        private static Point2i ExtremePoints(IList<Point3f> points)
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

            var d2x = Point3f.SqrDistance(points[max.x], points[min.x]);
            var d2y = Point3f.SqrDistance(points[max.y], points[min.y]);
            var d2z = Point3f.SqrDistance(points[max.z], points[min.z]);

            if (d2x > d2y && d2x > d2z)
                return new Point2i(min.x, max.x);
            else if (d2y > d2z)
                return new Point2i(min.y, max.y);
            else
                return new Point2i(min.z, max.z);
        }

    }

}