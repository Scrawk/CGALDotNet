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

    }
}
