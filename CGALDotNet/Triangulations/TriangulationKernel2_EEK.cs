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

        internal override IntPtr CreateFromPoints(Point2d[] points, int startIndex, int count)
        {
            return Triangulation2_EEK_CreateFromPoints(points, startIndex, count);
        }

        internal override IntPtr CreateFromPolygon(IntPtr ptr)
        {
            return Triangulation2_EEK_CreateFromPolygon(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            Triangulation2_EEK_Clear(ptr);
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

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            Triangulation2_EEK_GetPoints(ptr, points, startIndex, count);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Triangulation2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Triangulation2_EEK_CreateFromPoints([In] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Triangulation2_EEK_CreateFromPolygon(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_Clear(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Triangulation2_EEK_IsValid(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Triangulation2_EEK_VertexCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Triangulation2_EEK_FaceCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Triangulation2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int startIndex, int count);



    }
}
