using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Triangulations
{
    internal abstract class ConstrainedDelaunayTriangulationKernel2 : BaseTriangulationKernel2
    {

        internal abstract int ConstrainedEdgesCount(IntPtr ptr);

        internal abstract bool HasIncidentConstraints(IntPtr ptr, int index);

        internal abstract int IncidentConstraintCount(IntPtr ptr, int index);

        internal abstract void InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b);

        internal abstract void InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2);

        internal abstract void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count);

        internal abstract void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

        internal abstract void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

        internal abstract void GetConstraints(IntPtr ptr, TriEdge2[] constraints, int count);

        internal abstract void GetConstraints(IntPtr ptr, Segment2d[] constraints, int count);

        internal abstract void GetIncidentConstraints(IntPtr ptr, int vertexIndex, TriEdge2[] constraints, int count);

        internal abstract void RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex);

        internal abstract void RemoveIncidentConstraints(IntPtr ptr, int vertexIndex);

        internal abstract int MarkDomains(IntPtr ptr, int[] indices, int count);


    }
}
