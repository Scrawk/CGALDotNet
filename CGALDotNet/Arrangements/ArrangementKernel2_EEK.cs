using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    internal sealed class ArrangementKernel2_EEK : ArrangementKernel2
    {

        internal static readonly ArrangementKernel2 Instance = new ArrangementKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return Arrangement2_EEK_Create();
        }

        internal override IntPtr CreateFromSegments(Segment2d[] segments, int startIndex, int count)
        {
            return Arrangement2_EEK_CreateFromSegments(segments, startIndex, count);
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

        internal override void Assign(IntPtr ptr, IntPtr ptrOther)
        {
            Arrangement2_EEK_Assign(ptr, ptrOther);
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

        internal override void SetVertexIndices(IntPtr ptr)
        {
            Arrangement2_EEK_SetVertexIndices(ptr);
        }

        internal override void SetHalfEdgeIndices(IntPtr ptr)
        {
            Arrangement2_EEK_SetHalfEdgeIndices(ptr);
        }

        internal override void SetFaceIndices(IntPtr ptr)
        {
            Arrangement2_EEK_SetFaceIndices(ptr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            Arrangement2_EEK_GetPoints(ptr, points, startIndex, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            Arrangement2_EEK_GetSegments(ptr, segments, startIndex, count);
        }

        internal override void GetVertices(IntPtr ptr, ArrVertex2[] vertices, int startIndex, int count)
        {
            Arrangement2_EEK_GetVertices(ptr, vertices, startIndex, count);
        }

        internal override void GetHalfEdges(IntPtr ptr, ArrHalfEdge2[] edges, int startIndex, int count)
        {
            Arrangement2_EEK_GetHalfEdges(ptr, edges, startIndex, count);
        }

        internal override void GetFaces(IntPtr ptr, ArrFace2[] faces, int startIndex, int count)
        {
            Arrangement2_EEK_GetFaces(ptr, faces, startIndex, count);
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

        internal override bool BatchedPointQuery(IntPtr ptr, Point2d[] points, ArrQuery[] results, int startIndex, int count)
        {
            return Arrangement2_EEK_BatchedPointQuery(ptr, points, results, startIndex, count);
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

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_CreateFromSegments([In] Segment2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_IsValid(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_Clear(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_IsEmpty(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_Assign(IntPtr ptr, IntPtr ptrOther);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_VertexCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_IsolatedVerticesCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_VerticesAtInfinityCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_HalfEdgeCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_FaceCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_EdgeCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_UnboundedFaceCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_SetVertexIndices(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_SetHalfEdgeIndices(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_SetFaceIndices(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_GetVertices(IntPtr ptr, [Out] ArrVertex2[] vertices, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_GetHalfEdges(IntPtr ptr, [Out] ArrHalfEdge2[] edges, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_GetFaces(IntPtr ptr, [Out] ArrFace2[] faces, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_CreateLocator(IntPtr ptr, ARR_LOCATOR type);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_ReleaseLocator(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_PointQuery(IntPtr ptr, Point2d point, [Out] out ArrQuery result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_BatchedPointQuery(IntPtr ptr, [Out] Point2d[] points, [Out] ArrQuery[] results, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_RayQuery(IntPtr ptr, Point2d point, bool up, [Out] out ArrQuery result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_IntersectsSegment(IntPtr ptr, Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_RemoveVertexByIndex(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_RemoveVertexByPoint(IntPtr ptr, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_RemoveEdgeByIndex(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Arrangement2_EEK_RemoveEdgeBySegment(IntPtr ptr, Segment2d segment);


    }
}
