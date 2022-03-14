using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriVertex3 : IEquatable<TriVertex3>
    {
        /// <summary>
        /// The vertices point.
        /// </summary>
        public Point3d Point;

        /// <summary>
        /// Is this a infinte vertex.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The vertices degree is the 
        /// number of edges connecting to it.
        /// </summary>
        public int Degree;

        /// <summary>
        /// The vertices index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The one of the cells the vertex is connected to.
        /// </summary>
        public int CellIndex;

        public override string ToString()
        {
            return string.Format("[TriVertex3: Index={0}, Point={1}, IsInfinite={2}, Degree={3}, CellIndex={4}]",
                Index, Point, IsInfinite, Degree, CellIndex);
        }

        /// <summary>
        /// Are the two vertices equal.
        /// </summary>
        /// <param name="v1">The first vertex.</param>
        /// <param name="v2">The second vertex.</param>
        /// <returns>True if the vertexs are equal.</returns>
        public static bool operator ==(TriVertex3 v1, TriVertex3 v2)
        {
            return v1.Index == v2.Index
                 && v1.IsInfinite == v2.IsInfinite
                 && v1.Degree == v2.Degree
                 && v1.CellIndex == v2.CellIndex
                 && v1.Point == v2.Point;
        }

        /// <summary>
        /// Are the two vertices not equal.
        /// </summary>
        /// <param name="v1">The first vertex.</param>
        /// <param name="v2">The second vertex.</param>
        /// <returns>True if the vertexs are not equal.</returns>
        public static bool operator !=(TriVertex3 v1, TriVertex3 v2)
        {
            return v1.Index != v2.Index
                       || v1.IsInfinite != v2.IsInfinite
                       || v1.Degree != v2.Degree
                       || v1.CellIndex != v2.CellIndex
                       || v1.Point != v2.Point;
        }

        /// <summary>
        /// Are these objects equal.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TriVertex3)) return false;
            TriVertex3 v = (TriVertex3)obj;
            return this == v;
        }

        /// <summary>
        /// Are these vertexs equal.
        /// </summary>
        /// <param name="vertex">The other vertex.</param>
        /// <returns>True if the vertexs are equal.</returns>
        public bool Equals(TriVertex3 vertex)
        {
            return this == vertex;
        }

        /// <summary>
        /// The vertexs hash code.
        /// </summary>
        /// <returns>The vertexs hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                hash = (hash * MathUtil.HASH_PRIME_2) ^ IsInfinite.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Degree.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ CellIndex.GetHashCode();
                hash = (hash * MathUtil.HASH_PRIME_2) ^ Point.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Enumerate around all the other vertices in this vertexs cell.
        /// </summary>
        /// <param name="tri">The triangulation the vertex belongs to.</param>
        /// <returns>All the other vertices in this vertexs cell</returns>
        public IEnumerable<TriVertex3> EnumerateVertices(BaseTriangulation3 tri)
        {
            if (tri.GetCell(CellIndex, out TriCell3 c))
            {
                for (int i = 0; i < 4; i++)
                {
                    int index = c.GetVertexIndex(i);
                    if (index != Index && tri.GetVertex(index, out TriVertex3 v))
                    {
                        yield return v;
                    }
                }
            }
        }

        /// <summary>
        /// Enumerate around all the other vertices in this vertexs cell.
        /// </summary>
        /// <param name="vertices">A array of the other vertices in the triangulation.</param>
        /// <param name="cells">A array of the other cells in the triangulation.</param>
        /// <returns>All the other vertices in this vertexs cell</returns>
        public IEnumerable<TriVertex3> EnumerateVertices(TriVertex3[] vertices, TriCell3[] cells)
        {
            if (CellIndex == CGALGlobal.NULL_INDEX)
                yield break;

            var c = cells[CellIndex];

            for (int i = 0; i < 4; i++)
            {
                int index = c.GetVertexIndex(i);

                if (index == CGALGlobal.NULL_INDEX || index == Index)
                    continue;

                yield return vertices[index];
            }
        }
    }

}
