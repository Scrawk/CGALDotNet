using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Arrangements
{
    internal class ArrangementKernel2_EEK : ArrangementKernel2
    {
        internal override string Name => "EEK";

        internal static readonly ArrangementKernel2 Instance = new ArrangementKernel2_EEK();

        internal override IntPtr Create()
        {
            return Arrangement2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            Arrangement2_EEK_Release(ptr);
        }

        internal override bool IsValid(IntPtr ptr)
        {
            return Arrangement2_EEK_IsValid(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            Arrangement2_EEK_Clear(ptr);
        }

        internal override bool IsEmpty(IntPtr ptr)
        {
            return Arrangement2_EEK_IsEmpty(ptr);
        }

        internal override int BuildStamp(IntPtr ptr)
        {
            return Arrangement2_EEK_BuildStamp(ptr);
        }

        internal override void Assign(IntPtr ptr, IntPtr ptrOther)
        {
            Arrangement2_EEK_Assign(ptr, ptrOther);
        }

        internal override IntPtr Overlay(IntPtr ptr, IntPtr ptrOther)
        {
            return Arrangement2_EEK_Overlay(ptr, ptrOther);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return Arrangement2_EEK_VertexCount(ptr);
        }

        internal override int IsolatedVerticesCount(IntPtr ptr)
        {
            return Arrangement2_EEK_IsolatedVerticesCount(ptr);
        }

        internal override int VerticesAtInfinityCount(IntPtr ptr)
        {
            return Arrangement2_EEK_VerticesAtInfinityCount(ptr);
        }

        internal override int HalfEdgeCount(IntPtr ptr)
        {
            return Arrangement2_EEK_HalfEdgeCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return Arrangement2_EEK_FaceCount(ptr);
        }

        internal override int EdgeCount(IntPtr ptr)
        {
            return Arrangement2_EEK_EdgeCount(ptr);
        }

        internal override int UnboundedFaceCount(IntPtr ptr)
        {
            return Arrangement2_EEK_UnboundedFaceCount(ptr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Arrangement2_EEK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            Arrangement2_EEK_GetSegments(ptr, segments, count);
        }

        internal override void GetVertices(IntPtr ptr, ArrVertex2[] vertices, int count)
        {
            Arrangement2_EEK_GetVertices(ptr, vertices, count);
        }

        internal override bool GetVertex(IntPtr ptr, int index, out ArrVertex2 arrVertex)
        {
            return Arrangement2_EEK_GetVertex(ptr, index, out arrVertex);
        }

        internal override void GetHalfEdges(IntPtr ptr, ArrHalfedge2[] edges, int count)
        {
            Arrangement2_EEK_GetHalfEdges(ptr, edges, count);
        }

        internal override bool GetHalfEdge(IntPtr ptr, int index, out ArrHalfedge2 arrEdge)
        {
            return Arrangement2_EEK_GetHalfEdge(ptr, index, out arrEdge);
        }

        internal override void GetFaces(IntPtr ptr, ArrFace2[] faces, int count)
        {
            Arrangement2_EEK_GetFaces(ptr, faces, count);
        }

        internal override bool GetFace(IntPtr ptr, int index, out ArrFace2 arrFace)
        {
            return Arrangement2_EEK_GetFace(ptr, index, out arrFace);
        }

        internal override int GetFaceHoleCount(IntPtr ptr, int index)
        {
            return Arrangement2_EEK_GetFaceHoleCount(ptr, index);
        }

        internal override int GetHoleVertexCount(IntPtr ptr, int faceIndex, int holeIndex)
        {
            return Arrangement2_EEK_GetHoleVertexCount(ptr, faceIndex, holeIndex);
        }

        internal override void CreateLocator(IntPtr ptr, ARR_LOCATOR type)
        {
            Arrangement2_EEK_CreateLocator(ptr, type);
        }

        internal override void ReleaseLocator(IntPtr ptr)
        {
            Arrangement2_EEK_ReleaseLocator(ptr);
        }

        internal override bool PointQuery(IntPtr ptr, Point2d point, out ArrQuery result)
        {
            return Arrangement2_EEK_PointQuery(ptr, point, out result);
        }

        internal override bool BatchedPointQuery(IntPtr ptr, Point2d[] points, ArrQuery[] results, int count)
        {
            return Arrangement2_EEK_BatchedPointQuery(ptr, points, results, count);
        }

        internal override bool RayQuery(IntPtr ptr, Point2d point, bool up, out ArrQuery result)
        {
            return Arrangement2_EEK_RayQuery(ptr, point, up, out result);
        }

        internal override bool IntersectsSegment(IntPtr ptr, Segment2d segment)
        {
            return Arrangement2_EEK_IntersectsSegment(ptr, segment);
        }

        internal override void InsertPoint(IntPtr ptr, Point2d point)
        {
            Arrangement2_EEK_InsertPoint(ptr, point);
        }

        internal override void InsertPolygon(IntPtr ptr, IntPtr polyPtr, bool nonItersecting)
        {
            Arrangement2_EEK_InsertPolygon(ptr, polyPtr, nonItersecting);
        }

        internal override void InsertPolygonWithHoles(IntPtr ptr, IntPtr pwhPtr, bool nonItersecting)
        {
            Arrangement2_EEK_InsertPolygonWithHoles(ptr, pwhPtr, nonItersecting);
        }

        internal override void InsertSegment(IntPtr ptr, Segment2d segment, bool nonItersecting)
        {
            Arrangement2_EEK_InsertSegment(ptr, segment, nonItersecting);
        }

        internal override void InsertSegments(IntPtr ptr, Segment2d[] segments, int count, bool nonItersecting)
        {
            Arrangement2_EEK_InsertSegments(ptr, segments, count, nonItersecting);
        }

        internal override bool RemoveVertexByIndex(IntPtr ptr, int index)
        {
            return Arrangement2_EEK_RemoveVertexByIndex(ptr, index);
        }

        internal override bool RemoveVertexByPoint(IntPtr ptr, Point2d point)
        {
            return Arrangement2_EEK_RemoveVertexByPoint(ptr, point);
        }

        internal override bool RemoveEdgeByIndex(IntPtr ptr, int index)
        {
            return Arrangement2_EEK_RemoveEdgeByIndex(ptr, index);
        }

        internal override bool RemoveEdgeBySegment(IntPtr ptr, Segment2d segment)
        {
            return Arrangement2_EEK_RemoveEdgeBySegment(ptr, segment);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Arrangement2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_IsValid(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_IsEmpty(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_BuildStamp(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_Assign(IntPtr ptr, IntPtr ptrOther);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Arrangement2_EEK_Overlay(IntPtr ptr, IntPtr ptrOther);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_VertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_IsolatedVerticesCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_VerticesAtInfinityCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_HalfEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_FaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_EdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_UnboundedFaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_GetVertices(IntPtr ptr, [Out] ArrVertex2[] vertices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_GetVertex(IntPtr ptr, int index, [Out] out ArrVertex2 arrVertex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_GetHalfEdges(IntPtr ptr, [Out] ArrHalfedge2[] edges, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_GetHalfEdge(IntPtr ptr, int index, [Out] out ArrHalfedge2 arrEdge);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_GetFaces(IntPtr ptr, [Out] ArrFace2[] faces, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_GetFace(IntPtr ptr, int index, [Out] out ArrFace2 arrFace);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_GetFaceHoleCount(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Arrangement2_EEK_GetHoleVertexCount(IntPtr ptr, int faceIndex, int holeIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_CreateLocator(IntPtr ptr, ARR_LOCATOR type);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_ReleaseLocator(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_PointQuery(IntPtr ptr, Point2d point, [Out] out ArrQuery result);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_BatchedPointQuery(IntPtr ptr, [Out] Point2d[] points, [Out] ArrQuery[] results, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_RayQuery(IntPtr ptr, Point2d point, bool up, [Out] out ArrQuery result);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_IntersectsSegment(IntPtr ptr, Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_InsertPolygon(IntPtr ptr, IntPtr polyPtr, bool nonItersecting);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_InsertPolygonWithHoles(IntPtr ptr, IntPtr pwhPtr, bool nonItersecting);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_InsertSegment(IntPtr ptr, Segment2d segment, bool nonItersecting);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Arrangement2_EEK_InsertSegments(IntPtr ptr, [In] Segment2d[] points, int count, bool nonItersecting);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_RemoveVertexByIndex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_RemoveVertexByPoint(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_RemoveEdgeByIndex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Arrangement2_EEK_RemoveEdgeBySegment(IntPtr ptr, Segment2d segment);


    }
}
