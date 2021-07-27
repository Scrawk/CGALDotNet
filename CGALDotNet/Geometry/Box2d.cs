using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Box2d : IEquatable<Box2d>
    {

        public Point2d Min;

        public Point2d Max;

        public Box2d(double min, double max)
        {
            Min = new Point2d(min);
            Max = new Point2d(max);
        }

        public Box2d(double minX, double minY, double maxX, double maxY)
        {
            Min = new Point2d(minX, minY);
            Max = new Point2d(maxX, maxY);
        }

        public Box2d(Point2d min, Point2d max)
        {
            Min = min;
            Max = max;
        }

        public Point2d Center
        {
            get { return (Min + Max) * 0.5; }
        }

        public Point2d Size
        {
            get { return new Point2d(Width, Height); }
        }

        public double Width
        {
            get { return Max.x - Min.x; }
        }

        public double Height
        {
            get { return Max.y - Min.y; }
        }

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

        public override bool Equals(object obj)
        {
            if (!(obj is Box2d)) return false;
            Box2d box = (Box2d)obj;
            return this == box;
        }

        public bool Equals(Box2d box)
        {
            return this == box;
        }

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

        public override string ToString()
        {
            return string.Format("[Box2d: Min={0}, Max={1}, Width={2}, Height={3}]", Min, Max, Width, Height);
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
        /// Returns true if this box intersects the other box.
        /// </summary>
        public bool Intersects(Box2d a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box.
        /// </summary>
        public bool Contains(Box2d a)
        {
            if (a.Max.x > Max.x || a.Min.x < Min.x) return false;
            if (a.Max.y > Max.y || a.Min.y < Min.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the point.
        /// </summary>
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

        public static Box2d CalculateBounds(IList<Point2d> vertices)
        {
            Point2d min = Point2d.PositiveInfinity;
            Point2d max = Point2d.NegativeInfinity;

            int count = vertices.Count;
            for (int i = 0; i < count; i++)
            {
                var v = vertices[i];
                if (v.x < min.x) min.x = v.x;
                if (v.y < min.y) min.y = v.y;

                if (v.x > max.x) max.x = v.x;
                if (v.y > max.y) max.y = v.y;
            }

            return new Box2d(min, max);
        }

        public static Box2d CalculateBounds(Point2d a, Point2d b)
        {
            double xmin = Math.Min(a.x, b.x);
            double xmax = Math.Max(a.x, b.x);
            double ymin = Math.Min(a.y, b.y);
            double ymax = Math.Max(a.y, b.y);

            return new Box2d(xmin, ymin, xmax, ymax);
        }

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

















