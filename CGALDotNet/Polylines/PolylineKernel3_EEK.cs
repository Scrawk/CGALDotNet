using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polylines
{
    internal class PolylineKernel3_EEK : PolylineKernel3
    {
        internal override string Name => "EEK";

        internal static readonly PolylineKernel3 Instance = new PolylineKernel3_EEK();

        internal override IntPtr Create()
        {
            return Polyline3_EEK_Create();
        }

        internal override IntPtr CreateWithCount(int count)
        {
            return Polyline3_EEK_CreateWithCount(count);
        }

        internal override void Release(IntPtr ptr)
        {
            Polyline3_EEK_Release(ptr);
        }

        internal override int Count(IntPtr ptr)
        {
            return Polyline3_EEK_Count(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return Polyline3_EEK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Polyline3_EEK_Convert(ptr, k);
        }

        internal override void Clear(IntPtr ptr)
        {
            Polyline3_EEK_Clear(ptr);
        }

        internal override int Capacity(IntPtr ptr)
        {
            return Polyline3_EEK_Capacity(ptr);
        }

        internal override void Resize(IntPtr ptr, int count)
        {
            Polyline3_EEK_Resize(ptr, count);
        }

        internal override void Reverse(IntPtr ptr)
        {
            Polyline3_EEK_Reverse(ptr);
        }

        internal override void ShrinkToFit(IntPtr ptr)
        {
            Polyline3_EEK_ShrinkToFit(ptr);
        }

        internal override void Erase(IntPtr ptr, int index)
        {
            Polyline3_EEK_Erase(ptr, index);
        }

        internal override void EraseRange(IntPtr ptr, int start, int count)
        {
            Polyline3_EEK_EraseRange(ptr, start, count);
        }

        internal override void Insert(IntPtr ptr, int index, Point3d point)
        {
            Polyline3_EEK_Insert(ptr, index, point);
        }

        internal override void InsertRange(IntPtr ptr, int start, int count, Point3d[] points)
        {
            Polyline3_EEK_InsertRange(ptr, start, count, points);
        }

        internal override bool IsClosed(IntPtr ptr, double threshold)
        {
            return Polyline3_EEK_IsClosed(ptr, threshold);
        }

        internal override double SqLength(IntPtr ptr)
        {
            return Polyline3_EEK_SqLength(ptr);
        }

        internal override Point3d GetPoint(IntPtr ptr, int index)
        {
            return Polyline3_EEK_GetPoint(ptr, index);
        }

        internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
        {
            Polyline3_EEK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment3d[] segments, int count)
        {
            Polyline3_EEK_GetSegments(ptr, segments, count);
        }

        internal override void SetPoint(IntPtr ptr, int index, Point3d point)
        {
            Polyline3_EEK_SetPoint(ptr, index, point);
        }

        internal override void SetPoints(IntPtr ptr, Point3d[] points, int count)
        {
            Polyline3_EEK_SetPoints(ptr, points, count);
        }

        internal override void Transform(IntPtr ptr, Matrix4x4d matrix)
        {
            Polyline3_EEK_Transform(ptr, matrix);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline3_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline3_EEK_CreateWithCount(int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline3_EEK_Count(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline3_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline3_EEK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline3_EEK_Capacity(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Resize(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Reverse(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_ShrinkToFit(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Erase(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_EraseRange(IntPtr ptr, int start, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Insert(IntPtr ptr, int index, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_InsertRange(IntPtr ptr, int start, int count, Point3d[] points);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polyline3_EEK_IsClosed(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polyline3_EEK_SqLength(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d Polyline3_EEK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_GetSegments(IntPtr ptr, [Out] Segment3d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_SetPoint(IntPtr ptr, int index, Point3d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_SetPoints(IntPtr ptr, Point3d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline3_EEK_Transform(IntPtr ptr, Matrix4x4d matrix);
    }
}
