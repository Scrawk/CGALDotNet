using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Single;
using POINT3 = CGALDotNetGeometry.Numerics.Point3f;
using POINT4 = CGALDotNetGeometry.Numerics.Point4f;
using MATRIX3 = CGALDotNetGeometry.Numerics.Matrix3x3f;

namespace CGALDotNetGeometry.Shapes
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Box3f : IEquatable<Box3f>
    {

        public POINT3 Min;

        public POINT3 Max;

        public Box3f(REAL min, REAL max)
        {
            Min = new POINT3(min);
            Max = new POINT3(max);
        }

        public Box3f(REAL minX, REAL maxX, REAL minY, REAL maxY, REAL minZ, REAL maxZ)
        {
            Min = new POINT3(minX, minY, minZ);
            Max = new POINT3(maxX, maxY, maxZ);
        }

        public Box3f(POINT3 min, POINT3 max)
        {
            Min = min;
            Max = max;
        }

        public POINT3 Center
        {
            get { return (Min + Max) * 0.5f; }
        }

        public POINT3 Size
        {
            get { return new POINT3(Width, Height, Depth); }
        }

        public REAL Width
        {
            get { return Max.x - Min.x; }
        }

        public REAL Height
        {
            get { return Max.y - Min.y; }
        }

        public REAL Depth
        {
            get { return Max.z - Min.z; }
        }

        public REAL Area
        {
            get
            {
                return (Max.x - Min.x) * (Max.y - Min.y) * (Max.z - Min.z);
            }
        }

        public REAL SurfaceArea
        {
            get
            {
                POINT3 d = Max - Min;
                return 2.0f * (d.x * d.y + d.x * d.z + d.y * d.z);
            }
        }

        public Box3f Bounds => this;

        public static Box3f operator +(Box3f box, REAL s)
        {
            return new Box3f(box.Min + s, box.Max + s);
        }

        public static Box3f operator +(Box3f box, POINT3 v)
        {
            return new Box3f(box.Min + v, box.Max + v);
        }

        public static Box3f operator -(Box3f box, REAL s)
        {
            return new Box3f(box.Min - s, box.Max - s);
        }

        public static Box3f operator -(Box3f box, POINT3 v)
        {
            return new Box3f(box.Min - v, box.Max - v);
        }

        public static Box3f operator *(Box3f box, REAL s)
        {
            return new Box3f(box.Min * s, box.Max * s);
        }

        public static Box3f operator /(Box3f box, REAL s)
        {
            return new Box3f(box.Min / s, box.Max / s);
        }

        public static Box3f operator *(Box3f box, MATRIX3 m)
        {
            return new Box3f(m * box.Min, m * box.Max);
        }

        public static bool operator ==(Box3f b1, Box3f b2)
        {
            return b1.Min == b2.Min && b1.Max == b2.Max;
        }

        public static bool operator !=(Box3f b1, Box3f b2)
        {
            return b1.Min != b2.Min || b1.Max != b2.Max;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Box3f)) return false;
            Box3f box = (Box3f)obj;
            return this == box;
        }

        public bool Equals(Box3f box)
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
            return string.Format("[Box3f: Min={0}, Max={1}, Width={2}, Height={3}, Depth={4}]", Min, Max, Width, Height, Depth);
        }

        public void GetCorners(IList<POINT3> corners)
        {
            corners[0] = new POINT3(Min.x, Min.y, Min.z);
            corners[1] = new POINT3(Max.x, Min.y, Min.z);
            corners[2] = new POINT3(Max.x, Min.y, Max.z);
            corners[3] = new POINT3(Min.x, Min.y, Max.z);

            corners[4] = new POINT3(Min.x, Max.y, Min.z);
            corners[5] = new POINT3(Max.x, Max.y, Min.z);
            corners[6] = new POINT3(Max.x, Max.y, Max.z);
            corners[7] = new POINT3(Min.x, Max.y, Max.z);
        }

        public void GetCorners(IList<POINT4> corners)
        {
            corners[0] = new POINT4(Min.x, Min.y, Min.z, 1);
            corners[1] = new POINT4(Max.x, Min.y, Min.z, 1);
            corners[2] = new POINT4(Max.x, Min.y, Max.z, 1);
            corners[3] = new POINT4(Min.x, Min.y, Max.z, 1);

            corners[4] = new POINT4(Min.x, Max.y, Min.z, 1);
            corners[5] = new POINT4(Max.x, Max.y, Min.z, 1);
            corners[6] = new POINT4(Max.x, Max.y, Max.z, 1);
            corners[7] = new POINT4(Min.x, Max.y, Max.z, 1);
        }

        /// <summary>
        /// Returns the bounding box containing this box and the given point.
        /// </summary>
        public static Box3f Enlarge(Box3f box, POINT3 p)
        {
            var b = new Box3f();
            b.Min.x = Math.Min(box.Min.x, p.x);
            b.Min.y = Math.Min(box.Min.y, p.y);
            b.Min.z = Math.Min(box.Min.z, p.z);
            b.Max.x = Math.Max(box.Max.x, p.x);
            b.Max.y = Math.Max(box.Max.y, p.y);
            b.Max.z = Math.Max(box.Max.z, p.z);
            return b;
        }

        /// <summary>
        /// Returns the bounding box containing this box and the given box.
        /// </summary>
        public static Box3f Enlarge(Box3f box0, Box3f box1)
        {
            var b = new Box3f();
            b.Min.x = Math.Min(box0.Min.x, box1.Min.x);
            b.Min.y = Math.Min(box0.Min.y, box1.Min.y);
            b.Min.z = Math.Min(box0.Min.z, box1.Min.z);
            b.Max.x = Math.Max(box0.Max.x, box1.Max.x);
            b.Max.y = Math.Max(box0.Max.y, box1.Max.y);
            b.Max.z = Math.Max(box0.Max.z, box1.Max.z);
            return b;
        }

        /// <summary>
        /// Return a new box expanded by the amount.
        /// </summary>
        /// <param name="box">The box to expand.</param>
        /// <param name="amount">The amount to expand.</param>
        /// <returns>The expanded box.</returns>
        public static Box3f Expand(Box3f box, REAL amount)
        {
            return new Box3f(box.Min - amount, box.Max + amount);
        }

        /// <summary>
        /// Returns true if this box intersects the other box.
        /// </summary>
        public bool Intersects(Box3f a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            if (Max.z < a.Min.z || Min.z > a.Max.z) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box.
        /// </summary>
        public bool Contains(Box3f a)
        {
            if (a.Max.x > Max.x || a.Min.x < Min.x) return false;
            if (a.Max.y > Max.y || a.Min.y < Min.y) return false;
            if (a.Max.z > Max.z || a.Min.z < Min.z) return false;
            return true;
        }

        /// <summary>
        /// Returns true if this bounding box contains the given point.
        /// </summary>
        public bool Contains(POINT3 p)
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
        public POINT3 Closest(POINT3 p)
        {
            POINT3 c;

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
        /// Return the signed distance to the point. 
        /// If point is outside box field is positive.
        /// If point is inside box field is negative.
        /// </summary>
        public REAL SignedDistance(POINT3 p)
        {
            POINT3 d = (p - Center).Absolute - Size * 0.5f;
            POINT3 max = POINT3.Max(d, 0);
            return max.Magnitude + Math.Min(MathUtil.Max(d.x, d.y, d.z), 0.0f);
        }

        public static Box3f CalculateBounds(IList<POINT3> vertices)
        {
            POINT3 min = POINT3.PositiveInfinity;
            POINT3 max = POINT3.NegativeInfinity;

            int count = vertices.Count;
            for (int i = 0; i < count; i++)
            {
                var v = vertices[i];
                if (v.x < min.x) min.x = v.x;
                if (v.y < min.y) min.y = v.y;
                if (v.z < min.z) min.z = v.z;

                if (v.x > max.x) max.x = v.x;
                if (v.y > max.y) max.y = v.y;
                if (v.z > max.z) max.z = v.z;
            }

            return new Box3f(min, max);
        }

        public static Box3f CalculateBounds(POINT3 a, POINT3 b)
        {
            REAL xmin = Math.Min(a.x, b.x);
            REAL xmax = Math.Max(a.x, b.x);
            REAL ymin = Math.Min(a.y, b.y);
            REAL ymax = Math.Max(a.y, b.y);
            REAL zmin = Math.Min(a.z, b.z);
            REAL zmax = Math.Max(a.z, b.z);

            return new Box3f(xmin, xmax, ymin, ymax, zmin, zmax);
        }
    }

}




















