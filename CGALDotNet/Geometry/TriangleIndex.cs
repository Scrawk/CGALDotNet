using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleIndex : IEquatable<TriangleIndex>
    {
        public int A, B, C;

        public bool HasNullIndex => A == -1 || B == -1 || C == -1;

        public TriangleIndex Reversed => new TriangleIndex(C, B, A);

        public TriangleIndex(int a, int b, int c)
        {
            A = a; 
            B = b; 
            C = c; 
        }

        public static bool operator ==(TriangleIndex t1, TriangleIndex t2)
        {
            return t1.A == t2.A && t1.B == t2.B && t1.C == t2.C;
        }

        public static bool operator !=(TriangleIndex t1, TriangleIndex t2)
        {
            return t1.A != t2.A || t1.B != t2.B || t1.C != t2.C;
        }

        /// <summary>
        /// Is the triangle equal to this object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Is the triangle equal to this object.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriangleIndex)) return false;
            TriangleIndex tri = (TriangleIndex)obj;
            return this == tri;
        }

        /// <summary>
        /// Is the triangle equal to the other triangle.
        /// </summary>
        /// <param name="tri">The other triangle.</param>
        /// <returns>Is the triangle equal to the other triangle.</returns>
        public bool Equals(TriangleIndex tri)
        {
            return this == tri;
        }

        /// <summary>
        /// The triangles hash code.
        /// </summary>
        /// <returns>The triangles hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ A.GetHashCode();
                hash = (hash * 16777619) ^ B.GetHashCode();
                hash = (hash * 16777619) ^ C.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// The triangle as a string.
        /// </summary>
        /// <returns>The triangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[TriangleIndex: A={0}, B={1}, C={2}]", A, B, C);
        }
    }
}
