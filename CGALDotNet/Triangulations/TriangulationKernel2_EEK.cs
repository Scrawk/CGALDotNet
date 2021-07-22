using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    internal sealed class TriangulationKernel2_EEK : TriangulationKernel2
    {

        internal static readonly TriangulationKernel2 Instance = new TriangulationKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return Triangulation2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            Triangulation2_EEK_Release(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            Triangulation2_EEK_Clear(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return Triangulation2_EEK_Copy(ptr);
        }

        internal override bool IsValid(IntPtr ptr)
        {
            return Triangulation2_EEK_IsValid(ptr);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return Triangulation2_EEK_VertexCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return Triangulation2_EEK_FaceCount(ptr);
        }

        internal override void InsertPoint(IntPtr ptr, Point2d point)
        {
            Triangulation2_EEK_InsertPoint(ptr, point);
        }

        internal override void InsertPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            Triangulation2_EEK_InsertPoints(ptr, points, startIndex, count);
        }

        internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
        {
            Triangulation2_EEK_InsertPolygon(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
        {
            Triangulation2_EEK_InsertPolygonWithHoles(triPtr, pwhPtr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            Triangulation2_EEK_GetPoints(ptr, points, startIndex, count);
        }

        internal override void GetIndices(IntPtr ptr, int[] indices, int startIndex, int count)
        {
            Triangulation2_EEK_GetIndices(ptr, indices, startIndex, count);
        }

        internal override void GetVertices(IntPtr ptr, [Out] TriVertex2[] vertices, int startIndex, int count)
        {
            Triangulation2_EEK_GetVertices(ptr, vertices, startIndex, count);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Triangulation2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_Clear(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Triangulation2_EEK_Copy(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Triangulation2_EEK_IsValid(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Triangulation2_EEK_VertexCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Triangulation2_EEK_FaceCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_InsertPoints(IntPtr ptr, [In] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_GetIndices(IntPtr ptr, [Out] int[] indices, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_GetVertices(IntPtr ptr, [Out] TriVertex2[] vertices, int startIndex, int count);

    }
}
