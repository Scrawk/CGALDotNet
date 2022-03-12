using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// From Index to TwinIndex must match layout
    /// of the unmanaged TriEdge2 in the TriEdge2 header file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriEdge2 : IEquatable<TriEdge2>
    {
        /// <summary>
        /// The edges face index in the triangulation.
        /// </summary>
        public int FaceIndex;

        /// <summary>
        /// The neighbours index in the face array betwen 0 and 2.
        /// </summary>
        public int NeighbourIndex;

        /// <summary>
        /// The edges segment.
        /// </summary>
        public Segment2d Segment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faceIndex">The face index in the triangulation</param>
        /// <param name="neighbourIndex">The neighbours index in the face array betwen 0 and 2.</param>
        public TriEdge2(int faceIndex, int neighbourIndex)
        {
            FaceIndex = faceIndex;
            NeighbourIndex = neighbourIndex;
            Segment = new Segment2d();
        }

        public override string ToString()
        {
            return string.Format("[TriEdge2:  FaceIndex={0}, NeighbourIndex={1}]", 
                FaceIndex, NeighbourIndex);
        }

        /// <summary>
        /// Are the two edges equal.
        /// </summary>
        /// <param name="e1">The first edge.</param>
        /// <param name="e2">The second edge.</param>
        /// <returns>True if the edges are equal.</returns>
        public static bool operator ==(TriEdge2 e1, TriEdge2 e2)
        {
            return e1.FaceIndex == e2.FaceIndex && e1.NeighbourIndex == e2.NeighbourIndex;
        }

        /// <summary>
        /// Are the two edges not equal.
        /// </summary>
        /// <param name="e1">The first edge.</param>
        /// <param name="e2">The second edge.</param>
        /// <returns>True if the edges are not equal.</returns>
        public static bool operator !=(TriEdge2 e1, TriEdge2 e2)
        {
            return e1.FaceIndex != e2.FaceIndex || e1.NeighbourIndex != e2.NeighbourIndex;
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriEdge2)) return false;
            TriEdge2 v = (TriEdge2)obj;
            return this == v;
        }

        /// <summary>
        /// Are these edges equal.
        /// </summary>
        /// <param name="edge">The other edge.</param>
        /// <returns>True if the edges are equal.</returns>
        public bool Equals(TriEdge2 edge)
        {
            return this == edge;
        }

        /// <summary>
        /// The edges hash code.
        /// </summary>
        /// <returns>The edges hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ FaceIndex.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ NeighbourIndex.GetHashCode();
                return hash;
            }
        }

    }
}
