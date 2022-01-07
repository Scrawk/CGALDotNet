using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Box struct defined by a min and max point.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Box3d : IEquatable<Box3d>
    {

        /// <summary>
        /// The boxs min point.
        /// </summary>
        public Point3d Min;

        /// <summary>
        /// The boxs max point.
        /// </summary>
        public Point3d Max;

        /// <summary>
        /// Construct a box from a min and max value.
        /// </summary>
        /// <param name="min">The x,y min value.</param>
        /// <param name="max">The x,y max value.</param>
        public Box3d(double min, double max)
        {
            Min = new Point3d(min);
            Max = new Point3d(max);
        }

        /// <summary>
        /// Construct a box from a min and max values.
        /// </summary>
        /// <param name="minX">The x min value.</param>
        /// <param name="minY">The y min value.</param>
        /// <param name="minZ">The z min value.</param>
        /// <param name="maxX">The x max value.</param>
        /// <param name="maxY">The y max value.</param>
        /// <param name="maxZ">The z max value.</param>
        public Box3d(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            Min = new Point3d(minX, minY, minZ);
            Max = new Point3d(maxX, maxY, maxZ);
        }

        /// <summary>
        /// Construct a box from a min and max points.
        /// </summary>
        /// <param name="min">The min point.</param>
        /// <param name="max">The max point.</param>
        public Box3d(Point3d min, Point3d max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// The boxes center point.
        /// </summary>
        public Point3d Center
        {
            get { return (Min + Max) * 0.5; }
        }

        /// <summary>
        /// The width and height of the box as a point.
        /// </summary>
        public Point3d Size
        {
            get { return new Point3d(Width, Height, Depth); }
        }

        /// <summary>
        /// The boxs width.
        /// </summary>
        public double Width
        {
            get { return Max.x - Min.x; }
        }

        /// <summary>
        /// The boxs height.
        /// </summary>
        public double Height
        {
            get { return Max.y - Min.y; }
        }


        /// <summary>
        /// The boxs depth.
        /// </summary>
        public double Depth
        {
            get { return Max.z - Min.z; }
        }

        /// <summary>
        /// The area of the box.
        /// </summary>
        public double Area
        {
            get { return (Max.x - Min.x) * (Max.y - Min.y) * (Max.z - Min.z); }
        }

        public static Box3d operator +(Box3d box, double s)
        {
            return new Box3d(box.Min + s, box.Max + s);
        }

        public static Box3d operator +(Box3d box, Point3d v)
        {
            return new Box3d(box.Min + v, box.Max + v);
        }

        public static Box3d operator -(Box3d box, double s)
        {
            return new Box3d(box.Min - s, box.Max - s);
        }

        public static Box3d operator -(Box3d box, Point3d v)
        {
            return new Box3d(box.Min - v, box.Max - v);
        }

        public static Box3d operator *(Box3d box, double s)
        {
            return new Box3d(box.Min * s, box.Max * s);
        }

        public static Box3d operator /(Box3d box, double s)
        {
            return new Box3d(box.Min / s, box.Max / s);
        }

        public static bool operator ==(Box3d b1, Box3d b2)
        {
            return b1.Min == b2.Min && b1.Max == b2.Max;
        }

        public static bool operator !=(Box3d b1, Box3d b2)
        {
            return b1.Min != b2.Min || b1.Max != b2.Max;
        }

        /// <summary>
        /// Is the box equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>If the box and object are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Box3d)) return false;
            Box3d box = (Box3d)obj;
            return this == box;
        }

        /// <summary>
        /// Is the box equal to the other box.
        /// </summary>
        /// <param name="box">The other box to compare.</param>
        /// <returns>If the box and other box are equal.</returns>
        public bool Equals(Box3d box)
        {
            return this == box;
        }

        /// <summary>
        /// The boxes hashcode.
        /// </summary>
        /// <returns>The boxes hashcode.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Min.GetHashCode();
                hash = (hash * 16777619) ^ Max.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The box as a string.
        /// </summary>
        /// <returns>The box as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Box3d: Min={0}, Max={1}, Width={2}, Height={3}]", Min, Max, Width, Height);
        }

        /// <summary>
        /// Round the boxs min and max values.
        /// </summary>
        /// <param name="digits">number of digits to round to.</param>
        public void Round(int digits)
        {
            Min = Min.Rounded(digits);
            Max = Max.Rounded(digits);
        }

        /// <summary>
        /// Returns true if this box intersects the other box.
        /// </summary>
        /// <param name="a">The other box.</param>
        /// <returns>True if the boxes intersect.</returns>
        public bool Intersects(Box3d a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            if (Max.z < a.Min.z || Min.z > a.Max.z) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box
        /// </summary>
        /// <param name="a">The other box.</param>
        /// <returns>True if the box contains the box.</returns>
        public bool Contains(Box3d a)
        {
            if (a.Max.x > Max.x || a.Min.x < Min.x) return false;
            if (a.Max.y > Max.y || a.Min.y < Min.y) return false;
            if (a.Max.z > Max.z || a.Min.z < Min.z) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the point.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns>True if the box contains the point.</returns>
        public bool Contains(Point3d p)
        {
            if (p.x > Max.x || p.x < Min.x) return false;
            if (p.y > Max.y || p.y < Min.y) return false;
            if (p.z > Max.z || p.z < Min.z) return false;
            return true;
        }

        /// <summary>
        /// Find the closest point to the box.
        /// If point inside box return point.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns></returns>
        public Point3d Closest(Point3d p)
        {
            Point3d c;

            if (p.x < Min.x)
                c.x = Min.x;
            else if (p.x > Max.x)
                c.x = Max.x;
            else
                c.x = p.x;

            if (p.y < Min.y)
                c.y = Min.y;
            else if (p.y > Max.y)
                c.y = Max.y;
            else
                c.y = p.y;

            if (p.z < Min.z)
                c.z = Min.z;
            else if (p.z > Max.z)
                c.z = Max.z;
            else
                c.z = p.z;

            return c;
        }

        /// <summary>
        /// Find the min and max points and return the box.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>The bounding box.</returns>
        public static Box3d CalculateBounds(IList<Point3d> points)
        {
            Point3d min = Point3d.PositiveInfinity;
            Point3d max = Point3d.NegativeInfinity;

            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                var v = points[i];
                if (v.x < min.x) min.x = v.x;
                if (v.y < min.y) min.y = v.y;
                if (v.z < min.z) min.z = v.z;

                if (v.x > max.x) max.x = v.x;
                if (v.y > max.y) max.y = v.y;
                if (v.z > max.z) max.z = v.z;

            }

            return new Box3d(min, max);
        }

        /// <summary>
        /// Find the min and max of a and b and return the box.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <returns>The bounding box.</returns>
        public static Box3d CalculateBounds(Point3d a, Point3d b)
        {
            double xmin = Math.Min(a.x, b.x);
            double xmax = Math.Max(a.x, b.x);
            double ymin = Math.Min(a.y, b.y);
            double ymax = Math.Max(a.y, b.y);
            double zmin = Math.Min(a.z, b.z);
            double zmax = Math.Max(a.z, b.z);

            return new Box3d(xmin, ymin, zmin, xmax, ymax, zmax);
        }

        /*
        public Plane3d[] GetPlanes()
        {
            var center = Center;
            var half = Size * 0.5;

            var planes = new Plane3d[6];

            planes[0] = new Plane3d(center - new Point3d(half.x, 0, 0), new Vector3d(1, 0, 0));
            planes[1] = new Plane3d(center + new Point3d(half.x, 0, 0), new Vector3d(-1, 0, 0));

            planes[2] = new Plane3d(center - new Point3d(0, half.y, 0), new Vector3d(0, 1, 0));
            planes[3] = new Plane3d(center + new Point3d(0, half.y, 0), new Vector3d(0, -1, 0));

            planes[4] = new Plane3d(center - new Point3d(0, 0, half.z), new Vector3d(0, 0, 1));
            planes[5] = new Plane3d(center + new Point3d(0, 0, half.z), new Vector3d(0, 0, -1));

            return planes;
        }
        */
    }

}

















