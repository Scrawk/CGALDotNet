using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Int32;
using POINT3 = CGALDotNetGeometry.Numerics.Point3i;
using POINT4 = CGALDotNetGeometry.Numerics.Point4d;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// A 3D box represented by its min and max values.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Box3i : IEquatable<Box3i>
    {

        /// <summary>
        /// The boxes min point.
        /// </summary>
        public POINT3 Min;

        /// <summary>
        /// The boxes max point.
        /// </summary>
        public POINT3 Max;

        /// <summary>
        /// Construct a new box.
        /// </summary>
        /// <param name="min">The boxes min point.</param>
        /// <param name="max">The boxes max point.</param>
        public Box3i(REAL min, REAL max)
        {
            Min = new POINT3(min);
            Max = new POINT3(max);
        }

        /// <summary>
        /// Construct a new box.
        /// </summary>
        /// <param name="minX">The boxes min x value.</param>
        /// <param name="minY">The boxes min y value.</param>
        /// <param name="minZ">The boxes min z value.</param>
        /// <param name="maxX">The boxes max x value.</param>
        /// <param name="maxY">The boxes max y value.</param>
        /// <param name="maxZ">The boxes max z value.</param>
        //public Box3i(REAL minX, REAL minY, REAL minZ, REAL maxX, REAL maxY, REAL maxZ)
        //{
        //    Min = new POINT3(minX, minY, minZ);
        //    Max = new POINT3(maxX, maxY, maxZ);
        //}

        /// <summary>
        /// Construct a new box.
        /// </summary>
        /// <param name="min">The boxes min point.</param>
        /// <param name="max">The boxes max point.</param>
        public Box3i(POINT3 min, POINT3 max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// The center of the box.
        /// </summary>
        public Point3d Center
        {
            get { return (Min + Max).Point3d * 0.5; }
        }

        /// <summary>
        /// The size of the boxes sides.
        /// </summary>
        public POINT3 Size
        {
            get { return new POINT3(Width, Height, Depth); }
        }

        /// <summary>
        /// The size of the box on the x axis.
        /// </summary>
        public REAL Width
        {
            get { return Max.x - Min.x; }
        }

        /// <summary>
        /// The size of the box on the y axis.
        /// </summary>
        public REAL Height
        {
            get { return Max.y - Min.y; }
        }

        /// <summary>
        /// The size of the box on the z axis.
        /// </summary>
        public REAL Depth
        {
            get { return Max.z - Min.z; }
        }

        /// <summary>
        /// The volume of the box.
        /// </summary>
        public REAL Volume
        {
            get { return (Max.x - Min.x) * (Max.y - Min.y) * (Max.z - Min.z); }
        }

        /// <summary>
        /// THe boxes surface area.
        /// </summary>
        public double SurfaceArea
        {
            get
            {
                POINT3 d = Max - Min;
                return 2.0 * (d.x * d.y + d.x * d.z + d.y * d.z);
            }
        }

        public static Box3i operator +(Box3i box, REAL s)
        {
            return new Box3i(box.Min + s, box.Max + s);
        }

        public static Box3i operator +(Box3i box, POINT3 v)
        {
            return new Box3i(box.Min + v, box.Max + v);
        }

        public static Box3i operator -(Box3i box, REAL s)
        {
            return new Box3i(box.Min - s, box.Max - s);
        }

        public static Box3i operator -(Box3i box, POINT3 v)
        {
            return new Box3i(box.Min - v, box.Max - v);
        }

        public static Box3i operator *(Box3i box, REAL s)
        {
            return new Box3i(box.Min * s, box.Max * s);
        }

        public static Box3i operator /(Box3i box, REAL s)
        {
            return new Box3i(box.Min / s, box.Max / s);
        }

        public static bool operator ==(Box3i b1, Box3i b2)
        {
            return b1.Min == b2.Min && b1.Max == b2.Max;
        }

        public static bool operator !=(Box3i b1, Box3i b2)
        {
            return b1.Min != b2.Min || b1.Max != b2.Max;
        }

        /// <summary>
        /// Is the box equal to this obj.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the box equal to this obj.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Box3i)) return false;
            Box3i box = (Box3i)obj;
            return this == box;
        }

        /// <summary>
        /// Is the box equal to the other box.
        /// </summary>
        /// <param name="box">The other box.</param>
        /// <returns>Is the box equal to the other box.</returns>
        public bool Equals(Box3i box)
        {
            return this == box;
        }

        /// <summary>
        /// The boxes hash code.
        /// </summary>
        /// <returns>The boxes hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Min.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Max.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Box3i: Min={0}, Max={1}, Width={2}, Height={3}, Depth={4}]", Min, Max, Width, Height, Depth);
        }

        /// <summary>
        /// Get the boxes corner points as a array.
        /// </summary>
        /// <returns>The boxes corner points as a array</returns>
        public POINT3[] GetCorners()
        {
            var corners = new POINT3[8];
            corners[0] = new POINT3(Min.x, Min.y, Min.z);
            corners[1] = new POINT3(Max.x, Min.y, Min.z);
            corners[2] = new POINT3(Max.x, Min.y, Max.z);
            corners[3] = new POINT3(Min.x, Min.y, Max.z);

            corners[4] = new POINT3(Min.x, Max.y, Min.z);
            corners[5] = new POINT3(Max.x, Max.y, Min.z);
            corners[6] = new POINT3(Max.x, Max.y, Max.z);
            corners[7] = new POINT3(Min.x, Max.y, Max.z);
            return corners;
        }

        /// <summary>
        /// Copy the boxes corner points in the array.
        /// </summary>
        /// <param name="corners">A array that has a size of at least 8.</param>
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

        /// <summary>
        /// Copy the boxes corner points in the array.
        /// </summary>
        /// <param name="corners">A array that has a size of at least 8.</param>
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
        public static Box3i Enlarge(Box3i box, POINT3 p)
        {
            var b = new Box3i();
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
        public static Box3i Enlarge(Box3i box0, Box3i box1)
        {
            var b = new Box3i();
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
        public static Box3i Expand(Box3i box, REAL amount)
        {
            return new Box3i(box.Min - amount, box.Max + amount);
        }

        /// <summary>
        /// Returns true if this box intersects the other box.
        /// </summary>
        public bool Intersects(Box3i a)
        {
            if (Max.x < a.Min.x || Min.x > a.Max.x) return false;
            if (Max.y < a.Min.y || Min.y > a.Max.y) return false;
            if (Max.z < a.Min.z || Min.z > a.Max.z) return false;
            return true;
        }

        /// <summary>
        /// Does the box contain the other box.
        /// </summary>
        public bool Contains(Box3i a)
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
        /// Caculate the bounding box of the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>The bounding box.</returns>
        public static Box3i CalculateBounds(IList<POINT3> points)
        {
            POINT3 min = POINT3.MaxValue;
            POINT3 max = POINT3.MinValue;

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

            return new Box3i(min, max);
        }

        /// <summary>
        /// Calculate the bounds of 2 points.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point</param>
        /// <returns>The bounding box.</returns>
        public static Box3i CalculateBounds(POINT3 a, POINT3 b)
        {
            REAL xmin = Math.Min(a.x, b.x);
            REAL xmax = Math.Max(a.x, b.x);
            REAL ymin = Math.Min(a.y, b.y);
            REAL ymax = Math.Max(a.y, b.y);
            REAL zmin = Math.Min(a.z, b.z);
            REAL zmax = Math.Max(a.z, b.z);

            var min = new POINT3(xmin, ymin, zmin);
            var max = new POINT3(xmax, ymax, zmax);

            return new Box3i(min, max);
        }

    }

}




















