using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNetGeometry.Shapes
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Ray3f : IEquatable<Ray3f>
    {

        public Point3f Position;

        public Vector3f Direction;

        public Ray3f(Point3f position, Vector3f direction)
        {
            Position = position;
            Direction = direction;
        }

        public static bool operator ==(Ray3f r1, Ray3f r2)
        {
            return r1.Position == r2.Position && r1.Direction == r2.Direction;
        }

        public static bool operator !=(Ray3f r1, Ray3f r2)
        {
            return r1.Position != r2.Position || r1.Direction != r2.Direction;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ray3f)) return false;
            Ray3f ray = (Ray3f)obj;
            return this == ray;
        }

        public bool Equals(Ray3f ray)
        {
            return this == ray;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Position.GetHashCode();
                hash = (hash * 16777619) ^ Direction.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("[Ray3f: Position={0}, Direction={1}]", Position, Direction);
        }

        /// <summary>
        /// Intersection between ray and sphere.
        /// </summary>
        /// <param name="sphere">the sphere</param>
        /// <param name="t">Intersection point = Position + t * Direction</param>
        /// <returns>If rays intersect</returns>
        public bool Intersects(Sphere3f sphere, out float t)
        {
            t = 0;
            Vector3f m = (Position - sphere.Center).Vector3f;

            float b = Vector3f.Dot(m, Direction);
            float c = Vector3f.Dot(m, m) - sphere.Radius2;

            if (c > 0.0 && b > 0.0) return false;

            float discr = b * b - c;
            if (discr < 0.0) return false;

            t = -b - MathUtil.Sqrt(discr);

            if (t < 0) t = 0;
            return true;
        }

    }
}

