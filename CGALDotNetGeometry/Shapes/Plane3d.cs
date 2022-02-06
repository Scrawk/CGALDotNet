using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

using REAL = System.Double;
using POINT3 = CGALDotNetGeometry.Numerics.Point3d;
using VECTOR3 = CGALDotNetGeometry.Numerics.Vector3d;

namespace CGALDotNetGeometry.Shapes
{
    /// <summary>
    /// Plane struct defined by a position and direction.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Plane3d : IEquatable<Plane3d>
    {
        /// <summary>
        /// A plane facing the x axis.
        /// </summary>
        public readonly static Plane3d UnitX = new Plane3d(VECTOR3.UnitX);

        /// <summary>
        /// A plane facing the y axis.
        /// </summary>
        public readonly static Plane3d UnitY = new Plane3d(VECTOR3.UnitY);

        /// <summary>
        /// A plane facing the z axis.
        /// </summary>
        public readonly static Plane3d UnitZ = new Plane3d(VECTOR3.UnitZ);

        /// <summary>
        /// The planes position.
        /// </summary>
        public POINT3 Position;

        /// <summary>
        /// The planes direction.
        /// </summary>
        public VECTOR3 Normal;

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="normal">The planes direction.</param>
        public Plane3d(VECTOR3 normal)
        {
            Normal = normal;
            Position = POINT3.Zero;
        }

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="position">The planes position.</param>
        /// <param name="normal">The planes direction.</param>
        public Plane3d(POINT3 position, VECTOR3 normal)
        {
            Normal = normal;
            Position = position;
        }

        /// <summary>
        /// Create a new plane.
        /// </summary>
        /// <param name="normal">The planes direction.</param>
        /// <param name="distance">The planes distance from the origin.</param>
        public Plane3d(VECTOR3 normal, REAL distance)
        {
            Normal = normal;
            Position = POINT3.Zero + Normal * distance;
        }

        /// <summary>
        /// From three noncollinear points (ordered ccw).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Plane3d(POINT3 a, POINT3 b, POINT3 c)
        {
            Normal = VECTOR3.Cross(b - a, c - a);
            Normal.Normalize();
            Position = POINT3.Zero + Normal * VECTOR3.Dot(Normal, a);
        }

        /// <summary>
        /// The planes distance from the origin.
        /// </summary>
        public REAL Distance
        {
            get { return Position.Magnitude; }
        }

        /// <summary>
        /// The planes square distance from the origin.
        /// </summary>
        public REAL SqrDistance
        {
            get { return Position.SqrMagnitude; }
        }

        /// <summary>
        /// Check if the two planes are equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>True if the planes are equal.</returns>
        public static bool operator ==(Plane3d p1, Plane3d p2)
        {
            return p1.Position == p2.Position && p1.Normal == p2.Normal;
        }

        /// <summary>
        /// Check if the two planes are not equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>True if the planes are not equal.</returns>
        public static bool operator !=(Plane3d p1, Plane3d p2)
        {
            return p1.Position != p2.Position || p1.Normal != p2.Normal;
        }

        /// <summary>
        /// Check if this plane is equal to the other object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>Are these planes equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Plane3d)) return false;
            Plane3d plane = (Plane3d)obj;
            return this == plane;
        }

        /// <summary>
        /// Check if this plane is equal to the other plane.
        /// </summary>
        /// <param name="plane">The other plane.</param>
        /// <returns>Are these planes equal.</returns>
        public bool Equals(Plane3d plane)
        {
            return this == plane;
        }

        /// <summary>
        /// The planes hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Position.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Normal.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The plane as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Plane3d: Positions{0}, Normal={1}]", Position, Normal);
        }

        /// <summary>
        /// The closest point on the plane to the point p.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns>The closest point on the plane.</returns>
        public POINT3 Closest(POINT3 p)
        {
            REAL t = VECTOR3.Dot(Normal, p) - Distance;
            return p - t * Normal;
        }
    }
}
