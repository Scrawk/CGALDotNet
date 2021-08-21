using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGeom2D.Numerics;
using CGeom2D.Points;

using REAL = CGeom2D.Numerics.Int128;
using POINT2 = CGeom2D.Points.Point2i;

namespace CGeom2D.Geometry
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Box2i : IEquatable<Box2i>
    {

        public POINT2 Min;

        public POINT2 Max;

        public Box2i(REAL min, REAL max)
        {
            Min = new POINT2(min);
            Max = new POINT2(max);
        }

        public Box2i(REAL minX, REAL minY, REAL maxX, REAL maxY)
        {
            Min = new POINT2(minX, minY);
            Max = new POINT2(maxX, maxY);
        }

        public Box2i(POINT2 min, POINT2 max)
        {
            Min = min;
            Max = max;
        }

        public POINT2 Size
        {
            get { return new POINT2(Width, Height); }
        }

        public REAL Width
        {
            get { return Max.x - Min.x; }
        }

        public REAL Height
        {
            get { return Max.y - Min.y; }
        }

        public REAL Area
        {
            get { return (Max.x - Min.x) * (Max.y - Min.y); }
        }

        public static Box2i operator +(Box2i box, REAL s)
        {
            return new Box2i(box.Min + s, box.Max + s);
        }

        public static Box2i operator +(Box2i box, POINT2 v)
        {
            return new Box2i(box.Min + v, box.Max + v);
        }

        public static Box2i operator -(Box2i box, REAL s)
        {
            return new Box2i(box.Min - s, box.Max - s);
        }

        public static Box2i operator -(Box2i box, POINT2 v)
        {
            return new Box2i(box.Min - v, box.Max - v);
        }

        public static Box2i operator *(Box2i box, REAL s)
        {
            return new Box2i(box.Min * s, box.Max * s);
        }

        public static Box2i operator /(Box2i box, REAL s)
        {
            return new Box2i(box.Min / s, box.Max / s);
        }

        public static bool operator ==(Box2i b1, Box2i b2)
        {
            return b1.Min == b2.Min && b1.Max == b2.Max;
        }

        public static bool operator !=(Box2i b1, Box2i b2)
        {
            return b1.Min != b2.Min || b1.Max != b2.Max;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Box2i)) return false;
            Box2i box = (Box2i)obj;
            return this == box;
        }

        public bool Equals(Box2i box)
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
            return string.Format("[Box2i: Min={0}, Max={1}, Width={2}, Height={3}]", Min, Max, Width, Height);
        }

        /// <summary>
        /// Get the boxs corner vertices.
        /// </summary>
        /// <returns>The corner vertices.</returns>
        public POINT2[] GetCorners()
        {
            var corners = new POINT2[4];
            corners[0] = new POINT2(Min.x, Min.y);
            corners[1] = new POINT2(Max.x, Min.y);
            corners[2] = new POINT2(Max.x, Max.y);
            corners[3] = new POINT2(Min.x, Max.y);
            return corners;
        }

        /// <summary>
        /// Returns true if this box intersects the other box.
        /// </summary>
        public bool Intersects(Box2i a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box.
        /// </summary>
        public bool Contains(Box2i a)
        {
            if (a.Max.x > Max.x || a.Min.x < Min.x) return false;
            if (a.Max.y > Max.y || a.Min.y < Min.y) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the point.
        /// </summary>
        public bool Contains(POINT2 p)
        {
            if (p.x > Max.x || p.x < Min.x) return false;
            if (p.y > Max.y || p.y < Min.y) return false;
            return true;
        }

        /// <summary>
        /// Find the closest point to the box.
        /// If point inside box return point.
        /// </summary>
        public POINT2 Closest(POINT2 p)
        {
            POINT2 c;

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

        public static Box2i CalculateBounds(IList<POINT2> points)
        {
            POINT2 min = POINT2.MaxValue;
            POINT2 max = POINT2.MinValue;

            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                var v = points[i];
                if (v.x < min.x) min.x = v.x;
                if (v.y < min.y) min.y = v.y;

                if (v.x > max.x) max.x = v.x;
                if (v.y > max.y) max.y = v.y;
            }

            return new Box2i(min, max);
        }

        public static Box2i CalculateBounds(IList<Segment2i> segments)
        {
            POINT2 min = POINT2.MaxValue;
            POINT2 max = POINT2.MinValue;

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

            return new Box2i(min, max);
        }

    }

}

















