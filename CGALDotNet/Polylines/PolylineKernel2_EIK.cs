using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polylines
{
    internal class PolylineKernel2_EIK : PolylineKernel2
    {
        internal override string Name => "EIK";

        internal static readonly PolylineKernel2 Instance = new PolylineKernel2_EIK();

        internal override IntPtr Create()
        {
            return Polyline2_EIK_Create();
        }

        internal override IntPtr CreateWithCount(int count)
        {
            return Polyline2_EIK_CreateWithCount(count);
        }

        internal override void Release(IntPtr ptr)
        {
            Polyline2_EIK_Release(ptr);
        }

        internal override int Count(IntPtr ptr)
        {
            return Polyline2_EIK_Count(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return Polyline2_EIK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Polyline2_EIK_Convert(ptr, k);
        }

        internal override void Clear(IntPtr ptr)
        {
            Polyline2_EIK_Clear(ptr);
        }

        internal override int Capacity(IntPtr ptr)
        {
            return Polyline2_EIK_Capacity(ptr);
        }

        internal override void Resize(IntPtr ptr, int count)
        {
            Polyline2_EIK_Resize(ptr, count);
        }

        internal override void Reverse(IntPtr ptr)
        {
            Polyline2_EIK_Reverse(ptr);
        }

        internal override void ShrinkToFit(IntPtr ptr)
        {
            Polyline2_EIK_ShrinkToFit(ptr);
        }

        internal override void Erase(IntPtr ptr, int index)
        {
            Polyline2_EIK_Erase(ptr, index);
        }

        internal override void EraseRange(IntPtr ptr, int start, int count)
        {
            Polyline2_EIK_EraseRange(ptr, start, count);
        }

        internal override void Insert(IntPtr ptr, int index, Point2d point)
        {
            Polyline2_EIK_Insert(ptr, index, point);
        }

        internal override void InsertRange(IntPtr ptr, int start, int count, Point2d[] points)
        {
            Polyline2_EIK_InsertRange(ptr, start, count, points);
        }

        internal override bool IsClosed(IntPtr ptr, double threshold)
        {
            return Polyline2_EIK_IsClosed(ptr, threshold);
        }

        internal override double SqLength(IntPtr ptr)
        {
            return Polyline2_EIK_SqLength(ptr);
        }

        internal override Point2d GetPoint(IntPtr ptr, int index)
        {
            return Polyline2_EIK_GetPoint(ptr, index);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polyline2_EIK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            Polyline2_EIK_GetSegments(ptr, segments, count);
        }

        internal override void SetPoint(IntPtr ptr, int index, Point2d point)
        {
            Polyline2_EIK_SetPoint(ptr, index, point);
        }

        internal override void SetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polyline2_EIK_SetPoints(ptr, points, count);
        }

        internal override void Translate(IntPtr ptr, Point2d translation)
        {
            Polyline2_EIK_Translate(ptr, translation);
        }

        internal override void Rotate(IntPtr ptr, double rotation)
        {
            Polyline2_EIK_Rotate(ptr, rotation);
        }

        internal override void Scale(IntPtr ptr, double scale)
        {
            Polyline2_EIK_Scale(ptr, scale);
        }

        internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Polyline2_EIK_Transform(ptr, translation, rotation, scale);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EIK_CreateWithCount(int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline2_EIK_Count(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline2_EIK_Capacity(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Resize(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Reverse(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_ShrinkToFit(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Erase(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_EraseRange(IntPtr ptr, int start, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Insert(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_InsertRange(IntPtr ptr, int start, int count, Point2d[] points);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polyline2_EIK_IsClosed(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polyline2_EIK_SqLength(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polyline2_EIK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_SetPoint(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_SetPoints(IntPtr ptr, Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Translate(IntPtr ptr, Point2d translation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Rotate(IntPtr ptr, double rotation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Scale(IntPtr ptr, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);
    }
}
