using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    internal abstract class ArrangementKernel2 : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract bool IsValid(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract bool IsEmpty(IntPtr ptr);

        internal abstract int BuildStamp(IntPtr ptr);

        internal abstract void Assign(IntPtr ptr, IntPtr ptrOther);

        internal abstract IntPtr Overlay(IntPtr ptr, IntPtr ptrOther);

        internal abstract int VertexCount(IntPtr ptr);

        internal abstract int IsolatedVerticesCount(IntPtr ptr);

        internal abstract int VerticesAtInfinityCount(IntPtr ptr);

        internal abstract int HalfEdgeCount(IntPtr ptr);

        internal abstract int FaceCount(IntPtr ptr);

        internal abstract int EdgeCount(IntPtr ptr);

        internal abstract int UnboundedFaceCount(IntPtr ptr);

        internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int count);
        
        internal abstract void GetSegments(IntPtr ptr, Segment2d[] segments, int count);

        internal abstract void GetVertices(IntPtr ptr, ArrVertex2[] vertices, int count);

        internal abstract bool GetVertex(IntPtr ptr, int index, out ArrVertex2 arrVertex);

        internal abstract void GetHalfEdges(IntPtr ptr, ArrHalfedge2[] edges, int count);

        internal abstract bool GetHalfEdge(IntPtr ptr, int index, out ArrHalfedge2 arrEdge);

        internal abstract void GetFaces(IntPtr ptr, ArrFace2[] faces, int count);

        internal abstract bool GetFace(IntPtr ptr, int index, out ArrFace2 arrFace);

        internal abstract int GetFaceHoleCount(IntPtr ptr, int index);

        internal abstract int GetHoleVertexCount(IntPtr ptr, int faceIndex, int holeIndex);

        internal abstract void CreateLocator(IntPtr ptr, ARR_LOCATOR type);

        internal abstract void ReleaseLocator(IntPtr ptr);

        internal abstract bool PointQuery(IntPtr ptr, Point2d point, out ArrQuery result);

        internal abstract bool BatchedPointQuery(IntPtr ptr, Point2d[] points, ArrQuery[] results, int count);

        internal abstract bool RayQuery(IntPtr ptr, Point2d point, bool up, out ArrQuery result);

        internal abstract bool IntersectsSegment(IntPtr ptr, Segment2d segment);

        internal abstract void InsertPoint(IntPtr ptr, Point2d point);

        internal abstract void InsertPolygon(IntPtr ptr, IntPtr polyPtr, bool nonItersecting);

        internal abstract void InsertPolygonWithHoles(IntPtr ptr, IntPtr pwhPtr, bool nonItersecting);

        internal abstract void InsertSegment(IntPtr ptr, Segment2d segment, bool nonItersecting);

        internal abstract void InsertSegments(IntPtr ptr, Segment2d[] segments, int count, bool nonItersecting);

        internal abstract bool RemoveVertexByIndex(IntPtr ptr, int index);

        internal abstract bool RemoveVertexByPoint(IntPtr ptr, Point2d point);

        internal abstract bool RemoveEdgeByIndex(IntPtr ptr, int index);

        internal abstract bool RemoveEdgeBySegment(IntPtr ptr, Segment2d segment);
    }
}
