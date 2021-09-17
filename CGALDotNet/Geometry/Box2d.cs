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
    public struct Box2d : IEquatable<Box2d>, IGeometry2d
    {

        /// <summary>
        /// The boxs min point.
        /// </summary>
        public Point2d Min;

        /// <summary>
        /// The boxs max point.
        /// </summary>
        public Point2d Max;

        /// <summary>
        /// Construct a box from a min and max value.
        /// </summary>
        /// <param name="min">The x,y min value.</param>
        /// <param name="max">The x,y max value.</param>
        public Box2d(double min, double max)
        {
            Min = new Point2d(min);
            Max = new Point2d(max);
        }

        /// <summary>
        /// Construct a box from a min and max values.
        /// </summary>
        /// <param name="minX">The x min value.</param>
        /// <param name="minY">The y min value.</param>
        /// <param name="maxX">The x max value.</param>
        /// <param name="maxY">The y max value.</param>
        public Box2d(double minX, double minY, double maxX, double maxY)
        {
            Min = new Point2d(minX, minY);
            Max = new Point2d(maxX, maxY);
        }

        /// <summary>
        /// Construct a box from a min and max points.
        /// </summary>
        /// <param name="min">The min point.</param>
        /// <param name="max">The max point.</param>
        public Box2d(Point2d min, Point2d max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// The boxes center point.
        /// </summary>
        public Point2d Center
        {
            get { return (Min + Max) * 0.5; }
        }

        /// <summary>
        /// The width and height of the box as a point.
        /// </summary>
        public Point2d Size
        {
            get { return new Point2d(Width, Height); }
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
        /// The area of the box.
        /// </summary>
        public double Area
        {
            get { return (Max.x - Min.x) * (Max.y - Min.y); }
        }

        public static Box2d operator +(Box2d box, double s)
        {
            return new Box2d(box.Min + s, box.Max + s);
        }

        public static Box2d operator +(Box2d box, Point2d v)
        {
            return new Box2d(box.Min + v, box.Max + v);
        }

        public static Box2d operator -(Box2d box, double s)
        {
            return new Box2d(box.Min - s, box.Max - s);
        }

        public static Box2d operator -(Box2d box, Point2d v)
        {
            return new Box2d(box.Min - v, box.Max - v);
        }

        public static Box2d operator *(Box2d box, double s)
        {
            return new Box2d(box.Min * s, box.Max * s);
        }

        public static Box2d operator /(Box2d box, double s)
        {
            return new Box2d(box.Min / s, box.Max / s);
        }

        public static bool operator ==(Box2d b1, Box2d b2)
        {
            return b1.Min == b2.Min && b1.Max == b2.Max;
        }

        public static bool operator !=(Box2d b1, Box2d b2)
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
            if (!(obj is Box2d)) return false;
            Box2d box = (Box2d)obj;
            return this == box;
        }

        /// <summary>
        /// Is the box equal to the other box.
        /// </summary>
        /// <param name="box">The other box to compare.</param>
        /// <returns>If the box and other box are equal.</returns>
        public bool Equals(Box2d box)
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
            return string.Format("[Box2d: Min={0}, Max={1}, Width={2}, Height={3}]", Min, Max, Width, Height);
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
        /// Transform the box by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix2x2d m)
        {
            Min = m * Min;
            Max = m * Max;
        }

        /// <summary>
        /// Transform the box by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix3x3d m)
        {
            Min = m * Min;
            Max = m * Max;
        }

        /// <summary>
        /// Transform the box by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        public void Transform(Matrix4x4d m)
        {
            Min = m * Min;
            Max = m * Max;
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
        /// Get the boxs corner vertices.
        /// </summary>
        /// <returns>The corner vertices.</returns>
        public Point2d[] GetCorners()
        {
            var corners = new Point2d[4];
            corners[0] = new Point2d(Min.x, Min.y);
            corners[1] = new Point2d(Max.x, Min.y);
            corners[2] = new Point2d(Max.x, Max.y);
            corners[3] = new Point2d(Min.x, Max.y);
            return corners;
        }

        /// <summary>
        /// Returns true if this box intersects the other box.
        /// </summary>
        /// <param name="a">The other box.</param>
        /// <returns>True if the boxes intersect.</returns>
        public bool Intersects(Box2d a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box
        /// </summary>
        /// <param name="a">The other box.</param>
        /// <returns>True if the box contains the box.</returns>
        public bool Contains(Box2d a)
        {
            if (a.Max.x > Max.x || a.Min.x < Min.x) return false;
            if (a.Max.y > Max.y || a.Min.y < Min.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the point.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns>True if the box contains the point.</returns>
        public bool Contains(Point2d p)
        {
            if (p.x > Max.x || p.x < Min.x) return false;
            if (p.y > Max.y || p.y < Min.y) return false;
            return true;
        }

        /// <summary>
        /// Find the closest point to the box.
        /// If point inside box return point.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns></returns>
        public Point2d Closest(Point2d p)
        {
            Point2d c;

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

            return c;
        }

        /// <summary>
        /// Find the min and max points and return the box.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>The bounding box.</returns>
        public static Box2d CalculateBounds(IList<Point2d> points)
        {
            Point2d min = Point2d.PositiveInfinity;
            Point2d max = Point2d.NegativeInfinity;

            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                var v = points[i];
                if (v.x < min.x) min.x = v.x;
                if (v.y < min.y) min.y = v.y;

                if (v.x > max.x) max.x = v.x;
                if (v.y > max.y) max.y = v.y;
            }

            return new Box2d(min, max);
        }

        /// <summary>
        /// Find the min and max of a and b and return the box.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <returns>The bounding box.</returns>
        public static Box2d CalculateBounds(Point2d a, Point2d b)
        {
            double xmin = Math.Min(a.x, b.x);
            double xmax = Math.Max(a.x, b.x);
            double ymin = Math.Min(a.y, b.y);
            double ymax = Math.Max(a.y, b.y);

            return new Box2d(xmin, ymin, xmax, ymax);
        }

        /// <summary>
        /// Find the min and max points of the segments and return the box.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <returns>The bounding box.</returns>
        public static Box2d CalculateBounds(IList<Segment2d> segments)
        {
            Point2d min = Point2d.PositiveInfinity;
            Point2d max = Point2d.NegativeInfinity;

            int count = segments.Count;
            for (int i = 0; i < count; i++)
            {
                var seg = segments[i];

                if (seg.A.x < min.x) min.x = seg.A.x;
                if (seg.A.y < min.y) min.y = seg.A.y;
                if (seg.B.x < min.x) min.x = seg.B.x;
                if (seg.B.y < min.y) min.y = seg.B.y;

                if (seg.A.x > max.x) max.x = seg.A.x;
                if (seg.A.y > max.y) max.y = seg.A.y;
                if (seg.B.x > max.x) max.x = seg.B.x;
                if (seg.B.y > max.y) max.y = seg.B.y;
            }

            return new Box2d(min, max);
        }

    }

}

















