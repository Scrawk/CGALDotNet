using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    internal abstract class ArrangementKernel2
    {
        internal ArrangementKernel2()
        {

        }

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract IntPtr CreateFromSegments(Segment2d[] segment, int startIndex, int count);

        internal abstract void Release(IntPtr ptr);

        internal abstract int VertexCount(IntPtr ptr);

        internal abstract int IsolatedVerticesCount(IntPtr ptr);

        internal abstract int VerticesAtInfinityCount(IntPtr ptr);

        internal abstract int HalfEdgeCount(IntPtr ptr);

        internal abstract int FaceCount(IntPtr ptr);

        internal abstract int EdgeCount(IntPtr ptr);

        internal abstract int UnboundedFaceCount(IntPtr ptr);

        internal abstract void SetVertexIndices(IntPtr ptr);

        internal abstract void SetHalfEdgeIndices(IntPtr ptr);

        internal abstract void SetFaceIndices(IntPtr ptr);

        internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count);

        internal abstract void GetSegments(IntPtr ptr, Segment2d[] segments, int startIndex, int count);

        internal abstract void GetVertices(IntPtr ptr, ArrVertex2[] vertices, int startIndex, int count);

        internal abstract void GetHalfEdges(IntPtr ptr, ArrHalfEdge2[] edges, int startIndex, int count);

        internal abstract void GetFaces(IntPtr ptr, ArrFace2[] faces, int startIndex, int count);

        internal abstract void CreateLocator(IntPtr ptr, ARR_LOCATOR type);

        internal abstract void ReleaseLocator(IntPtr ptr);

        internal abstract bool PointQuery(IntPtr ptr, Point2d point, out ArrQuery result);

        internal abstract bool BatchedPointQuery(IntPtr ptr, Point2d[] points, ArrQuery[] results, int startIndex, int count);

        internal abstract bool RayQuery(IntPtr ptr, Point2d point, bool up, out ArrQuery result);
    }
}
