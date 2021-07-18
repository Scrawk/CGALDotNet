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

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_CreateFromSegments([In] Segment2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_Release(IntPtr ptr);

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
    }
}
