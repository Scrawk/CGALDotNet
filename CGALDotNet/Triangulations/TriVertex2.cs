using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// Struct for a triangles vertex.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in TriVertex2.h file.
    /// </summary>
    public struct TriVertex2
    {
        /// <summary>
        /// The vertices point.
        /// </summary>
        public Point2d Point;

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
