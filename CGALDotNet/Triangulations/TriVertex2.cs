using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// From Point to HalfEdgeIndex must match layout
    /// of the unmanaged TriVertex2 in the TriVertex2 header file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriVertex2
    {
        /// <summary>
        /// The vertices point.
        /// </summary>
        public Point3d Point;

        /// <summary>
        /// Is this a infinite vertex.
        /// </summary>
        public bool IsInfinite;

        /// <summary>
        /// The number of egdes connected to the vertex.
        /// </summary>
        public int Degree;

        /// <summary>
        /// The vertices index in the triangulation.
        /// </summary>
        public int Index;

        /// <summary>
        /// The one of the faces the vertex is connected to.
        /// </summary>
        public int FaceIndex;

        public override string ToString()
        {
            return string.Format("[TriVertex2: Index={0}, Point={1}, IsInfinite={2}, Degree={3}, Face={4}]", 
                Index, Point, IsInfinite, Degree, FaceIndex);
        }
    }
}
