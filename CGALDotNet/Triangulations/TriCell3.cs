using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// From Index to HalfEdgeIndex must match layout
    /// of the unmanaged TriFace2 in the TriFace2 header file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TriCell3 : IEquatable<TriCell3>
    {
        /// <summary>
        /// Is this the infinite cell.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The cells index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The cells 4 vertices.
        /// </summary>
        private fixed int VertexIndices[4];

        /// <summary>
        /// The cells 4 neighbor cells.
        /// </summary>
        private fixed int NeighborIndices[4];

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[TriCell2: Index={0}, IsInfinite={1}, Vertex0={2}, Vertex1={3}, Vertex2={4}, Vertex3={5}]",
                Index, IsInfinite, VertexIndices[0], VertexIndices[1], VertexIndices[2], VertexIndices[3]);
        }

        /// <summary>
        /// Are the two cells equal.
        /// </summary>
        /// <param name="f1">The first cell.</param>
        /// <param name="f2">The second cell.</param>
        /// <returns>True if the cells are equal.</returns>
        public static bool operator ==(TriCell3 f1, TriCell3 f2)
        {
            return f1.Index == f2.Index && f1.IsInfinite == f2.IsInfinite 
                && VerticesEqual(f1, f2) && NeighborEqual(f1, f2);
        }

        /// <summary>
        /// Are the two cells not equal.
        /// </summary>
        /// <param name="f1">The first cell.</param>
        /// <param name="f2">The second cell.</param>
        /// <returns>True if the cells are not equal.</returns>
        public static bool operator !=(TriCell3 f1, TriCell3 f2)
        {
            return f1.Index != f2.Index || f1.IsInfinite != f2.IsInfinite
                    || !VerticesEqual(f1, f2) || !NeighborEqual(f1, f2);
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriCell3)) return false;
            TriCell3 v = (TriCell3)obj;
            return this == v;
        }

        /// <summary>
        /// Are these cells equal.
        /// </summary>
        /// <param name="cell">The other cell.</param>
        /// <returns>True if the cells are equal.</returns>
        public bool Equals(TriCell3 cell)
        {
            return this == cell;
        }

        /// <summary>
        /// The cells hash code.
        /// </summary>
        /// <returns>The cells hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ IsInfinite.GetHashCode();

                for(int i = 0; i < 4; i++)
                    hash = (hash * MathUtil.HASH_PRIME_2) ^ VertexIndices[i].GetHashCode();

                for (int i = 0; i < 4; i++)
                    hash = (hash * MathUtil.HASH_PRIME_2) ^ NeighborIndices[i].GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Get a vertex index.
        /// </summary>
        /// <param name="i">The vertices index 0-3.</param>
        /// <returns>The vertices index in the triangulation.</returns>
        public int GetVertexIndex(int i)
        {
            if (i < 0 || i >= 4)
                throw new ArgumentOutOfRangeException(i + "out of range.");

            return VertexIndices[i];
        }

        /// <summary>
        /// Get a neighbor cell index.
        /// </summary>
        /// <param name="i">The neighbor cell index 0-3.</param>
        /// <returns>A neighbor cell index in the triangulation.</returns>
        public int GetNeighborIndex(int i)
        {
            if (i < 0 || i >= 4)
                throw new ArgumentOutOfRangeException(i + "out of range.");

            return NeighborIndices[i];
        }

        /// <summary>
        /// Enumerate the vertices of the cell.
        /// </summary>
        /// <param name="tri">The triangle the vertices below too.</param>
        /// <returns>The cell vertices.</returns>
        public IEnumerable<TriVertex3> EnumerateVertices(BaseTriangulation3 tri)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tri.GetVertex(i, out TriVertex3 v))
                {
                    yield return v;
                }
            }
        }

        /// <summary>
        /// Enumerate the vertices of the cell.
        /// </summary>
        /// <param name="vertices">The vertices array.</param>
        /// <returns>The cell vertices.</returns>
        public IEnumerable<TriVertex3> EnumerateVertices(TriVertex3[] vertices)
        {
            for (int i = 0; i < 4; i++)
            {
                int index = GetVertexIndex(i);

                if (index != CGALGlobal.NULL_INDEX)
                {
                    yield return vertices[index];
                }
            }
        }

        /// <summary>
        /// Enumerate the vertices of the cell.
        /// </summary>
        /// <param name="tri">The triangle the vertices below too.</param>
        /// <returns>The cell vertices.</returns>
        public IEnumerable<TriCell3> EnumerateNeighbors(BaseTriangulation3 tri)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tri.GetCell(i, out TriCell3 c))
                {
                    yield return c;
                }
            }
        }

        /// <summary>
        /// Enumerate the neighbors of the cell.
        /// </summary>
        /// <param name="cells">The cell array.</param>
        /// <returns>The cell neighbors.</returns>
        public IEnumerable<TriCell3> EnumerateNeighbors(TriCell3[] cells)
        {
            for (int i = 0; i < 4; i++)
            {
                int index = GetNeighborIndex(i);

                if (index != CGALGlobal.NULL_INDEX)
                {
                    yield return cells[index];
                }
            }
        }

        /// <summary>
        /// Are the two vertex arrays equal.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool VerticesEqual(TriCell3 c1, TriCell3 c2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (c1.VertexIndices[i] != c2.VertexIndices[i]) 
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Are the two neighbor arrays equal.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool NeighborEqual(TriCell3 c1, TriCell3 c2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (c1.NeighborIndices[i] != c2.NeighborIndices[i])
                    return false;
            }

            return true;
        }

    }
}
