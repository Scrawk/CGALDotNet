using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// Struct for the triangle edge.
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in TriEdge2.h file.
    /// </summary>
    public struct TriEdge2
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
        /// 
        /// </summary>
        /// <param name="faceIndex">The face index in the triangulation</param>
        /// <param name="neighbourIndex">The neighbours index in the face array betwen 0 and 2.</param>
        public TriEdge2(int faceIndex, int neighbourIndex)
        {
            FaceIndex = faceIndex;
            NeighbourIndex = neighbourIndex;
        }

        public override string ToString()
        {
            return string.Format("[TriEdge2:  FaceIndex={0}, NeighbourIndex={1}]", 
                FaceIndex, NeighbourIndex);
        }

    }
}
