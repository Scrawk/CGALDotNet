using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    internal abstract class ConstrainedTriangulationKernel2 : BaseTriangulationKernel2
    {
        internal abstract int ConstrainedEdgesCount(IntPtr ptr);

        internal abstract bool HasIncidentConstraints(IntPtr ptr, int index);

        internal abstract int IncidentConstraintCount(IntPtr ptr, int index);

        internal abstract void InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b);

        internal abstract void InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2);

        internal abstract void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int startIndex, int count);

        internal abstract void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

        internal abstract void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

        internal abstract void GetConstraints(IntPtr ptr, TriEdge2[] constraints, int startIndex, int count);

        internal abstract void GetConstraints(IntPtr ptr, Segment2d[] constraints, int startIndex, int count);

        internal abstract void GetIncidentConstraints(IntPtr ptr, int vertexIndex, TriEdge2[] constraints, int startIndex, int count);

        internal abstract void RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex);

        internal abstract void RemoveIncidentConstraints(IntPtr ptr, int vertexIndex);

        //internal abstract int GetPolygonIndices(IntPtr ptrTri, IntPtr polyPtr, int[] indices, int startIndex, int count, ORIENTATION orientation);

        //internal abstract int GetPolygonWithHolesIndices(IntPtr ptrTri, IntPtr pwhPtr, int[] indices, int startIndex, int count, ORIENTATION orientation);

        internal abstract int MarkDomains(IntPtr ptr, int[] indices, int startIndex, int count);

    }
}
