using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// Struct for a triangles face.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in TriFace2.h file.
    /// </summary>
    public unsafe struct TriFace2
    {
        /// <summary>
        /// Is this the infinite face.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The faces index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The faces 3 vertices.
        /// </summary>
        public fixed int VertexIndex[3];

        public override string ToString()
        {
            return string.Format("[TriFace2: Index={0}, IsInfinite={1}, Vertex0={2}, Vertex1={3}, Vertex2={4}]",
                Index, IsInfinite, VertexIndex[0], VertexIndex[1], VertexIndex[2]);
        }

        /// <summary>
        /// Get a vertex index and wrap around array.
        /// </summary>
        /// <param name="i">The vertices index wrapped to 0-2.</param>
        /// <returns>The vertices index in the triangulation.</returns>
        public int GetVertexIndex(int i)
        {
            i = CGALGlobal.Wrap(i, 3);
            return VertexIndex[i];
        }

    }
}
